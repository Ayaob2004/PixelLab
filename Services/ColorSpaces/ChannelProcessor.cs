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
           
            Image<Bgr, byte> img = inputImage.ToImage<Bgr, byte>();
            int width = img.Width;
            int height = img.Height;
            Image<Gray, byte> cChannel =new Image<Gray, byte>(width, height);
            Image<Gray, byte> mChannel =new Image<Gray, byte>(width, height);
            Image<Gray, byte> yChannel =new Image<Gray, byte>(width, height);
            Image<Gray, byte> kChannel =new Image<Gray, byte>(width, height);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Bgr pixel = img[y, x];

                    double b = pixel.Blue / 255.0;
                    double g = pixel.Green / 255.0;
                    double r = pixel.Red / 255.0;

                  
                    double k = 1.0 - Math.Max(r, Math.Max(g, b));
                    double c = 0;
                    double m = 0;
                    double yColor = 0;
                    if (k < 1.0)
                    {
                        c = (1 - r - k) / (1 - k);
                        m = (1 - g - k) / (1 - k);
                        yColor = (1 - b - k) / (1 - k);
                    }

                    
                    cChannel.Data[y, x, 0] =(byte)(c * 255);
                    mChannel.Data[y, x, 0] =(byte)(m * 255);
                    yChannel.Data[y, x, 0] =(byte)(yColor * 255);
                    kChannel.Data[y, x, 0] =(byte)(k * 255);
                }
            }

          
            ColorSpaceModel model =new ColorSpaceModel();

            model.ColorSpaceName = "CMYK";

            model.Channels = new List<ChannelInfo>()
    {
        new ChannelInfo()
        {
            Name = "Cyan",
            Data = cChannel.Mat,
            MinValue = 0,
            MaxValue = 255,
            NeutralValue = 0
        },

        new ChannelInfo()
        {
            Name = "Magenta",
            Data = mChannel.Mat,
            MinValue = 0,
            MaxValue = 255,
            NeutralValue = 0
        },

        new ChannelInfo()
        {
            Name = "Yellow",
            Data = yChannel.Mat,
            MinValue = 0,
            MaxValue = 255,
            NeutralValue = 0
        },

        new ChannelInfo()
        {
            Name = "Black",
            Data = kChannel.Mat,
            MinValue = 0,
            MaxValue = 255,
            NeutralValue = 0
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
                     MaxValue = 179,
                     NeutralValue = 0
                },

                new ChannelInfo
                {
                    Name = "Saturation",
                    Data = splitChannels[1],
                    MinValue = 0,
                    MaxValue =255 ,
                    NeutralValue = 0
                },

                new ChannelInfo
                {
                    Name = "Value",
                    Data = splitChannels[2],
                    MinValue = 0,
                    MaxValue = 255,
                    NeutralValue = 0
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
            MaxValue = 255,
            NeutralValue = 0
        },

        new ChannelInfo()
        {
            Name = "Green",
            Data = splitChannels[1],
            MinValue = 0,
            MaxValue = 255,
            NeutralValue = 0
        },

        new ChannelInfo()
        {
            Name = "Red",
            Data = splitChannels[2],
            MinValue = 0,
            MaxValue = 255,
            NeutralValue = 0
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
            MaxValue = 255,
            NeutralValue = 0



        },

        new ChannelInfo()
        {
            Name = "A (Green - Red)",
            Data = splitChannels[1],
            MinValue = 0,
            MaxValue = 255,
            NeutralValue = 128
        },

        new ChannelInfo()
        {
            Name = "B (Blue - Yellow)",
            Data = splitChannels[2],
            MinValue = 0,
            MaxValue = 255,
            NeutralValue = 128

        }
    };

            return model;
        }
        ///////////////////////////////////////////////////////////////////////////YUV
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
            Name = "Y (Luma)",
            Data = splitChannels[0],
            MinValue = 0,
            MaxValue = 255,
            NeutralValue = 0

        },

        new ChannelInfo()
        {
            Name = "U (Cb equivalent)",
            Data = splitChannels[1],
            MinValue = 0,
            MaxValue = 255,
            NeutralValue = 128

        },

        new ChannelInfo()
        {
            Name = "V (Cr equivalent)",
            Data = splitChannels[2],
            MinValue = 0,
            MaxValue = 255,
            NeutralValue = 128
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
            Name = "Y (Luma)",
            Data = splitChannels[0],
            MinValue= 16,
            MaxValue  = 235,
            NeutralValue = 16
        },

        new ChannelInfo()
        {
            Name = "Cb (Blue Chroma)",
            Data = splitChannels[1],
            MinValue = 16,
            MaxValue = 240,
            NeutralValue = 128
        },

        new ChannelInfo()
        {
            Name = "Cr (Red Chroma)",
            Data = splitChannels[2],
            MinValue = 16,
            MaxValue = 240,
            NeutralValue = 128
        }
    };

            return model;
        }
    }
}
