using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ComponentModel;
using EARTHLib;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.IO;
using System.Xml;
using NativeMethods;
using HookAPI;

namespace GESnapHelper
{
    public struct SCamParams
    {
        public double Latitude;
        public double Longitude;
        public double Altitude;
        public double Range;
        public double Tilt;
        public double Azimuth;
        public double Speed;
    }
    public partial class GESnapHelper : Form
    {
        #region PrivateMembers

        private const int tipLeft = 300;
        private const int tipTop = -30;
        private const string hint =
            "请执行[开始][启动GE]开启GE\n" +
            "CTRL +单击 查看经纬度坐标\n" +
            "SHIFT+单击 获取经纬度坐标\n" +
            "若启动GE后却看不到影像画面\n" +
            "请先[关闭GE]然后再[启动GE]";

        private IntPtr GEHMainWnd = (IntPtr)0;
        private IntPtr GEHRenderWnd = (IntPtr)0;

        private ApplicationGE GEApp = null;
        private bool isGEStarted = false;

        SCamParams scp = new SCamParams();
        string strParamsXmlFilePath = null;
        string strBackup = "AutoBackup";

        private MouseHook mouseHook;

        private Rectangle GEHRenderRect = new Rectangle();

        private double rp1lat;
        private double rp1lon;
        private double rp2lat;
        private double rp2lon;
        private double range;
        private double alt = 0.0;
        private AltitudeModeGE am = AltitudeModeGE.RelativeToGroundAltitudeGE;
        private double tilt = 0.0;
        double azimuth = 0.0;
        double speed = 5.0;
        private double lat_d;
        private double lon_d;
        private int seg_rows;
        private int seg_cols;
        private int seg_w;
        private int seg_h;
        private int dst_w;
        private int dst_h;
        private int left;
        private int top;
        string combPathRoot;
        string combImageName;

        #endregion PrivateMembers

        public GESnapHelper()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized; //最大化显示
            tabDocker.TabPages.Clear();
            tabDocker.TabPages.Add(tabGEViewer);
            SetBackgroundImage(tabGEViewer);
            SetFocusParamsDefault();

            string str = Application.ExecutablePath;
            strParamsXmlFilePath = str.Substring(0, str.LastIndexOf('\\') + 1) + strBackup;

            if (!Directory.Exists(strParamsXmlFilePath))
            {
                Directory.CreateDirectory(strParamsXmlFilePath);
            }
            strParamsXmlFilePath += "\\AutoSavedParams.xml";
            if (File.Exists(strParamsXmlFilePath))
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(strParamsXmlFilePath);
                XmlNodeList nodes = xDoc.SelectNodes("//Place");
                foreach (XmlNode node in nodes)
                {
                    XmlNode name = node.SelectSingleNode("Name");
                    comboBoxPlaces.Items.Add(name.InnerText);
                }
            }
            else
            {
                CreateParamsXmlFile();
            }
            comboBoxPlaces.SelectedIndex = -1;
        }

        #region GEFunctions

        /// <summary>
        /// 功能:尝试启动Google Earth实例
        /// </summary>
        /// <param>
        /// 参数:parentDocker
        /// 含义:GE渲染窗口所停靠的父窗口
        /// </param>
        private void TryStartGE(Control parentDocker)
        {
            try
            {
                //创建GE新实例
                GEApp = new ApplicationGE();
                //取得GE主窗口句柄
                GEHMainWnd = (IntPtr)GEApp.GetMainHwnd();
                //隐藏GoogleEarth主窗口
                WindowsAPI.SetWindowPos(GEHMainWnd, WindowsAPI.HWND_BOTTOM,
                    0, 0, 0, 0, WindowsAPI.SWP_NOSIZE | WindowsAPI.SWP_HIDEWINDOW);
                //取得GE的影像窗口(渲染窗口)句柄
                GEHRenderWnd = (IntPtr)GEApp.GetRenderHwnd();
                //调整视图窗口尺寸
                ResizeTabPage(tabGEViewer);
                //等待GE启动
                System.Threading.Thread.Sleep(1000);
                //启动成功,设置标记
                isGEStarted = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Starting GE");
            }
        }

        /// <summary>
        /// 功能:尝试关闭GE
        /// </summary>
        private void TryCloseGE()
        {
            try
            {
                //杀掉GoogleEarth进程
                Process[] geProcess = Process.GetProcessesByName("GoogleEarth");
                foreach (var p in geProcess)
                {
                    p.Kill();
                }
                //清除内容
                GEApp = null;
                GEHMainWnd = (IntPtr)0;
                GEHRenderWnd = (IntPtr)0;
                isGEStarted = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Shutdown GE");
            }
        }

        /// <summary>
        /// 功能:重设GE渲染窗口的尺寸
        /// <param>
        /// 参数:parentDocker
        /// 含义:GE渲染窗口所停靠的父窗口
        /// </param>
        private void ResizeTabPage(TabPage parentDocker)
        {
            RECT rect = new RECT();
            WindowsAPI.GetClientRect(GEHRenderWnd, out rect);

            int left = (parentDocker.Width - rect.Width) / 2;
            int top = (parentDocker.Height - rect.Height) / 2;
            if (left < 0) left = 0;
            if (top < 0) top = 0;
            Point pt = tabGEViewer.PointToScreen(new Point(left, top));
            GEHRenderRect = new Rectangle(pt, new Size(rect.Width, rect.Height));
            parentDocker.AutoScrollMinSize = new Size(rect.Width, rect.Height);
            //将渲染窗口嵌入到父窗体合适位置
            WindowsAPI.MoveWindow(GEHRenderWnd, left, top, rect.Width, rect.Height, true);
            WindowsAPI.SetParent(GEHRenderWnd, parentDocker.Handle);
        }

        #endregion GEFunctions

        #region MessageHandlers

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            msgToolTip.Show(hint, tabGEViewer, tipLeft, 20, 20000);

            try
            {
                mouseHook = new MouseHook();
                mouseHook.MouseClick += MyMouseClick;
                mouseHook.StartHook(HookType.WH_MOUSE_LL, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            btnDrag1.Enabled = false;
            btnDrag1.Text = "";
            btnDrag1.BackColor = Color.Silver;
            btnDrag2.Enabled = false;
            btnDrag2.Text = "";
            btnDrag2.BackColor = Color.Silver;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if (isGEStarted)
            {
                TryCloseGE();
            }
            if (mouseHook != null)
            {
                mouseHook.StopHook();
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            if (isGEStarted)
            {
                ResizeTabPage(tabGEViewer);
            }
        }

        private void MyMouseClick(object sender, MouseEventArgs e)
        {
            if (GEApp == null ||  // 前提1:GE启动
                (tabDocker.SelectedTab != tabGEViewer) ||  //条件2:在GE标签页
                (!GEHRenderRect.Contains(e.Location)) ||  //条件3:在Render区域点击鼠标
                e.Button != MouseButtons.Left) //条件4:按下的是鼠标左键
            {
                return; //不满足以上任何一个条件都会退出
            }

            double dx = 2.0 * (e.X - GEHRenderRect.Left) / GEHRenderRect.Width - 1.0;
            double dy = 2.0 * (GEHRenderRect.Height - e.Y + GEHRenderRect.Top) / GEHRenderRect.Height - 1.0;

            if (Control.ModifierKeys == Keys.Control) //按下CTRL键
            {
                tabGEViewer.BeginInvoke(new ProcGELoacation(ShowGELoacation), dx, dy);
            }
            else if (Control.ModifierKeys == Keys.Shift) //按下SHIFT键
            {
                tabGEViewer.BeginInvoke(new ProcGELoacation(GrabGELocation), dx, dy);
            }
        }

        private delegate void ProcGELoacation(double dx, double dy);

        private void ShowGELoacation(double dx, double dy)
        {
            PointOnTerrainGE pt = GEApp.GetPointOnTerrainFromScreenCoords(dx, dy);
            msgToolTip.Show(string.Format("纬度={0}, 经度={1})", pt.Latitude, pt.Longitude), tabGEViewer, tipLeft, tipTop, 5000);
        }

        private void GrabGELocation(double dx, double dy)
        {
            if (!tabDocker.Contains(tabXPViewer))
            {
                tabDocker.TabPages.Add(tabXPViewer);
            }
            tabDocker.SelectTab(tabXPViewer);

            PointOnTerrainGE pt = GEApp.GetPointOnTerrainFromScreenCoords(dx, dy);
            msgToolTip.RemoveAll();

            CameraInfoGE camInfo = GEApp.GetCamera(0);
            scp.Latitude = pt.Latitude;
            scp.Longitude = pt.Longitude;
            scp.Altitude = camInfo.FocusPointAltitude;
            scp.Range = camInfo.Range;
            scp.Tilt = camInfo.Tilt;
            scp.Azimuth = camInfo.Azimuth;
            scp.Speed = 3.0;

            textBox_Latitude.Text = scp.Latitude.ToString();
            textBox_Longitude.Text = scp.Longitude.ToString();
            textBox_Altitude.Text = scp.Altitude.ToString();
            textBox_Range.Text = scp.Range.ToString();
            textBox_Tilt.Text = scp.Tilt.ToString();
            textBox_Azimuth.Text = scp.Azimuth.ToString();
            textBox_Speed.Text = scp.Speed.ToString();
            textBox_PlaceId.Text = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            comboBoxPlaces.SelectedIndex = -1;
            btnDrag1.Enabled = true;
            btnDrag1.Text = ">>";
            btnDrag1.BackColor = Color.LightBlue;
            btnDrag2.Enabled = true;
            btnDrag2.Text = ">>";
            btnDrag2.BackColor = Color.LightBlue;
        }

        private void btnStartGE_Click(object sender, EventArgs e)
        {
            if (CheckGEState(false, "启动 Google Earth"))
            {
                SetBackgroundImage(tabGEViewer, true);
                TryStartGE(tabGEViewer);
                ResizeTabPage(tabGEViewer);
            }
        }

        private void btnStopGE_Click(object sender, EventArgs e)
        {
            if (CheckGEState(true, "关闭 Google Earth"))
            {
                SetBackgroundImage(tabGEViewer);
                TryCloseGE();
            }

            //关闭GE之后应当移除[辅助面板]标签页
            if (tabDocker.Contains(tabXPViewer))
            {
                tabDocker.TabPages.Remove(tabXPViewer);
            }

            msgToolTip.Show(hint, tabGEViewer, tipLeft, 20, 10000);
        }

        private void btnExitApp_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK != MessageBox.Show("确定要退出程序吗?", "提示", MessageBoxButtons.OKCancel))
            {
                return;
            }
            if (isGEStarted)
            {
                TryCloseGE();
            }
            Application.Exit();
        }

        private void btnGESnap_MouseEnter(object sender, EventArgs e)
        {
            tabDocker.SelectTab(tabGEViewer);
        }

        private void btnAPISnap_MouseEnter(object sender, EventArgs e)
        {
            tabDocker.SelectTab(tabGEViewer);
        }

        private void btnGESnap_Click(object sender, EventArgs e)
        {
            if (CheckGEState(true, "GE截图"))
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "JPEG图片(*.jpg)|*.jpg";
                    sfd.AddExtension = true;
                    sfd.CheckPathExists = true;
                    sfd.Title = "保存Google Earth截图(灰度图)";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        GEApp.SaveScreenShot(sfd.FileName, 100);
                        msgToolTip.Show(string.Format("\'{0} Saved!", sfd.FileName), tabGEViewer, tipLeft, tipTop, 2000);
                    }
                }
            }
        }

        private void btnAPISnap_Click(object sender, EventArgs e)
        {
            if (CheckGEState(true, "API截图"))
            {
                RECT rect = new RECT();
                WindowsAPI.GetClientRect(GEHRenderWnd, out rect);

                // 取得Render DC
                IntPtr hRenderDC = WindowsAPI.GetWindowDC(GEHRenderWnd);
                // 创建hBitmap
                IntPtr hBitmap = WindowsAPI.CreateCompatibleBitmap(hRenderDC, rect.Width, rect.Height);
                // 创建MEM DC
                IntPtr hMemDC = WindowsAPI.CreateCompatibleDC(hRenderDC);
                // 将Bitmap Select到MemDC
                WindowsAPI.SelectObject(hMemDC, hBitmap);
                // 直接拷屏
                WindowsAPI.BitBlt(hMemDC, rect.left, rect.top, rect.Width, rect.Height, hRenderDC, 0, 0, WindowsAPI.SRCCOPY);

                #region SaveImage

                using (Bitmap bmp = Bitmap.FromHbitmap(hBitmap))
                {
                    using (SaveFileDialog sfd = new SaveFileDialog())
                    {
                        sfd.Filter = "JPEG图片(*.jpg)|*.jpg|PNG图片(*.png)|*.png";
                        sfd.AddExtension = true;
                        sfd.CheckPathExists = true;
                        sfd.Title = "保存Google Earth截图(彩色图)";

                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            ImageFormat imgFormat = null;
                            // 默认选择JPG
                            if (sfd.FilterIndex == 0)
                            {
                                imgFormat = ImageFormat.Jpeg;
                            }
                            // 选择PNG
                            else
                            {
                                imgFormat = ImageFormat.Png;
                            }
                            bmp.Save(sfd.FileName, imgFormat);
                            msgToolTip.Show(string.Format("\'{0} Saved!", sfd.FileName), tabGEViewer, tipLeft, tipTop, 2000);
                        }
                    }
                    //销毁资源
                    WindowsAPI.DeleteDC(hRenderDC);
                    WindowsAPI.DeleteDC(hMemDC);
                }

                #endregion SaveImage
            }

        }

        private void btnDashBoard_Click(object sender, EventArgs e)
        {
            if (CheckGEState(true, "辅助面板"))
            {
                if (tabDocker.Contains(tabXPViewer))
                {
                    tabDocker.SelectTab(tabXPViewer);
                    return;
                }
                tabDocker.TabPages.Add(tabXPViewer);
                tabDocker.SelectTab(tabXPViewer);
                btnStartCapture.Enabled = false;
            }
        }

        private void btnSaveFocusParams_Click(object sender, EventArgs e)
        {
            IntelliGetFocusParams();
            WriteFocusParamsToFile();
            comboBoxPlaces.Items.Add(textBox_PlaceId.Text);
            comboBoxPlaces.SelectedIndex = -1;
            msgToolTip.Show(string.Format("\'{0}\' 已保存!", strParamsXmlFilePath), tabGEViewer, tipLeft, tipTop, 2000);
        }

        private void btnGetFocusParams_Click(object sender, EventArgs e)
        {
            CameraInfoGE camInfo = GEApp.GetCamera(0);
            scp.Latitude = camInfo.FocusPointLatitude;
            scp.Longitude = camInfo.FocusPointLongitude;
            scp.Altitude = camInfo.FocusPointAltitude;
            scp.Range = camInfo.Range;
            scp.Tilt = camInfo.Tilt;
            scp.Azimuth = camInfo.Azimuth;
            scp.Speed = 3.0;

            textBox_Latitude.Text = scp.Latitude.ToString();
            textBox_Longitude.Text = scp.Longitude.ToString();
            textBox_Altitude.Text = scp.Altitude.ToString();
            textBox_Range.Text = scp.Range.ToString();
            textBox_Tilt.Text = scp.Tilt.ToString();
            textBox_Azimuth.Text = scp.Azimuth.ToString();
            textBox_Speed.Text = scp.Speed.ToString();
            textBox_PlaceId.Text = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            comboBoxPlaces.SelectedIndex = -1;
            btnDrag1.Enabled = true;
            btnDrag1.Text = ">>";
            btnDrag1.BackColor = Color.LightBlue;
            btnDrag2.Enabled = true;
            btnDrag2.Text = ">>";
            btnDrag2.BackColor = Color.LightBlue;
        }

        private void comboBoxPlaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPlaces.SelectedIndex < 0)
            {
                return; //未选择任何项目
            }

            if (!File.Exists(strParamsXmlFilePath))
            {
                MessageBox.Show(strParamsXmlFilePath + "\n文件未找到");
                IntelliGetFocusParams();
                return;
            }
            msgToolTip.Show(string.Format("从文件 \'{0}\' 载入数据", strParamsXmlFilePath), tabXPViewer, tipLeft, tipTop, 2000);
            string strPlaceName = comboBoxPlaces.Text;
            if (strPlaceName == null || strPlaceName == "")
            {
                MessageBox.Show("请在下拉列表中选择一项");
                return;
            }
            textBox_PlaceId.Text = strPlaceName;
            LoadFocusParamsFromFile(comboBoxPlaces.Text);
        }

        private void btnClearFocusParams_Click(object sender, EventArgs e)
        {
            textBox_Latitude.Clear();
            textBox_Longitude.Clear();
            textBox_Altitude.Clear();
            textBox_Range.Clear();
            textBox_Tilt.Clear();
            textBox_Azimuth.Clear();
            textBox_Speed.Clear();
            textBox_PlaceId.Clear();
            comboBoxPlaces.SelectedIndex = -1;

            btnDrag1.Enabled = false;
            btnDrag1.Text = "";
            btnDrag1.BackColor = Color.Silver;
            btnDrag2.Enabled = false;
            btnDrag2.Text = "";
            btnDrag2.BackColor = Color.Silver;
        }

        private void btnConfirmFocusParams_Click(object sender, EventArgs e)
        {
            IntelliGetFocusParams();

            GEApp.SetCameraParams(scp.Latitude, scp.Longitude, scp.Altitude,
                AltitudeModeGE.AbsoluteAltitudeGE,
                scp.Range, scp.Tilt, scp.Azimuth, scp.Speed);

            tabDocker.TabPages.Remove(tabXPViewer);

            string msg = "== 当前视角焦点 ==\n";
            msg += "标签:" + textBox_PlaceId.Text + "\n";
            msg += "纬度:" + textBox_Latitude.Text + "\n";
            msg += "经度:" + textBox_Longitude.Text + "\n";
            msg += "视高:" + textBox_Range.Text + "米";
            msgToolTip.RemoveAll();
            msgToolTip.Show(msg, tabGEViewer, tabGEViewer.Width / 2 - 60, tabGEViewer.Height / 2 + 20, 5000);
        }

        private void btnDrag1_Click(object sender, EventArgs e)
        {
            textBox_RP1Lat.Text = scp.Latitude.ToString();
            textBox_RP1Lon.Text = scp.Longitude.ToString();
            btnDrag1.Enabled = false;
            btnDrag1.Text = "";
            btnDrag1.BackColor = Color.Silver;
            btnDrag2.Enabled = false;
            btnDrag2.Text = "";
            btnDrag2.BackColor = Color.Silver;
        }

        private void btnDrag2_Click(object sender, EventArgs e)
        {
            textBox_RP2Lat.Text = scp.Latitude.ToString();
            textBox_RP2Lon.Text = scp.Longitude.ToString();
            btnDrag1.Enabled = false;
            btnDrag1.Text = "";
            btnDrag1.BackColor = Color.Silver;
            btnDrag2.Enabled = false;
            btnDrag2.Text = "";
            btnDrag2.BackColor = Color.Silver;
        }

        private void btnPrepareCapture_Click(object sender, EventArgs e)
        {
            string sRP1Lat = textBox_RP1Lat.Text;
            string sRP1Lon = textBox_RP1Lon.Text;
            string sRP2Lat = textBox_RP2Lat.Text;
            string sRP2Lon = textBox_RP2Lon.Text;
            string sRctRange = textBox_RctRange.Text;

            #region CheckInput

            if (string.IsNullOrEmpty(sRP1Lat))
            {
                MessageBox.Show("请输入对角点1的纬度!", "提示");
                return;
            }
            if (string.IsNullOrEmpty(sRP1Lon))
            {
                MessageBox.Show("请输入对角点1的经度!", "提示");
                return;
            }
            if (string.IsNullOrEmpty(sRP2Lat))
            {
                MessageBox.Show("请输入对角点2的纬度!", "提示");
                return;
            }
            if (string.IsNullOrEmpty(sRP2Lon))
            {
                MessageBox.Show("请输入对角点2的经度!", "提示");
                return;
            }
            if (string.IsNullOrEmpty(sRctRange))
            {
                MessageBox.Show("请输入视角高度!", "提示");
                return;
            }

            #endregion CheckInput

            rp1lat = double.Parse(sRP1Lat);
            rp1lon = double.Parse(sRP1Lon);
            rp2lat = double.Parse(sRP2Lat);
            rp2lon = double.Parse(sRP2Lon);
            range = double.Parse(sRctRange);

            string sdr = textBox_Range.Text.Trim();
            double def_range = double.Parse(sdr);

            #region CheckInput2

            if (rp1lat < rp2lat)
            {
                MessageBox.Show("纬度: 请确保对角点1在对角点2的上方", "提示");
                return;
            }
            if (rp1lon > rp2lon)
            {
                MessageBox.Show("经度: 请确保对角点1在对角点2的左侧", "提示");
                return;
            }
            if (range > def_range || range < 0)
            {
                MessageBox.Show(string.Format("视高: 合法的输入在0到{0}之间", def_range), "提示");
                return;
            }

            #endregion

            #region GEPrepare

            GEApp.SetCameraParams(rp1lat, rp1lon, alt, am, range, tilt, azimuth, speed);
            PointOnTerrainGE pt = GEApp.GetPointOnTerrainFromScreenCoords(1.0, 1.0);
            lat_d = pt.Latitude - rp1lat;
            lon_d = pt.Longitude - rp1lon;
            seg_rows = (int)((rp1lat - rp2lat) / lat_d + 1.5);
            seg_cols = (int)((rp2lon - rp1lon) / lon_d + 1.5);
            seg_w = GEHRenderRect.Width / 2; ;
            seg_h = GEHRenderRect.Height / 2;
            dst_w = seg_w * seg_cols;
            dst_h = seg_h * seg_rows;
            left = GEHRenderRect.Left + seg_w / 2;
            top = GEHRenderRect.Top + seg_h / 2;

            if(seg_rows<=0||seg_cols<=0)
            {
                MessageBox.Show("根据你所设置的参数,截图不足一张\n可以尝试:" +
                    "修改左侧参数列表中的视高参数\n点击【应用】应用更改, 然后重试截图","错误");
                return;
            }

            #endregion GEPrepare

            textBox_CaptureInfo.Text =
                string.Format("{0}\n\n分片数目={1} ({2}行*{3}列)\n分片尺寸={4}*{5}\n拼接后尺寸={6}*{7}"+
                "\n每个像素大约对应{8}米", DateTime.Now.ToString(),seg_rows * seg_cols, seg_rows, seg_cols, 
                seg_w, seg_h, dst_w, dst_h,range/1320);

            btnStartCapture.Enabled = true;
        }

        private void btnStartCapture_Click(object sender, EventArgs e)
        {
            btnStartCapture.Enabled = false;
            tabDocker.SelectTab(tabGEViewer);

            #region Prepare

            string str = strParamsXmlFilePath.Replace('/', '\\');
            str = str.Remove(str.IndexOf(strBackup));
            string sdt = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            combPathRoot = string.Format("{0}Capture\\{1}_H{2}\\", str, sdt, range);
            Directory.CreateDirectory(combPathRoot);

            double lat_mid = rp1lat + lat_d * seg_cols / 2;
            double lon_mid = rp1lon + lon_d * seg_rows / 2;
            combImageName = string.Format("{0}Combined_{1}.jpg", combPathRoot, sdt);
            StreamWriter sw = new StreamWriter(combPathRoot + "info.txt");
            sw.WriteLine("Center Lat={0}\r\nCenter Lon={1}\r\nResolution={2}(meter/pix)", lat_mid, lon_mid, range / 1320);
            sw.Flush();
            sw.Close();

            #endregion Prepare

            #region Capture

            Bitmap dst = new Bitmap(dst_w, dst_h);
            Graphics g = Graphics.FromImage(dst);
            System.Drawing.Size sz = new System.Drawing.Size(seg_w, seg_h);

            int ni=0,nn = seg_cols * seg_rows;

            double lat=rp1lat;
            double lon=rp1lon;
            for (int i = 0; i < seg_rows; ++i)
            {
                msgToolTip.Show(string.Format("Progress: {0:D2}/{1:D2}", ni,nn), tabGEViewer, tipLeft + 100, tipTop, 3000);

                for (int j = 0; j <seg_cols; ++j)
                {
                    ++ni;

                    GEApp.SetCameraParams(lat, lon, alt, am, range, tilt, azimuth, speed);

                    while (GEApp.StreamingProgressPercentage < 100)
                    {
                        Application.DoEvents();
                    }
                    GEApp.SaveScreenShot(string.Format("{0}R{1:D3}_C{2:D3}.jpg", combPathRoot, i + 1, j + 1), 100);
                    g.CopyFromScreen(left, top, j * seg_w, i * seg_h, sz);

                    lon += lon_d;
                }
                lat -= lat_d;
                lon = rp1lon;
            }

            dst.Save(combImageName, ImageFormat.Jpeg);
            g.Dispose();
            dst.Dispose();

            msgToolTip.Show(combImageName + " Saved!", tabXPViewer, tipLeft, tipTop, 2000);

            tabDocker.SelectTab(tabXPViewer);

            #endregion Capture

            msgToolTip.Show(string.Format("截图完成! 保存在\'{0}\'", combPathRoot), tabXPViewer, tipLeft, tipTop, 5000);
        }

        private void btnAboutAuthor_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.ShowDialog(this);
        }

        #endregion MessageHandlers

        #region AuxFunctions

        private bool CheckGEState(bool bExpRun, string caption)
        {
            bool state = true;
            if (bExpRun)
            {
                //期望GE运行而实际并未运行
                if (!isGEStarted)
                {
                    MessageBox.Show("Goolge Earth 尚未启动/在线运行", caption);
                    state = false;
                }
            }
            else
            {
                //期望GE关闭而实际正在运行
                if (isGEStarted)
                {
                    MessageBox.Show("Goolge Earth 正在运行", caption);
                    state = false;
                }
            }

            return state;
        }

        //reset=true表示清除背景图片
        private void SetBackgroundImage(Control control, bool reset = false)
        {
            if (reset)
            {
                control.BackgroundImage = null;
            }
            else
            {
                control.BackgroundImage = Properties.Resources.GEBgnd;
                control.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        private void IntelliGetFocusParams()
        {
            string text = textBox_Latitude.Text;
            if (text == null || text == "")
            {
                textBox_Latitude.Text = "31°14'30''N";
                scp.Latitude = 31.24167;
            }
            else
            {
                scp.Latitude = TranslateLatLon(text);
                if (scp.Latitude >= 90 || scp.Latitude <= -90)
                {
                    textBox_Latitude.Text = "31°14'30''N";
                    scp.Latitude = 31.24167;
                }
            }

            text = textBox_Longitude.Text;
            if (text == null || text == "")
            {
                textBox_Longitude.Text = "121°29'43''E";
                scp.Longitude = 121.4953;
            }
            else
            {
                scp.Longitude = TranslateLatLon(text);
                if (scp.Longitude >= 180 || scp.Longitude <= -180)
                {
                    textBox_Longitude.Text = "121°29'43''E";
                    scp.Longitude = 121.4953;
                }
            }

            text = textBox_Altitude.Text;
            if (text == null || text == "")
            {
                textBox_Altitude.Text = "0.0";
                scp.Altitude = 0.0;
            }
            else
            {
                scp.Altitude = double.Parse(text);
                if (scp.Altitude < 0)
                {
                    textBox_Altitude.Text = "0.0";
                    scp.Altitude = 0.0;
                }
            }

            text = textBox_Range.Text;
            if (text == null || text == "")
            {
                textBox_Range.Text = "2000.0";
                scp.Range = 2000.0;
            }
            else
            {
                scp.Range = double.Parse(text);
                if (scp.Range <= 0)
                {
                    textBox_Range.Text = "2000.0";
                    scp.Range = 2000.0;
                }
            }

            text = textBox_Tilt.Text;
            if (text == null || text == "")
            {
                textBox_Tilt.Text = "0.0";
                scp.Tilt = 0.0;
            }
            else
            {
                scp.Tilt = double.Parse(text);
                if (scp.Tilt < 0)
                {
                    textBox_Tilt.Text = "0.0";
                    scp.Tilt = 0.0;
                }
            }

            text = textBox_Azimuth.Text;
            if (text == null || text == "")
            {
                textBox_Azimuth.Text = "0.0";
                scp.Azimuth = 0.0;
            }
            else
            {
                scp.Azimuth = double.Parse(text);
            }

            text = textBox_Speed.Text;
            if (text == null || text == "")
            {
                textBox_Speed.Text = "3.0";
                scp.Speed = 3.0;
            }
            else
            {
                scp.Speed = double.Parse(text);
                if (scp.Speed <= 0)
                {
                    textBox_Speed.Text = "3.0";
                    scp.Speed = 3.0;
                }
            }

            text = textBox_PlaceId.Text;
            if (text == null || text == "")
            {
                textBox_PlaceId.Text = DateTime.Now.ToString("yyyMMdd_HHmmss");
            }
        }

        private void SetFocusParamsDefault()
        {
            // 上海外滩,东方明珠塔
            // (31°14'30''N 121°29'43''E)
            // (31.24167°N 121.4953°E)

            textBox_Latitude.Text = "31°14'30''N";
            textBox_Longitude.Text = "121°29'43''E";
            textBox_Altitude.Text = "0";
            textBox_Range.Text = "2000";
            textBox_Tilt.Text = "0";
            textBox_Azimuth.Text = "0";
            textBox_Speed.Text = "3";
            textBox_PlaceId.Text = "上海外滩";

            scp.Latitude = 31.24167;
            scp.Longitude = 121.4953;
            scp.Altitude = 0;
            scp.Range = 2000;
            scp.Tilt = 0;
            scp.Azimuth = 0;
            scp.Speed = 3;
        }

        private double TranslateLatLon(string slatlon)
        {
            string str = slatlon.Trim(); //移除字符串中的空白
            double ddeg = 0.0;
            double dmin = 0.0;
            double dsec = 0.0;
            int start = 0, pos = 0;
            #region VAL
            pos = str.IndexOf('°', start);
            if (pos > 0)
            {
                #region ddeg
                while (start < pos)
                {
                    if (str[start] == '0') ++start;
                    else break;
                }
                if (start < pos)
                {
                    ddeg = double.Parse(str.Substring(start, pos - start));
                }
                #endregion ddeg

                start = pos + 1;
                pos = str.IndexOf('\'', start);
                if (pos > 0)
                {
                    #region dmin
                    while (start < pos)
                    {
                        if (str[start] == '0') ++start;
                        else break;
                    }
                    if (start < pos)
                    {
                        dmin = double.Parse(str.Substring(start, pos - start));
                    }
                    #endregion dmin

                    start = pos + 1;
                    pos = str.IndexOf('\'', start);
                    if (pos < 0) pos = str.Length - 1;
                    #region dsec
                    while (start < pos)
                    {
                        if (str[start] == '0') ++start;
                        else break;
                    }
                    if (start < pos)
                    {
                        dsec = double.Parse(str.Substring(start, pos - start));
                    }
                    #endregion dsec
                } //if(pos,dmin)
                #region SGN
                pos = str.Length - 1;
                if (str[pos] == 'S' || str[pos] == 'W')
                {
                    ddeg = -ddeg;
                    dmin = -dmin;
                    dsec = -dsec;
                } //if(pos,len-1)
                #endregion SGN
            } //if(pos ddeg)
            else
            {
                ddeg = double.Parse(str);
            }
            #endregion VAL

            return (ddeg + dmin / 60.0 + dsec / 3600.0);
        }

        private void CreateParamsXmlFile()
        {
            XmlDocument xDoc = new XmlDocument();
            XmlElement root = xDoc.CreateElement("Parameters");
            root.SetAttribute("Property", "AutoSavedParameters");
            xDoc.AppendChild(root);
            xDoc.Save(strParamsXmlFilePath);
        }

        private void WriteFocusParamsToFile()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(strParamsXmlFilePath);
            XmlNodeList nodes = xDoc.SelectNodes("//Name");
            bool exists = false;
            foreach (XmlNode node in nodes)
            {
                if (node.InnerText == textBox_PlaceId.Text)
                {
                    exists = true;
                    break;
                }
            }
            if (exists)
            {
                MessageBox.Show("名称 \'" + textBox_PlaceId.Text + "\' 已经存在,请设置一个新的别名!");
            }
            else
            {
                XmlNode root = xDoc.SelectSingleNode("Parameters");
                XmlElement place = xDoc.CreateElement("Place");
                place.SetAttribute("Property", "FocusPlace");
                XmlElement name = xDoc.CreateElement("Name");
                name.InnerText = textBox_PlaceId.Text;
                XmlElement lat = xDoc.CreateElement("Latitude");
                lat.InnerText = textBox_Latitude.Text;
                XmlElement lon = xDoc.CreateElement("Longitude");
                lon.InnerText = textBox_Longitude.Text;
                XmlElement alt = xDoc.CreateElement("Altitude");
                alt.InnerText = textBox_Altitude.Text;
                XmlElement rng = xDoc.CreateElement("Range");
                rng.InnerText = textBox_Range.Text;
                XmlElement ang = xDoc.CreateElement("Tilt");
                ang.InnerText = textBox_Tilt.Text;
                XmlElement azm = xDoc.CreateElement("Azimuth");
                azm.InnerText = textBox_Azimuth.Text;
                XmlElement spd = xDoc.CreateElement("Speed");
                spd.InnerText = textBox_Speed.Text;
                place.AppendChild(name);
                place.AppendChild(lat);
                place.AppendChild(lon);
                place.AppendChild(alt);
                place.AppendChild(rng);
                place.AppendChild(ang);
                place.AppendChild(azm);
                place.AppendChild(spd);
                root.AppendChild(place);
            }
            xDoc.Save(strParamsXmlFilePath);
        }

        private void LoadFocusParamsFromFile(string strPlaceName)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(strParamsXmlFilePath);
            XmlNodeList nodes = xDoc.SelectNodes("//Place");
            int i, count = nodes.Count;
            for (i = 0; i < count; ++i)
            {
                XmlNode node = nodes[i];
                XmlNode sub = node.SelectSingleNode("Name");
                if (sub.InnerText == strPlaceName)
                {
                    sub = node.SelectSingleNode("Latitude");
                    textBox_Latitude.Text = sub.InnerText;
                    sub = node.SelectSingleNode("Longitude");
                    textBox_Longitude.Text = sub.InnerText;
                    sub = node.SelectSingleNode("Altitude");
                    textBox_Altitude.Text = sub.InnerText;
                    sub = node.SelectSingleNode("Range");
                    textBox_Range.Text = sub.InnerText;
                    sub = node.SelectSingleNode("Tilt");
                    textBox_Tilt.Text = sub.InnerText;
                    sub = node.SelectSingleNode("Azimuth");
                    textBox_Azimuth.Text = sub.InnerText;
                    sub = node.SelectSingleNode("Speed");
                    textBox_Speed.Text = sub.InnerText;
                    break;
                }
            }
        }

        #endregion AuxFunctions

    }

}
