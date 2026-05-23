using PixelLab.Services.ColorSpaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelLab.Services.ColorSpaces
{
    ///تعبر عن النظام اللوني مستخدم ومعلومات عن قنواته 
    class ColorSpaceModel
    {
        public string ColorSpaceName { get; set; }
        public List<ChannelInfo> Channels { get; set; }

        public ColorSpaceModel Copy()
        {
            ColorSpaceModel newModel = new ColorSpaceModel();

            newModel.ColorSpaceName = this.ColorSpaceName;
            newModel.Channels = new List<ChannelInfo>();

            foreach (var ch in this.Channels)
            {
                newModel.Channels.Add(new ChannelInfo
                {
                    Name = ch.Name,
                    Data = ch.Data.Clone()   // مهم جدًا
                });
            }

            return newModel;
        }
    }
}
