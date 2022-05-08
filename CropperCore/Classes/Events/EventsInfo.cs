using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CropperCore.Classes.Events
{
    /// <summary>
    /// Info for events init on javascript
    /// </summary>
    internal class EventsInfo
    {
        [JsonPropertyName("ready")]
        public bool HasReady { get; set; } = false;

        [JsonPropertyName("cropstart")]
        public bool HasCropstart { get; set; } = false;

        [JsonPropertyName("cropmove")]
        public bool HasCropmove { get; set; } = false;

        [JsonPropertyName("cropend")]
        public bool HasCropend { get; set; } = false;

        [JsonPropertyName("crop")]
        public bool HasCrop { get; set; } = false;

        [JsonPropertyName("zoom")]
        public bool HasZoom { get; set; } = false;
    }
}
