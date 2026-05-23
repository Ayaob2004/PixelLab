using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PixelLab.Services
{
    class ImageQuantizationColorsService
    {
            public Bitmap Quantize(Bitmap image, int colorCount) {

            Bitmap clone = new Bitmap(image.Width,image.Height, PixelFormat.Format24bppRgb);

            using (Graphics g = Graphics.FromImage(clone))
            {
                g.DrawImage(image, 0, 0);
            }
            List<Color> palette = AllowColors(clone, colorCount);

            Rectangle rect = new Rectangle(0,0,image.Width, image.Height);
            BitmapData srcData = clone.LockBits( rect,ImageLockMode.ReadOnly,PixelFormat.Format24bppRgb);
            Bitmap result = new Bitmap(clone.Width, clone.Height,PixelFormat.Format24bppRgb);
            BitmapData dstData = result.LockBits( rect, ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

            int bytes = Math.Abs(srcData.Stride) * image.Height;

            byte[] srcBuffer = new byte[bytes];
            byte[] dstBuffer = new byte[bytes];

            
            Marshal.Copy(srcData.Scan0, srcBuffer, 0,  bytes);


            int stride = srcData.Stride;
            int width = clone.Width;
            int height = clone.Height;

            for (int y = 0; y < height; y++) { 
                 int row = y * stride;
                for (int x = 0; x < width; x++) {
                    int i = row + x * 3;
                    Color original = Color.FromArgb(srcBuffer[i + 2],  srcBuffer[i + 1],  srcBuffer[i]);
                    Color nearest = FindNearColor(original, palette);

                    dstBuffer[i] = nearest.B;
                    dstBuffer[i + 1] = nearest.G;
                    dstBuffer[i + 2] = nearest.R;
                }
            }
            Marshal.Copy(dstBuffer,0,dstData.Scan0, bytes);
            clone.UnlockBits(srcData);
            result.UnlockBits(dstData);

            return result;
        }

        private List<Color> AllowColors( Bitmap image,  int colorCount)
        {
            Dictionary<Color, int> colorFrequency = new Dictionary<Color, int>();

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color original =  image.GetPixel(x, y);
                    int r =  (original.R / 16) * 16;
                    int g = (original.G / 16) * 16;
                    int b = (original.B / 16) * 16;

                    Color c =  Color.FromArgb(r, g, b);
                    if (colorFrequency.ContainsKey(c))
                        colorFrequency[c]++;
                    else
                        colorFrequency[c] = 1;
                }
            }
      List<Color> palette = colorFrequency.OrderByDescending(c => c.Value).Take(colorCount).Select(c => c.Key).ToList();

            return palette;
        }

        private Color FindNearColor( Color color, List<Color> palette)
        {
            Color best = palette[0];
            double minDistance =  double.MaxValue;
            foreach (Color p in palette)
            {
                double distance =  (color.R - p.R) * (color.R - p.R) +(color.G - p.G) * (color.G - p.G) + (color.B - p.B) * (color.B - p.B);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    best = p;
                }
            }
            return best;
        }
       }
    }
