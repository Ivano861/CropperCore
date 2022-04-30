using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CropperCore.Classes
{
    public class CropperSetCanvasData
    {
        /// <summary>
        /// the offset left of the canvas
        /// </summary>
        [JsonPropertyName("left")]
        public double Left { get; set; }

        /// <summary>
        /// the offset top of the canvas
        /// </summary>
        [JsonPropertyName("top")]
        public double Top { get; set; }

        /// <summary>
        /// the width of the canvas
        /// </summary>
        [JsonPropertyName("width")]
        public double Width { get; set; }

        /// <summary>
        /// the height of the canvas
        /// </summary>
        [JsonPropertyName("height")]
        public double Height { get; set; }
    }

    public class CropperGetCanvasData : CropperSetCanvasData
    {
        /// <summary>
        /// the natural width of the canvas (read only)
        /// </summary>
        [JsonPropertyName("naturalWidth")]
        public double NaturalWidth { get; set; }

        /// <summary>
        /// the natural height of the canvas (read only)
        /// </summary>
        [JsonPropertyName("naturalHeight")]
        public double NaturalHeight { get; set; }
    }
}
