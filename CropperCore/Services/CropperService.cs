using CropperCore.Classes;
using CropperCore.Classes.Events;
using CropperCore.Enumerates;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using CropperCore.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace CropperCore.Services
{
    public class CropperService : IDisposable
    {
        private DotNetObjectReference<CropperService>? DotNetHelper { get; set; }

        #region Properties
        private IJSRuntime JsRuntime { get; set; }

        public CropperEvents Events { get; private set; }

        public bool IsCreate { get; private set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Create service with IJSRuntime injection
        /// </summary>
        /// <param name="jsRuntime"></param>
        public CropperService(IJSRuntime jsRuntime)
        {
            IsCreate = false;
            JsRuntime = jsRuntime;
            DotNetHelper = DotNetObjectReference.Create(this);
            Events = new CropperEvents();
        }
        #endregion

        #region Events callback
        [JSInvokable]
        public async Task OnReadyDelegate()
        {
            await Events.OnReady(new EventArgs());
        }
        [JSInvokable]
        public async Task OnCropStartDelegate(EventCropChangeArgs args)
        {
            await Events.OnCropStart(args);
        }
        [JSInvokable]
        public async Task OnCropMoveDelegate(EventCropChangeArgs args)
        {
            await Events.OnCropMove(args);
        }
        [JSInvokable]
        public async Task OnCropEndDelegate(EventCropChangeArgs args)
        {
            await Events.OnCropEnd(args);
        }
        [JSInvokable]
        public async Task OnCropDelegate(EventCropArgs args)
        {
            await Events.OnCrop(args);
        }
        [JSInvokable]
        public async Task OnZoomDelegate(EventZoomChangeArgs args)
        {
            await Events.OnZoom(args);
        }
        #endregion

        #region Events active/disactive
        public async Task AddOnReady()
        {
            await JsRuntime.InvokeVoidAsync("CropCore.addReady", DotNetHelper);
        }
        public async Task RemoveOnReady(/*Func<Task> action*/)
        {
            await JsRuntime.InvokeVoidAsync("CropCore.removeReady");
        }

        public async Task AddOnCropStart()
        {
            await JsRuntime.InvokeVoidAsync("CropCore.addCropStart", DotNetHelper);
        }
        public async Task RemoveOnCropStart(/*Func<Task> action*/)
        {
            await JsRuntime.InvokeVoidAsync("CropCore.removeCropStart");
        }

        public async Task AddOnCropMove()
        {
            await JsRuntime.InvokeVoidAsync("CropCore.addCropMove", DotNetHelper);
        }
        public async Task RemoveOnCropMove(/*Func<Task> action*/)
        {
            await JsRuntime.InvokeVoidAsync("CropCore.removeCropMove");
        }

        public async Task AddOnCropEnd()
        {
            await JsRuntime.InvokeVoidAsync("CropCore.addCropEnd", DotNetHelper);
        }
        public async Task RemoveOnCropEnd(/*Func<Task> action*/)
        {
            await JsRuntime.InvokeVoidAsync("CropCore.removeCropEnd");
        }

        public async Task AddOnCrop()
        {
            await JsRuntime.InvokeVoidAsync("CropCore.addCrop", DotNetHelper);
        }
        public async Task RemoveOnCrop(/*Func<Task> action*/)
        {
            await JsRuntime.InvokeVoidAsync("CropCore.removeCrop");
        }

        public async Task AddOnZoom()
        {
            await JsRuntime.InvokeVoidAsync("CropCore.addZoom", DotNetHelper);
        }
        public async Task RemoveOnZoom(/*Func<Task> action*/)
        {
            await JsRuntime.InvokeVoidAsync("CropCore.removeZoom");
        }
        #endregion

        #region Methods
        /// <summary>
        /// Create a new cropper object
        /// </summary>
        /// <param name="id">The ID of the HTML element that contains the image</param>
        /// <param name="options">Optional object that contains properties for creating the cropper object</param>
        /// <remarks>
        /// The HTML element can only be a img or canvas
        /// </remarks>
        public async Task Create(string id, CropperOtions? options = null)
        {
            try
            {
                await JsRuntime.InvokeVoidAsync("CropCore.createCrop", id, options, DotNetHelper, Events);
                IsCreate = true;
            }
            catch (JSException ex)
            {
                string message = ex.Message;
                throw;
            }
        }

        /// <summary>
        /// Create a new cropper object
        /// </summary>
        /// <param name="el">HTML element that contains the image</param>
        /// <param name="options">Optional object that contains properties for creating the cropper object</param>
        /// <remarks>
        /// The HTML element can only be a img or canvas
        /// </remarks>
        public async Task Create(ElementReference el, CropperOtions? options = null)
        {
            try
            {
                await JsRuntime.InvokeVoidAsync("CropCore.createCrop", el, options, DotNetHelper, Events);
                IsCreate = true;
            }
            catch (JSException ex)
            {
                string message = ex.Message;
                throw;
            }
        }

        public async Task ConfirmCrop()
        {
            try
            {
                await JsRuntime.InvokeVoidAsync("CropCore.confirmCrop");
            }
            catch (JSException ex)
            {
                string message = ex.Message;
                throw;
            }
        }

        public async Task Crop()
        {
            try
            {
                await JsRuntime.InvokeVoidAsync("CropCore.crop");
            }
            catch (JSException ex)
            {
                string message = ex.Message;
                throw;
            }
        }

        public async Task Reset()
        {
            try
            {
                await JsRuntime.InvokeVoidAsync("CropCore.reset");
            }
            catch (JSException ex)
            {
                string message = ex.Message;
                throw;
            }
        }
        public async Task Clear()
        {
            try
            {
                await JsRuntime.InvokeVoidAsync("CropCore.clear");
            }
            catch (JSException ex)
            {
                string message = ex.Message;
                throw;
            }
        }

        public async Task Enable()
        {
            try
            {
                await JsRuntime.InvokeVoidAsync("CropCore.enable");
            }
            catch (JSException ex)
            {
                string message = ex.Message;
                throw;
            }
        }
        public async Task Disable()
        {
            try
            {
                await JsRuntime.InvokeVoidAsync("CropCore.disable");
            }
            catch (JSException ex)
            {
                string message = ex.Message;
                throw;
            }
        }
        public async Task Destroy()
        {
            try
            {
                await JsRuntime.InvokeVoidAsync("CropCore.destroy");
                IsCreate = false;
            }
            catch (JSException ex)
            {
                string message = ex.Message;
                throw;
            }
        }
        public async Task Move(double offsetX, double? offsetY = null)
        {
            try
            {
                await JsRuntime.InvokeVoidAsync("CropCore.move", offsetX, offsetY);
            }
            catch (JSException ex)
            {
                string message = ex.Message;
                throw;
            }
        }
        public async Task MoveTo(double x, double? y = null)
        {
            try
            {
                await JsRuntime.InvokeVoidAsync("CropCore.moveTo", x, y);
            }
            catch (JSException ex)
            {
                string message = ex.Message;
                throw;
            }
        }
        public async Task Zoom(double ratio)
        {
            try
            {
                await JsRuntime.InvokeVoidAsync("CropCore.zoom", ratio);
            }
            catch (JSException ex)
            {
                string message = ex.Message;
                throw;
            }
        }
        public async Task ZoomTo(double ratio, CropperZoomSchema? schema = null)
        {
            try
            {
                await JsRuntime.InvokeVoidAsync("CropCore.zoomTo", ratio, schema);
            }
            catch (JSException ex)
            {
                string message = ex.Message;
                throw;
            }
        }
        public async Task Rotate(double degree)
        {
            try
            {
                await JsRuntime.InvokeVoidAsync("CropCore.rotate", degree);
            }
            catch (JSException ex)
            {
                string message = ex.Message;
                throw;
            }
        }
        public async Task RotateTo(double degree)
        {
            try
            {
                await JsRuntime.InvokeVoidAsync("CropCore.rotateTo", degree);
            }
            catch (JSException ex)
            {
                string message = ex.Message;
                throw;
            }
        }
        public async Task Scale(double scaleX, double? scaleY = null)
        {
            try
            {
                await JsRuntime.InvokeVoidAsync("CropCore.scale", scaleX, scaleY);
            }
            catch (JSException ex)
            {
                string message = ex.Message;
                throw;
            }
        }
        public async Task ScaleX(double scaleX)
        {
            try
            {
                await JsRuntime.InvokeVoidAsync("CropCore.scaleX", scaleX);
            }
            catch (JSException ex)
            {
                string message = ex.Message;
                throw;
            }
        }
        public async Task ScaleY(double scaleY)
        {
            try
            {
                await JsRuntime.InvokeVoidAsync("CropCore.scaleY", scaleY);
            }
            catch (JSException ex)
            {
                string message = ex.Message;
                throw;
            }
        }
        public async Task<CropperData> GetData(bool? rounded = false)
        {
            try
            {
                return await JsRuntime.InvokeAsync<CropperData>("CropCore.getData", rounded);
            }
            catch (JSException ex)
            {
                string message = ex.Message;
                throw;
            }
        }
        public async Task<CropperData> SetData(CropperData data)
        {
            try
            {
                return await JsRuntime.InvokeAsync<CropperData>("CropCore.setData", data);
            }
            catch (JSException ex)
            {
                string message = ex.Message;
                throw;
            }
        }

        public async Task<CropperContainerData> GetContainerData()
        {
            try
            {
                return await JsRuntime.InvokeAsync<CropperContainerData>("CropCore.getContainerData");
            }
            catch (JSException ex)
            {
                string message = ex.Message;
                throw;
            }
        }
        public async Task<CropperImageData> GetImageData()
        {
            try
            {
                return await JsRuntime.InvokeAsync<CropperImageData>("CropCore.getImageData");
            }
            catch (JSException ex)
            {
                string message = ex.Message;
                throw;
            }
        }
        public async Task<CropperGetCanvasData> GetCanvasData()
        {
            try
            {
                return await JsRuntime.InvokeAsync<CropperGetCanvasData>("CropCore.getCanvasData");
            }
            catch (JSException ex)
            {
                string message = ex.Message;
                throw;
            }
        }
        public async Task SetCanvasData(CropperSetCanvasData data)
        {
            try
            {
                await JsRuntime.InvokeVoidAsync("CropCore.setCanvasData", data);
            }
            catch (JSException ex)
            {
                string message = ex.Message;
                throw;
            }
        }
        public async Task<CropperCropBoxData> GetCropBoxData()
        {
            try
            {
                return await JsRuntime.InvokeAsync<CropperCropBoxData>("CropCore.getCropBoxData");
            }
            catch (JSException ex)
            {
                string message = ex.Message;
                throw;
            }
        }
        public async Task SetCropBoxData(CropperCropBoxData data)
        {
            try
            {
                await JsRuntime.InvokeVoidAsync("CropCore.setCropBoxData", data);
            }
            catch (JSException ex)
            {
                string message = ex.Message;
                throw;
            }
        }

        public async Task GetCroppedCanvas(ElementReference dest, CropperCroppedCanvas options)
        {
            try
            {
                await JsRuntime.InvokeVoidAsync("CropCore.getCroppedCanvas", dest, options);
            }
            catch (JSException ex)
            {
                string message = ex.Message;
                throw;
            }
        }
        public async Task GetCroppedCanvas(string idDest, CropperCroppedCanvas options)
        {
            try
            {
                await JsRuntime.InvokeVoidAsync("CropCore.getCroppedCanvas", idDest, options);
            }
            catch (JSException ex)
            {
                string message = ex.Message;
                throw;
            }
        }
        public async Task GetCroppedCanvas(CropperCroppedCanvas options)
        {
            try
            {
                var t = await JsRuntime.InvokeAsync<object>("CropCore.getCroppedCanvasHTML", options);
            }
            catch (JSException ex)
            {
                string message = ex.Message;
                throw;
            }
        }

        public async Task SetAspectRatio(double aspectRatio)
        {
            try
            {
                await JsRuntime.InvokeVoidAsync("CropCore.setAspectRatio", (double.IsFinite(aspectRatio) ? aspectRatio : "NaN"));
            }
            catch (JSException ex)
            {
                string message = ex.Message;
                throw;
            }
        }
        public async Task SetDragMode(DragMode mode)
        {
            try
            {
                await JsRuntime.InvokeVoidAsync("CropCore.setDragMode", (Enum.GetName(typeof(DragMode), mode) ?? "").ToLower());
            }
            catch (JSException ex)
            {
                string message = ex.Message;
                throw;
            }
        }
        #endregion

        public void Dispose()
        {
            Events?.Dispose();
            DotNetHelper?.Dispose();
            Console.WriteLine($"{nameof(CropperService)}.Dispose()");
        }
    }
}
