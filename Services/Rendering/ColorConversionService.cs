using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PixelLab.Services.Rendering
{
    public static class ColorConversionService
    {
        // COLOR CONVERSIONS
        public static Color HsvToRgb(float h, float s, float v)
        {
            h = h - (float)Math.Floor(h);

            if (s <= 0f)
            {
                int gray = ClampToByte(v * 255f);
                return Color.FromArgb(gray, gray, gray);
            }

            float sector = h * 6f;
            int i = (int)Math.Floor(sector);
            float f = sector - i;

            float p = v * (1f - s);
            float q = v * (1f - s * f);
            float t = v * (1f - s * (1f - f));

            float r;
            float g;
            float b;

            switch (i % 6)
            {
                case 0: r = v; g = t; b = p; break;
                case 1: r = q; g = v; b = p; break;
                case 2: r = p; g = v; b = t; break;
                case 3: r = p; g = q; b = v; break;
                case 4: r = t; g = p; b = v; break;
                default: r = v; g = p; b = q; break;
            }

            return Color.FromArgb(ClampToByte(r * 255f), ClampToByte(g * 255f), ClampToByte(b * 255f));
        }

        public static Color YcbcrToRgb(float y255, float cb255, float cr255)
        {
            float cb = cb255 - 128f;
            float cr = cr255 - 128f;

            float r = y255 + 1.402f * cr;
            float g = y255 - 0.344136f * cb - 0.714136f * cr;
            float b = y255 + 1.772f * cb;

            return Color.FromArgb(ClampToByte(r), ClampToByte(g), ClampToByte(b));
        }

        public static Color YuvToRgb(float y255, float u255, float v255)
        {
            float u = u255 - 128f;
            float v = v255 - 128f;

            float r = y255 + 1.13983f * v;
            float g = y255 - 0.39465f * u - 0.58060f * v;
            float b = y255 + 2.03211f * u;

            return Color.FromArgb(ClampToByte(r), ClampToByte(g), ClampToByte(b));
        }

        public static Color LabToRgb(float l, float a, float b)
        {
            float y = (l + 16f) / 116f;
            float x = a / 500f + y;
            float z = y - b / 200f;

            x = LabPivotInverse(x);
            y = LabPivotInverse(y);
            z = LabPivotInverse(z);

            float X = 95.047f * x / 100f;
            float Y = 100.000f * y / 100f;
            float Z = 108.883f * z / 100f;

            float r = X * 3.2406f + Y * -1.5372f + Z * -0.4986f;
            float g = X * -0.9689f + Y * 1.8758f + Z * 0.0415f;
            float blue = X * 0.0557f + Y * -0.2040f + Z * 1.0570f;

            r = SrgbGammaCorrect(r);
            g = SrgbGammaCorrect(g);
            blue = SrgbGammaCorrect(blue);

            return Color.FromArgb(ClampToByte(r * 255f), ClampToByte(g * 255f), ClampToByte(blue * 255f));
        }

        public static void RgbToHsv(Color color, out float h, out float s, out float v)
        {
            float r = color.R / 255f;
            float g = color.G / 255f;
            float b = color.B / 255f;

            float max = Math.Max(r, Math.Max(g, b));
            float min = Math.Min(r, Math.Min(g, b));
            float delta = max - min;

            v = max;

            if (max == 0f)
                s = 0f;
            else
                s = delta / max;

            if (delta == 0f)
            {
                h = 0f;
            }
            else if (max == r)
            {
                h = 60f * (((g - b) / delta) % 6f);
            }
            else if (max == g)
            {
                h = 60f * (((b - r) / delta) + 2f);
            }
            else
            {
                h = 60f * (((r - g) / delta) + 4f);
            }

            if (h < 0f)
                h += 360f;
        }

        public static void RgbToCmyk(Color color, out float c, out float m, out float y, out float k)
        {
            float r = color.R / 255f;
            float g = color.G / 255f;
            float b = color.B / 255f;

            k = 1f - Math.Max(r, Math.Max(g, b));

            if (k >= 1f)
            {
                c = 0f;
                m = 0f;
                y = 0f;
                k = 1f;
                return;
            }

            c = (1f - r - k) / (1f - k);
            m = (1f - g - k) / (1f - k);
            y = (1f - b - k) / (1f - k);
        }

        public static void RgbToYuv(Color color, out float y, out float u, out float v)
        {
            float r = color.R;
            float g = color.G;
            float b = color.B;

            y = 0.299f * r + 0.587f * g + 0.114f * b;
            u = -0.14713f * r - 0.28886f * g + 0.436f * b;
            v = 0.615f * r - 0.51499f * g - 0.10001f * b;
        }

        public static void RgbToYcbcr(Color color, out float y, out float cb, out float cr)
        {
            float r = color.R;
            float g = color.G;
            float b = color.B;

            y = 0.299f * r + 0.587f * g + 0.114f * b;

            cb = 128f
                 - 0.168736f * r
                 - 0.331264f * g
                 + 0.5f * b;

            cr = 128f
                 + 0.5f * r
                 - 0.418688f * g
                 - 0.081312f * b;
        }

        public static void RgbToLab(Color color, out float l, out float a, out float b)
        {
            float r = SrgbToLinear(color.R / 255f);
            float g = SrgbToLinear(color.G / 255f);
            float blue = SrgbToLinear(color.B / 255f);

            float x = r * 0.4124f + g * 0.3576f + blue * 0.1805f;
            float y = r * 0.2126f + g * 0.7152f + blue * 0.0722f;
            float z = r * 0.0193f + g * 0.1192f + blue * 0.9505f;

            x *= 100f;
            y *= 100f;
            z *= 100f;

            float xr = x / 95.047f;
            float yr = y / 100.000f;
            float zr = z / 108.883f;

            float fx = LabPivotForward(xr);
            float fy = LabPivotForward(yr);
            float fz = LabPivotForward(zr);

            l = 116f * fy - 16f;
            a = 500f * (fx - fy);
            b = 200f * (fy - fz);
        }

        public static float SrgbToLinear(float value)
        {
            if (value <= 0.04045f)
                return value / 12.92f;

            return (float)Math.Pow((value + 0.055f) / 1.055f, 2.4);
        }

        public static float LabPivotForward(float value)
        {
            if (value > 0.008856f)
                return (float)Math.Pow(value, 1.0 / 3.0);

            return 7.787f * value + 16f / 116f;
        }

        public static float LabPivotInverse(float value)
        {
            float value3 = value * value * value;
            return value3 > 0.008856f ? value3 : (value - 16f / 116f) / 7.787f;
        }

        public static float SrgbGammaCorrect(float value)
        {
            if (value <= 0.0031308f)
                return 12.92f * value;

            return 1.055f * (float)Math.Pow(value, 1.0 / 2.4) - 0.055f;
        }

        public static int ClampToByte(float value)
        {
            if (value < 0f)
                return 0;

            if (value > 255f)
                return 255;

            return (int)Math.Round(value);
        }
    }
}
