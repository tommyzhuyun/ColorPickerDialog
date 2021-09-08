/** Powered By 鸡蛋甲天下(潘妮)
 *  联系方式（QQ）：1943495203
 *  找色专用面板中的各个显示模块
 *  @HSV.cs
 *  @SquareBitmap.cs
 *  Version 1.1
 *  2021.9.9
 */

using FastBitmapLib;
using System;
using System.Drawing;
using System.Drawing.Imaging;


namespace ColorPicker
{
    class SquareBitmap : IDisposable
    {
        private HSV GivenHsv, LastHsv;
        private Color GivenColor, LastColor;
        private HsvRgb GivenChannel, LastChannel;
        public Bitmap HSVRGB { private set; get; }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="color">指定初始化的颜色</param>
        /// <param name="channel">HUE, SATURATION, VALUE, RED, GREEN, BLUE</param>
        /// <param name="ColorBoard">正方形的颜色面板</param>
        public SquareBitmap(Color color, HsvRgb channel, Size ColorBoard)
        {
            this.GivenColor = this.LastColor = color;
            this.GivenHsv = this.LastHsv = HSV.FromRgb(GivenColor);
            this.GivenChannel = this.LastChannel = channel;

            this.HSVRGB = new Bitmap(ColorBoard.Width, ColorBoard.Height, PixelFormat.Format32bppPArgb);
            UpDate(true);
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="hsv">指定初始化的颜色</param>
        /// <param name="channel">HUE, SATURATION, VALUE, RED, GREEN, BLUE</param>
        /// <param name="ColorBoard">正方形的颜色面板</param>
        public SquareBitmap(HSV hsv, HsvRgb channel, Size ColorBoard)
        {
            this.GivenHsv = this.LastHsv = hsv;
            this.GivenColor = this.LastColor = HSV.ToRgb(hsv);
            this.GivenChannel = this.LastChannel = channel;

            CreateColorPlate(ColorBoard);
            UpDate(true);
        }

        /// <summary>
        /// 初始化: 无图
        /// </summary>
        /// <param name="hsv">指定初始化的颜色</param>
        /// <param name="channel">HUE, SATURATION, VALUE, RED, GREEN, BLUE</param>
        /// <param name="ColorBoard">正方形的颜色面板</param>
        public SquareBitmap(HSV hsv)
        {
            this.GivenHsv = this.LastHsv = hsv;
            this.GivenColor = this.LastColor = HSV.ToRgb(hsv);
            this.GivenChannel = this.LastChannel = HsvRgb.Hue;

            this.HSVRGB = null;
            UpDate(true);
        }
        /// <summary>
        /// 初始化: 无图
        /// </summary>
        /// <param name="hsv">指定初始化的颜色</param>
        /// <param name="channel">HUE, SATURATION, VALUE, RED, GREEN, BLUE</param>
        /// <param name="ColorBoard">正方形的颜色面板</param>
        public SquareBitmap(Color color)
        {
            this.GivenColor = this.LastColor = color;
            this.GivenHsv = this.LastHsv = HSV.FromRgb(GivenColor);
            this.GivenChannel = this.LastChannel = HsvRgb.Hue;

            this.HSVRGB = null;
            UpDate(true);
        }

        /// <summary>
        /// 初始化: 无图
        /// </summary>
        /// <param name="hsv">指定初始化的颜色</param>
        /// <param name="channel">HUE, SATURATION, VALUE, RED, GREEN, BLUE</param>
        /// <param name="ColorBoard">正方形的颜色面板</param>
        public SquareBitmap(Color color, HSV hsv)
        {
            this.GivenColor = this.LastColor = color;
            this.GivenHsv = this.LastHsv = hsv;
            this.GivenChannel = this.LastChannel = HsvRgb.Hue;

            this.HSVRGB = null;
            UpDate(true);
        }

        /// <summary>
        /// Dispose all Bitmap
        /// </summary>
        public void Dispose()
        {
            HSVRGB?.Dispose();
        }

        ~SquareBitmap()
        {
            Dispose();
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

        /// <summary>
        /// 更新颜色板3
        /// </summary>
        /// <param name="hsv">指定初始化的HSV</param>
        /// <param name="channel">HUE, SATURATION, VALUE, RED, GREEN, BLUE</param>
        public void UpDate(Color color, HSV hsv, HsvRgb channel)
        {
            this.GivenChannel = channel;
            this.GivenHsv = hsv;
            this.GivenColor = color;
            UpDate(false);
        }
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

            if ((GivenChannel != LastChannel || ChangeAbility || init) && HSVRGB != null)
                UpColorPlate(HSVRGB);

            this.LastChannel = this.GivenChannel;
            this.LastHsv = this.GivenHsv;
            this.LastColor = this.GivenColor;
        }
        #endregion

        #region 更新图像
        public void CreateColorPlate(Size ColorBoard)
        {
            this.HSVRGB = new Bitmap(ColorBoard.Width, ColorBoard.Height, PixelFormat.Format32bppPArgb);
        }

        /// <summary>
        /// 正方形颜色面板
        /// </summary>
        public void UpColorPlate(Bitmap HSVRGB)
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
        public void UpColorLine(Bitmap Bitmap, HsvRgb Channel, bool horizontal)
        {
            int Hue = GivenHsv.H;
            int Sat = GivenHsv.S;
            int Value = GivenHsv.V;
            if (Channel == HsvRgb.Hue && (Sat == 0 || Value == 0))
            {
                Sat = Value = 255;
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

        /// <summary>
        ///  After Using This, you need to Dispose it.
        /// </summary>
        /// <param name="Bitmap">Height should be 10. Width should be 360+4 or 256+4</param>
        /// <param name="channel">HUE, SATURATION, VALUE, RED, GREEN, BLUE</param>
        /// <returns>与长方形颜色选择条图像相对应的指针信息（横向）</returns>
        public void ColorLinePointer(Bitmap Bitmap, HsvRgb channel)
        {
            int Width = Bitmap.Width;
            int Height = Bitmap.Height;

            if (Height != 10 ||
                (channel == HsvRgb.Brightness) ||
                (channel != HsvRgb.Hue && Width != 256 + 4) ||
                (channel == HsvRgb.Hue && Width != 361 + 4))
                return;

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

            int[] DataArray = new int[Width * Height];
            int ControlColor = SystemColors.Control.ToArgb();
            for (int i = 0; i < DataArray.Length; i++)
                DataArray[i] = ControlColor;

            for (int i = pointX; i < pointX + 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (shape[j, i - pointX] == 1)
                        DataArray[i + j * Width] = color;
                    if (shape[j, i - pointX] == 2)
                        DataArray[i + j * Width] = invertcolor;
                }
            }
            using (FastBitmap bp = Bitmap.FastLock())
            {
                bp.CopyFromArray(DataArray);
            }
        }
        #endregion

        #region 返回结果图像
        /// <summary>
        /// After Using This, you need to Dispose it.
        /// </summary>
        /// <returns>返回有内接圆的图像</returns>
        public void ColorBox(Image ColorBox)
        {
            Rectangle rect = new Rectangle(-6, -6, 12, 12);//内接圆的正方形大小
            
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
                g.DrawImage(HSVRGB, new Point(0, 0));

                g.TranslateTransform(pt.X, pt.Y);//变更圆的原点位置
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;//抗锯齿
                g.DrawEllipse(p, rect);//给定的正方形内画内接圆
            }

        }

        /// <summary>
        /// 返回取色框内的颜色
        /// </summary>
        /// <param name="pt">颜色框坐标</param>
        /// <returns>返回取色框内的颜色</returns>
        public Color SetColorBox(Point pt)
        {
            if (HSVRGB == null) throw new NullReferenceException("ColorBoard is Not be seted");
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
