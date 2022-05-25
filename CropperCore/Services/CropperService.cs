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
        
        public delegate Task EventCropStartPointerDownHandlerAsync(object sender, CropPointerEventArgs e);
        public delegate Task EventCropStartTouchStartHandlerAsync(object sender, CropTouchEventArgs e);
        public delegate Task EventCropStartMouseDownHandlerAsync(object sender, CropMouseEventArgs e);

        public delegate Task EventCropMovePointerMoveHandlerAsync(object sender, CropPointerEventArgs e);
        public delegate Task EventCropMoveTouchMoveHandlerAsync(object sender, CropTouchEventArgs e);
        public delegate Task EventCropMoveMouseMoveHandlerAsync(object sender, CropMouseEventArgs e);

        public delegate Task EventCropEndPointerUpHandlerAsync(object sender, CropPointerEventArgs e);
        public delegate Task EventCropEndPointerCancelHandlerAsync(object sender, CropPointerEventArgs e);
        public delegate Task EventCropEndTouchEndHandlerAsync(object sender, CropTouchEventArgs e);
        public delegate Task EventCropEndTouchCancelHandlerAsync(object sender, CropTouchEventArgs e);
        public delegate Task EventCropEndMouseUpHandlerAsync(object sender, CropMouseEventArgs e);

        public delegate Task EventCropHandlerAsync(object sender, CropEventArgs e);

        public delegate bool EventZoomMouseMoveHandler(object sender, ZoomMouseEventArgs e);
        public delegate bool EventZoomPointerMoveHandler(object sender, ZoomPointerEventArgs e);
        public delegate bool EventZoomWheelHandler(object sender, ZoomWheelEventArgs e);
        public delegate bool EventZoomTouchMoveHandler(object sender, ZoomTouchEventArgs e);
        public delegate bool EventZoomCommandHandler(object sender, ZoomCommandEventArgs e);
        #endregion

        #region Events definitions
        public event EventHandlerAsync? ReadyEvent;

        public event EventCropStartPointerDownHandlerAsync? CropStartPointerDownEvent;
        public event EventCropStartTouchStartHandlerAsync? CropStartTouchStartEvent;
        public event EventCropStartMouseDownHandlerAsync? CropStartMouseDownEvent;

        public event EventCropMovePointerMoveHandlerAsync? CropMovePointerMoveEvent;
        public event EventCropMoveTouchMoveHandlerAsync? CropMoveTouchMoveEvent;
        public event EventCropMoveMouseMoveHandlerAsync? CropMoveMouseMoveEvent;

        public event EventCropEndPointerUpHandlerAsync? CropEndPointerUpEvent;
        public event EventCropEndPointerCancelHandlerAsync? CropEndPointerCancelEvent;
        public event EventCropEndTouchEndHandlerAsync? CropEndTouchEndEvent;
        public event EventCropEndTouchCancelHandlerAsync? CropEndTouchCancelEvent;
        public event EventCropEndMouseUpHandlerAsync? CropEndMouseUpEvent;

        public event EventCropHandlerAsync? CropEvent;

        public event EventZoomMouseMoveHandler? ZoomMouseMoveEvent;
        public event EventZoomPointerMoveHandler? ZoomPointerMoveEvent;
        public event EventZoomWheelHandler? ZoomWheelEvent;
        public event EventZoomTouchMoveHandler? ZoomTouchMoveEvent;
        public event EventZoomCommandHandler? ZoomCommandEvent;
        #endregion

        #region Events callback
        #region Ready
        [JSInvokable]
        public async Task OnReadyDelegate()
        {
            if (ReadyEvent is not null)
            {
                await ReadyEvent.Invoke(this, new EventArgs());
            }
        }
        #endregion

        #region CropStart
        [JSInvokable]
        public async Task OnCropStartPointerDownDelegate(CropPointerEventArgs args)
        {
            if (CropStartPointerDownEvent is not null)
            {
                await CropStartPointerDownEvent.Invoke(this, args);
            }
        }
        public async Task OnCropStartTouchStartDelegate(CropTouchEventArgs args)
        {
            if (CropStartTouchStartEvent is not null)
            {
                await CropStartTouchStartEvent.Invoke(this, args);
            }
        }
        public async Task OnCropStartMouseDownDelegate(CropMouseEventArgs args)
        {
            if (CropStartMouseDownEvent is not null)
            {
                await CropStartMouseDownEvent.Invoke(this, args);
            }
        }
        #endregion

        #region CropMove
        [JSInvokable]
        public async Task OnCropMovePonterMoveDelegate(CropPointerEventArgs args)
        {
            if (CropMovePointerMoveEvent is not null)
            {
                await CropMovePointerMoveEvent.Invoke(this, args);
            }
        }
        public async Task OnCropMoveTouchMoveDelegate(CropTouchEventArgs args)
        {
            if (CropMoveTouchMoveEvent is not null)
            {
                await CropMoveTouchMoveEvent.Invoke(this, args);
            }
        }
        public async Task OnCropMoveMouseMoveDelegate(CropMouseEventArgs args)
        {
            if (CropMoveMouseMoveEvent is not null)
            {
                await CropMoveMouseMoveEvent.Invoke(this, args);
            }
        }
        #endregion

        #region CropEnd
        [JSInvokable]
        public async Task OnCropEndPointerUpDelegate(CropPointerEventArgs args)
        {
            if (CropEndPointerUpEvent is not null)
            {
                await CropEndPointerUpEvent.Invoke(this, args);
            }
        }
        public async Task OnCropEndPointerCancelDelegate(CropPointerEventArgs args)
        {
            if (CropEndPointerCancelEvent is not null)
            {
                await CropEndPointerCancelEvent.Invoke(this, args);
            }
        }
        public async Task OnCropEndTouchEndDelegate(CropTouchEventArgs args)
        {
            if (CropEndTouchEndEvent is not null)
            {
                await CropEndTouchEndEvent.Invoke(this, args);
            }
        }
        public async Task OnCropEndTouchCancelDelegate(CropTouchEventArgs args)
        {
            if (CropEndTouchCancelEvent is not null)
            {
                await CropEndTouchCancelEvent.Invoke(this, args);
            }

        }
        public async Task OnCropEndMouseUpDelegate(CropMouseEventArgs args)
        {
            if (CropEndMouseUpEvent is not null)
            {
                await CropEndMouseUpEvent.Invoke(this, args);
            }
        }
        #endregion

        #region Crop
        [JSInvokable]
        public async Task OnCropDelegate(CropEventArgs args)
        {
            if (CropEvent is not null)
            {
                await CropEvent.Invoke(this, args);
            }
        }
        #endregion

        #region Zoom
        [JSInvokable]
        public bool OnZoomMouseMoveDelegate(ZoomMouseEventArgs args)
        {
            if (ZoomMouseMoveEvent is not null)
            {
                return ZoomMouseMoveEvent.Invoke(this, args);
            }

            return true;
        }
        [JSInvokable]
        public bool OnZoomPointerMoveDelegate(ZoomPointerEventArgs args)
        {
            if (ZoomPointerMoveEvent is not null)
            {
                return ZoomPointerMoveEvent.Invoke(this, args);
            }

            return true;
        }
        [JSInvokable]
        public bool OnZoomWheelDelegate(ZoomWheelEventArgs args)
        {
            if (ZoomWheelEvent is not null)
            {
                return ZoomWheelEvent.Invoke(this, args);
            }

            return true;
        }
        [JSInvokable]
        public bool OnZoomTouchMoveDelegate(ZoomTouchEventArgs args)
        {
            if (ZoomTouchMoveEvent is not null)
            {
                return ZoomTouchMoveEvent.Invoke(this, args);
            }

            return true;
        }
        [JSInvokable]
        public bool OnZoomCommandDelegate(ZoomCommandEventArgs args)
        {
            if (ZoomCommandEvent is not null)
            {
                return ZoomCommandEvent.Invoke(this, args);
            }

            return true;
        }
        #endregion
        #endregion

        #region Events active/disactive
        #region Ready
        public async Task AddOnReady()
        {
            await JsRuntime.InvokeVoidAsync("CropCore.addReady", DotNetHelper);
        }
        public async Task RemoveOnReady()
        {
            await JsRuntime.InvokeVoidAsync("CropCore.removeReady");
        }
        #endregion

        #region CropStart
        public async Task AddOnCropStart()
        {
            await JsRuntime.InvokeVoidAsync("CropCore.addCropStart", DotNetHelper);
        }
        public async Task RemoveOnCropStart()
        {
            await JsRuntime.InvokeVoidAsync("CropCore.removeCropStart");
        }
        //public async Task AddOnCropStartPointerDown()
        //{
        //    await JsRuntime.InvokeVoidAsync("CropCore.addCropStartPointerDown", DotNetHelper);
        //}
        //public async Task AddOnCropStartTouchStart()
        //{
        //    await JsRuntime.InvokeVoidAsync("CropCore.addCropStartTouchStart", DotNetHelper);
        //}
        //public async Task AddOnCropStartMouseDown()
        //{
        //    await JsRuntime.InvokeVoidAsync("CropCore.addCropStartMouseDown", DotNetHelper);
        //}
        //public async Task RemoveOnCropStartPointerDown()
        //{
        //    await JsRuntime.InvokeVoidAsync("CropCore.removeCropStartPointerDown");
        //}
        //public async Task RemoveOnCropStartTouchStart()
        //{
        //    await JsRuntime.InvokeVoidAsync("CropCore.removeCropStartTouchStart");
        //}
        //public async Task RemoveOnCropStartMouseDown()
        //{
        //    await JsRuntime.InvokeVoidAsync("CropCore.removeCropStartMouseDown");
        //}
        #endregion

        #region CropMove
        public async Task AddOnCropMove()
        {
            await JsRuntime.InvokeVoidAsync("CropCore.addCropMove", DotNetHelper);
        }
        public async Task RemoveOnCropMove()
        {
            await JsRuntime.InvokeVoidAsync("CropCore.removeCropMove");
        }
        //public async Task AddOnCropMovePointerMove()
        //{
        //    await JsRuntime.InvokeVoidAsync("CropCore.addCropMovePointerMove", DotNetHelper);
        //}
        //public async Task AddOnCropMoveTouchMove()
        //{
        //    await JsRuntime.InvokeVoidAsync("CropCore.addCropMoveTouchMove", DotNetHelper);
        //}
        //public async Task AddOnCropMoveMouseMove()
        //{
        //    await JsRuntime.InvokeVoidAsync("CropCore.addCropMoveMouseMove", DotNetHelper);
        //}
        //public async Task RemoveOnCropMovePointerMove()
        //{
        //    await JsRuntime.InvokeVoidAsync("CropCore.removeCropMovePointerMove");
        //}
        //public async Task RemoveOnCropMoveTouchMove()
        //{
        //    await JsRuntime.InvokeVoidAsync("CropCore.removeCropMoveTouchMove");
        //}
        //public async Task RemoveOnCropMoveMouseMove()
        //{
        //    await JsRuntime.InvokeVoidAsync("CropCore.removeCropMoveMouseMove");
        //}
        #endregion

        #region CropEnd
        public async Task AddOnCropEnd()
        {
            await JsRuntime.InvokeVoidAsync("CropCore.addCropEnd", DotNetHelper);
        }
        public async Task RemoveOnCropEnd()
        {
            await JsRuntime.InvokeVoidAsync("CropCore.removeCropEnd");
        }
        //public async Task AddOnCropEndPointerUp()
        //{
        //    await JsRuntime.InvokeVoidAsync("CropCore.addCropEndPointerUp", DotNetHelper);
        //}
        //public async Task AddOnCropEndPointerCancel()
        //{
        //    await JsRuntime.InvokeVoidAsync("CropCore.addCropEndPointerCancel", DotNetHelper);
        //}
        //public async Task AddOnCropEndTouchEnd()
        //{
        //    await JsRuntime.InvokeVoidAsync("CropCore.addCropEndTouchEnd", DotNetHelper);
        //}
        //public async Task AddOnCropEndTouchCancel()
        //{
        //    await JsRuntime.InvokeVoidAsync("CropCore.addCropEndTouchCancel", DotNetHelper);
        //}
        //public async Task AddOnCropEndMouseUp()
        //{
        //    await JsRuntime.InvokeVoidAsync("CropCore.addCropEndMouseUp", DotNetHelper);
        //}
        //public async Task RemoveOnCropEndPointerUp()
        //{
        //    await JsRuntime.InvokeVoidAsync("CropCore.removeCropEndPointerUp");
        //}
        //public async Task RemoveOnCropEndPointerCancel()
        //{
        //    await JsRuntime.InvokeVoidAsync("CropCore.removeCropEndPointerCancel");
        //}
        //public async Task RemoveOnCropEndTouchEnd()
        //{
        //    await JsRuntime.InvokeVoidAsync("CropCore.removeCropEndTouchEnd");
        //}
        //public async Task RemoveOnCropEndTouchCancel()
        //{
        //    await JsRuntime.InvokeVoidAsync("CropCore.removeCropEndTouchCancel");
        //}
        //public async Task RemoveOnCropEndMouseUp()
        //{
        //    await JsRuntime.InvokeVoidAsync("CropCore.removeCropEndMouseUp");
        //}
        #endregion

        #region Crop
        public async Task AddOnCrop()
        {
            await JsRuntime.InvokeVoidAsync("CropCore.addCrop", DotNetHelper);
        }
        public async Task RemoveOnCrop()
        {
            await JsRuntime.InvokeVoidAsync("CropCore.removeCrop");
        }
        #endregion

        #region Zoom
        public async Task AddOnZoom()
        {
            await JsRuntime.InvokeVoidAsync("CropCore.addZoom", DotNetHelper);
        }
        public async Task RemoveOnZoom()
        {
            await JsRuntime.InvokeVoidAsync("CropCore.removeZoom");
        }
        //public async Task AddOnZoomMouseMove()
        //{
        //    await JsRuntime.InvokeVoidAsync("CropCore.addZoomMouseMove", DotNetHelper);
        //}
        //public async Task AddOnZoomPointerMove()
        //{
        //    await JsRuntime.InvokeVoidAsync("CropCore.addZoomPointerMove", DotNetHelper);
        //}
        //public async Task AddOnZoomWheel()
        //{
        //    await JsRuntime.InvokeVoidAsync("CropCore.addZoomWheel", DotNetHelper);
        //}
        //public async Task AddOnZoomTouchMove()
        //{
        //    await JsRuntime.InvokeVoidAsync("CropCore.addZoomTouchMove", DotNetHelper);
        //}
        //public async Task AddOnZoomCommand()
        //{
        //    await JsRuntime.InvokeVoidAsync("CropCore.addZoomCommand", DotNetHelper);
        //}
        //public async Task RemoveOnZoomMouseMove()
        //{
        //    await JsRuntime.InvokeVoidAsync("CropCore.removeZoomMouseMove");
        //}
        //public async Task RemoveOnZoomPointerMove()
        //{
        //    await JsRuntime.InvokeVoidAsync("CropCore.removeZoomPointerMove");
        //}
        //public async Task RemoveOnZoomWheel()
        //{
        //    await JsRuntime.InvokeVoidAsync("CropCore.removeZoomWheel");
        //}
        //public async Task RemoveOnZoomTouchMove()
        //{
        //    await JsRuntime.InvokeVoidAsync("CropCore.removeZoomTouchMove");
        //}
        //public async Task RemoveOnZoomCommand()
        //{
        //    await JsRuntime.InvokeVoidAsync("CropCore.removeZoomCommand");
        //}
        #endregion
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
        public async Task Create(string id, CropperOtions? options = null, string? name = null)
        {
            try
            {
                await JsRuntime.InvokeVoidAsync("CropCore.create", id, options, DotNetHelper, new EventsInfo
                {
                    HasReady = ReadyEvent != null,
                    HasCropstart = CropStartPointerDownEvent != null,
                    HasCropmove = CropMovePointerMoveEvent != null,
                    HasCropend = CropEndPointerCancelEvent != null,
                    HasCrop = CropEvent != null,
                    HasZoom = ZoomMouseMoveEvent != null || ZoomPointerMoveEvent != null || ZoomWheelEvent != null || ZoomTouchMoveEvent != null || ZoomCommandEvent != null
                },
                name);
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
        public async Task Create(ElementReference el, CropperOtions? options = null, string? name = null)
        {
            try
            {
                await JsRuntime.InvokeVoidAsync("CropCore.create", el, options, DotNetHelper, new EventsInfo
                {
                    HasReady = ReadyEvent != null,
                    HasCropstart = CropStartPointerDownEvent != null,
                    HasCropmove = CropMovePointerMoveEvent != null,
                    HasCropend = CropEndPointerCancelEvent != null,
                    HasCrop = CropEvent != null,
                    HasZoom = ZoomMouseMoveEvent != null || ZoomPointerMoveEvent != null || ZoomWheelEvent != null || ZoomTouchMoveEvent != null || ZoomCommandEvent != null
                },
                name);
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

            if (CropStartPointerDownEvent is not null)
            {
                Delegate[] clientList = CropStartPointerDownEvent.GetInvocationList();
                foreach (var d in clientList)
                    CropStartPointerDownEvent -= (d as EventCropStartPointerDownHandlerAsync);
            }
            if (CropStartTouchStartEvent is not null)
            {
                Delegate[] clientList = CropStartTouchStartEvent.GetInvocationList();
                foreach (var d in clientList)
                    CropStartTouchStartEvent -= (d as EventCropStartTouchStartHandlerAsync);
            }
            if (CropStartMouseDownEvent is not null)
            {
                Delegate[] clientList = CropStartMouseDownEvent.GetInvocationList();
                foreach (var d in clientList)
                    CropStartMouseDownEvent -= (d as EventCropStartMouseDownHandlerAsync);
            }

            if (CropMovePointerMoveEvent is not null)
            {
                Delegate[] clientList = CropMovePointerMoveEvent.GetInvocationList();
                foreach (var d in clientList)
                    CropMovePointerMoveEvent -= (d as EventCropMovePointerMoveHandlerAsync);
            }
            if (CropMoveTouchMoveEvent is not null)
            {
                Delegate[] clientList = CropMoveTouchMoveEvent.GetInvocationList();
                foreach (var d in clientList)
                    CropMoveTouchMoveEvent -= (d as EventCropMoveTouchMoveHandlerAsync);
            }
            if (CropMoveMouseMoveEvent is not null)
            {
                Delegate[] clientList = CropMoveMouseMoveEvent.GetInvocationList();
                foreach (var d in clientList)
                    CropMoveMouseMoveEvent -= (d as EventCropMoveMouseMoveHandlerAsync);
            }

            if (CropEndPointerUpEvent is not null)
            {
                Delegate[] clientList = CropEndPointerUpEvent.GetInvocationList();
                foreach (var d in clientList)
                    CropEndPointerUpEvent -= (d as EventCropEndPointerUpHandlerAsync);
            }
            if (CropEndPointerCancelEvent is not null)
            {
                Delegate[] clientList = CropEndPointerCancelEvent.GetInvocationList();
                foreach (var d in clientList)
                    CropEndPointerCancelEvent -= (d as EventCropEndPointerCancelHandlerAsync);
            }
            if (CropEndTouchEndEvent is not null)
            {
                Delegate[] clientList = CropEndTouchEndEvent.GetInvocationList();
                foreach (var d in clientList)
                    CropEndTouchEndEvent -= (d as EventCropEndTouchEndHandlerAsync);
            }
            if (CropEndTouchCancelEvent is not null)
            {
                Delegate[] clientList = CropEndTouchCancelEvent.GetInvocationList();
                foreach (var d in clientList)
                    CropEndTouchCancelEvent -= (d as EventCropEndTouchCancelHandlerAsync);
            }
            if (CropEndMouseUpEvent is not null)
            {
                Delegate[] clientList = CropEndMouseUpEvent.GetInvocationList();
                foreach (var d in clientList)
                    CropEndMouseUpEvent -= (d as EventCropEndMouseUpHandlerAsync);
            }

            if (CropEvent is not null)
            {
                Delegate[] clientList = CropEvent.GetInvocationList();
                foreach (var d in clientList)
                    CropEvent -= (d as EventCropHandlerAsync);
            }

            if (ZoomMouseMoveEvent is not null)
            {
                Delegate[] clientList = ZoomMouseMoveEvent.GetInvocationList();
                foreach (var d in clientList)
                    ZoomMouseMoveEvent -= (d as EventZoomMouseMoveHandler);
            }
            if (ZoomPointerMoveEvent is not null)
            {
                Delegate[] clientList = ZoomPointerMoveEvent.GetInvocationList();
                foreach (var d in clientList)
                    ZoomPointerMoveEvent -= (d as EventZoomPointerMoveHandler);
            }
            if (ZoomWheelEvent is not null)
            {
                Delegate[] clientList = ZoomWheelEvent.GetInvocationList();
                foreach (var d in clientList)
                    ZoomWheelEvent -= (d as EventZoomWheelHandler);
            }
            if (ZoomTouchMoveEvent is not null)
            {
                Delegate[] clientList = ZoomTouchMoveEvent.GetInvocationList();
                foreach (var d in clientList)
                    ZoomTouchMoveEvent -= (d as EventZoomTouchMoveHandler);
            }
            if (ZoomCommandEvent is not null)
            {
                Delegate[] clientList = ZoomCommandEvent.GetInvocationList();
                foreach (var d in clientList)
                    ZoomCommandEvent -= (d as EventZoomCommandHandler);
            }

            DotNetHelper?.Dispose();
            Console.WriteLine($"{nameof(CropperService)}.Dispose()");
        }

        public async ValueTask DisposeAsync()
        {
            await RemoveOnReady();

            await RemoveOnCropStart();
            //await RemoveOnCropStartPointerDown();
            //await RemoveOnCropStartTouchStart();
            //await RemoveOnCropStartMouseDown();

            await RemoveOnCropMove();
            //await RemoveOnCropMovePointerMove();
            //await RemoveOnCropMoveTouchMove();
            //await RemoveOnCropMoveMouseMove();

            await RemoveOnCropEnd();
            //await RemoveOnCropEndMouseUp();
            //await RemoveOnCropEndPointerUp();
            //await RemoveOnCropEndPointerCancel();
            //await RemoveOnCropEndTouchEnd();
            //await RemoveOnCropEndTouchCancel();

            await RemoveOnCrop();

            await RemoveOnZoom();
            //await RemoveOnZoomPointerMove();
            //await RemoveOnZoomMouseMove();
            //await RemoveOnZoomWheel();
            //await RemoveOnZoomTouchMove();
            //await RemoveOnZoomCommand();
        }
    }
}
