using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CropperCore.Classes.Events
{
    public class CropperEvents : IDisposable
    {
        internal CropperEvents()
        { }

        /// <summary>
        ///  Delegate for raedy event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public delegate Task EventHandlerAsync(object sender, EventArgs e);
        public delegate Task EventCropStartHandlerAsync(object sender, EventCropChangeArgs e);
        public delegate Task EventCropMoveHandlerAsync(object sender, EventCropChangeArgs e);
        public delegate Task EventCropEndHandlerAsync(object sender, EventCropChangeArgs e);
        public delegate Task EventCropHandlerAsync(object sender, EventCropArgs e);
        public delegate Task EventZoomHandlerAsync(object sender, EventZoomChangeArgs e);
        public event EventHandlerAsync? Ready;
        public event EventCropStartHandlerAsync? CropStart;
        public event EventCropMoveHandlerAsync? CropMove;
        public event EventCropEndHandlerAsync? CropEnd;
        public event EventCropHandlerAsync? Crop;
        public event EventZoomHandlerAsync? Zoom;

        internal async Task OnReady(EventArgs args)
        {
            if (Ready is not null)
            {
                await Ready.Invoke(this, args);
            }
        }

        internal async Task OnCropStart(EventCropChangeArgs args)
        {
            if (CropStart is not null)
            {
                await CropStart.Invoke(this, args);
            }
        }

        internal async Task OnCropMove(EventCropChangeArgs args)
        {
            if (CropMove is not null)
            {
                await CropMove.Invoke(this, args);
            }
        }

        internal async Task OnCropEnd(EventCropChangeArgs args)
        {
            if (CropEnd is not null)
            {
                await CropEnd.Invoke(this, args);
            }
        }

        internal async Task OnCrop(EventCropArgs args)
        {
            if (Crop is not null)
            {
                await Crop.Invoke(this, args);
            }
        }

        internal async Task OnZoom(EventZoomChangeArgs args)
        {
            if (Zoom is not null)
            {
                await Zoom.Invoke(this, args);
            }
        }

        public void Dispose()
        {
            if (Ready is not null)
            {
                Delegate[] clientList = Ready.GetInvocationList();
                foreach (var d in clientList)
                    Ready -= (d as EventHandlerAsync);
            }
            if (CropStart is not null)
            {
                Delegate[] clientList = CropStart.GetInvocationList();
                foreach (var d in clientList)
                    CropStart -= (d as EventCropStartHandlerAsync);
            }
            if (CropMove is not null)
            {
                Delegate[] clientList = CropMove.GetInvocationList();
                foreach (var d in clientList)
                    CropMove -= (d as EventCropMoveHandlerAsync);
            }
            if (CropEnd is not null)
            {
                Delegate[] clientList = CropEnd.GetInvocationList();
                foreach (var d in clientList)
                    CropEnd -= (d as EventCropEndHandlerAsync);
            }
            if (Crop is not null)
            {
                Delegate[] clientList = Crop.GetInvocationList();
                foreach (var d in clientList)
                    Crop -= (d as EventCropHandlerAsync);
            }
            if (Zoom is not null)
            {
                Delegate[] clientList = Zoom.GetInvocationList();
                foreach (var d in clientList)
                    Zoom -= (d as EventZoomHandlerAsync);
            }
            Console.WriteLine($"{nameof(CropperEvents)}.Dispose()");
        }

        [JsonPropertyName("ready")]
        //public bool hasReady { get; set; } = true;
        public bool hasReady
        {
            get { return Ready != null; }
        }
        [JsonPropertyName("cropstart")]
        public bool hasCropstart
        {
            get { return CropStart != null; }
        }
        [JsonPropertyName("cropmove")]
        public bool hasCropmove
        {
            get { return CropMove != null; }
        }
        [JsonPropertyName("cropend")]
        public bool hasCropend
        {
            get { return CropEnd != null; }
        }
        [JsonPropertyName("crop")]
        public bool hasCrop
        {
            get { return Crop != null; }
        }
        [JsonPropertyName("zoom")]
        public bool hasZoom
        {
            get { return Zoom != null; }
        }
    }
}
