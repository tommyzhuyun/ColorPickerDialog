/** Powered By 鸡蛋甲天下(潘妮)
 *  联系方式（QQ）：1943495203
 *  找色专用面板
 *  @FastBitmap.cs
 *  @HSV.cs
 *  @SquareBitmap.cs
 *  Version 1.0
 *  2021.8.22
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using FastBitmapLib;


namespace ColorPicker
{
    public partial class ColorPickers : Form
    {
        public Color GivenColor { set; get; }
        public Color SetColor { set; get; }
        public HSV SetHSV { set; get; }
        public string RGBstring { private set; get; }

        private SquareBitmap sbmp;
        private HsvRgb LastChannel, GivenChannel;
        private bool isSettingValue = false;

        #region 窗体设计
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="Color">选定的颜色</param>
        public ColorPickers(Color Color)
        {
            InitializeComponent();
            this.GivenColor = Color;
            this.GivenChannel = this.LastChannel = HsvRgb.Hue;
        }

        private void ColorPicker_Load(object sender, EventArgs e)
        {
            this.SetColor = GivenColor;
            this.SetHSV = HSV.FromRgb(GivenColor);
            this.Newer.BackColor = GivenColor;
            this.Older.BackColor = GivenColor;
            this.RGBstring = HSV.HTMLString(SetColor);
            this.sbmp = new SquareBitmap(SetColor, LastChannel, ColorBox.Size, BoardMode.Size, HueLine.Size, RedLine.Size);
            this.isSettingValue = false;

            UpDate();
            sbmp.UpDate(SetColor, LastChannel);
            ImageUpdate();
        }
        #endregion


        #region 刷新数据
        /// <summary>
        /// 同步更新数据，启用抗干扰UpdateActive功能。
        /// </summary>
        private void UpDate()
        {
            isSettingValue = true;
            this.RGBstring = this.HTML.Text = HSV.HTMLString(SetColor);
            this.HTML.Update();
            this.Newer.BackColor = SetColor;
            this.Newer.Update();

            this.UpDownH.Value = SetHSV.H;
            this.UpDownH.Update();
            this.UpDownS.Value = SetHSV.S;
            this.UpDownS.Update();
            this.UpDownV.Value = SetHSV.V;
            this.UpDownV.Update();
            this.UpDownR.Value = SetColor.R;
            this.UpDownR.Update();
            this.UpDownG.Value = SetColor.G;
            this.UpDownG.Update();
            this.UpDownB.Value = SetColor.B;
            this.UpDownB.Update();

            isSettingValue = false;
        }
        /// <summary>
        /// 同步更新图像
        /// </summary>
        /// <param name="init">是否为初始化的判断</param>
        private void ImageUpdate()
        {
            isSettingValue = true;
            //Console.WriteLine("Update:" + LastChannel);

            this.ColorBox.Image?.Dispose();
            this.ColorBox.Image = (Image)sbmp.ColorBox();
            this.ColorBox.Refresh();

            this.BoardMode.Image?.Dispose();
            this.BoardMode.Image = (Image)sbmp.BoardLiner.Clone();
            this.BoardMode.Refresh();

            this.HueLine.Image?.Dispose();
            this.HueLine.Image = (Image)sbmp.HueLiner.Clone();
            this.HueLine.Refresh();

            this.SatLine.Image?.Dispose();
            this.SatLine.Image = (Image)sbmp.SatLiner.Clone();
            this.SatLine.Refresh();

            this.ValLine.Image?.Dispose();
            this.ValLine.Image = (Image)sbmp.ValLiner.Clone();
            this.ValLine.Refresh();

            this.RedLine.Image?.Dispose();
            this.RedLine.Image = (Image)sbmp.RedLiner.Clone();
            this.RedLine.Refresh();

            this.GreenLine.Image?.Dispose();
            this.GreenLine.Image = (Image)sbmp.GreenLiner.Clone();
            this.GreenLine.Refresh();

            this.BlueLine.Image?.Dispose();
            this.BlueLine.Image = (Image)sbmp.BlueLiner.Clone();
            this.BlueLine.Refresh();

            this.PointH.Image?.Dispose();
            this.PointH.Image = sbmp.ColorLinePointer(this.PointH.Size, HsvRgb.Hue);
            this.PointH.Refresh();

            this.PointS.Image?.Dispose();
            this.PointS.Image = sbmp.ColorLinePointer(this.PointS.Size, HsvRgb.Saturation);
            this.PointS.Refresh();

            this.PointV.Image?.Dispose();
            this.PointV.Image = sbmp.ColorLinePointer(this.PointV.Size, HsvRgb.Value);
            this.PointV.Refresh();

            this.PointR.Image?.Dispose();
            this.PointR.Image = sbmp.ColorLinePointer(this.PointR.Size, HsvRgb.Red);
            this.PointR.Refresh();

            this.PointG.Image?.Dispose();
            this.PointG.Image = sbmp.ColorLinePointer(this.PointG.Size, HsvRgb.Green);
            this.PointG.Refresh();

            this.PointB.Image?.Dispose();
            this.PointB.Image = sbmp.ColorLinePointer(this.PointB.Size, HsvRgb.Blue);
            this.PointB.Refresh();

            isSettingValue = false;
        }
        #endregion


        #region 调色板模式选择
        Boolean mode = true;
        private void HSVRGBmode_Click(object sender, EventArgs e)
        {
            isSettingValue = true;
            mode = !mode;
            if (mode)
            {
                HSVRGBmode.Text = "RGB模式";
                HR.Text = "H";
                SG.Text = "S";
                VB.Text = "V";
                LastChannel = HsvRgb.Hue;
            }
            else
            {
                HSVRGBmode.Text = "HSV模式";
                HR.Text = "R";
                SG.Text = "G";
                VB.Text = "B";
                LastChannel = HsvRgb.Red;
            }
            HR.Checked = true;
            SG.Checked = false;
            VB.Checked = false;

            HSVRGBmode.Update();
            HR.Update();
            SG.Update();
            VB.Update();
            isSettingValue = false;

            UpDate();
            sbmp.UpDate(SetColor, LastChannel);
            ImageUpdate();
        }
        private void CheckedChanged(object sender, EventArgs e)
        {
            if (isSettingValue)
                return;
            if (HR.Checked && mode) GivenChannel = HsvRgb.Hue;
            if (SG.Checked && mode) GivenChannel = HsvRgb.Saturation;
            if (VB.Checked && mode) GivenChannel = HsvRgb.Value;
            if (HR.Checked && !mode) GivenChannel = HsvRgb.Red;
            if (SG.Checked && !mode) GivenChannel = HsvRgb.Green;
            if (VB.Checked && !mode) GivenChannel = HsvRgb.Blue;

            if (LastChannel != GivenChannel)
            {
                LastChannel = GivenChannel;
                UpDate();
                sbmp.UpDate(SetColor, LastChannel);
                ImageUpdate();
            }
        }
        #endregion


        #region 主窗体按钮
        private void Reset_Click(object sender, EventArgs e)
        {
            isSettingValue = true;
            SetColor = GivenColor;
            HTML.Text = HSV.HTMLString(GivenColor);
            HTML.Update();

            UpDate();
            sbmp.UpDate(SetColor, LastChannel);
            ImageUpdate();
        }
        private void Apply_Click(object sender, EventArgs e)
        {
            RGBstring = HSV.HTMLString(SetColor);
            DialogResult = DialogResult.OK;
            Close();
        }
        private void Cancle_Click(object sender, EventArgs e)
        {
            this.SetColor = this.GivenColor;
            Close();
        }
        private void ColorPicker_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.ColorBox.Image?.Dispose();
            this.BoardMode.Image?.Dispose();
            this.HueLine.Image?.Dispose();
            this.SatLine.Image?.Dispose();
            this.ValLine.Image?.Dispose();
            this.RedLine.Image?.Dispose();
            this.GreenLine.Image?.Dispose();
            this.BlueLine.Image?.Dispose();
            this.sbmp?.Dispose();
        }
        #endregion


        #region 输入窗口
        private void MainHTMLChanged(object sender, EventArgs e)
        {
            if (isSettingValue)
                return;
            Color color = this.SetColor;
            HSV.ReadFromHTML(HTML.Text, ref color);
            if (color.Equals(SetColor))
                return;

            if (!HSV.Compair(color, SetColor))
            {
                this.SetColor = color;

                UpDate();
                sbmp.UpDate(SetColor, LastChannel);
                ImageUpdate();
            }
            HTML.Select(Right, 0);
        }
        private void HSV_ValueChanged(object sender, EventArgs e)
        {
            if (isSettingValue)
                return;
            this.SetHSV = new HSV((int)UpDownH.Value, (int)UpDownS.Value, (int)UpDownV.Value);
            this.SetColor = HSV.ToRgb(SetHSV);

            UpDate();
            sbmp.UpDate(SetHSV, LastChannel);
            ImageUpdate();
        }

        private void RGB_ValueChanged(object sender, EventArgs e)
        {
            if (isSettingValue)
                return;
            this.SetColor = Color.FromArgb((int)UpDownR.Value, (int)UpDownG.Value, (int)UpDownB.Value);
            this.SetHSV = HSV.FromRgb(SetColor);

            UpDate();
            sbmp.UpDate(SetColor, LastChannel);
            ImageUpdate();
        }
        #endregion


        #region 鼠标点击图片反馈
        private bool MouseDowned = false;
        private void ColorPickerSquare_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.MouseDowned = true;
                BoardMouseChannel(e.Location);
            }
        }

        private void ColorBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.MouseDowned && e.Button == MouseButtons.Left)
            {
                Point pt = e.Location;
                if (e.X < 0)
                    pt.X = 0;
                else if (e.X > ((PictureBox)sender).Width - 1)
                    pt.X = ((PictureBox)sender).Width - 1;
                if (e.Y < 0)
                    pt.Y = 0;
                else if (e.Y > ((PictureBox)sender).Height - 1)
                    pt.Y = ((PictureBox)sender).Height - 1;

                //Debug.Text = pt.ToString();
                BoardMouseChannel(pt);
            }
        }
        private void Line_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.MouseDowned = true;
                LineMouseChannel(sender, e.Location);
            }
        }

        private void Line_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.MouseDowned && e.Button == MouseButtons.Left)
            {
                Point pt = e.Location;
                if (e.X < 0)
                    pt.X = 0;
                else if (e.X > ((PictureBox)sender).Width - 1)
                    pt.X = ((PictureBox)sender).Width - 1;

                LineMouseChannel(sender, pt);
            }
        }

        private void PicMouseUp(object sender, MouseEventArgs e)
        {
            this.MouseDowned = false;
        }

        private void BoardMouseChannel(Point pt)
        {
            switch (LastChannel)
            {
                case HsvRgb.Hue:
                    SetHSV = new HSV(SetHSV.H, pt.X, pt.Y);
                    break;
                case HsvRgb.Saturation:
                    SetHSV = new HSV(pt.Y * 360 / 255, SetHSV.S, pt.X);
                    break;
                case HsvRgb.Value:
                    SetHSV = new HSV(pt.Y * 360 / 255, pt.X, SetHSV.V);
                    break;
                case HsvRgb.Red:
                    SetColor = Color.FromArgb(SetColor.R, pt.X, pt.Y);
                    break;
                case HsvRgb.Green:
                    SetColor = Color.FromArgb(pt.Y, SetColor.G, pt.X);
                    break;
                case HsvRgb.Blue:
                    SetColor = Color.FromArgb(pt.Y, pt.X, SetColor.B);
                    break;
            }
            switch (LastChannel)
            {
                case HsvRgb.Hue:
                case HsvRgb.Saturation:
                case HsvRgb.Value:
                    SetColor = HSV.ToRgb(SetHSV);
                    sbmp.UpDate(SetHSV, LastChannel);
                    break;
                case HsvRgb.Red:
                case HsvRgb.Green:
                case HsvRgb.Blue:
                    SetHSV = HSV.FromRgb(SetColor);
                    sbmp.UpDate(SetColor, LastChannel);
                    break;
            }
            UpDate();
            ImageUpdate();
        }
        private void LineMouseChannel(object sender, Point pt)
        {
            if (sender.Equals(HueLine))
                UpDownH.Value = pt.X;
            if (sender.Equals(SatLine))
                UpDownS.Value = pt.X;
            if (sender.Equals(ValLine))
                UpDownV.Value = pt.X;
            if (sender.Equals(RedLine))
                UpDownR.Value = pt.X;
            if (sender.Equals(GreenLine))
                UpDownG.Value = pt.X;
            if (sender.Equals(BlueLine))
                UpDownB.Value = pt.X;
            if (sender.Equals(BoardMode))
            {
                if (pt.Y < 0)
                    pt.Y = 0;
                else if (pt.Y > ((PictureBox)sender).Height - 1)
                    pt.Y = ((PictureBox)sender).Height - 1;
                switch (LastChannel)
                {
                    case HsvRgb.Hue:
                        UpDownH.Value = pt.Y * 360 / 255;
                        break;
                    case HsvRgb.Saturation:
                        UpDownS.Value = pt.Y;
                        break;
                    case HsvRgb.Value:
                        UpDownV.Value = pt.Y;
                        break;
                    case HsvRgb.Red:
                        UpDownR.Value = pt.Y;
                        break;
                    case HsvRgb.Green:
                        UpDownG.Value = pt.Y;
                        break;
                    case HsvRgb.Blue:
                        UpDownB.Value = pt.Y;
                        break;
                }
            }
        }
        #endregion

    }

}
