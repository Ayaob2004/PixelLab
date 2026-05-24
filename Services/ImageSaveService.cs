using System.Drawing;
using System.Drawing.Imaging;

namespace PixelLab.Services {
    public class ImageSaveService {
        public void SaveImage(Image image, string path, ImageFormat format) {
            image.Save(path, format);
        }
    }
}