using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CropperCore.Classes
{
    public class CropperImageData
    {
        /// <summary>
        /// the offset left of the image
        /// </summary>
        [JsonPropertyName("left")]
        public double Left { get; set; }

        /// <summary>
        /// the offset top of the image
        /// </summary>
        [JsonPropertyName("top")]
        public double Top { get; set; }

        /// <summary>
        /// the width of the image
        /// </summary>
        [JsonPropertyName("width")]
        public double Width { get; set; }

        /// <summary>
        /// the height of the image
        /// </summary>
        [JsonPropertyName("height")]
        public double Height { get; set; }

        /// <summary>
        /// the natural width of the image
        /// </summary>
        [JsonPropertyName("naturalWidth")]
        public double NaturalWidth { get; set; }

        /// <summary>
        /// the natural height of the image
        /// </summary>
        [JsonPropertyName("naturalHeight")]
        public double NaturalHeight { get; set; }

        /// <summary>
        /// the aspect ratio of the image
        /// </summary>
        [JsonPropertyName("aspectRatio")]
        public double AspectRatio { get; set; }

        /// <summary>
        /// the rotated degrees of the image if it is rotated
        /// </summary>
        [JsonPropertyName("rotate")]
        public double Rotate { get; set; }

        /// <summary>
        /// the scaling factor to apply on the abscissa of the image if scaled
        /// </summary>
        [JsonPropertyName("scaleX")]
        public double ScaleX { get; set; }

        /// <summary>
        /// the scaling factor to apply on the ordinate of the image if scaled
        /// </summary>
        [JsonPropertyName("scaleY")]
        public double ScaleY { get; set; }
    }
}
