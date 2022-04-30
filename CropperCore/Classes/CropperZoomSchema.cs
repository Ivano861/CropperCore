using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CropperCore.Classes
{
    public class CropperZoomSchema
    {
        [JsonPropertyName("x")] 
        public double X { get; set; }

        [JsonPropertyName("y")] 
        public double Y { get; set; }
    }
}
