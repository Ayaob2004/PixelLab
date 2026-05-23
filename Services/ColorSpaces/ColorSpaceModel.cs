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
            var newModel = new ColorSpaceModel
            {
                ColorSpaceName = this.ColorSpaceName,
                Channels = new List<ChannelInfo>()
            };

            foreach (var ch in this.Channels)
            {
                newModel.Channels.Add(new ChannelInfo
                {
                    Name = ch.Name,
                    Data = ch.Data.Clone(),  
                    Enabled = ch.Enabled,
                    MinValue = ch.MinValue,
                    MaxValue = ch.MaxValue,
                    NeutralValue = ch.NeutralValue   
                });
            }

            return newModel;
        }
    }
}
