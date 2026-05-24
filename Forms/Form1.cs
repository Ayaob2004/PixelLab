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
using System.IO;

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

            checkBox1.Visible = false;
            checkBox2.Visible = false;
            checkBox3.Visible = false;
            checkBox4.Visible = false;

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            image_picture_box.AllowDrop = true;
        }

        private void reset_button_Click(object sender, EventArgs e)
        {
            image_picture_box.Image = originalImage;
            color_systems.SelectedIndex = 0;

            track_bar_channel1.Value = 0;
            track_bar_channel2.Value = 0;
            track_bar_channel3.Value = 0;
            track_bar_channel4.Value = 0;

            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;

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
                SetupUI(baseModel);
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
                    SetupUI(baseModel);
                    break;

                case "YCbCr":
                    resultMat = ColorSystems.ToYcbcr(inputMat);
                    baseModel = ChannelProcessor.GetYCbCrChannels(inputMat);
                    SetupUI(baseModel);
                    break;

                case "YUV":
                    resultMat = ColorSystems.ToYuv(inputMat);
                    baseModel = ChannelProcessor.GetYUVChannels(inputMat);
                    SetupUI(baseModel);
                    break;

                case "LAB":
                    resultMat = ColorSystems.ToLab(inputMat);
                    baseModel = ChannelProcessor.GetLABChannels(inputMat);
                    SetupUI(baseModel);
                    break;

                case "CMYK":
                    resultMat = ColorSystems.ToCmyk(inputMat);
                    baseModel = ChannelProcessor.GetCMYKChannels(inputMat);
                    SetupUI(baseModel);
                    break;
            }
            /*if(resultMat == null)
            {
                MessageBox.Show("Color system not supported or failed conversion");
            }*/

            image_picture_box.Image =
                resultMat.ToImage<Bgr, byte>().ToBitmap();
        }

        private void SetupUI(ColorSpaceModel m)
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

            CheckBox[] checkBoxes =
            {
                checkBox1,
                checkBox2,
                checkBox3,
                checkBox4
            };
            foreach (var slider in sliders)
            {
                slider.Minimum = -255;
                slider.Maximum = 255;
                slider.Value = 0;
            }

            checkBoxes[3].Visible = false;

            for (int i = 0; i < m.Channels.Count; i++)
            {
                

                sliders[i].Visible = true;
                labels[i].Visible = true;
                checkBoxes[i].Visible = true;

                labels[i].Text = m.Channels[i].Name;

                sliders[i].Minimum = m.Channels[i].MinValue;
                sliders[i].Maximum = m.Channels[i].MaxValue;
                sliders[i].Value = m.Channels[i].MinValue;

                checkBoxes[i].Checked = false;
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

        private void ApplyWithChannelToggle()
        {
            if (baseModel == null) return;

            model = baseModel.Copy();

            track_bar_channel1.Value = model.Channels[0].MinValue;
            track_bar_channel2.Value = model.Channels[1].MinValue;
            track_bar_channel3.Value = model.Channels[2].MinValue;

            if (model.Channels.Count > 3)
            {
                track_bar_channel4.Value = model.Channels[3].MinValue;
            }

            // تعطيل القنوات حسب الـ checkboxes
            if (checkBox1.Checked)
            {
                ChannelAdjustments.DisableChannel(model, 0);
            }

            if (checkBox2.Checked)
            {
                ChannelAdjustments.DisableChannel(model, 1);
            }

            if (checkBox3.Checked)
            {
                ChannelAdjustments.DisableChannel(model, 2);
            }

            if (model.Channels.Count > 3 && checkBox4.Checked)
            {
                ChannelAdjustments.DisableChannel(model, 3);
            }

            image_picture_box.Image =
                ChannelMerger.Merge(model).ToBitmap();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ApplyWithChannelToggle();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            ApplyWithChannelToggle();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            ApplyWithChannelToggle();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            ApplyWithChannelToggle();
        }
        string[] files = null;

        private string currentImagePath = "";
        private void image_picture_box_DragEnter(object sender, DragEventArgs e)
        {
            files = (string[])e.Data.GetData(DataFormats.FileDrop);
            string pathExImg = Path.GetExtension(files[0]);
            if ((pathExImg == ".jpg" || pathExImg == ".png") && files.Count() == 1)
            {
                e.Effect = DragDropEffects.All;
            }
        }
        private Bitmap orginalImage;
        private void image_picture_box_DragDrop(object sender, DragEventArgs e)
        {
            currentImagePath = files[0];
            orginalImage = new Bitmap(currentImagePath);
            image_picture_box.Image = new Bitmap(orginalImage);
            
        }
    }
}
