using System;
using System.Drawing;
using System.IO;
using System.Numerics;

namespace PixelLab.Services {
    public class ImageInfoService {
        public ImageInfo GetImageInfo(string imagePath, Image image) {
            ImageInfo info = new ImageInfo();

            FileInfo fileInfo = new FileInfo(imagePath);
            double sizeKB = fileInfo.Length / 1024.0;
            int pixelCount = image.Width * image.Height;
            int colorDepth = Image.GetPixelFormatSize(image.PixelFormat);
            int gcd = (int)BigInteger.GreatestCommonDivisor(image.Width, image.Height);
            int aspectWidth = image.Width / gcd;
            int aspectHeight = image.Height / gcd;

            info.FileName = fileInfo.Name;
            info.Path = fileInfo.FullName;
            info.Format = fileInfo.Extension.Replace(".", "").ToUpper();
            info.AspectRatio = aspectWidth + ":" + aspectHeight;
            info.Dimensions = image.Width + " x " + image.Height;
            info.FileSize = sizeKB.ToString("0.00") + " KB";
            info.PixelCount = pixelCount.ToString();
            info.Dpi = image.HorizontalResolution + " x " + image.VerticalResolution;
            info.PixelFormat = image.PixelFormat.ToString();
            info.ColorDepth = colorDepth + " bits";
            info.LastModified = fileInfo.LastWriteTime.ToString();

            return info;
        }
    }
}