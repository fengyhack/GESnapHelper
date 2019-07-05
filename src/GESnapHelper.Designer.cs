namespace GESnapHelper
{
    partial class GESnapHelper
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GESnapHelper));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.tabDocker = new System.Windows.Forms.TabControl();
            this.tabGEViewer = new System.Windows.Forms.TabPage();
            this.tabXPViewer = new System.Windows.Forms.TabPage();
            this.groupBoxCaptureParams = new System.Windows.Forms.GroupBox();
            this.btnPrepareCapture = new System.Windows.Forms.Button();
            this.textBox_CaptureInfo = new System.Windows.Forms.RichTextBox();
            this.btnStartCapture = new System.Windows.Forms.Button();
            this.label_RctRange = new System.Windows.Forms.Label();
            this.textBox_RctRange = new System.Windows.Forms.TextBox();
            this.btnDrag2 = new System.Windows.Forms.Button();
            this.btnDrag1 = new System.Windows.Forms.Button();
            this.groupBoxRectPoint1 = new System.Windows.Forms.GroupBox();
            this.label_RP1Lat = new System.Windows.Forms.Label();
            this.textBox_RP1Lat = new System.Windows.Forms.TextBox();
            this.textBox_RP1Lon = new System.Windows.Forms.TextBox();
            this.label_RP1Lon = new System.Windows.Forms.Label();
            this.groupBoxRectPoint2 = new System.Windows.Forms.GroupBox();
            this.textBox_RP2Lat = new System.Windows.Forms.TextBox();
            this.textBox_RP2Lon = new System.Windows.Forms.TextBox();
            this.label_RP2Lat = new System.Windows.Forms.Label();
            this.label_RP2Lon = new System.Windows.Forms.Label();
            this.groupBoxFocusParams = new System.Windows.Forms.GroupBox();
            this.label_xDoc = new System.Windows.Forms.Label();
            this.labelTip = new System.Windows.Forms.Label();
            this.btnClearFocusParams = new System.Windows.Forms.Button();
            this.comboBoxPlaces = new System.Windows.Forms.ComboBox();
            this.textBox_PlaceId = new System.Windows.Forms.TextBox();
            this.label_PlaceName = new System.Windows.Forms.Label();
            this.btnGetFocusParams = new System.Windows.Forms.Button();
            this.btnSaveFocusParams = new System.Windows.Forms.Button();
            this.btnConfirmFocusParams = new System.Windows.Forms.Button();
            this.label_LonExp = new System.Windows.Forms.Label();
            this.label_LatExp = new System.Windows.Forms.Label();
            this.label_Speed = new System.Windows.Forms.Label();
            this.label_Azimuth = new System.Windows.Forms.Label();
            this.label_Angle = new System.Windows.Forms.Label();
            this.label_Range = new System.Windows.Forms.Label();
            this.label_Altitude = new System.Windows.Forms.Label();
            this.label_Longitude = new System.Windows.Forms.Label();
            this.label_Latitude = new System.Windows.Forms.Label();
            this.textBox_Speed = new System.Windows.Forms.TextBox();
            this.textBox_Azimuth = new System.Windows.Forms.TextBox();
            this.textBox_Tilt = new System.Windows.Forms.TextBox();
            this.textBox_Range = new System.Windows.Forms.TextBox();
            this.textBox_Altitude = new System.Windows.Forms.TextBox();
            this.textBox_Longitude = new System.Windows.Forms.TextBox();
            this.textBox_Latitude = new System.Windows.Forms.TextBox();
            this.toolBar = new System.Windows.Forms.ToolStrip();
            this.btnAppx = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnStartGE = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStopGE = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExitApp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSnap = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnGESnap = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAPISnap = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDashboard = new System.Windows.Forms.ToolStripButton();
            this.btnAboutAuthor = new System.Windows.Forms.ToolStripButton();
            this.msgToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.mainPanel.SuspendLayout();
            this.tabDocker.SuspendLayout();
            this.tabXPViewer.SuspendLayout();
            this.groupBoxCaptureParams.SuspendLayout();
            this.groupBoxRectPoint1.SuspendLayout();
            this.groupBoxRectPoint2.SuspendLayout();
            this.groupBoxFocusParams.SuspendLayout();
            this.toolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.tabDocker);
            this.mainPanel.Controls.Add(this.toolBar);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1182, 855);
            this.mainPanel.TabIndex = 0;
            // 
            // tabDocker
            // 
            this.tabDocker.Controls.Add(this.tabGEViewer);
            this.tabDocker.Controls.Add(this.tabXPViewer);
            this.tabDocker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDocker.Location = new System.Drawing.Point(0, 30);
            this.tabDocker.Name = "tabDocker";
            this.tabDocker.SelectedIndex = 0;
            this.tabDocker.Size = new System.Drawing.Size(1182, 825);
            this.tabDocker.TabIndex = 1;
            // 
            // tabGEViewer
            // 
            this.tabGEViewer.BackColor = System.Drawing.Color.LightGray;
            this.tabGEViewer.Location = new System.Drawing.Point(4, 32);
            this.tabGEViewer.Name = "tabGEViewer";
            this.tabGEViewer.Padding = new System.Windows.Forms.Padding(3);
            this.tabGEViewer.Size = new System.Drawing.Size(1174, 789);
            this.tabGEViewer.TabIndex = 0;
            this.tabGEViewer.Text = "GE影像";
            // 
            // tabXPViewer
            // 
            this.tabXPViewer.AutoScroll = true;
            this.tabXPViewer.AutoScrollMinSize = new System.Drawing.Size(800, 800);
            this.tabXPViewer.BackColor = System.Drawing.Color.Silver;
            this.tabXPViewer.Controls.Add(this.groupBoxCaptureParams);
            this.tabXPViewer.Controls.Add(this.groupBoxFocusParams);
            this.tabXPViewer.Location = new System.Drawing.Point(4, 32);
            this.tabXPViewer.Name = "tabXPViewer";
            this.tabXPViewer.Padding = new System.Windows.Forms.Padding(3);
            this.tabXPViewer.Size = new System.Drawing.Size(1174, 789);
            this.tabXPViewer.TabIndex = 1;
            this.tabXPViewer.Text = "辅助面板";
            // 
            // groupBoxCaptureParams
            // 
            this.groupBoxCaptureParams.Controls.Add(this.btnPrepareCapture);
            this.groupBoxCaptureParams.Controls.Add(this.textBox_CaptureInfo);
            this.groupBoxCaptureParams.Controls.Add(this.btnStartCapture);
            this.groupBoxCaptureParams.Controls.Add(this.label_RctRange);
            this.groupBoxCaptureParams.Controls.Add(this.textBox_RctRange);
            this.groupBoxCaptureParams.Controls.Add(this.btnDrag2);
            this.groupBoxCaptureParams.Controls.Add(this.btnDrag1);
            this.groupBoxCaptureParams.Controls.Add(this.groupBoxRectPoint1);
            this.groupBoxCaptureParams.Controls.Add(this.groupBoxRectPoint2);
            this.groupBoxCaptureParams.Location = new System.Drawing.Point(385, 34);
            this.groupBoxCaptureParams.Name = "groupBoxCaptureParams";
            this.groupBoxCaptureParams.Size = new System.Drawing.Size(392, 747);
            this.groupBoxCaptureParams.TabIndex = 1;
            this.groupBoxCaptureParams.TabStop = false;
            this.groupBoxCaptureParams.Text = "截图参数";
            // 
            // btnPrepareCapture
            // 
            this.btnPrepareCapture.Location = new System.Drawing.Point(57, 433);
            this.btnPrepareCapture.Name = "btnPrepareCapture";
            this.btnPrepareCapture.Size = new System.Drawing.Size(134, 47);
            this.btnPrepareCapture.TabIndex = 26;
            this.btnPrepareCapture.Text = "截图准备";
            this.btnPrepareCapture.UseVisualStyleBackColor = true;
            this.btnPrepareCapture.Click += new System.EventHandler(this.btnPrepareCapture_Click);
            // 
            // textBox_CaptureInfo
            // 
            this.textBox_CaptureInfo.BackColor = System.Drawing.SystemColors.Info;
            this.textBox_CaptureInfo.Location = new System.Drawing.Point(57, 504);
            this.textBox_CaptureInfo.Name = "textBox_CaptureInfo";
            this.textBox_CaptureInfo.ReadOnly = true;
            this.textBox_CaptureInfo.Size = new System.Drawing.Size(292, 175);
            this.textBox_CaptureInfo.TabIndex = 24;
            this.textBox_CaptureInfo.Text = "";
            // 
            // btnStartCapture
            // 
            this.btnStartCapture.Location = new System.Drawing.Point(218, 433);
            this.btnStartCapture.Name = "btnStartCapture";
            this.btnStartCapture.Size = new System.Drawing.Size(134, 47);
            this.btnStartCapture.TabIndex = 23;
            this.btnStartCapture.Text = "开始截图";
            this.btnStartCapture.UseVisualStyleBackColor = true;
            this.btnStartCapture.Click += new System.EventHandler(this.btnStartCapture_Click);
            // 
            // label_RctRange
            // 
            this.label_RctRange.AutoSize = true;
            this.label_RctRange.Location = new System.Drawing.Point(74, 372);
            this.label_RctRange.Name = "label_RctRange";
            this.label_RctRange.Size = new System.Drawing.Size(86, 23);
            this.label_RctRange.TabIndex = 20;
            this.label_RctRange.Text = "视高(米)";
            // 
            // textBox_RctRange
            // 
            this.textBox_RctRange.Location = new System.Drawing.Point(168, 369);
            this.textBox_RctRange.Name = "textBox_RctRange";
            this.textBox_RctRange.Size = new System.Drawing.Size(184, 31);
            this.textBox_RctRange.TabIndex = 19;
            // 
            // btnDrag2
            // 
            this.btnDrag2.BackColor = System.Drawing.Color.LightBlue;
            this.btnDrag2.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnDrag2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Orange;
            this.btnDrag2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDrag2.Location = new System.Drawing.Point(6, 262);
            this.btnDrag2.Name = "btnDrag2";
            this.btnDrag2.Size = new System.Drawing.Size(49, 40);
            this.btnDrag2.TabIndex = 3;
            this.btnDrag2.Text = ">>";
            this.btnDrag2.UseVisualStyleBackColor = false;
            this.btnDrag2.Click += new System.EventHandler(this.btnDrag2_Click);
            // 
            // btnDrag1
            // 
            this.btnDrag1.BackColor = System.Drawing.Color.LightBlue;
            this.btnDrag1.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnDrag1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Orange;
            this.btnDrag1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDrag1.Location = new System.Drawing.Point(6, 101);
            this.btnDrag1.Name = "btnDrag1";
            this.btnDrag1.Size = new System.Drawing.Size(49, 40);
            this.btnDrag1.TabIndex = 2;
            this.btnDrag1.Text = ">>";
            this.btnDrag1.UseVisualStyleBackColor = false;
            this.btnDrag1.Click += new System.EventHandler(this.btnDrag1_Click);
            // 
            // groupBoxRectPoint1
            // 
            this.groupBoxRectPoint1.Controls.Add(this.label_RP1Lat);
            this.groupBoxRectPoint1.Controls.Add(this.textBox_RP1Lat);
            this.groupBoxRectPoint1.Controls.Add(this.textBox_RP1Lon);
            this.groupBoxRectPoint1.Controls.Add(this.label_RP1Lon);
            this.groupBoxRectPoint1.Location = new System.Drawing.Point(60, 45);
            this.groupBoxRectPoint1.Name = "groupBoxRectPoint1";
            this.groupBoxRectPoint1.Size = new System.Drawing.Size(312, 135);
            this.groupBoxRectPoint1.TabIndex = 22;
            this.groupBoxRectPoint1.TabStop = false;
            this.groupBoxRectPoint1.Text = "对角点1";
            // 
            // label_RP1Lat
            // 
            this.label_RP1Lat.AutoSize = true;
            this.label_RP1Lat.Location = new System.Drawing.Point(14, 39);
            this.label_RP1Lat.Name = "label_RP1Lat";
            this.label_RP1Lat.Size = new System.Drawing.Size(74, 23);
            this.label_RP1Lat.TabIndex = 11;
            this.label_RP1Lat.Text = "纬度(°)";
            // 
            // textBox_RP1Lat
            // 
            this.textBox_RP1Lat.Location = new System.Drawing.Point(108, 36);
            this.textBox_RP1Lat.Name = "textBox_RP1Lat";
            this.textBox_RP1Lat.Size = new System.Drawing.Size(184, 31);
            this.textBox_RP1Lat.TabIndex = 9;
            // 
            // textBox_RP1Lon
            // 
            this.textBox_RP1Lon.Location = new System.Drawing.Point(108, 80);
            this.textBox_RP1Lon.Name = "textBox_RP1Lon";
            this.textBox_RP1Lon.Size = new System.Drawing.Size(184, 31);
            this.textBox_RP1Lon.TabIndex = 10;
            // 
            // label_RP1Lon
            // 
            this.label_RP1Lon.AutoSize = true;
            this.label_RP1Lon.Location = new System.Drawing.Point(14, 85);
            this.label_RP1Lon.Name = "label_RP1Lon";
            this.label_RP1Lon.Size = new System.Drawing.Size(74, 23);
            this.label_RP1Lon.TabIndex = 12;
            this.label_RP1Lon.Text = "经度(°)";
            // 
            // groupBoxRectPoint2
            // 
            this.groupBoxRectPoint2.Controls.Add(this.textBox_RP2Lat);
            this.groupBoxRectPoint2.Controls.Add(this.textBox_RP2Lon);
            this.groupBoxRectPoint2.Controls.Add(this.label_RP2Lat);
            this.groupBoxRectPoint2.Controls.Add(this.label_RP2Lon);
            this.groupBoxRectPoint2.Location = new System.Drawing.Point(60, 203);
            this.groupBoxRectPoint2.Name = "groupBoxRectPoint2";
            this.groupBoxRectPoint2.Size = new System.Drawing.Size(312, 135);
            this.groupBoxRectPoint2.TabIndex = 21;
            this.groupBoxRectPoint2.TabStop = false;
            this.groupBoxRectPoint2.Text = "对角点2";
            // 
            // textBox_RP2Lat
            // 
            this.textBox_RP2Lat.Location = new System.Drawing.Point(108, 46);
            this.textBox_RP2Lat.Name = "textBox_RP2Lat";
            this.textBox_RP2Lat.Size = new System.Drawing.Size(184, 31);
            this.textBox_RP2Lat.TabIndex = 13;
            // 
            // textBox_RP2Lon
            // 
            this.textBox_RP2Lon.Location = new System.Drawing.Point(108, 85);
            this.textBox_RP2Lon.Name = "textBox_RP2Lon";
            this.textBox_RP2Lon.Size = new System.Drawing.Size(184, 31);
            this.textBox_RP2Lon.TabIndex = 14;
            // 
            // label_RP2Lat
            // 
            this.label_RP2Lat.AutoSize = true;
            this.label_RP2Lat.Location = new System.Drawing.Point(14, 45);
            this.label_RP2Lat.Name = "label_RP2Lat";
            this.label_RP2Lat.Size = new System.Drawing.Size(74, 23);
            this.label_RP2Lat.TabIndex = 15;
            this.label_RP2Lat.Text = "纬度(°)";
            // 
            // label_RP2Lon
            // 
            this.label_RP2Lon.AutoSize = true;
            this.label_RP2Lon.Location = new System.Drawing.Point(14, 88);
            this.label_RP2Lon.Name = "label_RP2Lon";
            this.label_RP2Lon.Size = new System.Drawing.Size(74, 23);
            this.label_RP2Lon.TabIndex = 16;
            this.label_RP2Lon.Text = "经度(°)";
            // 
            // groupBoxFocusParams
            // 
            this.groupBoxFocusParams.Controls.Add(this.label_xDoc);
            this.groupBoxFocusParams.Controls.Add(this.labelTip);
            this.groupBoxFocusParams.Controls.Add(this.btnClearFocusParams);
            this.groupBoxFocusParams.Controls.Add(this.comboBoxPlaces);
            this.groupBoxFocusParams.Controls.Add(this.textBox_PlaceId);
            this.groupBoxFocusParams.Controls.Add(this.label_PlaceName);
            this.groupBoxFocusParams.Controls.Add(this.btnGetFocusParams);
            this.groupBoxFocusParams.Controls.Add(this.btnSaveFocusParams);
            this.groupBoxFocusParams.Controls.Add(this.btnConfirmFocusParams);
            this.groupBoxFocusParams.Controls.Add(this.label_LonExp);
            this.groupBoxFocusParams.Controls.Add(this.label_LatExp);
            this.groupBoxFocusParams.Controls.Add(this.label_Speed);
            this.groupBoxFocusParams.Controls.Add(this.label_Azimuth);
            this.groupBoxFocusParams.Controls.Add(this.label_Angle);
            this.groupBoxFocusParams.Controls.Add(this.label_Range);
            this.groupBoxFocusParams.Controls.Add(this.label_Altitude);
            this.groupBoxFocusParams.Controls.Add(this.label_Longitude);
            this.groupBoxFocusParams.Controls.Add(this.label_Latitude);
            this.groupBoxFocusParams.Controls.Add(this.textBox_Speed);
            this.groupBoxFocusParams.Controls.Add(this.textBox_Azimuth);
            this.groupBoxFocusParams.Controls.Add(this.textBox_Tilt);
            this.groupBoxFocusParams.Controls.Add(this.textBox_Range);
            this.groupBoxFocusParams.Controls.Add(this.textBox_Altitude);
            this.groupBoxFocusParams.Controls.Add(this.textBox_Longitude);
            this.groupBoxFocusParams.Controls.Add(this.textBox_Latitude);
            this.groupBoxFocusParams.Location = new System.Drawing.Point(18, 34);
            this.groupBoxFocusParams.Name = "groupBoxFocusParams";
            this.groupBoxFocusParams.Size = new System.Drawing.Size(349, 747);
            this.groupBoxFocusParams.TabIndex = 0;
            this.groupBoxFocusParams.TabStop = false;
            this.groupBoxFocusParams.Text = "焦点(位置)参数";
            // 
            // label_xDoc
            // 
            this.label_xDoc.AutoSize = true;
            this.label_xDoc.Location = new System.Drawing.Point(18, 521);
            this.label_xDoc.Name = "label_xDoc";
            this.label_xDoc.Size = new System.Drawing.Size(90, 23);
            this.label_xDoc.TabIndex = 24;
            this.label_xDoc.Text = "存档列表";
            // 
            // labelTip
            // 
            this.labelTip.AutoSize = true;
            this.labelTip.Location = new System.Drawing.Point(13, 697);
            this.labelTip.Name = "labelTip";
            this.labelTip.Size = new System.Drawing.Size(314, 23);
            this.labelTip.TabIndex = 23;
            this.labelTip.Text = "若参数错误,将会自动设置为默认值";
            // 
            // btnClearFocusParams
            // 
            this.btnClearFocusParams.Location = new System.Drawing.Point(25, 632);
            this.btnClearFocusParams.Name = "btnClearFocusParams";
            this.btnClearFocusParams.Size = new System.Drawing.Size(128, 47);
            this.btnClearFocusParams.TabIndex = 22;
            this.btnClearFocusParams.Text = "清空";
            this.btnClearFocusParams.UseVisualStyleBackColor = true;
            this.btnClearFocusParams.Click += new System.EventHandler(this.btnClearFocusParams_Click);
            // 
            // comboBoxPlaces
            // 
            this.comboBoxPlaces.FormattingEnabled = true;
            this.comboBoxPlaces.Location = new System.Drawing.Point(114, 521);
            this.comboBoxPlaces.Name = "comboBoxPlaces";
            this.comboBoxPlaces.Size = new System.Drawing.Size(185, 31);
            this.comboBoxPlaces.TabIndex = 21;
            this.comboBoxPlaces.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlaces_SelectedIndexChanged);
            // 
            // textBox_PlaceId
            // 
            this.textBox_PlaceId.Location = new System.Drawing.Point(115, 457);
            this.textBox_PlaceId.Name = "textBox_PlaceId";
            this.textBox_PlaceId.Size = new System.Drawing.Size(184, 31);
            this.textBox_PlaceId.TabIndex = 20;
            // 
            // label_PlaceName
            // 
            this.label_PlaceName.AutoSize = true;
            this.label_PlaceName.Location = new System.Drawing.Point(29, 457);
            this.label_PlaceName.Name = "label_PlaceName";
            this.label_PlaceName.Size = new System.Drawing.Size(50, 23);
            this.label_PlaceName.TabIndex = 19;
            this.label_PlaceName.Text = "别名";
            // 
            // btnGetFocusParams
            // 
            this.btnGetFocusParams.Location = new System.Drawing.Point(25, 569);
            this.btnGetFocusParams.Name = "btnGetFocusParams";
            this.btnGetFocusParams.Size = new System.Drawing.Size(128, 47);
            this.btnGetFocusParams.TabIndex = 18;
            this.btnGetFocusParams.Text = "获取焦点";
            this.btnGetFocusParams.UseVisualStyleBackColor = true;
            this.btnGetFocusParams.Click += new System.EventHandler(this.btnGetFocusParams_Click);
            // 
            // btnSaveFocusParams
            // 
            this.btnSaveFocusParams.Location = new System.Drawing.Point(171, 569);
            this.btnSaveFocusParams.Name = "btnSaveFocusParams";
            this.btnSaveFocusParams.Size = new System.Drawing.Size(128, 47);
            this.btnSaveFocusParams.TabIndex = 17;
            this.btnSaveFocusParams.Text = "保存数据";
            this.btnSaveFocusParams.UseVisualStyleBackColor = true;
            this.btnSaveFocusParams.Click += new System.EventHandler(this.btnSaveFocusParams_Click);
            // 
            // btnConfirmFocusParams
            // 
            this.btnConfirmFocusParams.Location = new System.Drawing.Point(171, 632);
            this.btnConfirmFocusParams.Name = "btnConfirmFocusParams";
            this.btnConfirmFocusParams.Size = new System.Drawing.Size(128, 47);
            this.btnConfirmFocusParams.TabIndex = 1;
            this.btnConfirmFocusParams.Text = "应用";
            this.btnConfirmFocusParams.UseVisualStyleBackColor = true;
            this.btnConfirmFocusParams.Click += new System.EventHandler(this.btnConfirmFocusParams_Click);
            // 
            // label_LonExp
            // 
            this.label_LonExp.AutoSize = true;
            this.label_LonExp.Location = new System.Drawing.Point(32, 150);
            this.label_LonExp.Name = "label_LonExp";
            this.label_LonExp.Size = new System.Drawing.Size(219, 23);
            this.label_LonExp.TabIndex = 15;
            this.label_LonExp.Text = "[-180,180](东经+,西经-)";
            // 
            // label_LatExp
            // 
            this.label_LatExp.AutoSize = true;
            this.label_LatExp.Location = new System.Drawing.Point(32, 69);
            this.label_LatExp.Name = "label_LatExp";
            this.label_LatExp.Size = new System.Drawing.Size(252, 23);
            this.label_LatExp.TabIndex = 14;
            this.label_LatExp.Text = "[-90,90](赤道0,北纬+,南纬-)";
            // 
            // label_Speed
            // 
            this.label_Speed.AutoSize = true;
            this.label_Speed.Location = new System.Drawing.Point(21, 405);
            this.label_Speed.Name = "label_Speed";
            this.label_Speed.Size = new System.Drawing.Size(90, 23);
            this.label_Speed.TabIndex = 13;
            this.label_Speed.Text = "移动速度";
            // 
            // label_Azimuth
            // 
            this.label_Azimuth.AutoSize = true;
            this.label_Azimuth.Location = new System.Drawing.Point(21, 352);
            this.label_Azimuth.Name = "label_Azimuth";
            this.label_Azimuth.Size = new System.Drawing.Size(94, 23);
            this.label_Azimuth.TabIndex = 12;
            this.label_Azimuth.Text = "方位角(°)";
            // 
            // label_Angle
            // 
            this.label_Angle.AutoSize = true;
            this.label_Angle.Location = new System.Drawing.Point(21, 298);
            this.label_Angle.Name = "label_Angle";
            this.label_Angle.Size = new System.Drawing.Size(74, 23);
            this.label_Angle.TabIndex = 11;
            this.label_Angle.Text = "倾角(°)";
            // 
            // label_Range
            // 
            this.label_Range.AutoSize = true;
            this.label_Range.Location = new System.Drawing.Point(21, 245);
            this.label_Range.Name = "label_Range";
            this.label_Range.Size = new System.Drawing.Size(86, 23);
            this.label_Range.TabIndex = 10;
            this.label_Range.Text = "视高(米)";
            // 
            // label_Altitude
            // 
            this.label_Altitude.AutoSize = true;
            this.label_Altitude.Location = new System.Drawing.Point(21, 193);
            this.label_Altitude.Name = "label_Altitude";
            this.label_Altitude.Size = new System.Drawing.Size(86, 23);
            this.label_Altitude.TabIndex = 9;
            this.label_Altitude.Text = "标高(米)";
            // 
            // label_Longitude
            // 
            this.label_Longitude.AutoSize = true;
            this.label_Longitude.Location = new System.Drawing.Point(21, 115);
            this.label_Longitude.Name = "label_Longitude";
            this.label_Longitude.Size = new System.Drawing.Size(74, 23);
            this.label_Longitude.TabIndex = 8;
            this.label_Longitude.Text = "经度(°)";
            // 
            // label_Latitude
            // 
            this.label_Latitude.AutoSize = true;
            this.label_Latitude.Location = new System.Drawing.Point(21, 38);
            this.label_Latitude.Name = "label_Latitude";
            this.label_Latitude.Size = new System.Drawing.Size(74, 23);
            this.label_Latitude.TabIndex = 7;
            this.label_Latitude.Text = "纬度(°)";
            // 
            // textBox_Speed
            // 
            this.textBox_Speed.Location = new System.Drawing.Point(115, 402);
            this.textBox_Speed.Name = "textBox_Speed";
            this.textBox_Speed.Size = new System.Drawing.Size(184, 31);
            this.textBox_Speed.TabIndex = 6;
            // 
            // textBox_Azimuth
            // 
            this.textBox_Azimuth.Location = new System.Drawing.Point(115, 349);
            this.textBox_Azimuth.Name = "textBox_Azimuth";
            this.textBox_Azimuth.Size = new System.Drawing.Size(184, 31);
            this.textBox_Azimuth.TabIndex = 5;
            // 
            // textBox_Tilt
            // 
            this.textBox_Tilt.Location = new System.Drawing.Point(115, 295);
            this.textBox_Tilt.Name = "textBox_Tilt";
            this.textBox_Tilt.Size = new System.Drawing.Size(184, 31);
            this.textBox_Tilt.TabIndex = 4;
            // 
            // textBox_Range
            // 
            this.textBox_Range.Location = new System.Drawing.Point(115, 242);
            this.textBox_Range.Name = "textBox_Range";
            this.textBox_Range.Size = new System.Drawing.Size(184, 31);
            this.textBox_Range.TabIndex = 3;
            // 
            // textBox_Altitude
            // 
            this.textBox_Altitude.Location = new System.Drawing.Point(115, 190);
            this.textBox_Altitude.Name = "textBox_Altitude";
            this.textBox_Altitude.Size = new System.Drawing.Size(184, 31);
            this.textBox_Altitude.TabIndex = 2;
            // 
            // textBox_Longitude
            // 
            this.textBox_Longitude.Location = new System.Drawing.Point(115, 110);
            this.textBox_Longitude.Name = "textBox_Longitude";
            this.textBox_Longitude.Size = new System.Drawing.Size(184, 31);
            this.textBox_Longitude.TabIndex = 1;
            // 
            // textBox_Latitude
            // 
            this.textBox_Latitude.Location = new System.Drawing.Point(115, 35);
            this.textBox_Latitude.Name = "textBox_Latitude";
            this.textBox_Latitude.Size = new System.Drawing.Size(184, 31);
            this.textBox_Latitude.TabIndex = 0;
            // 
            // toolBar
            // 
            this.toolBar.Font = new System.Drawing.Font("Cambria", 12F);
            this.toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAppx,
            this.toolStripSeparator1,
            this.btnSnap,
            this.toolStripSeparator2,
            this.btnDashboard,
            this.btnAboutAuthor});
            this.toolBar.Location = new System.Drawing.Point(0, 0);
            this.toolBar.Name = "toolBar";
            this.toolBar.Size = new System.Drawing.Size(1182, 30);
            this.toolBar.TabIndex = 0;
            this.toolBar.Text = "toolStrip1";
            // 
            // btnAppx
            // 
            this.btnAppx.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnStartGE,
            this.btnStopGE,
            this.btnExitApp});
            this.btnAppx.Image = ((System.Drawing.Image)(resources.GetObject("btnAppx.Image")));
            this.btnAppx.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAppx.Name = "btnAppx";
            this.btnAppx.Size = new System.Drawing.Size(79, 27);
            this.btnAppx.Text = "开始";
            this.btnAppx.ToolTipText = "点此开始";
            // 
            // btnStartGE
            // 
            this.btnStartGE.Name = "btnStartGE";
            this.btnStartGE.Size = new System.Drawing.Size(164, 28);
            this.btnStartGE.Text = "启动GE";
            this.btnStartGE.ToolTipText = "启动Google Earth实例";
            this.btnStartGE.Click += new System.EventHandler(this.btnStartGE_Click);
            // 
            // btnStopGE
            // 
            this.btnStopGE.Name = "btnStopGE";
            this.btnStopGE.Size = new System.Drawing.Size(164, 28);
            this.btnStopGE.Text = "关闭GE";
            this.btnStopGE.ToolTipText = "关闭Google Earth实例";
            this.btnStopGE.Click += new System.EventHandler(this.btnStopGE_Click);
            // 
            // btnExitApp
            // 
            this.btnExitApp.Name = "btnExitApp";
            this.btnExitApp.Size = new System.Drawing.Size(164, 28);
            this.btnExitApp.Text = "退出程序";
            this.btnExitApp.ToolTipText = "关闭窗口并退出程序";
            this.btnExitApp.Click += new System.EventHandler(this.btnExitApp_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 30);
            // 
            // btnSnap
            // 
            this.btnSnap.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGESnap,
            this.btnAPISnap});
            this.btnSnap.Image = ((System.Drawing.Image)(resources.GetObject("btnSnap.Image")));
            this.btnSnap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSnap.Name = "btnSnap";
            this.btnSnap.Size = new System.Drawing.Size(79, 27);
            this.btnSnap.Text = "截图";
            this.btnSnap.ToolTipText = "截取当前画面";
            // 
            // btnGESnap
            // 
            this.btnGESnap.Name = "btnGESnap";
            this.btnGESnap.Size = new System.Drawing.Size(153, 28);
            this.btnGESnap.Text = "GE截图";
            this.btnGESnap.ToolTipText = "Google Earth 内嵌截图(灰度图,但更稳定)";
            this.btnGESnap.Click += new System.EventHandler(this.btnGESnap_Click);
            this.btnGESnap.MouseEnter += new System.EventHandler(this.btnGESnap_MouseEnter);
            // 
            // btnAPISnap
            // 
            this.btnAPISnap.Name = "btnAPISnap";
            this.btnAPISnap.Size = new System.Drawing.Size(153, 28);
            this.btnAPISnap.Text = "API截图";
            this.btnAPISnap.ToolTipText = "能截取彩色图像";
            this.btnAPISnap.Click += new System.EventHandler(this.btnAPISnap_Click);
            this.btnAPISnap.MouseEnter += new System.EventHandler(this.btnAPISnap_MouseEnter);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 30);
            // 
            // btnDashboard
            // 
            this.btnDashboard.Image = global::GESnapHelper.Properties.Resources.GEDashbd;
            this.btnDashboard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(70, 27);
            this.btnDashboard.Text = "面板";
            this.btnDashboard.ToolTipText = "参数设置";
            this.btnDashboard.Click += new System.EventHandler(this.btnDashBoard_Click);
            // 
            // btnAboutAuthor
            // 
            this.btnAboutAuthor.Image = global::GESnapHelper.Properties.Resources.GEStart;
            this.btnAboutAuthor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAboutAuthor.Name = "btnAboutAuthor";
            this.btnAboutAuthor.Size = new System.Drawing.Size(70, 27);
            this.btnAboutAuthor.Text = "关于";
            this.btnAboutAuthor.Click += new System.EventHandler(this.btnAboutAuthor_Click);
            // 
            // GESnapHelper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 855);
            this.Controls.Add(this.mainPanel);
            this.Font = new System.Drawing.Font("Cambria", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GESnapHelper";
            this.Text = "Google Earth 截图助手";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.tabDocker.ResumeLayout(false);
            this.tabXPViewer.ResumeLayout(false);
            this.groupBoxCaptureParams.ResumeLayout(false);
            this.groupBoxCaptureParams.PerformLayout();
            this.groupBoxRectPoint1.ResumeLayout(false);
            this.groupBoxRectPoint1.PerformLayout();
            this.groupBoxRectPoint2.ResumeLayout(false);
            this.groupBoxRectPoint2.PerformLayout();
            this.groupBoxFocusParams.ResumeLayout(false);
            this.groupBoxFocusParams.PerformLayout();
            this.toolBar.ResumeLayout(false);
            this.toolBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.ToolStrip toolBar;
        private System.Windows.Forms.ToolStripDropDownButton btnAppx;
        private System.Windows.Forms.ToolStripMenuItem btnStartGE;
        private System.Windows.Forms.ToolStripMenuItem btnStopGE;
        private System.Windows.Forms.ToolStripMenuItem btnExitApp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton btnSnap;
        private System.Windows.Forms.ToolStripMenuItem btnGESnap;
        private System.Windows.Forms.ToolStripMenuItem btnAPISnap;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.TabControl tabDocker;
        private System.Windows.Forms.TabPage tabGEViewer;
        private System.Windows.Forms.TabPage tabXPViewer;
        private System.Windows.Forms.ToolTip msgToolTip;
        private System.Windows.Forms.GroupBox groupBoxFocusParams;
        private System.Windows.Forms.Label label_LonExp;
        private System.Windows.Forms.Label label_LatExp;
        private System.Windows.Forms.Label label_Speed;
        private System.Windows.Forms.Label label_Azimuth;
        private System.Windows.Forms.Label label_Angle;
        private System.Windows.Forms.Label label_Range;
        private System.Windows.Forms.Label label_Altitude;
        private System.Windows.Forms.Label label_Longitude;
        private System.Windows.Forms.Label label_Latitude;
        private System.Windows.Forms.TextBox textBox_Speed;
        private System.Windows.Forms.TextBox textBox_Azimuth;
        private System.Windows.Forms.TextBox textBox_Tilt;
        private System.Windows.Forms.TextBox textBox_Range;
        private System.Windows.Forms.TextBox textBox_Altitude;
        private System.Windows.Forms.TextBox textBox_Longitude;
        private System.Windows.Forms.TextBox textBox_Latitude;
        private System.Windows.Forms.Button btnConfirmFocusParams;
        private System.Windows.Forms.ToolStripButton btnDashboard;
        private System.Windows.Forms.Button btnSaveFocusParams;
        private System.Windows.Forms.Button btnGetFocusParams;
        private System.Windows.Forms.TextBox textBox_PlaceId;
        private System.Windows.Forms.Label label_PlaceName;
        private System.Windows.Forms.ComboBox comboBoxPlaces;
        private System.Windows.Forms.Button btnClearFocusParams;
        private System.Windows.Forms.Label labelTip;
        private System.Windows.Forms.Label label_xDoc;
        private System.Windows.Forms.GroupBox groupBoxCaptureParams;
        private System.Windows.Forms.Label label_RP2Lon;
        private System.Windows.Forms.Label label_RP2Lat;
        private System.Windows.Forms.TextBox textBox_RP2Lon;
        private System.Windows.Forms.TextBox textBox_RP2Lat;
        private System.Windows.Forms.Label label_RP1Lon;
        private System.Windows.Forms.Label label_RP1Lat;
        private System.Windows.Forms.TextBox textBox_RP1Lon;
        private System.Windows.Forms.TextBox textBox_RP1Lat;
        private System.Windows.Forms.Button btnDrag2;
        private System.Windows.Forms.Label label_RctRange;
        private System.Windows.Forms.TextBox textBox_RctRange;
        private System.Windows.Forms.Button btnDrag1;
        private System.Windows.Forms.GroupBox groupBoxRectPoint1;
        private System.Windows.Forms.GroupBox groupBoxRectPoint2;
        private System.Windows.Forms.Button btnStartCapture;
        private System.Windows.Forms.RichTextBox textBox_CaptureInfo;
        private System.Windows.Forms.Button btnPrepareCapture;
        private System.Windows.Forms.ToolStripButton btnAboutAuthor;
    }
}

