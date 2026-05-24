using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using PixelLab.Services;
using Emgu.CV;
using PixelLab.Services.ColorSpaces;

namespace PixelLab

{
    public partial class formShowImg : Form
    {
        private ImageQuantizationColorsService quantizeImg = new ImageQuantizationColorsService();
        private ImageInfoService imageInfoService = new ImageInfoService();
        private ImageSaveService imageSaveService = new ImageSaveService();
        private Bitmap orginalImage;
        public formShowImg()
        {
            InitializeComponent();
        }

        private void formShowImg_Load(object sender, EventArgs e)
        {
            picImg.AllowDrop = true;
        }

        string[] files = null;

        private string currentImagePath = "";
        private void picImg_DragEnter(object sender, DragEventArgs e)
        {
            files = (string[])e.Data.GetData(DataFormats.FileDrop);
            string pathExImg = Path.GetExtension(files[0]);
            if ((pathExImg == ".jpg" || pathExImg == ".png") && files.Count() == 1)
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void picImg_DragDrop(object sender, DragEventArgs e)
        {
            currentImagePath = files[0];
            orginalImage = new Bitmap(currentImagePath);
            picImg.Image = new Bitmap(orginalImage);
            ShowImageInfo();
        }
        private void btnImg_Click(object sender, EventArgs e)
        {
            ofd.Title = "Select Image";
            ofd.Filter = "jpg file|*.jpg| png flie|*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                currentImagePath = ofd.FileName;
                orginalImage = new Bitmap(currentImagePath);
                picImg.Image = new Bitmap(orginalImage);
                ShowImageInfo();
            }
        }

        private void btnQuantize_Click(object sender, EventArgs e)
        {
            if (picImg.Image == null)
            {
                MessageBox.Show("Select Image First !!");
                return;
            }
            Bitmap orginal = new Bitmap(picImg.Image);
            Bitmap result = quantizeImg.Quantize(orginal, 24);
            picImg.Image = result;

        }

        private void ColorCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (picImg.Image == null)
            {
                MessageBox.Show("Please select an image first.");
                return;
            }
            if (ColorCount.SelectedIndex == 0)
            {
                return;
            }
            int colorCount = int.Parse(ColorCount.SelectedItem.ToString());

            Bitmap result = quantizeImg.Quantize(orginalImage, colorCount);
            picImg.Image = result;
        }




        private void ShowImageInfo() {
            if (string.IsNullOrEmpty(currentImagePath) || picImg.Image == null) {
                return;
            }

            ImageInfo info = imageInfoService.GetImageInfo(currentImagePath, picImg.Image);

            lblFileNameValue.Text = info.FileName;
            lblPathValue.Text = info.Path;
            lblFormatValue.Text = info.Format;
            lblAspectRatioValue.Text = info.AspectRatio;
            lblDimensionsValue.Text = info.Dimensions;
            lblFileSizeValue.Text = info.FileSize;
            lblPixelCountValue.Text = info.PixelCount;
            lblDpiValue.Text = info.Dpi;
            lblPixelFormatValue.Text = info.PixelFormat;
            lblColorDepthValue.Text = info.ColorDepth;
            lblLastModifiedValue.Text = info.LastModified;

            toolTip1.SetToolTip(lblFileNameValue, info.FileName);
            toolTip1.SetToolTip(lblPathValue, info.Path);
        }
        private void btnSaveImage_Click(object sender, EventArgs e) {
            if (picImg.Image == null) {
                MessageBox.Show("Please select an image first.");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save Image";
            sfd.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp";
            sfd.FileName = "edited_image";

            if (sfd.ShowDialog() == DialogResult.OK) {
                System.Drawing.Imaging.ImageFormat format;
                string extension = Path.GetExtension(sfd.FileName).ToLower();
                if (extension == ".jpg") {
                    format = System.Drawing.Imaging.ImageFormat.Jpeg;
                } else if (extension == ".bmp") {
                    format = System.Drawing.Imaging.ImageFormat.Bmp;
                } else {
                    format = System.Drawing.Imaging.ImageFormat.Png;
                }
                imageSaveService.SaveImage(picImg.Image, sfd.FileName, format);
                MessageBox.Show("Image saved successfully.");
            }
        }

        private void picImg_Click_1(object sender, EventArgs e)
        {

        }

   
    }
}
