using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
namespace PixelLab.Services.ColorSpaces
{
    class ColorSystems
    {

        // ================= CMY
        public static Bitmap ToCmy(Bitmap rgbImage)
        {

            Bitmap cmyImage = new Bitmap(rgbImage.Width, rgbImage.Height);

            Rectangle rect = new Rectangle(0, 0, rgbImage.Width, rgbImage.Height);

            BitmapData rgbData = rgbImage.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            BitmapData cmyData = cmyImage.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

            int bytes = Math.Abs(rgbData.Stride) * rgbImage.Height;

            byte[] rgbBuffer = new byte[bytes];
            byte[] cmyBuffer = new byte[bytes];

            System.Runtime.InteropServices.Marshal.Copy(rgbData.Scan0, rgbBuffer, 0, bytes);

            for (int i = 0; i < bytes; i += 3)
            {
                byte b = rgbBuffer[i];
                byte g = rgbBuffer[i + 1];
                byte r = rgbBuffer[i + 2];

                // CMY conversion
                cmyBuffer[i] = (byte)(255 - r);     // C
                cmyBuffer[i + 1] = (byte)(255 - g); // M
                cmyBuffer[i + 2] = (byte)(255 - b); // Y
            }

            System.Runtime.InteropServices.Marshal.Copy(cmyBuffer, 0, cmyData.Scan0, bytes);

            rgbImage.UnlockBits(rgbData);
            cmyImage.UnlockBits(cmyData);

            return cmyImage;
        }

        // ================= HSV 
        public static Mat ToHsv(Mat img)
        {
            Mat hsv = new Mat();
            CvInvoke.CvtColor(img, hsv, ColorConversion.Bgr2Hsv);
            return hsv;
        }

        // ================= YCbCr
        public static Mat ToYcbcr(Mat img)
        {
            Mat ycbcr = new Mat();
            CvInvoke.CvtColor(img, ycbcr, ColorConversion.Bgr2YCrCb);
            return ycbcr;
        }

        // ================= YUV 
        public static Mat ToYuv(Mat img)
        {
            Mat yuv = new Mat();
            CvInvoke.CvtColor(img, yuv, ColorConversion.Bgr2Yuv);
            return yuv;
        }

        // ================= LAB 
        public static Mat ToLab(Mat img)
        {
            Mat lab = new Mat();
            CvInvoke.CvtColor(img, lab, ColorConversion.Bgr2Lab);
            return lab;
        }

        // ================= YCMK
    public static Mat ToCmyk(Mat inputImage)
        {
           
            if (inputImage == null || inputImage.IsEmpty)
            {
                throw new ArgumentException("الصورة المدخلة فارغة أو غير صالحة.");
            }
            // 1. تحويل الـ Mat إلى كائن Image للوصول السريع للبكسلات بدون مفهرسات معقدة
            Image<Bgr, byte> img = inputImage.ToImage<Bgr, byte>();

            // 2. إنشاء صورة جديدة فارغة لتخزين النتيجة بنفس الأبعاد
            Image<Bgr, byte> outputImg = new Image<Bgr, byte>(img.Width, img.Height);

            // 3. المرور على كافة بكسلات الصورة (الأسطر والأعمدة)
            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    // جلب لون البكسل الحالي في Emgu CV
                    Bgr pixel = img[y, x];
                    double b = pixel.Blue;
                    double g = pixel.Green;
                    double r = pixel.Red;

                    // 4. تطبيق معادلة التحويل الرياضية إلى CMYK
                    double rd = r / 255.0;
                    double gd = g / 255.0;
                    double bd = b / 255.0;

                    double k = 1.0 - Math.Max(rd, Math.Max(gd, bd));
                    double c, m, yColor;

                    if (k == 1.0)
                    {
                        c = 0; m = 0; yColor = 0;
                    }
                    else
                    {
                        c = (1.0 - rd - k) / (1.0 - k);
                        m = (1.0 - gd - k) / (1.0 - k);
                        yColor = (1.0 - bd - k) / (1.0 - k);
                    }

                    // 5. إعادة الحساب إلى BGR لمحاكاة مظهر الـ CMYK على الشاشة
                    byte bNew = (byte)((1.0 - yColor) * (1.0 - k) * 255);
                    byte gNew = (byte)((1.0 - m) * (1.0 - k) * 255);
                    byte rNew = (byte)((1.0 - c) * (1.0 - k) * 255);

                    // تعيين اللون الجديد للبكسل في صورة الخرج
                    outputImg[y, x] = new Bgr(bNew, gNew, rNew);
                }
            }

            // 6. إعادة تحويل كائن Image إلى Mat ليصبح الدخل والخرج متطابقين كما طلبت
            return outputImg.Mat;
        }
      

        //////////////////////////////////////////////////////////////////////////////////
        
        
    }
}
