using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using PixelLab.Services.ColorSpaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelLab.Services.ColorSpaces
{
    /// عزل القنوات لكل نظام لوني 
    class ChannelProcessor
    {
        ////////////////////////////////////////////////////////////////////////////CMYK
        public static ColorSpaceModel GetCMYKChannels(Mat inputImage)
        {
            // تحويل الصورة للوصول للبكسلات
            Image<Bgr, byte> img = inputImage.ToImage<Bgr, byte>();
            int width = img.Width;
            int height = img.Height;

            // إنشاء قنوات CMYK
            Image<Gray, byte> cChannel =
                new Image<Gray, byte>(width, height);

            Image<Gray, byte> mChannel =
                new Image<Gray, byte>(width, height);

            Image<Gray, byte> yChannel =
                new Image<Gray, byte>(width, height);

            Image<Gray, byte> kChannel =
                new Image<Gray, byte>(width, height);

            // المرور على كل البكسلات
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Bgr pixel = img[y, x];

                    double b = pixel.Blue / 255.0;
                    double g = pixel.Green / 255.0;
                    double r = pixel.Red / 255.0;

                    // حساب K
                    double k = 1.0 - Math.Max(r, Math.Max(g, b));

                    double c = 0;
                    double m = 0;
                    double yColor = 0;

                    // منع القسمة على صفر
                    if (k < 1.0)
                    {
                        c = (1 - r - k) / (1 - k);
                        m = (1 - g - k) / (1 - k);
                        yColor = (1 - b - k) / (1 - k);
                    }

                    // تحويل إلى 0-255
                    cChannel.Data[y, x, 0] =
                        (byte)(c * 255);

                    mChannel.Data[y, x, 0] =
                        (byte)(m * 255);

                    yChannel.Data[y, x, 0] =
                        (byte)(yColor * 255);

                    kChannel.Data[y, x, 0] =
                        (byte)(k * 255);
                }
            }

            // إنشاء الموديل النهائي
            ColorSpaceModel model =new ColorSpaceModel();

            model.ColorSpaceName = "CMYK";

            model.Channels = new List<ChannelInfo>()
    {
        new ChannelInfo()
        {
            Name = "Cyan",
            Data = cChannel.Mat,
            MinValue = 0,
            MaxValue = 255
        },

        new ChannelInfo()
        {
            Name = "Magenta",
            Data = mChannel.Mat,
            MinValue = 0,
             MaxValue = 255
        },

        new ChannelInfo()
        {
            Name = "Yellow",
            Data = yChannel.Mat,
            MinValue = 0,
            MaxValue = 255
        },

        new ChannelInfo()
        {
            Name = "Black",
            Data = kChannel.Mat,
            MinValue = 0,
            MaxValue = 255
        }
    };

            return model;
        }
        //////////////////////////////////////////////////////////////////////////HSV
        public static ColorSpaceModel GetHSVChannels(Mat image)
        {
            Mat hsvImage = ColorSystems.ToHsv(image);
            VectorOfMat splitChannels = new VectorOfMat();
            CvInvoke.Split(hsvImage, splitChannels);
            ColorSpaceModel model = new ColorSpaceModel();
            model.ColorSpaceName = "HSV";
            model.Channels = new List<ChannelInfo>()
            {
                new ChannelInfo
                {
                    Name = "Hue",
                    Data = splitChannels[0],
                     MinValue = 0,
                     MaxValue = 179
                },

                new ChannelInfo
                {
                    Name = "Saturation",
                    Data = splitChannels[1],
                    MinValue = 0,
                    MaxValue = 255
                },

                new ChannelInfo
                {
                    Name = "Value",
                    Data = splitChannels[2],
                    MinValue = 0,
                     MaxValue = 255
                }
            };

            return model;
        }
        //////////////////////////////////////////////////////////////////////////RGB
        public static ColorSpaceModel GetRGBChannels(Mat image)
        {
            VectorOfMat splitChannels = new VectorOfMat();

            CvInvoke.Split(image, splitChannels);

            ColorSpaceModel model =
                new ColorSpaceModel();

            model.ColorSpaceName = "RGB";

            model.Channels = new List<ChannelInfo>()
    {
        new ChannelInfo()
        {
            Name = "Blue",
            Data = splitChannels[0],
            MinValue = 0,
            MaxValue = 255
        },

        new ChannelInfo()
        {
            Name = "Green",
            Data = splitChannels[1],
            MinValue = 0,
             MaxValue = 255
        },

        new ChannelInfo()
        {
            Name = "Red",
            Data = splitChannels[2],
            MinValue = 0,
            MaxValue = 255
        }
    };

            return model;
        }
        ///////////////////////////////////////////////////////////////////////////LAB
        public static ColorSpaceModel GetLABChannels(Mat image)
        {
            Mat labImage = ColorSystems.ToLab(image);

            VectorOfMat splitChannels =
                new VectorOfMat();

            CvInvoke.Split(labImage, splitChannels);

            ColorSpaceModel model =
                new ColorSpaceModel();

            model.ColorSpaceName = "LAB";

            model.Channels = new List<ChannelInfo>()
    {
        new ChannelInfo()
        {
            Name = "Lightness",
            Data = splitChannels[0],
            MinValue = 0,
            MaxValue = 255
        },

        new ChannelInfo()
        {
            Name = "A Channel",
            Data = splitChannels[1],
            MinValue = 0,
            MaxValue = 255
        },

        new ChannelInfo()
        {
            Name = "B Channel",
            Data = splitChannels[2],
            MinValue = 0,
            MaxValue = 255

        }
    };

            return model;
        }
        ///////////////////////////////////////////////////////////////////////////LAB
        public static ColorSpaceModel GetYUVChannels(Mat image)
        {
            Mat yuvImage = ColorSystems.ToYuv(image);

            VectorOfMat splitChannels =
                new VectorOfMat();

            CvInvoke.Split(yuvImage, splitChannels);

            ColorSpaceModel model =
                new ColorSpaceModel();

            model.ColorSpaceName = "YUV";

            model.Channels = new List<ChannelInfo>()
    {
        new ChannelInfo()
        {
            Name = "Y",
            Data = splitChannels[0],
            MinValue = 0,
            MaxValue = 255

        },

        new ChannelInfo()
        {
            Name = "U",
            Data = splitChannels[1],
            MinValue = 0,
            MaxValue = 255

        },

        new ChannelInfo()
        {
            Name = "V",
            Data = splitChannels[2],
            MinValue = 0,
            MaxValue = 255
        }
    };

            return model;
        }
        ///////////////////////////////////////////////////////////////////////////YCBCR
        public static ColorSpaceModel GetYCbCrChannels(Mat image)
        {
            Mat ycbcrImage = ColorSystems.ToYcbcr(image);

            VectorOfMat splitChannels =
                new VectorOfMat();

            CvInvoke.Split(ycbcrImage, splitChannels);

            ColorSpaceModel model =
                new ColorSpaceModel();

            model.ColorSpaceName = "YCbCr";

            model.Channels = new List<ChannelInfo>()
    {
        new ChannelInfo()
        {
            Name = "Y",
            Data = splitChannels[0],
            MinValue = 0,
            MaxValue = 255
        },

        new ChannelInfo()
        {
            Name = "Cb",
            Data = splitChannels[1],
            MinValue = 0,
            MaxValue = 255
        },

        new ChannelInfo()
        {
            Name = "Cr",
            Data = splitChannels[2],
            MinValue = 0,
            MaxValue = 255
        }
    };

            return model;
        }
    }
}
