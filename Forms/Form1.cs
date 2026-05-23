using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PixelLab.Services;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using PixelLab.Services.ColorSpaces;





namespace PixelLab.Forms
{
    public partial class Form1 : Form
    {
        Bitmap originalImage;

        ColorSpaceModel model;
        ColorSpaceModel baseModel;
        private void ApplyAllAdjustments()
        {
            if (baseModel == null) return;

            model = baseModel.Copy();

            ChannelAdjustments.AddValueToChannel(
                model,
                0,
                track_bar_channel1.Value
            );

            ChannelAdjustments.AddValueToChannel(
                model,
                1,
                track_bar_channel2.Value
            );

            ChannelAdjustments.AddValueToChannel(
                model,
                2,
                track_bar_channel3.Value
            );

            if (model.Channels.Count > 3)
            {
                ChannelAdjustments.AddValueToChannel(
                    model,
                    3,
                    track_bar_channel4.Value
                );
            }

            image_picture_box.Image =
                ChannelMerger.Merge(model).ToBitmap();
        }


        public Form1()
        {
            InitializeComponent();
            color_systems.SelectedIndex = 0;
            reset_button.Visible = false;
            color_systems.Visible = false;
            label1.Visible = false;//choose a color system label

            channel1.Visible = false;
            channel2.Visible = false;
            channel3.Visible = false;
            channel4.Visible = false;

            track_bar_channel1.Visible = false;
            track_bar_channel2.Visible = false;
            track_bar_channel3.Visible = false;
            track_bar_channel4.Visible = false;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void reset_button_Click(object sender, EventArgs e)
        {
            image_picture_box.Image = originalImage;
            color_systems.SelectedIndex = 0;

            track_bar_channel1.Value = 0;
            track_bar_channel2.Value = 0;
            track_bar_channel3.Value = 0;
            track_bar_channel4.Value = 0;

        }

        private void select_image_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Bitmap img = new Bitmap(ofd.FileName);

                originalImage = new Bitmap(img);
                image_picture_box.Image = originalImage;
                select_image_button.Visible = false;
                reset_button.Visible = true;
                color_systems.Visible = true;

            }
        }

        private void color_systems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (originalImage == null) return;

            string choice = color_systems.Text;

            // إخفاء السلايدرز دائمًا
            channel1.Visible = channel2.Visible = channel3.Visible = channel4.Visible = false;
            track_bar_channel1.Visible = track_bar_channel2.Visible =
                track_bar_channel3.Visible = track_bar_channel4.Visible = false;

            Bitmap resultBitmap = null;
            Mat inputMat = originalImage.ToImage<Bgr, byte>().Mat;
            Mat resultMat = null;

            // 🔴 RGB (Bitmap مباشر)
            if (choice == "RGB")
            {
                resultBitmap = originalImage;
                baseModel = ChannelProcessor.GetRGBChannels(inputMat);
                SetupUI(3, new[] { "Blue", "Green" ,"Red"});
                image_picture_box.Image = resultBitmap;
                
                return;
            }

            // 🟡 CMY (Bitmap مباشر)
            if (choice == "CMY")
            {
                resultBitmap = ColorSystems.ToCmy(originalImage);
                baseModel = null;
                image_picture_box.Image = resultBitmap;
                return;
            }

            // 🔵 باقي الأنظمة (Mat + sliders)
            switch (choice)
            {
                case "HSV":
                    resultMat = ColorSystems.ToHsv(inputMat);
                    baseModel = ChannelProcessor.GetHSVChannels(inputMat);
                    SetupUI(3, new[] { "Hue", "Saturation", "Value" });
                    break;

                case "YCbCr":
                    resultMat = ColorSystems.ToYcbcr(inputMat);
                    /*baseModel = ChannelProcessor.GetYCbCrChannels(inputMat);
                    SetupUI(3, new[] { "Y", "Cb", "Cr" });*/
                    break;

                case "YUV":
                    resultMat = ColorSystems.ToYuv(inputMat);
                    baseModel = ChannelProcessor.GetYUVChannels(inputMat);
                    SetupUI(3, new[] { "Y", "U", "V" });
                    break;

                case "LAB":
                    resultMat = ColorSystems.ToLab(inputMat);
                    baseModel = ChannelProcessor.GetLABChannels(inputMat);
                    SetupUI(3, new[] { "L", "A", "B" });
                    break;

                case "CMYK":
                    resultMat = ColorSystems.ToCmyk(inputMat);
                    baseModel = ChannelProcessor.GetCMYKChannels(inputMat);
                    SetupUI(4, new[] { "C", "M", "Y", "K" });
                    break;
            }
            /*if(resultMat == null)
            {
                MessageBox.Show("Color system not supported or failed conversion");
            }*/

            image_picture_box.Image =
                resultMat.ToImage<Bgr, byte>().ToBitmap();
        }

        private void SetupUI(int count, string[] names)
        {
            TrackBar[] sliders = {
        track_bar_channel1,
        track_bar_channel2,
        track_bar_channel3,
        track_bar_channel4
    };

            Label[] labels = {
        channel1,
        channel2,
        channel3,
        channel4
    };

            for (int i = 0; i < count; i++)
            {
                sliders[i].Visible = true;
                sliders[i].Minimum = -179;
                sliders[i].Maximum = 179;

                // أهم سطر
                if (sliders[i].Value < sliders[i].Minimum ||
                    sliders[i].Value > sliders[i].Maximum)
                {
                    sliders[i].Value = 0;
                }

                labels[i].Visible = true;
                labels[i].Text = names[i];
            }
        }

        private void track_bar_channel1_Scroll_1(object sender, EventArgs e)
        {
            ApplyAllAdjustments();


        }

        private void track_bar_channel2_Scroll(object sender, EventArgs e)
        {
            ApplyAllAdjustments();
        }

        private void track_bar_channel3_Scroll(object sender, EventArgs e)
        {
            ApplyAllAdjustments();

        }
        private void track_bar_channel4_Scroll(object sender, EventArgs e)
        {
            ApplyAllAdjustments();
        }




        private void channel1_Click(object sender, EventArgs e)
        {

        }

        
    }
}
