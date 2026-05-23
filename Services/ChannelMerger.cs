using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelLab.Services
{
    ///دمج لصورة بعد التعديلات
    class ChannelMerger
    {
        public static Mat Merge(ColorSpaceModel model)
        {
            VectorOfMat channels = new VectorOfMat();

            foreach (var channel in model.Channels)
            {
                channels.Push(channel.Data);
            }
            Mat mergedImage = new Mat();
            CvInvoke.Merge(channels, mergedImage);
            Mat result = new Mat();//بعد ما دمجن لازم نعرض الصورة ك  RGB
            ///لهيك حسب نوع الفضاء اللوني للصورة عم نحول 
            switch (model.ColorSpaceName)
            {
                case "HSV":
                    CvInvoke.CvtColor( mergedImage,result,ColorConversion.Hsv2Bgr);
                    break;

                case "LAB":
                    CvInvoke.CvtColor(mergedImage,result,ColorConversion.Lab2Bgr);
                    break;

                case "YUV":
                    CvInvoke.CvtColor(mergedImage,result,ColorConversion.Yuv2Bgr);
                    break;

                case "YCbCr":
                     CvInvoke.CvtColor(mergedImage,result, ColorConversion.YCrCb2Bgr);
                    break;

                case "RGB":
                    result = mergedImage.Clone();
                    break;
                  case "CMYK":
                    result = CmykToBgr(model);
                    break;

                default:
                    result = mergedImage.Clone();
                    break;
            }

            return result;
        }
        /////////////////////////////////////////////////////////////////
        private static Mat CmykToBgr(ColorSpaceModel model)
        {
            int width = model.Channels[0].Data.Width;
            int height = model.Channels[0].Data.Height;

            // إنشاء صورة الخرج
            Image<Bgr, byte> output =
                new Image<Bgr, byte>(width, height);

            // جلب القنوات
            Image<Gray, byte> cChannel =
                model.Channels[0]
                .Data
                .ToImage<Gray, byte>();

            Image<Gray, byte> mChannel =
                model.Channels[1]
                .Data
                .ToImage<Gray, byte>();

            Image<Gray, byte> yChannel =
                model.Channels[2]
                .Data
                .ToImage<Gray, byte>();

            Image<Gray, byte> kChannel =
                model.Channels[3]
                .Data
                .ToImage<Gray, byte>();

            // إعادة التحويل إلى BGR
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    double c =
                        cChannel.Data[y, x, 0] / 255.0;

                    double m =
                        mChannel.Data[y, x, 0] / 255.0;

                    double yColor =
                        yChannel.Data[y, x, 0] / 255.0;

                    double k =
                        kChannel.Data[y, x, 0] / 255.0;

                    // المعادلات العكسية
                    byte r =
                        (byte)((1 - c) * (1 - k) * 255);

                    byte g =
                        (byte)((1 - m) * (1 - k) * 255);

                    byte b =
                        (byte)((1 - yColor) * (1 - k) * 255);

                    output[y, x] =
                        new Bgr(b, g, r);
                }
            }

            return output.Mat;
        }

    }
}

