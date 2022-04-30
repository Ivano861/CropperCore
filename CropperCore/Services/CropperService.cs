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
            await JsRuntime.InvokeVoidAsync("CropCore.AddReady", DotNetHelper);
        }
        public async Task RemoveOnReady(/*Func<Task> action*/)
        {
            await JsRuntime.InvokeVoidAsync("CropCore.RemoveReady");
        }

        public async Task AddOnCropStart()
        {
            await JsRuntime.InvokeVoidAsync("CropCore.AddCropStart", DotNetHelper);
        }
        public async Task RemoveOnCropStart(/*Func<Task> action*/)
        {
            await JsRuntime.InvokeVoidAsync("CropCore.RemoveCropStart");
        }

        public async Task AddOnCropMove()
        {
            await JsRuntime.InvokeVoidAsync("CropCore.AddCropMove", DotNetHelper);
        }
        public async Task RemoveOnCropMove(/*Func<Task> action*/)
        {
            await JsRuntime.InvokeVoidAsync("CropCore.RemoveCropMove");
        }

        public async Task AddOnCropEnd()
        {
            await JsRuntime.InvokeVoidAsync("CropCore.AddCropEnd", DotNetHelper);
        }
        public async Task RemoveOnCropEnd(/*Func<Task> action*/)
        {
            await JsRuntime.InvokeVoidAsync("CropCore.RemoveCropEnd");
        }

        public async Task AddOnCrop()
        {
            await JsRuntime.InvokeVoidAsync("CropCore.AddCrop", DotNetHelper);
        }
        public async Task RemoveOnCrop(/*Func<Task> action*/)
        {
            await JsRuntime.InvokeVoidAsync("CropCore.RemoveCrop");
        }

        public async Task AddOnZoom()
        {
            await JsRuntime.InvokeVoidAsync("CropCore.AddZoom", DotNetHelper);
        }
        public async Task RemoveOnZoom(/*Func<Task> action*/)
        {
            await JsRuntime.InvokeVoidAsync("CropCore.RemoveZoom");
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
            await JsRuntime.InvokeVoidAsync("CropCore.CreateCrop", id, options, DotNetHelper, Events);
            IsCreate = true;
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
            await JsRuntime.InvokeVoidAsync("CropCore.CreateCrop", el, options, DotNetHelper, Events);
            IsCreate = true;
        }

        public async Task ConfirmCrop()
        {
            try
            {
                await JsRuntime.InvokeVoidAsync("CropCore.ConfirmCrop");
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
                await JsRuntime.InvokeVoidAsync("CropCore.Crop");
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
                await JsRuntime.InvokeVoidAsync("CropCore.Reset");
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
                await JsRuntime.InvokeVoidAsync("CropCore.Clear");
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
                await JsRuntime.InvokeVoidAsync("CropCore.Enable");
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
                await JsRuntime.InvokeVoidAsync("CropCore.Disable");
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
                await JsRuntime.InvokeVoidAsync("CropCore.Destroy");
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
                await JsRuntime.InvokeVoidAsync("CropCore.Move", offsetX, offsetY);
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
                await JsRuntime.InvokeVoidAsync("CropCore.MoveTo", x, y);
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
                await JsRuntime.InvokeVoidAsync("CropCore.Zoom", ratio);
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
                await JsRuntime.InvokeVoidAsync("CropCore.ZoomTo", ratio, schema);
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
                await JsRuntime.InvokeVoidAsync("CropCore.Rotate", degree);
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
                await JsRuntime.InvokeVoidAsync("CropCore.RotateTo", degree);
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
                await JsRuntime.InvokeVoidAsync("CropCore.Scale", scaleX, scaleY);
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
                await JsRuntime.InvokeVoidAsync("CropCore.ScaleX", scaleX);
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
                await JsRuntime.InvokeVoidAsync("CropCore.ScaleY", scaleY);
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
                return await JsRuntime.InvokeAsync<CropperData>("CropCore.GetData", rounded);
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
                return await JsRuntime.InvokeAsync<CropperData>("CropCore.SetData", data);
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
                return await JsRuntime.InvokeAsync<CropperContainerData>("CropCore.GetContainerData");
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
                return await JsRuntime.InvokeAsync<CropperImageData>("CropCore.GetImageData");
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
                return await JsRuntime.InvokeAsync<CropperGetCanvasData>("CropCore.GetCanvasData");
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
                await JsRuntime.InvokeVoidAsync("CropCore.SetCanvasData", data);
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
                return await JsRuntime.InvokeAsync<CropperCropBoxData>("CropCore.GetCropBoxData");
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
                await JsRuntime.InvokeVoidAsync("CropCore.SetCropBoxData", data);
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
                await JsRuntime.InvokeVoidAsync("CropCore.GetCroppedCanvas", dest, options);
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
                await JsRuntime.InvokeVoidAsync("CropCore.GetCroppedCanvas", idDest, options);
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
                var t = await JsRuntime.InvokeAsync<object>("CropCore.GetCroppedCanvasHTML", options);
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
                await JsRuntime.InvokeVoidAsync("CropCore.SetAspectRatio", (double.IsFinite(aspectRatio) ? aspectRatio : "NaN"));
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
                await JsRuntime.InvokeVoidAsync("CropCore.SetDragMode", (Enum.GetName(typeof(DragMode), mode) ?? "").ToLower());
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
