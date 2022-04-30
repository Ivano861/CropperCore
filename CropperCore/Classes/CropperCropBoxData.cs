using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CropperCore.Classes
{
    public class CropperCropBoxData
    {
        /// <summary>
        /// the offset left of the crop box
        /// </summary>
        [JsonPropertyName("left")]
        public double Left { get; set; }

        /// <summary>
        /// the offset top of the crop box
        /// </summary>
        [JsonPropertyName("top")]
        public double Top { get; set; }

        /// <summary>
        /// the width of the crop box
        /// </summary>
        [JsonPropertyName("width")]
        public double Width { get; set; }

        /// <summary>
        /// the height of the crop box
        /// </summary>
        [JsonPropertyName("height")]
        public double Height { get; set; }
    }
}
