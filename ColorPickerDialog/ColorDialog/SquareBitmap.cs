/** Powered By 鸡蛋甲天下(潘妮)
 *  联系方式（QQ）：1943495203
 *  找色专用面板中的各个显示模块
 *  @HSV.cs
 *  @SquareBitmap.cs
 *  Version 1.0
 *  2021.8.22
 */

using System;
using System.Drawing;
using System.Drawing.Imaging;
using FastBitmapLib;



namespace ColorPicker
{
    class SquareBitmap : IDisposable
    {
        private HSV GivenHsv, LastHsv;
        private Color GivenColor, LastColor;
        private HsvRgb GivenChannel, LastChannel;
        public Bitmap HSVRGB { private set; get; }
        public Bitmap BoardLiner { private set; get; }
        public Bitmap HueLiner { private set; get; }
        public Bitmap SatLiner { private set; get; }
        public Bitmap ValLiner { private set; get; }
        public Bitmap RedLiner { private set; get; }
        public Bitmap GreenLiner { private set; get; }
        public Bitmap BlueLiner { private set; get; }


        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="color">指定初始化的颜色</param>
        /// <param name="channel">HUE, SATURATION, VALUE, RED, GREEN, BLUE</param>
        /// <param name="HsvRgb">正方形的颜色面板</param>
        /// <param name="BoardLine">颜色面板用于改变基准色的颜色线条</param>
        /// <param name="HueLine">0~360长度的颜色线条</param>
        /// <param name="OtherLine">0~255长度的颜色线条</param>
        public SquareBitmap(Color color, HsvRgb channel, Size HsvRgb, Size BoardLine, Size HueLine, Size OtherLine)
        {
            this.GivenColor = this.LastColor = color;
            this.GivenHsv = this.LastHsv = HSV.FromRgb(GivenColor);
            this.GivenChannel = this.LastChannel = channel;

            this.HSVRGB = new Bitmap(HsvRgb.Width, HsvRgb.Height, PixelFormat.Format32bppPArgb);
            this.BoardLiner = new Bitmap(BoardLine.Width, BoardLine.Height, PixelFormat.Format32bppPArgb);
            this.HueLiner = new Bitmap(HueLine.Width, HueLine.Height, PixelFormat.Format32bppPArgb);
            this.SatLiner = new Bitmap(OtherLine.Width, OtherLine.Height, PixelFormat.Format32bppPArgb);
            this.ValLiner = new Bitmap(OtherLine.Width, OtherLine.Height, PixelFormat.Format32bppPArgb);
            this.RedLiner = new Bitmap(OtherLine.Width, OtherLine.Height, PixelFormat.Format32bppPArgb);
            this.GreenLiner = new Bitmap(OtherLine.Width, OtherLine.Height, PixelFormat.Format32bppPArgb);
            this.BlueLiner = new Bitmap(OtherLine.Width, OtherLine.Height, PixelFormat.Format32bppPArgb);

            UpDate(true);
        }

        /// <summary>
        /// Dispose all Bitmap
        /// </summary>
        public void Dispose()
        {
            HSVRGB?.Dispose();
            BoardLiner?.Dispose();
            HueLiner?.Dispose();
            SatLiner?.Dispose();
            ValLiner?.Dispose();
            RedLiner?.Dispose();
            GreenLiner?.Dispose();
            BlueLiner?.Dispose();
        }

        #region 更新内容
        /// <summary>
        /// 更新颜色板1
        /// </summary>
        /// <param name="color">指定初始化的颜色</param>
        /// <param name="channel">HUE, SATURATION, VALUE, RED, GREEN, BLUE</param>
        public void UpDate(Color color, HsvRgb channel)
        {
            this.GivenChannel = channel;
            this.GivenColor = color;
            this.GivenHsv = HSV.FromRgb(GivenColor);
            UpDate(false);
        }
        /// <summary>
        /// 更新颜色板2
        /// </summary>
        /// <param name="hsv">指定初始化的HSV</param>
        /// <param name="channel">HUE, SATURATION, VALUE, RED, GREEN, BLUE</param>
        public void UpDate(HSV hsv, HsvRgb channel)
        {
            this.GivenChannel = channel;
            this.GivenHsv = hsv;
            this.GivenColor = HSV.ToRgb(GivenHsv);
            UpDate(false);
        }
        #endregion


        #region 自我刷新内容(private)
        /// <summary>
        /// 正式刷新Bitmap
        /// </summary>
        private void UpDate(bool init)
        {
            bool ChangeAbility = false;
            switch (GivenChannel)
            {
                case HsvRgb.Hue:
                    if (GivenHsv.H != LastHsv.H) ChangeAbility = true;
                    break;
                case HsvRgb.Saturation:
                    if (GivenHsv.S != LastHsv.S) ChangeAbility = true;
                    break;
                case HsvRgb.Value:
                    if (GivenHsv.V != LastHsv.V) ChangeAbility = true;
                    break;
                case HsvRgb.Red:
                    if (GivenColor.R != LastColor.R) ChangeAbility = true;
                    break;
                case HsvRgb.Green:
                    if (GivenColor.G != LastColor.G) ChangeAbility = true;
                    break;
                case HsvRgb.Blue:
                    if (GivenColor.B != LastColor.B) ChangeAbility = true;
                    break;
            }

            if (GivenChannel != LastChannel || ChangeAbility || init)
                UpColorPlate(HSVRGB, GivenHsv, GivenColor, GivenChannel);

            UpColorLine(BoardLiner, GivenHsv, GivenColor, GivenChannel, false);

            UpColorLine(HueLiner, GivenHsv, GivenColor, HsvRgb.Hue, true);

            UpColorLine(SatLiner, GivenHsv, GivenColor, HsvRgb.Saturation, true);

            UpColorLine(ValLiner, GivenHsv, GivenColor, HsvRgb.Value, true);

            UpColorLine(RedLiner, GivenHsv, GivenColor, HsvRgb.Red, true);

            UpColorLine(GreenLiner, GivenHsv, GivenColor, HsvRgb.Green, true);

            UpColorLine(BlueLiner, GivenHsv, GivenColor, HsvRgb.Blue, true);

            this.LastChannel = this.GivenChannel;
            this.LastHsv = this.GivenHsv;
            this.LastColor = this.GivenColor;
        }

        /// <summary>
        /// 正方形颜色面板
        /// </summary>
        public static void UpColorPlate(Bitmap HSVRGB, HSV GivenHsv, Color GivenColor, HsvRgb GivenChannel)
        {
            int Width = HSVRGB.Width;
            int Height = HSVRGB.Height;

            int[] DataArray = new int[Width * Height];
            int ft, rg, hue;
            int SetColor = 0;
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    ft = i * 255 / (Width - 1);
                    rg = j * 255 / (Height - 1);
                    switch (GivenChannel)
                    {
                        case HsvRgb.Hue:
                            SetColor = HSV.ToRgbInt(new HSV(GivenHsv.H, ft, rg));
                            break;
                        case HsvRgb.Saturation:
                            hue = j * 360 / (Height - 1);
                            SetColor = HSV.ToRgbInt(new HSV(hue, GivenHsv.S, ft));
                            break;
                        case HsvRgb.Value:
                            hue = j * 360 / (Height - 1);
                            SetColor = HSV.ToRgbInt(new HSV(hue, ft, GivenHsv.V));
                            break;
                        case HsvRgb.Red:
                            SetColor = HSV.ARGB(GivenColor.R, ft, rg);
                            break;
                        case HsvRgb.Green:
                            SetColor = HSV.ARGB(rg, GivenColor.G, ft);
                            break;
                        case HsvRgb.Blue:
                            SetColor = HSV.ARGB(rg, ft, GivenColor.B);
                            break;
                    }
                    DataArray[i + j * Width] = SetColor;
                }
            }
            using (FastBitmap bp = HSVRGB.FastLock())
            {
                bp.CopyFromArray(DataArray);
            }
        }

        /// <summary>
        /// 长方形颜色选择条
        /// </summary>
        /// <param name="Bitmap">颜色条的Bitmap指针</param>
        /// <param name="Channel">HUE, SATURATION, VALUE, RED, GREEN, BLUE</param>
        /// <param name="horizontal">横条还是竖条</param>
        public static void UpColorLine(Bitmap Bitmap, HSV GivenHsv, Color GivenColor, HsvRgb Channel, bool horizontal)
        {
            int Hue = GivenHsv.H;
            int Sat = GivenHsv.S;
            int Value = GivenHsv.V;
            if (Channel == HsvRgb.Hue && (Sat == 0 || Value == 0))
            {
                Sat = 255;
                Value = 255;
            }

            int red = GivenColor.R;
            int green = GivenColor.G;
            int blue = GivenColor.B;
            int Width = Bitmap.Width, Height = Bitmap.Height;

            int[] DataArray = new int[Width * Height];
            if (horizontal)
            {
                for (int i = 0; i < Width; i++)
                {
                    int length = Width;
                    switch (Channel)
                    {
                        case HsvRgb.Hue:
                            Hue = i * 360 / (length - 1);
                            if (Hue > 360) Hue = 360;
                            break;
                        case HsvRgb.Saturation:
                            Sat = i * 0xff / (length - 1);
                            if (Sat > 0xff) Sat = 0xff;
                            break;
                        case HsvRgb.Value:
                            Value = i * 0xff / (length - 1);
                            if (Value > 0xff) Value = 0xff;
                            break;
                        case HsvRgb.Red:
                            red = i * 0xff / (length - 1);
                            if (red > 0xff) red = 0xff;
                            break;
                        case HsvRgb.Green:
                            green = i * 0xff / (length - 1);
                            if (green > 0xff) green = 0xff;
                            break;
                        case HsvRgb.Blue:
                            blue = i * 0xff / (length - 1);
                            if (blue > 0xff) blue = 0xff;
                            break;
                    }
                    int color = 0;
                    switch (Channel)
                    {
                        case HsvRgb.Hue:
                        case HsvRgb.Saturation:
                        case HsvRgb.Value:
                            color = HSV.ToRgbInt(new HSV(Hue, Sat, Value));
                            break;
                        case HsvRgb.Red:
                        case HsvRgb.Green:
                        case HsvRgb.Blue:
                            color = HSV.ARGB(red, green, blue);
                            break;
                    }

                    for (int j = 0; j < Height; j++)
                    {
                        DataArray[i + j * Width] = color;
                    }
                }
            }
            else
            {
                for (int j = 0; j < Height; j++)
                {
                    int length = Height;
                    switch (Channel)
                    {
                        case HsvRgb.Hue:
                            Hue = j * 360 / (length - 1);
                            if (Hue > 360) red = 360;
                            break;
                        case HsvRgb.Saturation:
                            Sat = j * 0xff / (length - 1);
                            if (Sat > 0xff) Sat = 0xff;
                            break;
                        case HsvRgb.Value:
                            Value = j * 0xff / (length - 1);
                            if (Value > 0xff) Value = 0xff;
                            break;
                        case HsvRgb.Red:
                            red = j * 0xff / (length - 1);
                            if (red > 0xff) red = 0xff;
                            break;
                        case HsvRgb.Green:
                            green = j * 0xff / (length - 1);
                            if (green > 0xff) green = 0xff;
                            break;
                        case HsvRgb.Blue:
                            blue = j * 0xff / (length - 1);
                            if (blue > 0xff) blue = 0xff;
                            break;
                    }
                    int color = 0;
                    switch (Channel)
                    {
                        case HsvRgb.Hue:
                        case HsvRgb.Saturation:
                        case HsvRgb.Value:
                            color = HSV.ToRgbInt(new HSV(Hue, Sat, Value));
                            break;
                        case HsvRgb.Red:
                        case HsvRgb.Green:
                        case HsvRgb.Blue:
                            color = HSV.ARGB(red, green, blue);
                            break;
                    }

                    for (int i = 0; i < Width; i++)
                    {
                        DataArray[i + j * Width] = color;
                    }
                }
            }
            using (FastBitmap bp = Bitmap.FastLock())
            {
                bp.CopyFromArray(DataArray);
            }
        }
        #endregion


        #region 返回结果图像(复制后)
        /// <summary>
        /// After Using This, you need to Dispose it.
        /// </summary>
        /// <returns>返回有内接圆的图像</returns>
        public Bitmap ColorBox()
        {
            Rectangle rect = new Rectangle(-6, -6, 12, 12);//内接圆的正方形大小
            Bitmap ColorBox = (Bitmap)HSVRGB.Clone();
            int width = ColorBox.Width, height = ColorBox.Height;
            int x = 0, y = 0;
            switch (LastChannel)
            {
                case HsvRgb.Hue:
                    x = LastHsv.S * (width - 1) / 255;
                    y = LastHsv.V * (height - 1) / 255;
                    break;
                case HsvRgb.Saturation:
                    y = LastHsv.H * (width - 1) / 360;
                    x = LastHsv.V * (height - 1) / 255;
                    break;
                case HsvRgb.Value:
                    y = LastHsv.H * (width - 1) / 360;
                    x = LastHsv.S * (height - 1) / 255;
                    break;
                case HsvRgb.Red:
                    x = LastColor.G * (width - 1) / 255;
                    y = LastColor.B * (height - 1) / 255;
                    break;
                case HsvRgb.Green:
                    x = LastColor.B * (width - 1) / 255;
                    y = LastColor.R * (height - 1) / 255;
                    break;
                case HsvRgb.Blue:
                    x = LastColor.G * (width - 1) / 255;
                    y = LastColor.R * (height - 1) / 255;
                    break;
            }
            Point pt = new Point(x, y);
            using (Graphics g = Graphics.FromImage(ColorBox))
            using (Pen p = new Pen(Color.FromArgb(LastColor.ToArgb() ^ 0xffffff), 2))//相对色，1像素
            {
                g.TranslateTransform(pt.X, pt.Y);//变更圆的原点位置
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;//抗锯齿

                g.DrawEllipse(p, rect);//给定的正方形内画内接圆
            }
            return ColorBox;
        }

        /// <summary>
        ///  After Using This, you need to Dispose it.
        /// </summary>
        /// <param name="Line">Height should be 10. Width should be 360+4 or 256+4</param>
        /// <param name="channel">HUE, SATURATION, VALUE, RED, GREEN, BLUE</param>
        /// <returns>与长方形颜色选择条图像相对应的指针信息（横向）</returns>
        public Bitmap ColorLinePointer(Size Line, HsvRgb channel)
        {
            Bitmap Bitmap = new Bitmap(Line.Width, Line.Height);

            if (Bitmap.Height != 10 ||
                (channel == HsvRgb.Brightness) ||
                (channel != HsvRgb.Hue && Line.Width != 256 + 4) ||
                (channel == HsvRgb.Hue && Line.Width != 361 + 4))
                return Bitmap;

            int pointX = 0;
            switch (channel)
            {
                case HsvRgb.Hue:
                    pointX = LastHsv.H;
                    break;
                case HsvRgb.Saturation:
                    pointX = LastHsv.S;
                    break;
                case HsvRgb.Value:
                    pointX = LastHsv.V;
                    break;
                case HsvRgb.Red:
                    pointX = LastColor.R;
                    break;
                case HsvRgb.Green:
                    pointX = LastColor.G;
                    break;
                case HsvRgb.Blue:
                    pointX = LastColor.B;
                    break;
            }

            int[,] shape = new int[10, 5] {
            {0,0,2,0,0 },
            {0,0,2,0,0 },
            {0,2,1,2,0 },
            {0,2,1,2,0 },
            {0,2,1,2,0 },
            {2,1,1,1,2 },
            {2,1,1,1,2 },
            {2,1,1,1,2 },
            {2,1,1,1,2 },
            {2,2,2,2,2 }};
            int color = LastColor.ToArgb();
            int invertcolor = Color.Black.ToArgb();

            //Copy Array To Memory
            int[] DataArray = new int[Line.Width * Line.Height];
            int ControlColor = SystemColors.Control.ToArgb();
            for (int i = 0; i < DataArray.Length; i++)
                DataArray[i] = ControlColor;

            for (int i = pointX; i < pointX + 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (shape[j, i - pointX] == 1)
                        DataArray[i + j * Line.Width] = color;
                    if (shape[j, i - pointX] == 2)
                        DataArray[i + j * Line.Width] = invertcolor;
                }
            }
            using (FastBitmap bp = Bitmap.FastLock())
            {
                bp.CopyFromArray(DataArray);
            }
            
            return Bitmap;
        }

        /// <summary>
        /// 快速填充新图像
        /// </summary>
        /// <param name="Color">填充颜色</param>
        /// <param name="Size">图像大小</param>
        /// <returns>返回填充好单一颜色的图像</returns>
        public static Bitmap FillUp(Color Color, Size Size)
        {
            Bitmap Bitmap = new Bitmap(Size.Width, Size.Height);
            using (FastBitmap bp = new FastBitmap(Bitmap))
            {
                bp.Lock();
                bp.Clear(Color);
                bp.Unlock();
            }
            return Bitmap;
        }

        /// <summary>
        /// 返回取色框内的颜色
        /// </summary>
        /// <param name="pt">颜色框坐标</param>
        /// <returns>返回取色框内的颜色</returns>
        public Color SetColorBox(Point pt)
        {
            if (pt.X < 0)
                pt.X = 0;
            if (pt.X > HSVRGB.Width)
                pt.X = HSVRGB.Width;
            if (pt.Y < 0)
                pt.Y = 0;
            if (pt.Y > HSVRGB.Height)
                pt.Y = HSVRGB.Height;

            Color c;
            using (FastBitmap fb = HSVRGB.FastLock())
            {
                c = fb.GetPixel(pt.X, pt.Y);
            }
            return c;
        }

        #endregion

    }

}
