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

namespace PixelLab

{
    public partial class formShowImg : Form
    {
        private ImageQuantizationColorsService quantizeImg = new ImageQuantizationColorsService();
        public formShowImg()
        {
            InitializeComponent();
        }

        private void formShowImg_Load(object sender, EventArgs e)
        {
            picImg.AllowDrop = true;
        }
        string[] files = null;
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
            picImg.Image = Image.FromFile(files[0]);
        }
        private void btnImg_Click(object sender, EventArgs e)
        {
            ofd.Title = "Select Image";
            ofd.Filter = "jpg file|*.jpg| png flie|*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picImg.Image = Image.FromFile(ofd.FileName);
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
            Bitmap result = quantizeImg.Quantize(orginal, 16);
            picImg.Image = result;

        }

      
    }
}
