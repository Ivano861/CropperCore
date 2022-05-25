using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CropperCore.Classes.Events
{
    public class ZoomPointerEventArgs : ZoomEventArgs
    {
        [JsonPropertyName("originalEvent")]
        public PointerEventArgs PointerMove { get; set; } = null!;
    }
}
