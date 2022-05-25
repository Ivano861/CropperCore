﻿using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CropperCore.Classes.Events
{
    public class ZoomWheelEventArgs : ZoomEventArgs
    {
        [JsonPropertyName("originalEvent")]
        public WheelEventArgs Wheel { get; set; } = null!;
    }
}
