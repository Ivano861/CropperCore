using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CropperCore.Classes.Events
{
    public abstract class ZoomEventArgs
    {
        [JsonPropertyName("oldRatio")]
        public double OldRatio { get; set; }

        [JsonPropertyName("ratio")]
        public double Ratio { get; set; }
    }
}
