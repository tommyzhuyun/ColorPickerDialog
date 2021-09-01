/** Powered By 鸡蛋甲天下(潘妮)
 *  联系方式（QQ）：1943495203
 *  找色专用面板中的各个显示模块
 *  @HSV.cs
 *  @SquareBitmap.cs
 *  Version 1.0
 *  2021.8.22
 */
using ColorPicker.Plugin;
using System;
using System.Drawing;
using System.Drawing.Imaging;



namespace ColorPicker
{
    class SquareBitmap : IDisposable
    {
        public static byte HUE = 1;
        public static byte SATURATION = 2;
        public static byte VALUE = 3;
        public static byte RED = 4;
        public static byte GREEN = 5;
        public static byte BLUE = 6;

        private HSV GivenHsv, LastHsv;
        private Color GivenColor, LastColor;
        private byte GivenChannel, LastChannel;
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
        public SquareBitmap(Color color, byte channel, Size HsvRgb, Size BoardLine, Size HueLine, Size OtherLine)
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
        public void UpDate(Color color, byte channel)
        {
            if (channel >= 1 && channel <= 6)
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
        public void UpDate(HSV hsv, byte channel)
        {
            if (channel >= 1 && channel <= 6)
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
                case 1:
                    if (GivenHsv.H != LastHsv.H) ChangeAbility = true;
                    break;
                case 2:
                    if (GivenHsv.S != LastHsv.S) ChangeAbility = true;
                    break;
                case 3:
                    if (GivenHsv.V != LastHsv.V) ChangeAbility = true;
                    break;
                case 4:
                    if (GivenColor.R != LastColor.R) ChangeAbility = true;
                    break;
                case 5:
                    if (GivenColor.G != LastColor.G) ChangeAbility = true;
                    break;
                case 6:
                    if (GivenColor.B != LastColor.B) ChangeAbility = true;
                    break;
            }


            if (GivenChannel != LastChannel || ChangeAbility || init)
                UpColorPlate();


            UpColorLine(BoardLiner, GivenChannel, false);

            UpColorLine(HueLiner, HUE, true);

            UpColorLine(SatLiner, SATURATION, true);

            UpColorLine(ValLiner, VALUE, true);

            UpColorLine(RedLiner, RED, true);

            UpColorLine(GreenLiner, GREEN, true);

            UpColorLine(BlueLiner, BLUE, true);


            this.LastChannel = this.GivenChannel;
            this.LastHsv = this.GivenHsv;
            this.LastColor = this.GivenColor;
        }

        /// <summary>
        /// 正方形颜色面板
        /// </summary>
        private void UpColorPlate()
        {
            using (FastBitmapLib.FastBitmap bp = new FastBitmapLib.FastBitmap(HSVRGB))
            {
                bp.Lock();
                int ft, rg, hue;
                int SetColor;
                int width = HSVRGB.Width;
                int height = HSVRGB.Height;
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        SetColor = 0;
                        ft = i * 255 / (width - 1);
                        rg = j * 255 / (height - 1);
                        switch (GivenChannel)
                        {
                            case 1:
                                SetColor = HSV.ToRgbInt(new HSV(GivenHsv.H, ft, rg));
                                break;
                            case 2:
                                hue = j * 360 / (height - 1);
                                SetColor = HSV.ToRgbInt(new HSV(hue, GivenHsv.S, ft));
                                break;
                            case 3:
                                hue = j * 360 / (height - 1);
                                SetColor = HSV.ToRgbInt(new HSV(hue, ft, GivenHsv.V));
                                break;
                            case 4:
                                SetColor = HSV.ARGB(GivenColor.R, ft, rg);
                                break;
                            case 5:
                                SetColor = HSV.ARGB(rg, GivenColor.G, ft);
                                break;
                            case 6:
                                SetColor = HSV.ARGB(rg, ft, GivenColor.B);
                                break;
                        }
                        bp.SetPixel(i, j, SetColor);
                    }
                }
                bp.Unlock();
            }
        }

        /// <summary>
        /// 长方形颜色选择条
        /// </summary>
        /// <param name="Bitmap">颜色条的Bitmap指针</param>
        /// <param name="Channel">HUE, SATURATION, VALUE, RED, GREEN, BLUE</param>
        /// <param name="horizontal">横条还是竖条</param>
        private void UpColorLine(Bitmap Bitmap, int Channel, bool horizontal)
        {
            int Hue = GivenHsv.H;
            int Sat = GivenHsv.S;
            int Value = GivenHsv.V;
            if (Channel == Hue && (Sat == 0 || Value == 0))
            {
                Sat = 255;
                Value = 255;
            }

            int red = GivenColor.R;
            int green = GivenColor.G;
            int blue = GivenColor.B;
            using (FastBitmapLib.FastBitmap bp = new FastBitmapLib.FastBitmap(Bitmap))
            {
                bp.Lock();
                //bp.Clear(Color.White);
                if (horizontal)
                {
                    for (int i = 0; i < Bitmap.Width; i++)
                    {
                        int length = Bitmap.Width;
                        switch (Channel)
                        {
                            case 1://HUE
                                Hue = i * 360 / (length - 1);
                                if (Hue > 360) Hue = 360;
                                break;
                            case 2://SAT
                                Sat = i * 0xff / (length - 1);
                                if (Sat > 0xff) Sat = 0xff;
                                break;
                            case 3://Value
                                Value = i * 0xff / (length - 1);
                                if (Value > 0xff) Value = 0xff;
                                break;
                            case 4:
                                red = i * 0xff / (length - 1);
                                if (red > 0xff) red = 0xff;
                                break;
                            case 5:
                                green = i * 0xff / (length - 1);
                                if (green > 0xff) green = 0xff;
                                break;
                            case 6:
                                blue = i * 0xff / (length - 1);
                                if (blue > 0xff) blue = 0xff;
                                break;
                        }
                        int color = 0;
                        switch (Channel)
                        {
                            case 1:
                            case 2:
                            case 3:
                                color = HSV.ToRgbInt(new HSV(Hue, Sat, Value));
                                break;
                            case 4:
                            case 5:
                            case 6:
                                color = HSV.ARGB(red, green, blue);
                                break;
                        }

                        for (int j = 0; j < Bitmap.Height; j++)
                        {
                            bp.SetPixel(i, j, color);
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < Bitmap.Height; j++)
                    {
                        int length = Bitmap.Height;
                        switch (Channel)
                        {
                            case 1://HUE
                                Hue = j * 360 / (length - 1);
                                if (Hue > 360) red = 360;
                                break;
                            case 2://SAT
                                Sat = j * 0xff / (length - 1);
                                if (Sat > 0xff) Sat = 0xff;
                                break;
                            case 3://Value
                                Value = j * 0xff / (length - 1);
                                if (Value > 0xff) Value = 0xff;
                                break;
                            case 4:
                                red = j * 0xff / (length - 1);
                                if (red > 0xff) red = 0xff;
                                break;
                            case 5:
                                green = j * 0xff / (length - 1);
                                if (green > 0xff) green = 0xff;
                                break;
                            case 6:
                                blue = j * 0xff / (length - 1);
                                if (blue > 0xff) blue = 0xff;
                                break;
                        }
                        int color = 0;
                        switch (Channel)
                        {
                            case 1:

                            case 2:
                            case 3:
                                color = HSV.ToRgbInt(new HSV(Hue, Sat, Value));
                                break;
                            case 4:
                            case 5:
                            case 6:
                                color = HSV.ARGB(red, green, blue);
                                break;
                        }

                        for (int i = 0; i < Bitmap.Width; i++)
                        {
                            bp.SetPixel(i, j, color);
                        }
                    }
                }
                bp.Unlock();
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
                case 1:
                    x = LastHsv.S * (width - 1) / 255;
                    y = LastHsv.V * (height - 1) / 255;
                    break;
                case 2:
                    y = LastHsv.H * (width - 1) / 360;
                    x = LastHsv.V * (height - 1) / 255;
                    break;
                case 3:
                    y = LastHsv.H * (width - 1) / 360;
                    x = LastHsv.S * (height - 1) / 255;
                    break;
                case 4:
                    x = LastColor.G * (width - 1) / 255;
                    y = LastColor.B * (height - 1) / 255;
                    break;
                case 5:
                    x = LastColor.B * (width - 1) / 255;
                    y = LastColor.R * (height - 1) / 255;
                    break;
                case 6:
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
        public Bitmap ColorLinePointer(Size Line, int channel)
        {
            Bitmap Bitmap = new Bitmap(Line.Width, Line.Height);

            if (Bitmap.Height != 10 ||
                (channel < 1 && channel > 6) ||
                (channel != 1 && Line.Width != 256 + 4) ||
                (channel == 1 && Line.Width != 361 + 4))
                return Bitmap;

            int pointX = 0;
            switch (channel)
            {
                case 1:
                    pointX = LastHsv.H;
                    break;
                case 2:
                    pointX = LastHsv.S;
                    break;
                case 3:
                    pointX = LastHsv.V;
                    break;
                case 4:
                    pointX = LastColor.R;
                    break;
                case 5:
                    pointX = LastColor.G;
                    break;
                case 6:
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
            using (FastBitmapLib.FastBitmap bp = new FastBitmapLib.FastBitmap(Bitmap))
            {
                bp.Lock();
                bp.Clear(SystemColors.Control);

                for (int i = pointX; i < pointX + 5; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (shape[j, i - pointX] == 1)
                            bp.SetPixel(i, j, color);
                        if (shape[j, i - pointX] == 2)
                            bp.SetPixel(i, j, invertcolor);
                    }
                }
                bp.Unlock();
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
            using (FastBitmapLib.FastBitmap bp = new FastBitmapLib.FastBitmap(Bitmap))
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
            using (FastBitmapLib.FastBitmap fb = new FastBitmapLib.FastBitmap(HSVRGB))
            {
                fb.Lock();
                c = fb.GetPixel(pt.X, pt.Y);
                fb.Unlock();
            }
            return c;
        }

        #endregion

    }

}
