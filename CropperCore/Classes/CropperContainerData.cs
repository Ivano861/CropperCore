using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CropperCore.Classes
{
    public class CropperContainerData
    {
        /// <summary>
        /// the current width of the container
        /// </summary>
        [JsonPropertyName("width")]
        public double Width { get; set; }

        /// <summary>
        /// the current height of the container
        /// </summary>
        [JsonPropertyName("height")]
        public double Height { get; set; }
    }
}
