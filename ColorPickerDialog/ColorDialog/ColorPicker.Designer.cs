
namespace ColorPicker
{
    partial class ColorPickers
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorPickers));
            this.ColorBox = new System.Windows.Forms.PictureBox();
            this.Apply = new System.Windows.Forms.Button();
            this.modeTab = new System.Windows.Forms.TabControl();
            this.Swatche = new System.Windows.Forms.TabPage();
            this.HSVRGBmode = new System.Windows.Forms.Button();
            this.BoardMode = new System.Windows.Forms.PictureBox();
            this.VB = new System.Windows.Forms.RadioButton();
            this.HR = new System.Windows.Forms.RadioButton();
            this.SG = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PointB = new System.Windows.Forms.PictureBox();
            this.PointG = new System.Windows.Forms.PictureBox();
            this.PointR = new System.Windows.Forms.PictureBox();
            this.PointV = new System.Windows.Forms.PictureBox();
            this.PointS = new System.Windows.Forms.PictureBox();
            this.PointH = new System.Windows.Forms.PictureBox();
            this.UpDownB = new System.Windows.Forms.NumericUpDown();
            this.UpDownG = new System.Windows.Forms.NumericUpDown();
            this.UpDownR = new System.Windows.Forms.NumericUpDown();
            this.UpDownV = new System.Windows.Forms.NumericUpDown();
            this.UpDownS = new System.Windows.Forms.NumericUpDown();
            this.UpDownH = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BlueLine = new System.Windows.Forms.PictureBox();
            this.GreenLine = new System.Windows.Forms.PictureBox();
            this.RedLine = new System.Windows.Forms.PictureBox();
            this.ValLine = new System.Windows.Forms.PictureBox();
            this.SatLine = new System.Windows.Forms.PictureBox();
            this.HueLine = new System.Windows.Forms.PictureBox();
            this.Reset = new System.Windows.Forms.Button();
            this.Cancle = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.HTML = new System.Windows.Forms.TextBox();
            this.Debug = new System.Windows.Forms.Label();
            this.Older = new System.Windows.Forms.PictureBox();
            this.Newer = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ColorBox)).BeginInit();
            this.modeTab.SuspendLayout();
            this.Swatche.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BoardMode)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PointB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PointG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PointR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PointV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PointS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PointH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SatLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HueLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Older)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Newer)).BeginInit();
            this.SuspendLayout();
            // 
            // ColorBox
            // 
            this.ColorBox.Location = new System.Drawing.Point(3, 4);
            this.ColorBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ColorBox.Name = "ColorBox";
            this.ColorBox.Size = new System.Drawing.Size(256, 256);
            this.ColorBox.TabIndex = 0;
            this.ColorBox.TabStop = false;
            this.ColorBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ColorPickerSquare_MouseDown);
            this.ColorBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ColorBox_MouseMove);
            this.ColorBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PicMouseUp);
            // 
            // Apply
            // 
            this.Apply.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Apply.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Apply.Location = new System.Drawing.Point(634, 368);
            this.Apply.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Apply.Name = "Apply";
            this.Apply.Size = new System.Drawing.Size(93, 28);
            this.Apply.TabIndex = 20;
            this.Apply.Text = "确定";
            this.Apply.UseVisualStyleBackColor = true;
            this.Apply.Click += new System.EventHandler(this.Apply_Click);
            // 
            // modeTab
            // 
            this.modeTab.Controls.Add(this.Swatche);
            this.modeTab.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.modeTab.Location = new System.Drawing.Point(12, 12);
            this.modeTab.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.modeTab.Name = "modeTab";
            this.modeTab.SelectedIndex = 0;
            this.modeTab.Size = new System.Drawing.Size(302, 327);
            this.modeTab.TabIndex = 1;
            // 
            // Swatche
            // 
            this.Swatche.BackColor = System.Drawing.SystemColors.Control;
            this.Swatche.Controls.Add(this.HSVRGBmode);
            this.Swatche.Controls.Add(this.BoardMode);
            this.Swatche.Controls.Add(this.ColorBox);
            this.Swatche.Controls.Add(this.VB);
            this.Swatche.Controls.Add(this.HR);
            this.Swatche.Controls.Add(this.SG);
            this.Swatche.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Swatche.Location = new System.Drawing.Point(4, 26);
            this.Swatche.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Swatche.Name = "Swatche";
            this.Swatche.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Swatche.Size = new System.Drawing.Size(294, 297);
            this.Swatche.TabIndex = 0;
            this.Swatche.Text = "色板方式";
            // 
            // HSVRGBmode
            // 
            this.HSVRGBmode.Location = new System.Drawing.Point(6, 267);
            this.HSVRGBmode.Name = "HSVRGBmode";
            this.HSVRGBmode.Size = new System.Drawing.Size(77, 23);
            this.HSVRGBmode.TabIndex = 10;
            this.HSVRGBmode.Text = "RGB模式";
            this.HSVRGBmode.UseVisualStyleBackColor = true;
            this.HSVRGBmode.Click += new System.EventHandler(this.HSVRGBmode_Click);
            // 
            // BoardMode
            // 
            this.BoardMode.Location = new System.Drawing.Point(265, 4);
            this.BoardMode.Name = "BoardMode";
            this.BoardMode.Size = new System.Drawing.Size(22, 256);
            this.BoardMode.TabIndex = 6;
            this.BoardMode.TabStop = false;
            this.BoardMode.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Line_MouseDown);
            this.BoardMode.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Line_MouseMove);
            this.BoardMode.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PicMouseUp);
            // 
            // VB
            // 
            this.VB.AutoSize = true;
            this.VB.Location = new System.Drawing.Point(184, 269);
            this.VB.Name = "VB";
            this.VB.Size = new System.Drawing.Size(34, 21);
            this.VB.TabIndex = 13;
            this.VB.Text = "V";
            this.VB.UseVisualStyleBackColor = true;
            this.VB.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // HR
            // 
            this.HR.AutoSize = true;
            this.HR.Checked = true;
            this.HR.Location = new System.Drawing.Point(104, 269);
            this.HR.Name = "HR";
            this.HR.Size = new System.Drawing.Size(35, 21);
            this.HR.TabIndex = 11;
            this.HR.TabStop = true;
            this.HR.Text = "H";
            this.HR.UseVisualStyleBackColor = true;
            this.HR.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // SG
            // 
            this.SG.AutoSize = true;
            this.SG.Location = new System.Drawing.Point(145, 269);
            this.SG.Name = "SG";
            this.SG.Size = new System.Drawing.Size(33, 21);
            this.SG.TabIndex = 12;
            this.SG.Text = "S";
            this.SG.UseVisualStyleBackColor = true;
            this.SG.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 353);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "新的：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 376);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "旧的：";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.PointB);
            this.panel1.Controls.Add(this.PointG);
            this.panel1.Controls.Add(this.PointR);
            this.panel1.Controls.Add(this.PointV);
            this.panel1.Controls.Add(this.PointS);
            this.panel1.Controls.Add(this.PointH);
            this.panel1.Controls.Add(this.UpDownB);
            this.panel1.Controls.Add(this.UpDownG);
            this.panel1.Controls.Add(this.UpDownR);
            this.panel1.Controls.Add(this.UpDownV);
            this.panel1.Controls.Add(this.UpDownS);
            this.panel1.Controls.Add(this.UpDownH);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.BlueLine);
            this.panel1.Controls.Add(this.GreenLine);
            this.panel1.Controls.Add(this.RedLine);
            this.panel1.Controls.Add(this.ValLine);
            this.panel1.Controls.Add(this.SatLine);
            this.panel1.Controls.Add(this.HueLine);
            this.panel1.Location = new System.Drawing.Point(319, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(517, 260);
            this.panel1.TabIndex = 6;
            // 
            // PointB
            // 
            this.PointB.Location = new System.Drawing.Point(144, 242);
            this.PointB.Name = "PointB";
            this.PointB.Size = new System.Drawing.Size(260, 10);
            this.PointB.TabIndex = 29;
            this.PointB.TabStop = false;
            // 
            // PointG
            // 
            this.PointG.Location = new System.Drawing.Point(144, 203);
            this.PointG.Name = "PointG";
            this.PointG.Size = new System.Drawing.Size(260, 10);
            this.PointG.TabIndex = 28;
            this.PointG.TabStop = false;
            // 
            // PointR
            // 
            this.PointR.Location = new System.Drawing.Point(144, 160);
            this.PointR.Name = "PointR";
            this.PointR.Size = new System.Drawing.Size(260, 10);
            this.PointR.TabIndex = 27;
            this.PointR.TabStop = false;
            // 
            // PointV
            // 
            this.PointV.Location = new System.Drawing.Point(144, 121);
            this.PointV.Name = "PointV";
            this.PointV.Size = new System.Drawing.Size(260, 10);
            this.PointV.TabIndex = 26;
            this.PointV.TabStop = false;
            // 
            // PointS
            // 
            this.PointS.Location = new System.Drawing.Point(144, 78);
            this.PointS.Name = "PointS";
            this.PointS.Size = new System.Drawing.Size(260, 10);
            this.PointS.TabIndex = 25;
            this.PointS.TabStop = false;
            // 
            // PointH
            // 
            this.PointH.Location = new System.Drawing.Point(144, 37);
            this.PointH.Name = "PointH";
            this.PointH.Size = new System.Drawing.Size(365, 10);
            this.PointH.TabIndex = 24;
            this.PointH.TabStop = false;
            // 
            // UpDownB
            // 
            this.UpDownB.Location = new System.Drawing.Point(59, 219);
            this.UpDownB.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.UpDownB.Name = "UpDownB";
            this.UpDownB.Size = new System.Drawing.Size(72, 23);
            this.UpDownB.TabIndex = 6;
            this.UpDownB.ValueChanged += new System.EventHandler(this.RGB_ValueChanged);
            // 
            // UpDownG
            // 
            this.UpDownG.Location = new System.Drawing.Point(59, 178);
            this.UpDownG.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.UpDownG.Name = "UpDownG";
            this.UpDownG.Size = new System.Drawing.Size(72, 23);
            this.UpDownG.TabIndex = 5;
            this.UpDownG.ValueChanged += new System.EventHandler(this.RGB_ValueChanged);
            // 
            // UpDownR
            // 
            this.UpDownR.Location = new System.Drawing.Point(59, 137);
            this.UpDownR.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.UpDownR.Name = "UpDownR";
            this.UpDownR.Size = new System.Drawing.Size(72, 23);
            this.UpDownR.TabIndex = 4;
            this.UpDownR.ValueChanged += new System.EventHandler(this.RGB_ValueChanged);
            // 
            // UpDownV
            // 
            this.UpDownV.Location = new System.Drawing.Point(59, 98);
            this.UpDownV.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.UpDownV.Name = "UpDownV";
            this.UpDownV.Size = new System.Drawing.Size(72, 23);
            this.UpDownV.TabIndex = 3;
            this.UpDownV.ValueChanged += new System.EventHandler(this.HSV_ValueChanged);
            // 
            // UpDownS
            // 
            this.UpDownS.Location = new System.Drawing.Point(59, 55);
            this.UpDownS.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.UpDownS.Name = "UpDownS";
            this.UpDownS.Size = new System.Drawing.Size(72, 23);
            this.UpDownS.TabIndex = 2;
            this.UpDownS.ValueChanged += new System.EventHandler(this.HSV_ValueChanged);
            // 
            // UpDownH
            // 
            this.UpDownH.Location = new System.Drawing.Point(59, 14);
            this.UpDownH.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.UpDownH.Name = "UpDownH";
            this.UpDownH.Size = new System.Drawing.Size(72, 23);
            this.UpDownH.TabIndex = 1;
            this.UpDownH.ValueChanged += new System.EventHandler(this.HSV_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Green;
            this.label8.Location = new System.Drawing.Point(5, 221);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 17);
            this.label8.TabIndex = 17;
            this.label8.Text = "绿色(B)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(5, 180);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "蓝色(G)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(5, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 17);
            this.label6.TabIndex = 15;
            this.label6.Text = "红色(R)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "明度(V)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "饱和(S)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "色调(H)";
            // 
            // BlueLine
            // 
            this.BlueLine.Location = new System.Drawing.Point(146, 219);
            this.BlueLine.Name = "BlueLine";
            this.BlueLine.Size = new System.Drawing.Size(256, 23);
            this.BlueLine.TabIndex = 11;
            this.BlueLine.TabStop = false;
            this.BlueLine.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Line_MouseDown);
            this.BlueLine.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Line_MouseMove);
            this.BlueLine.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PicMouseUp);
            // 
            // GreenLine
            // 
            this.GreenLine.Location = new System.Drawing.Point(146, 180);
            this.GreenLine.Name = "GreenLine";
            this.GreenLine.Size = new System.Drawing.Size(256, 23);
            this.GreenLine.TabIndex = 10;
            this.GreenLine.TabStop = false;
            this.GreenLine.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Line_MouseDown);
            this.GreenLine.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Line_MouseMove);
            this.GreenLine.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PicMouseUp);
            // 
            // RedLine
            // 
            this.RedLine.Location = new System.Drawing.Point(146, 137);
            this.RedLine.Name = "RedLine";
            this.RedLine.Size = new System.Drawing.Size(256, 23);
            this.RedLine.TabIndex = 9;
            this.RedLine.TabStop = false;
            this.RedLine.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Line_MouseDown);
            this.RedLine.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Line_MouseMove);
            this.RedLine.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PicMouseUp);
            // 
            // ValLine
            // 
            this.ValLine.Location = new System.Drawing.Point(146, 98);
            this.ValLine.Name = "ValLine";
            this.ValLine.Size = new System.Drawing.Size(256, 23);
            this.ValLine.TabIndex = 8;
            this.ValLine.TabStop = false;
            this.ValLine.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Line_MouseDown);
            this.ValLine.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Line_MouseMove);
            this.ValLine.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PicMouseUp);
            // 
            // SatLine
            // 
            this.SatLine.Location = new System.Drawing.Point(146, 55);
            this.SatLine.Name = "SatLine";
            this.SatLine.Size = new System.Drawing.Size(256, 23);
            this.SatLine.TabIndex = 7;
            this.SatLine.TabStop = false;
            this.SatLine.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Line_MouseDown);
            this.SatLine.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Line_MouseMove);
            this.SatLine.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PicMouseUp);
            // 
            // HueLine
            // 
            this.HueLine.Location = new System.Drawing.Point(146, 14);
            this.HueLine.Name = "HueLine";
            this.HueLine.Size = new System.Drawing.Size(361, 23);
            this.HueLine.TabIndex = 6;
            this.HueLine.TabStop = false;
            this.HueLine.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Line_MouseDown);
            this.HueLine.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Line_MouseMove);
            this.HueLine.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PicMouseUp);
            // 
            // Reset
            // 
            this.Reset.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Reset.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Reset.Location = new System.Drawing.Point(561, 307);
            this.Reset.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(41, 23);
            this.Reset.TabIndex = 22;
            this.Reset.Text = "重置";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // Cancle
            // 
            this.Cancle.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Cancle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Cancle.Location = new System.Drawing.Point(733, 368);
            this.Cancle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Cancle.Name = "Cancle";
            this.Cancle.Size = new System.Drawing.Size(93, 28);
            this.Cancle.TabIndex = 21;
            this.Cancle.Text = "取消";
            this.Cancle.UseVisualStyleBackColor = true;
            this.Cancle.Click += new System.EventHandler(this.Cancle_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(318, 307);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 17);
            this.label9.TabIndex = 9;
            this.label9.Text = "HTML代码";
            // 
            // HTML
            // 
            this.HTML.Location = new System.Drawing.Point(390, 307);
            this.HTML.Name = "HTML";
            this.HTML.Size = new System.Drawing.Size(165, 23);
            this.HTML.TabIndex = 0;
            this.HTML.TextChanged += new System.EventHandler(this.MainHTMLChanged);
            // 
            // Debug
            // 
            this.Debug.AutoSize = true;
            this.Debug.Location = new System.Drawing.Point(608, 310);
            this.Debug.Name = "Debug";
            this.Debug.Size = new System.Drawing.Size(47, 17);
            this.Debug.TabIndex = 11;
            this.Debug.Text = "Debug";
            // 
            // Older
            // 
            this.Older.Location = new System.Drawing.Point(79, 371);
            this.Older.Name = "Older";
            this.Older.Size = new System.Drawing.Size(196, 25);
            this.Older.TabIndex = 12;
            this.Older.TabStop = false;
            // 
            // Newer
            // 
            this.Newer.Location = new System.Drawing.Point(79, 346);
            this.Newer.Name = "Newer";
            this.Newer.Size = new System.Drawing.Size(196, 25);
            this.Newer.TabIndex = 13;
            this.Newer.TabStop = false;
            // 
            // ColorPickers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 404);
            this.Controls.Add(this.Newer);
            this.Controls.Add(this.Older);
            this.Controls.Add(this.Debug);
            this.Controls.Add(this.HTML);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Cancle);
            this.Controls.Add(this.Reset);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.modeTab);
            this.Controls.Add(this.Apply);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ColorPickers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "颜色对话框";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ColorPicker_FormClosing);
            this.Load += new System.EventHandler(this.ColorPicker_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ColorBox)).EndInit();
            this.modeTab.ResumeLayout(false);
            this.Swatche.ResumeLayout(false);
            this.Swatche.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BoardMode)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PointB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PointG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PointR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PointV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PointS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PointH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SatLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HueLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Older)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Newer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ColorBox;
        private System.Windows.Forms.Button Apply;
        private System.Windows.Forms.TabControl modeTab;
        private System.Windows.Forms.TabPage Swatche;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton VB;
        private System.Windows.Forms.RadioButton SG;
        private System.Windows.Forms.RadioButton HR;
        private System.Windows.Forms.PictureBox BoardMode;
        private System.Windows.Forms.Button HSVRGBmode;
        private System.Windows.Forms.PictureBox RedLine;
        private System.Windows.Forms.PictureBox ValLine;
        private System.Windows.Forms.PictureBox SatLine;
        private System.Windows.Forms.PictureBox HueLine;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox BlueLine;
        private System.Windows.Forms.PictureBox GreenLine;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.Button Cancle;
        private System.Windows.Forms.NumericUpDown UpDownB;
        private System.Windows.Forms.NumericUpDown UpDownG;
        private System.Windows.Forms.NumericUpDown UpDownR;
        private System.Windows.Forms.NumericUpDown UpDownV;
        private System.Windows.Forms.NumericUpDown UpDownS;
        private System.Windows.Forms.NumericUpDown UpDownH;
        private System.Windows.Forms.PictureBox PointH;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox HTML;
        private System.Windows.Forms.Label Debug;
        private System.Windows.Forms.PictureBox PointB;
        private System.Windows.Forms.PictureBox PointG;
        private System.Windows.Forms.PictureBox PointR;
        private System.Windows.Forms.PictureBox PointV;
        private System.Windows.Forms.PictureBox PointS;
        private System.Windows.Forms.PictureBox Older;
        private System.Windows.Forms.PictureBox Newer;
    }
}