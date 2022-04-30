using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CropperCore.Classes
{
    public class CropperData
    {
        /// <summary>
        /// the offset left of the cropped area
        /// </summary>
        [JsonPropertyName("x")]
        public double X { get; set; }

        /// <summary>
        /// the offset top of the cropped area
        /// </summary>
        [JsonPropertyName("y")]
        public double Y { get; set; }

        /// <summary>
        /// the width of the cropped area
        /// </summary>
        [JsonPropertyName("width")]
        public double Width { get; set; }

        /// <summary>
        /// the height of the cropped area
        /// </summary>
        [JsonPropertyName("height")]
        public double Height { get; set; }

        /// <summary>
        /// the rotated degrees of the image
        /// </summary>
        [JsonPropertyName("rotate")]
        public double Rotate { get; set; }

        /// <summary>
        /// the scaling factor to apply on the abscissa of the image
        /// </summary>
        [JsonPropertyName("scaleX")]
        public double ScaleX { get; set; }

        /// <summary>
        /// the scaling factor to apply on the ordinate of the image
        /// </summary>
        [JsonPropertyName("scaleY")]
        public double ScaleY { get; set; }
    }
}
