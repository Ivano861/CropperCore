using CropperCore.Converters;
using CropperCore.Enumerates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CropperCore.Classes
{
    public class CropperCroppedCanvas
    {
        /// <summary>
        /// the destination width of the output canvas.
        /// </summary>
        [JsonConverter(typeof(DoubleConverterJSON))]
        [JsonPropertyName("width")]
        public double Width { get; set; }

        /// <summary>
        /// the destination height of the output canvas.
        /// </summary>
        [JsonConverter(typeof(DoubleConverterJSON))]
        [JsonPropertyName("height")]
        public double Height { get; set; }

        /// <summary>
        /// the minimum destination width of the output canvas, the default value is 0.
        /// </summary>
        [JsonConverter(typeof(DoubleConverterJSON))]
        [JsonPropertyName("minWidth")]
        public double MinWidth { get; set; } = 0.0;

        /// <summary>
        /// the minimum destination height of the output canvas, the default value is 0.
        /// </summary>
        [JsonConverter(typeof(DoubleConverterJSON))]
        [JsonPropertyName("minHeight")]
        public double MinHeight { get; set; } = 0.0;

        /// <summary>
        /// the maximum destination width of the output canvas, the default value is Infinity.
        /// </summary>
        [JsonConverter(typeof(DoubleConverterJSON))]
        [JsonPropertyName("maxWidth")]
        public double MaxWidth { get; set; } = double.PositiveInfinity;

        /// <summary>
        /// the maximum destination height of the output canvas, the default value is Infinity.
        /// </summary>
        [JsonConverter(typeof(DoubleConverterJSON))]
        [JsonPropertyName("maxHeight")]
        public double MaxHeight { get; set; } = double.PositiveInfinity;

        /// <summary>
        /// a color to fill any alpha values in the output canvas, the default value is the transparent.
        /// </summary>
        [JsonPropertyName("fillColor")]
        public string FillColor { get; set; } = "transparent";

        /// <summary>
        /// set to change if images are smoothed (true, default) or not (false).
        /// </summary>
        [JsonPropertyName("imageSmoothingEnabled")]
        public bool ImageSmoothingEnabled { get; set; } = true;

        /// <summary>
        /// set the quality of image smoothing, one of "low" (default), "medium", or "high".
        /// </summary>
        [JsonPropertyName("imageSmoothingQuality")]
        public ImageSmoothingQuality ImageSmoothingQuality { get; set; } = ImageSmoothingQuality.Low;
    }
}
