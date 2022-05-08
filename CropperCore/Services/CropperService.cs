﻿using CropperCore.Classes;
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
using System.Text.Json.Serialization;

namespace CropperCore.Services
{
    public sealed class CropperService : IDisposable, IAsyncDisposable
    {
        private DotNetObjectReference<CropperService>? DotNetHelper { get; set; }

        #region Properties
        private IJSRuntime JsRuntime { get; set; }

        //public CropperEvents Events { get; private set; }

        private bool IsCreate { get; set; }
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
        }
        #endregion

        #region Events handler definitions
        public delegate Task EventHandlerAsync(object sender, EventArgs e);
        public delegate Task EventCropStartHandlerAsync(object sender, EventCropChangeArgs e);
        public delegate Task EventCropMoveHandlerAsync(object sender, EventCropChangeArgs e);
        public delegate Task EventCropEndHandlerAsync(object sender, EventCropChangeArgs e);
        public delegate Task EventCropHandlerAsync(object sender, EventCropArgs e);
        public delegate bool EventZoomHandler(object sender, EventZoomChangeArgs e);
        #endregion

        #region Events definitions
        public event EventHandlerAsync? ReadyEvent;
        public event EventCropStartHandlerAsync? CropStartEvent;
        public event EventCropMoveHandlerAsync? CropMoveEvent;
        public event EventCropEndHandlerAsync? CropEndEvent;
        public event EventCropHandlerAsync? CropEvent;
        public event EventZoomHandler? ZoomEvent;
        #endregion

        #region Events
        private async Task OnReady(EventArgs args)
        {
            if (ReadyEvent is not null)
            {
                await ReadyEvent.Invoke(this, args);
            }
        }

        private async Task OnCropStart(EventCropChangeArgs args)
        {
            if (CropStartEvent is not null)
            {
                await CropStartEvent.Invoke(this, args);
            }
        }

        private async Task OnCropMove(EventCropChangeArgs args)
        {
            if (CropMoveEvent is not null)
            {
                await CropMoveEvent.Invoke(this, args);
            }
        }

        private async Task OnCropEnd(EventCropChangeArgs args)
        {
            if (CropEndEvent is not null)
            {
                await CropEndEvent.Invoke(this, args);
            }
        }

        private async Task OnCrop(EventCropArgs args)
        {
            if (CropEvent is not null)
            {
                await CropEvent.Invoke(this, args);
            }
        }

        private bool OnZoom(EventZoomChangeArgs args)
        {
            if (ZoomEvent is not null)
            {
                return ZoomEvent.Invoke(this, args);
            }

            return true;
        }
        #endregion

        #region Events callback
        [JSInvokable]
        public async Task OnReadyDelegate()
        {
            await OnReady(new EventArgs());
        }
        [JSInvokable]
        public async Task OnCropStartDelegate(EventCropChangeArgs args)
        {
            await OnCropStart(args);
        }
        [JSInvokable]
        public async Task OnCropMoveDelegate(EventCropChangeArgs args)
        {
            await OnCropMove(args);
        }
        [JSInvokable]
        public async Task OnCropEndDelegate(EventCropChangeArgs args)
        {
            await OnCropEnd(args);
        }
        [JSInvokable]
        public async Task OnCropDelegate(EventCropArgs args)
        {
            await OnCrop(args);
        }
        [JSInvokable]
        public bool OnZoomDelegate(EventZoomChangeArgs args)
        {
            return OnZoom(args);
        }
        #endregion

        #region Events active/disactive
        public async Task AddOnReady()
        {
            await JsRuntime.InvokeVoidAsync("CropCore.addReady", DotNetHelper);
        }
        public async Task RemoveOnReady()
        {
            await JsRuntime.InvokeVoidAsync("CropCore.removeReady");
        }

        public async Task AddOnCropStart()
        {
            await JsRuntime.InvokeVoidAsync("CropCore.addCropStart", DotNetHelper);
        }
        public async Task RemoveOnCropStart()
        {
            await JsRuntime.InvokeVoidAsync("CropCore.removeCropStart");
        }

        public async Task AddOnCropMove()
        {
            await JsRuntime.InvokeVoidAsync("CropCore.addCropMove", DotNetHelper);
        }
        public async Task RemoveOnCropMove()
        {
            await JsRuntime.InvokeVoidAsync("CropCore.removeCropMove");
        }

        public async Task AddOnCropEnd()
        {
            await JsRuntime.InvokeVoidAsync("CropCore.addCropEnd", DotNetHelper);
        }
        public async Task RemoveOnCropEnd()
        {
            await JsRuntime.InvokeVoidAsync("CropCore.removeCropEnd");
        }

        public async Task AddOnCrop()
        {
            await JsRuntime.InvokeVoidAsync("CropCore.addCrop", DotNetHelper);
        }
        public async Task RemoveOnCrop()
        {
            await JsRuntime.InvokeVoidAsync("CropCore.removeCrop");
        }

        public async Task AddOnZoom()
        {
            await JsRuntime.InvokeVoidAsync("CropCore.addZoom", DotNetHelper);
        }
        public async Task RemoveOnZoom()
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
                await JsRuntime.InvokeVoidAsync("CropCore.createCrop", id, options, DotNetHelper, new EventsInfo
                {
                    HasReady = ReadyEvent != null,
                    HasCropstart = CropStartEvent != null,
                    HasCropmove = CropMoveEvent != null,
                    HasCropend = CropEndEvent != null,
                    HasCrop = CropEvent != null,
                    HasZoom = ZoomEvent != null
                });
                IsCreate = true;
            }
            catch (JSException ex)
            {
                throw ex;
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
                await JsRuntime.InvokeVoidAsync("CropCore.createCrop", el, options, DotNetHelper, new EventsInfo
                {
                    HasReady = ReadyEvent != null,
                    HasCropstart = CropStartEvent != null,
                    HasCropmove = CropMoveEvent != null,
                    HasCropend = CropEndEvent != null,
                    HasCrop = CropEvent != null,
                    HasZoom = ZoomEvent != null
                });
                IsCreate = true;
            }
            catch (JSException ex)
            {
                throw ex;
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
                throw ex;
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
                throw ex;
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
                throw ex;
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
                throw ex;
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
                throw ex;
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
                throw ex;
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
                throw ex;
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
                throw ex;
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
                throw ex;
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
                throw ex;
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
                throw ex;
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
                throw ex;
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
                throw ex;
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
                throw ex;
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
                throw ex;
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
                throw ex;
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
                throw ex;
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
                throw ex;
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
                throw ex;
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
                throw ex;
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
                throw ex;
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
                throw ex;
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
                throw ex;
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
                throw ex;
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
                throw ex;
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
                throw ex;
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
                throw ex;
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
                throw ex;
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
                throw ex;
            }
        }
        #endregion

        public void Dispose()
        {
            if (ReadyEvent is not null)
            {
                Delegate[] clientList = ReadyEvent.GetInvocationList();
                foreach (var d in clientList)
                    ReadyEvent -= (d as EventHandlerAsync);
            }
            if (CropStartEvent is not null)
            {
                Delegate[] clientList = CropStartEvent.GetInvocationList();
                foreach (var d in clientList)
                    CropStartEvent -= (d as EventCropStartHandlerAsync);
            }
            if (CropMoveEvent is not null)
            {
                Delegate[] clientList = CropMoveEvent.GetInvocationList();
                foreach (var d in clientList)
                    CropMoveEvent -= (d as EventCropMoveHandlerAsync);
            }
            if (CropEndEvent is not null)
            {
                Delegate[] clientList = CropEndEvent.GetInvocationList();
                foreach (var d in clientList)
                    CropEndEvent -= (d as EventCropEndHandlerAsync);
            }
            if (CropEvent is not null)
            {
                Delegate[] clientList = CropEvent.GetInvocationList();
                foreach (var d in clientList)
                    CropEvent -= (d as EventCropHandlerAsync);
            }
            if (ZoomEvent is not null)
            {
                Delegate[] clientList = ZoomEvent.GetInvocationList();
                foreach (var d in clientList)
                    ZoomEvent -= (d as EventZoomHandler);
            }

            DotNetHelper?.Dispose();
            Console.WriteLine($"{nameof(CropperService)}.Dispose()");
        }

        public async ValueTask DisposeAsync()
        {
            await RemoveOnReady();
            await RemoveOnCropStart();
            await RemoveOnCropMove();
            await RemoveOnCropEnd();
            await RemoveOnCrop();
            await RemoveOnZoom();
        }
    }
}
