/** Powered By 鸡蛋甲天下(潘妮)
 *  联系方式（QQ）：1943495203
 *  HSV构造体
 *  Version Final
 *  2021.8.22
 */
using System;
using System.Drawing;

namespace FastBitmapLib
{
    public enum HsvRgb
    {
        Hue,
        Saturation,
        Value,
        Brightness,
        Red,
        Green,
        Blue
    }

    public struct HSV
    {
        /// <summary>
        /// 色相 (Hue) 0~360
        /// </summary>
        public readonly int H;

        /// <summary>
        /// 彩度 (Saturation) 0~255 (0~100%)
        /// </summary>
        public readonly int S;

        /// <summary>
        /// 明度 (Value, Brightness) 0~255 (0~100%)
        /// </summary>
        public readonly int V;

        /// <summary>
        /// 检测HSV结构是否准确
        /// </summary>
        /// <param name="hsv">HSV结构</param>
        /// <returns>true or false</returns>
        public static bool Check(HSV hsv)
        {
            return !(hsv.H < 0 || hsv.H > 360
                || hsv.S < 0 || hsv.S > 0xff
                || hsv.V < 0 || hsv.V > 0xff);
        }

        /// <summary>
        /// 初始化程序
        /// </summary>
        /// <param name="hue">色相 (Hue) 0~360</param>
        /// <param name="saturation">彩度 (Saturation) 0~255 (0~100%)</param>
        /// <param name="value">明度 (Value, Brightness) 0~255 (0~100%)</param>
        public HSV(int hue, int saturation, int value)
        {
            if (hue > 360)
                this.H = 360;
            else if (hue < 0)
                this.H = 0;
            else
                this.H = hue;
            if (saturation > 255)
                this.S = 255;
            else if (hue < 0)
                this.S = 0;
            else
                this.S = saturation;
            if (value > 255)
                this.V = 255;
            else if (hue < 0)
                this.V = 0;
            else
                this.V = value;
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <returns>Example: H:360 S:255 V:255</returns>
        public override string ToString()
        {
            return "H: " + this.H + " S: " + this.S + " V: " + this.V;
        }

        /// <summary>
        /// Change RGB to HSV
        /// </summary>
        /// <param name="rgb">Color</param>
        /// <returns>HsvColor</returns>
        public static HSV FromRgb(Color rgb)
        {
            return FromRgb(rgb.R, rgb.G, rgb.B);
        }

        /// <summary>
        /// 由指定Color(int)来生成Hsv
        /// </summary>
        /// <param name="rgb">Color</param>
        /// <returns>HsvColor</returns>
        public static HSV FromRgb(int rgb)
        {
            return FromRgb((byte)(rgb >> 16), (byte)(rgb >> 8), (byte)rgb);
        }

        /// <summary>
        /// 由指定Color来生成Hsv
        /// </summary>
        /// <param name="R">Red:0~255</param>
        /// <param name="G">Green:0~255</param>
        /// <param name="B">Blue:0~255</param>
        /// <returns>HsvColor</returns>
        public static HSV FromRgb(byte R, byte G, byte B)
        {
            byte max = Math.Max(R, Math.Max(G, B));
            byte min = Math.Min(R, Math.Min(G, B));

            int value = max, hue, saturation;
            int chroma = max - min;

            if (chroma == 0)
                hue = 0;
            else if (value == R)
                hue = 60 * (G - B) / chroma;
            else if (value == G)
                hue = 60 * (B - R) / chroma + 120;
            else if (value == B)
                hue = 60 * (R - G) / chroma + 240;
            else
                hue = 0;

            if (hue < 0)
                hue += 360;

            if (value == 0)
                saturation = 0;
            else
                saturation = chroma * 0xff / value;

            return new HSV(hue, saturation, value);
        }

        /// <summary>
        /// 由指定Hsv来生成Color
        /// </summary>
        /// <param name="hsv">HsvColor</param>
        /// <returns>Color</returns>
        public static Color ToRgb(HSV hsv)
        {
            return Color.FromArgb(ToRgbInt(hsv));
        }

        /// <summary>
        /// 由指定Hsv来生成Color(int)
        /// </summary>
        /// <param name="hsv">HsvColor</param>
        /// <returns>int</returns>
        public static int ToRgbInt(HSV hsv)
        {
            int Chroma = hsv.V * hsv.S / 0xff;
            int Match = hsv.V - Chroma;
            int X = (int)(Match + Chroma * (1 - Math.Abs((float)hsv.H / 60 % 2 - 1)));
            Chroma += Match;

            int r = 0, g = 0, b = 0;
            if (hsv.V != 0)
            {
                switch (hsv.H / 60)
                {
                    case 0:
                    case 6:
                        r = Chroma;
                        g = X;
                        b = Match;
                        break;
                    case 1:
                        r = X;
                        g = Chroma;
                        b = Match;
                        break;
                    case 2:
                        r = Match;
                        g = Chroma;
                        b = X;
                        break;
                    case 3:
                        r = Match;
                        g = X;
                        b = Chroma;
                        break;
                    case 4:
                        r = X;
                        g = Match;
                        b = Chroma;
                        break;
                    case 5:
                        r = Chroma;
                        g = Match;
                        b = X;
                        break;
                }
            }

            return HSV.ARGB(r, g, b);
        }

        /// <summary>
        /// 色相 (Hue) 0~360
        /// </summary>
        /// <param name="rgb"></param>
        /// <returns>Hue 0~360</returns>
        public static int HueOnly(Color rgb)
        {
            return HueOnly(rgb.R, rgb.G, rgb.B);
        }

        /// <summary>
        /// 色相 (Hue) 0~360
        /// </summary>
        /// <param name="rgb">Color</param>
        /// <returns>Hue 0~360</returns>
        public static int HueOnly(int rgb)
        {
            return HueOnly((byte)(rgb >> 16), (byte)(rgb >> 8), (byte)rgb);
        }

        /// <summary>
        /// 色相 (Hue) 0~360
        /// </summary>
        /// <param name="R">Red:0~255</param>
        /// <param name="G">Green:0~255</param>
        /// <param name="B">Blue:0~255</param>
        /// <returns>Hue 0~360</returns>
        public static int HueOnly(byte R, byte G, byte B)
        {
            byte max = Math.Max(R, Math.Max(G, B));
            byte min = Math.Min(R, Math.Min(G, B));

            int hue, chroma = max - min;

            if (chroma == 0)
                hue = 0;
            else if (max == R)
                hue = 60 * (G - B) / chroma;
            else if (max == G)
                hue = 60 * (B - R) / chroma + 120;
            else if (max == B)
                hue = 60 * (R - G) / chroma + 240;
            else
                hue = 0;

            if (hue < 0)
                hue += 360;
            return hue;
        }

        /// <summary>
        /// 彩度 (Saturation) 0~255 (0~100%)
        /// </summary>
        /// <param name="rgb">Color</param>
        /// <returns>Saturation 0~255</returns>
        public static int SaturationOnly(Color rgb)
        {
            return SaturationOnly(rgb.R, rgb.G, rgb.B);
        }

        /// <summary>
        /// 彩度 (Saturation) 0~255 (0~100%)
        /// </summary>
        /// <param name="rgb">Color</param>
        /// <returns>Saturation 0~255</returns>
        public static int SaturationOnly(int rgb)
        {
            return SaturationOnly((byte)(rgb >> 16), (byte)(rgb >> 8), (byte)rgb);
        }

        /// <summary>
        /// 彩度 (Saturation) 0~255 (0~100%)
        /// </summary>
        /// <param name="R">Red:0~255</param>
        /// <param name="G">Green:0~255</param>
        /// <param name="B">Blue:0~255</param>
        /// <returns>Saturation 0~255</returns>
        public static int SaturationOnly(byte R, byte G, byte B)
        {
            byte max = Math.Max(R, Math.Max(G, B));
            byte min = Math.Min(R, Math.Min(G, B));

            int chroma = max - min;

            if (max == 0)
                return 0;
            else
                return chroma * 0xff / max;
        }

        /// <summary>
        /// 明度 (Value, Brightness) 0~255 (0~100%)
        /// </summary>
        /// <param name="rgb">Color</param>
        /// <returns>Value 0~255</returns>
        public static int ValueOnly(Color rgb)
        {
            return ValueOnly(rgb.R, rgb.G, rgb.B);
        }

        /// <summary>
        /// 明度 (Value, Brightness) 0~255 (0~100%)
        /// </summary>
        /// <param name="rgb">Color</param>
        /// <returns>Value 0~255</returns>
        public static int ValueOnly(int rgb)
        {
            return ValueOnly((byte)(rgb >> 16), (byte)(rgb >> 8), (byte)rgb);
        }
        /// <summary>
        /// 明度 (Value, Brightness) 0~255 (0~100%)
        /// </summary>
        /// <param name="R">Red:0~255</param>
        /// <param name="G">Green:0~255</param>
        /// <param name="B">Blue:0~255</param>
        /// <returns>Value 0~255</returns>
        public static int ValueOnly(byte R, byte G, byte B)
        {
            return Math.Max(R, Math.Max(G, B));
        }
        /// <summary>
        /// 明度 (Value, Brightness) 0~255 (0~100%)
        /// </summary>
        /// <param name="rgb">Color</param>
        /// <returns>Value 0~255</returns>
        public static int BrightnessOnly(Color rgb)
        {
            return BrightnessOnly(rgb.R, rgb.G, rgb.B);
        }

        /// <summary>
        /// 明度 (Value, Brightness) 0~255 (0~100%)
        /// </summary>
        /// <param name="rgb">Color</param>
        /// <returns>Value 0~255</returns>
        public static int BrightnessOnly(int rgb)
        {
            return BrightnessOnly((byte)(rgb >> 16), (byte)(rgb >> 8), (byte)rgb);
        }
        /// <summary>
        /// 明度 (Value, Brightness) 0~255 (0~100%)
        /// </summary>
        /// <param name="R">Red:0~255</param>
        /// <param name="G">Green:0~255</param>
        /// <param name="B">Blue:0~255</param>
        /// <returns>Value 0~255</returns>
        public static int BrightnessOnly(byte R, byte G, byte B)
        {
            byte max = Math.Max(R, Math.Max(G, B));
            byte min = Math.Min(R, Math.Min(G, B));
            return (max + min) / 2;
        }


        /// <summary>
        /// 附加功能：将RGB三种颜色组合成一个int形态的Color
        /// </summary>
        /// <param name="R">Red:0~255</param>
        /// <param name="G">Green:0~255</param>
        /// <param name="B">Blue:0~255</param>
        /// <returns>int: Color</returns>
        public static int ARGB(int R, int G, int B)
        {
            return (255 << 24) | ((byte)R << 16) | ((byte)G << 8) | ((byte)B << 0);
        }

        /// <summary>
        /// 附加功能：将RGB三种颜色组合成一个int形态的Color
        /// </summary>
        /// <param name="R">Red:0~255</param>
        /// <param name="G">Green:0~255</param>
        /// <param name="B">Blue:0~255</param>
        /// <returns>int: Color</returns>
        public static int ARGB(byte R, byte G, byte B)
        {
            return (255 << 24) | ((byte)R << 16) | ((byte)G << 8) | ((byte)B << 0);
        }

        /// <summary>
        /// 附加功能：将ARGB四种颜色组合成一个int形态的Color
        /// </summary>
        /// <param name="A">Alpha:0~255</param>
        /// <param name="R">Red:0~255</param>
        /// <param name="G">Green:0~255</param>
        /// <param name="B">Blue:0~255</param>
        /// <returns>int: Color</returns>
        public static int ARGB(byte A, byte R, byte G, byte B)
        {
            return ((byte)A << 24) | ((byte)R << 16) | ((byte)G << 8) | ((byte)B << 0);
        }

        /// <summary>
        /// 附加功能：将颜色转换为相对色(Color)
        /// </summary>
        /// <param name="color">转换前的颜色</param>
        /// <returns>转换后的相对颜色</returns>
        public static Color InvertedColor(Color color)
        {
            return Color.FromArgb(color.ToArgb() ^ 0xFFFFFF);
        }

        /// <summary>
        /// 附加功能：将颜色转换为相对色(int)
        /// </summary>
        /// <param name="color">转换前的颜色(int)</param>
        /// <returns>转换后的相对颜色(int)</returns>
        public static int InvertedColor(int color)
        {
            return color ^ 0xFFFFFF;
        }

        /// <summary>
        /// 附加功能：比较两种颜色之间，除去alpha透明度之外的差别
        /// </summary>
        /// <param name="compair1">Color</param>
        /// <param name="compair2">Color</param>
        /// <returns>相同则返回True，不相同则返回False</returns>
        public static Boolean Compair(Color compair1, Color compair2)
        {
            return compair1.R == compair2.R && compair1.G == compair2.G && compair1.B == compair2.B;
        }

        /// <summary>
        /// 附加功能：比较两种颜色之间，除去alpha透明度之外的差别
        /// </summary>
        /// <param name="compair1">Color</param>
        /// <param name="compair2">Color</param>
        /// <returns>相同则返回True，不相同则返回False</returns>
        public static Boolean Compair(int compair1, int compair2)
        {
            return (compair1 ^ 0xFFFFFF) == (compair2 ^ 0xFFFFFF);
        }

        /// <summary>
        /// 附加功能：从颜色数据写出相对的大写HTML格式字符串
        /// </summary>
        /// <param name="Color">Color颜色</param>
        /// <returns>HTML字符串</returns>
        public static string HTMLString(Color Color)
        {
            int code = Color.ToArgb() & 0xffffff;
            return "#" + Convert.ToString(code, 16).PadLeft(6, '0').ToUpper();
        }

        /// <summary>
        /// 附加功能：从HTML格式字符串中获取Color信息，并赋予给指针
        /// </summary>
        /// <param name="html">HTML文字字符串</param>
        /// <param name="color">Color的指针Pointer</param>
        public static void ReadFromHTML(String html, ref Color color)
        {
            if (html.Length != 7)
                return;
            if (html.Substring(0, 1) != "#")
                return;
            string str = html.Substring(1, 6);
            foreach (char c in str)
            {
                if (c >= '0' && c <= '9'
                    || c >= 'A' && c <= 'F'
                    || c >= 'a' && c <= 'f')
                    continue;
                else
                    return;
            }
            int code = Convert.ToInt32(str, 16);
            color = Color.FromArgb((255 << 24) | code);
        }

        /// <summary>
        /// 修正不符合标准的ARGB。修正标准0~255
        /// </summary>
        /// <param name="op">任意ARGB值</param>
        /// <returns>值的范围将修正为0~255</returns>
        public static int Normalise(int op)
        {
            if (op > 255) return 255;
            else if (op < 0) return 0;
            else return op;
        }

        /// <summary>
        /// 计算2个颜色的结果
        /// </summary>
        /// <param name="BaseColor">计算式左侧</param>
        /// <param name="TargetColor">计算式右侧</param>
        /// <returns>Color1 + Color2</returns>
        public static Color ADD(Color BaseColor, Color TargetColor)
        {
            int A = BaseColor.A + TargetColor.A;
            int R = BaseColor.R + TargetColor.R;
            int G = BaseColor.G + TargetColor.G;
            int B = BaseColor.B + TargetColor.B;

            A = Normalise(A);
            R = Normalise(R);
            G = Normalise(G);
            B = Normalise(B);

            return Color.FromArgb(A, R, G, B);
        }
        /// <summary>
        /// 计算2个颜色的结果
        /// </summary>
        /// <param name="BaseColor">计算式左侧</param>
        /// <param name="TargetColor">计算式右侧</param>
        /// <returns>Color1 - Color2</returns>
        public static Color SUB(Color BaseColor, Color TargetColor)
        {
            int A = BaseColor.A - TargetColor.A;
            int R = BaseColor.R - TargetColor.R;
            int G = BaseColor.G - TargetColor.G;
            int B = BaseColor.B - TargetColor.B;

            A = Normalise(A);
            R = Normalise(R);
            G = Normalise(G);
            B = Normalise(B);

            return Color.FromArgb(A, R, G, B);
        }
        /// <summary>
        /// 计算2个颜色的结果
        /// </summary>
        /// <param name="BaseColor">计算式左侧</param>
        /// <param name="TargetColor">计算式右侧</param>
        /// <returns>Color1 + Color2</returns>
        public static HSV ADD(HSV BaseColor, HSV TargetColor)
        {
            int H = BaseColor.H + TargetColor.H;
            int S = BaseColor.S + TargetColor.S;
            int V = BaseColor.V + TargetColor.V;

            return new HSV(H, S, V);
        }
        /// <summary>
        /// 计算2个颜色的结果
        /// </summary>
        /// <param name="BaseColor">计算式左侧</param>
        /// <param name="TargetColor">计算式右侧</param>
        /// <returns>Color1 - Color2</returns>
        public static HSV SUB(HSV BaseColor, HSV TargetColor)
        {
            int H = BaseColor.H - TargetColor.H;
            int S = BaseColor.S - TargetColor.S;
            int V = BaseColor.V - TargetColor.V;

            return new HSV(H, S, V);
        }

        /// <summary>
        /// 欧氏距离
        /// </summary>
        /// <param name="R1">计算式左侧</param>
        /// <param name="R2">计算式右侧</param>
        /// <returns>Distance^2 = (R2-R1)^2 + (B2-B1)^2 + (C2-C1)^2</returns>
        public static int EuclideanDistance(Color R1, Color R2)
        {
            int R = R1.R - R2.R;
            int G = R1.G - R2.G;
            int B = R1.B - R2.B;

            return R * R + G * G + B * B;
        }

        /// <summary>
        /// 欧氏距离
        /// </summary>
        /// <param name="H1">计算式左侧</param>
        /// <param name="H2">计算式右侧</param>
        /// <returns>Distance^2 = (R2-R1)^2 + (B2-B1)^2 + (C2-C1)^2</returns>
        public static int EuclideanDistance(HSV H1, HSV H2)
        {
            int H = H1.H - H2.H;
            int S = H1.S - H2.S;
            int V = H1.V - H2.V;

            return H * H + S * S + V * V;
        }


        /// <summary>
        /// 容差模式：区间容差
        /// </summary>
        /// <param name="BaseColor">判断的基准色</param>
        /// <param name="GivenColor">需要被“判断”的颜色</param>
        /// <param name="Distance">欧氏距离^2</param>
        /// <param name="isRGB">RGB模式为true，HSV模式为false</param>
        /// <returns>被判断的颜色在欧氏距离以内则为true</returns>
        public static bool ToleranceCompair(Color BaseColor, Color GivenColor, int Distance, bool isRGB)
        {
            if (isRGB)
                return EuclideanDistance(BaseColor, GivenColor) <= Distance;
            else
                return EuclideanDistance(HSV.FromRgb(BaseColor), HSV.FromRgb(GivenColor)) <= Distance;
        }
        /// <summary>
        /// 容差模式：区间容差
        /// </summary>
        /// <param name="BaseColor">判断的基准色</param>
        /// <param name="GivenColor">需要被“判断”的颜色</param>
        /// <param name="Distance">欧氏距离^2</param>
        /// <returns>被判断的颜色在欧氏距离以内则为true</returns>
        public static bool ToleranceCompair(Color BaseColor, Color GivenColor, byte R, byte G, byte B)
        {
            int r = BaseColor.R - GivenColor.R;
            int g = BaseColor.G - GivenColor.G;
            int b = BaseColor.B - GivenColor.B;
            return r * r <= R * R && g * g <= G * G && b * b <= B * B;
        }
        /// <summary>
        /// 容差模式：区间容差
        /// </summary>
        /// <param name="BaseColor">判断的基准色</param>
        /// <param name="GivenColor">需要被“判断”的颜色</param>
        /// <param name="Distance">欧氏距离^2</param>
        /// <returns>被判断的颜色在欧氏距离以内则为true</returns>
        public static bool ToleranceCompair(Color BaseColor, Color GivenColor, int H, int S, int V)
        {
            HSV b = HSV.FromRgb(BaseColor);
            HSV g = HSV.FromRgb(GivenColor);
            int h = b.H - g.H;
            int s = b.S - g.S;
            int v = b.V - g.V;
            return h * h <= H * H && s * s <= S * S && v * v <= V * V;
        }

    }
}
