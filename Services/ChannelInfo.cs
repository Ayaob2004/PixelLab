using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelLab.Services
{
    //معلومات قناة لونية لوحدها 
    class ChannelInfo
    {
        public string Name { get; set; }
        public Mat Data { get; set; }//  تخزن الصورة لقناة الواحدة(التي نستعرض معلوماته)ا
        public bool Enabled { get; set; } = true;
    }
}
