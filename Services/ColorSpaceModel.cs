using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelLab.Services
{
    ///تعبر عن النظام اللوني مستخدم ومعلومات عن قنواته 
    class ColorSpaceModel
    {
        public string ColorSpaceName { get; set; }
        public List<ChannelInfo> Channels { get; set; }
    }
}
