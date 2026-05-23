using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelLab.Services.ColorSpaces
{
    //تعديل  اشرطة المركبات 
    //تعديل عم يكون لكل البكسلات من اجل تعديل  على مركلة واحدة اي قناة واحدة 
    class ChannelAdjustments
    {
        public static void DisableChannel(ColorSpaceModel model,int channelIndex)
        {
            if (channelIndex < 0 ||
                channelIndex >= model.Channels.Count)
            {
                return;
            }
            model.Channels[channelIndex].Data.SetTo(new MCvScalar(0));
            model.Channels[channelIndex].Enabled = false;
        }


        public static void AddValueToChannel(ColorSpaceModel model,int channelIndex,double value)
        {
            if (channelIndex < 0 ||
                channelIndex >= model.Channels.Count)
            {
                return;
            }

            CvInvoke.Add(model.Channels[channelIndex].Data,new ScalarArray(value),model.Channels[channelIndex].Data);
        }
    }
}
