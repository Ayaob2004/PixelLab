using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelLab.Services
{
    class ImageQuantizationColorsService
    {
        public Bitmap Quantize(Bitmap image, int colorCount)

        {
            // تحويل الصورة لصيغة 24bit
            Bitmap clone = new Bitmap(image.Width,image.Height, PixelFormat.Format24bppRgb);

            using (Graphics g = Graphics.FromImage(clone))
            {
                g.DrawImage(image, 0, 0);
            }

            // قراءة الألوان باستخدام LockBits
            List<Color> pixels = GetPixelsFast(clone);

            // Median Cut
            List<List<Color>> buckets = new List<List<Color>>();
            buckets.Add(pixels);

            while (buckets.Count < colorCount)
            {
                List<Color> largest =
                    buckets.OrderByDescending(b => b.Count).First();

                buckets.Remove(largest);

                int rangeR = largest.Max(c => c.R) - largest.Min(c => c.R);
                int rangeG = largest.Max(c => c.G) - largest.Min(c => c.G);
                int rangeB = largest.Max(c => c.B) - largest.Min(c => c.B);

                if (rangeR >= rangeG && rangeR >= rangeB)
                    largest = largest.OrderBy(c => c.R).ToList();

                else if (rangeG >= rangeR && rangeG >= rangeB)
                    largest = largest.OrderBy(c => c.G).ToList();

                else
                    largest = largest.OrderBy(c => c.B).ToList();

                int mid = largest.Count / 2;

                buckets.Add(largest.Take(mid).ToList());
                buckets.Add(largest.Skip(mid).ToList());
            }

            // إنشاء palette
            List<Color> palette = new List<Color>();

            foreach (var bucket in buckets)
            {
                int r = (int)bucket.Average(c => c.R);
                int g = (int)bucket.Average(c => c.G);
                int b = (int)bucket.Average(c => c.B);

                palette.Add(Color.FromArgb(r, g, b));
            }

            // إنشاء الصورة الجديدة
            Bitmap result =
                ApplyPaletteFast(clone, palette);

            return result;
        }

        // ==========================
        // قراءة البكسلات بسرعة
        // ==========================
        private List<Color> GetPixelsFast(Bitmap image)
        {
            List<Color> pixels = new List<Color>();

            BitmapData data = image.LockBits(
                new Rectangle(0, 0, image.Width, image.Height),
                ImageLockMode.ReadOnly,
                PixelFormat.Format24bppRgb);

            unsafe
            {
                byte* ptr = (byte*)data.Scan0;

                for (int y = 0; y < image.Height; y++)
                {
                    byte* row = ptr + (y * data.Stride);

                    for (int x = 0; x < image.Width; x++)
                    {
                        int idx = x * 3;

                        byte b = row[idx];
                        byte g = row[idx + 1];
                        byte r = row[idx + 2];

                        pixels.Add(Color.FromArgb(r, g, b));
                    }
                }
            }

            image.UnlockBits(data);

            return pixels;
        }
        private Bitmap ApplyPaletteFast(
            Bitmap image,
            List<Color> palette)
        {
            Bitmap result = new Bitmap(
                image.Width,
                image.Height,
                PixelFormat.Format24bppRgb);

            BitmapData srcData = image.LockBits(
                new Rectangle(0, 0, image.Width, image.Height),
                ImageLockMode.ReadOnly,
                PixelFormat.Format24bppRgb);

            BitmapData dstData = result.LockBits(
                new Rectangle(0, 0, result.Width, result.Height),
                ImageLockMode.WriteOnly,
                PixelFormat.Format24bppRgb);

            unsafe
            {
                byte* src = (byte*)srcData.Scan0;
                byte* dst = (byte*)dstData.Scan0;

                for (int y = 0; y < image.Height; y++)
                {
                    byte* rowSrc = src + (y * srcData.Stride);
                    byte* rowDst = dst + (y * dstData.Stride);

                    for (int x = 0; x < image.Width; x++)
                    {
                        int idx = x * 3;

                        Color pixel = Color.FromArgb(
                            rowSrc[idx + 2],
                            rowSrc[idx + 1],
                            rowSrc[idx]);

                        Color nearest =
                            FindNearest(pixel, palette);

                        rowDst[idx] = nearest.B;
                        rowDst[idx + 1] = nearest.G;
                        rowDst[idx + 2] = nearest.R;
                    }
                }
            }

            image.UnlockBits(srcData);
            result.UnlockBits(dstData);

            return result;
        
    }
        private Color FindNearest(
                Color c,
                List<Color> palette)
        {
            Color best = palette[0];

            double minDist = double.MaxValue;

            foreach (var p in palette)
            {
                double dist =
                    (c.R - p.R) * (c.R - p.R) +
                    (c.G - p.G) * (c.G - p.G) +
                    (c.B - p.B) * (c.B - p.B);

                if (dist < minDist)
                {
                    minDist = dist;
                    best = p;
                }
            }

            return best;
        }
    }
}