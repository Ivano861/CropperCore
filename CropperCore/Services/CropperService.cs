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
    public sealed class CropperService : IAsyncDisposable
    {
        private DotNetObjectReference<CropperService> DotNetHelper { get; set; } = null!;

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

        public delegate Task EventCropStartPointerHandlerAsync(object sender, CropPointerEventArgs e);
        public delegate Task EventCropStartTouchHandlerAsync(object sender, CropTouchEventArgs e);
        public delegate Task EventCropStartMouseHandlerAsync(object sender, CropMouseEventArgs e);

        public delegate Task EventCropMovePointerHandlerAsync(object sender, CropPointerEventArgs e);
        public delegate Task EventCropMoveTouchHandlerAsync(object sender, CropTouchEventArgs e);
        public delegate Task EventCropMoveMouseHandlerAsync(object sender, CropMouseEventArgs e);

        public delegate Task EventCropEndPointerHandlerAsync(object sender, CropPointerEventArgs e);
        public delegate Task EventCropEndPointerCancelHandlerAsync(object sender, CropPointerEventArgs e);
        public delegate Task EventCropEndTouchHandlerAsync(object sender, CropTouchEventArgs e);
        public delegate Task EventCropEndTouchCancelHandlerAsync(object sender, CropTouchEventArgs e);
        public delegate Task EventCropEndMouseHandlerAsync(object sender, CropMouseEventArgs e);

        public delegate Task EventCropHandlerAsync(object sender, CropEventArgs e);

        public delegate bool EventZoomMouseHandler(object sender, ZoomMouseEventArgs e);
        public delegate bool EventZoomPointerHandler(object sender, ZoomPointerEventArgs e);
        public delegate bool EventZoomWheelHandler(object sender, ZoomWheelEventArgs e);
        public delegate bool EventZoomTouchHandler(object sender, ZoomTouchEventArgs e);
        public delegate bool EventZoomCommandHandler(object sender, ZoomCommandEventArgs e);
        #endregion

        #region Events definitions
        public event EventHandlerAsync? ReadyEvent;

        public event EventCropStartPointerHandlerAsync? CropStartPointerEvent;
        public event EventCropStartTouchHandlerAsync? CropStartTouchEvent;
        public event EventCropStartMouseHandlerAsync? CropStartMouseEvent;

        public event EventCropMovePointerHandlerAsync? CropMovePointerEvent;
        public event EventCropMoveTouchHandlerAsync? CropMoveTouchEvent;
        public event EventCropMoveMouseHandlerAsync? CropMoveMouseEvent;

        public event EventCropEndPointerHandlerAsync? CropEndPointerEvent;
        public event EventCropEndPointerCancelHandlerAsync? CropEndPointerCancelEvent;
        public event EventCropEndTouchHandlerAsync? CropEndTouchEvent;
        public event EventCropEndTouchCancelHandlerAsync? CropEndTouchCancelEvent;
        public event EventCropEndMouseHandlerAsync? CropEndMouseEvent;

        public event EventCropHandlerAsync? CropEvent;

        public event EventZoomMouseHandler? ZoomMouseEvent;
        public event EventZoomPointerHandler? ZoomPointerEvent;
        public event EventZoomWheelHandler? ZoomWheelEvent;
        public event EventZoomTouchHandler? ZoomTouchEvent;
        public event EventZoomCommandHandler? ZoomCommandEvent;
        #endregion

        #region Events callback
        #region Ready
        [JSInvokable]
        public async Task OnReadyCallback()
        {
            if (ReadyEvent is not null)
            {
                await ReadyEvent.Invoke(this, new EventArgs());
            }
        }
        #endregion

        #region CropStart
        [JSInvokable]
        public async Task OnCropStartPointerCallback(CropPointerEventArgs args)
        {
            if (CropStartPointerEvent is not null)
            {
                await CropStartPointerEvent.Invoke(this, args);
            }
        }
        public async Task OnCropStartTouchCallback(CropTouchEventArgs args)
        {
            if (CropStartTouchEvent is not null)
            {
                await CropStartTouchEvent.Invoke(this, args);
            }
        }
        public async Task OnCropStartMouseCallback(CropMouseEventArgs args)
        {
            if (CropStartMouseEvent is not null)
            {
                await CropStartMouseEvent.Invoke(this, args);
            }
        }
        #endregion

        #region CropMove
        [JSInvokable]
        public async Task OnCropMovePonterCallback(CropPointerEventArgs args)
        {
            if (CropMovePointerEvent is not null)
            {
                await CropMovePointerEvent.Invoke(this, args);
            }
        }
        public async Task OnCropMoveTouchCallback(CropTouchEventArgs args)
        {
            if (CropMoveTouchEvent is not null)
            {
                await CropMoveTouchEvent.Invoke(this, args);
            }
        }
        public async Task OnCropMoveMouseCallback(CropMouseEventArgs args)
        {
            if (CropMoveMouseEvent is not null)
            {
                await CropMoveMouseEvent.Invoke(this, args);
            }
        }
        #endregion

        #region CropEnd
        [JSInvokable]
        public async Task OnCropEndPointerCallback(CropPointerEventArgs args)
        {
            if (CropEndPointerEvent is not null)
            {
                await CropEndPointerEvent.Invoke(this, args);
            }
        }
        public async Task OnCropEndPointerCancelCallback(CropPointerEventArgs args)
        {
            if (CropEndPointerCancelEvent is not null)
            {
                await CropEndPointerCancelEvent.Invoke(this, args);
            }
        }
        public async Task OnCropEndTouchCallback(CropTouchEventArgs args)
        {
            if (CropEndTouchEvent is not null)
            {
                await CropEndTouchEvent.Invoke(this, args);
            }
        }
        public async Task OnCropEndTouchCancelCallback(CropTouchEventArgs args)
        {
            if (CropEndTouchCancelEvent is not null)
            {
                await CropEndTouchCancelEvent.Invoke(this, args);
            }

        }
        public async Task OnCropEndMouseCallback(CropMouseEventArgs args)
        {
            if (CropEndMouseEvent is not null)
            {
                await CropEndMouseEvent.Invoke(this, args);
            }
        }
        #endregion

        #region Crop
        [JSInvokable]
        public async Task OnCropCallback(CropEventArgs args)
        {
            if (CropEvent is not null)
            {
                await CropEvent.Invoke(this, args);
            }
        }
        #endregion

        #region Zoom
        [JSInvokable]
        public bool OnZoomMouseCallback(ZoomMouseEventArgs args)
        {
            if (ZoomMouseEvent is not null)
            {
                return ZoomMouseEvent.Invoke(this, args);
            }

            return true;
        }
        [JSInvokable]
        public bool OnZoomPointerCallback(ZoomPointerEventArgs args)
        {
            if (ZoomPointerEvent is not null)
            {
                return ZoomPointerEvent.Invoke(this, args);
            }

            return true;
        }
        [JSInvokable]
        public bool OnZoomWheelCallback(ZoomWheelEventArgs args)
        {
            if (ZoomWheelEvent is not null)
            {
                return ZoomWheelEvent.Invoke(this, args);
            }

            return true;
        }
        [JSInvokable]
        public bool OnZoomTouchCallback(ZoomTouchEventArgs args)
        {
            if (ZoomTouchEvent is not null)
            {
                return ZoomTouchEvent.Invoke(this, args);
            }

            return true;
        }
        [JSInvokable]
        public bool OnZoomCommandCallback(ZoomCommandEventArgs args)
        {
            if (ZoomCommandEvent is not null)
            {
                return ZoomCommandEvent.Invoke(this, args);
            }

            return true;
        }
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
                await JsRuntime.InvokeVoidAsync("CropCore.create", id, options, DotNetHelper, name);
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
                await JsRuntime.InvokeVoidAsync("CropCore.create", el, options, DotNetHelper, name);
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

        public async ValueTask DisposeAsync()
        {
            if (ReadyEvent is not null)
            {
                Delegate[] clientList = ReadyEvent.GetInvocationList();
                foreach (var d in clientList)
                    ReadyEvent -= (d as EventHandlerAsync);
            }

            if (CropStartPointerEvent is not null)
            {
                Delegate[] clientList = CropStartPointerEvent.GetInvocationList();
                foreach (var d in clientList)
                    CropStartPointerEvent -= (d as EventCropStartPointerHandlerAsync);
            }
            if (CropStartTouchEvent is not null)
            {
                Delegate[] clientList = CropStartTouchEvent.GetInvocationList();
                foreach (var d in clientList)
                    CropStartTouchEvent -= (d as EventCropStartTouchHandlerAsync);
            }
            if (CropStartMouseEvent is not null)
            {
                Delegate[] clientList = CropStartMouseEvent.GetInvocationList();
                foreach (var d in clientList)
                    CropStartMouseEvent -= (d as EventCropStartMouseHandlerAsync);
            }

            if (CropMovePointerEvent is not null)
            {
                Delegate[] clientList = CropMovePointerEvent.GetInvocationList();
                foreach (var d in clientList)
                    CropMovePointerEvent -= (d as EventCropMovePointerHandlerAsync);
            }
            if (CropMoveTouchEvent is not null)
            {
                Delegate[] clientList = CropMoveTouchEvent.GetInvocationList();
                foreach (var d in clientList)
                    CropMoveTouchEvent -= (d as EventCropMoveTouchHandlerAsync);
            }
            if (CropMoveMouseEvent is not null)
            {
                Delegate[] clientList = CropMoveMouseEvent.GetInvocationList();
                foreach (var d in clientList)
                    CropMoveMouseEvent -= (d as EventCropMoveMouseHandlerAsync);
            }

            if (CropEndPointerEvent is not null)
            {
                Delegate[] clientList = CropEndPointerEvent.GetInvocationList();
                foreach (var d in clientList)
                    CropEndPointerEvent -= (d as EventCropEndPointerHandlerAsync);
            }
            if (CropEndPointerCancelEvent is not null)
            {
                Delegate[] clientList = CropEndPointerCancelEvent.GetInvocationList();
                foreach (var d in clientList)
                    CropEndPointerCancelEvent -= (d as EventCropEndPointerCancelHandlerAsync);
            }
            if (CropEndTouchEvent is not null)
            {
                Delegate[] clientList = CropEndTouchEvent.GetInvocationList();
                foreach (var d in clientList)
                    CropEndTouchEvent -= (d as EventCropEndTouchHandlerAsync);
            }
            if (CropEndTouchCancelEvent is not null)
            {
                Delegate[] clientList = CropEndTouchCancelEvent.GetInvocationList();
                foreach (var d in clientList)
                    CropEndTouchCancelEvent -= (d as EventCropEndTouchCancelHandlerAsync);
            }
            if (CropEndMouseEvent is not null)
            {
                Delegate[] clientList = CropEndMouseEvent.GetInvocationList();
                foreach (var d in clientList)
                    CropEndMouseEvent -= (d as EventCropEndMouseHandlerAsync);
            }

            if (CropEvent is not null)
            {
                Delegate[] clientList = CropEvent.GetInvocationList();
                foreach (var d in clientList)
                    CropEvent -= (d as EventCropHandlerAsync);
            }

            if (ZoomMouseEvent is not null)
            {
                Delegate[] clientList = ZoomMouseEvent.GetInvocationList();
                foreach (var d in clientList)
                    ZoomMouseEvent -= (d as EventZoomMouseHandler);
            }
            if (ZoomPointerEvent is not null)
            {
                Delegate[] clientList = ZoomPointerEvent.GetInvocationList();
                foreach (var d in clientList)
                    ZoomPointerEvent -= (d as EventZoomPointerHandler);
            }
            if (ZoomWheelEvent is not null)
            {
                Delegate[] clientList = ZoomWheelEvent.GetInvocationList();
                foreach (var d in clientList)
                    ZoomWheelEvent -= (d as EventZoomWheelHandler);
            }
            if (ZoomTouchEvent is not null)
            {
                Delegate[] clientList = ZoomTouchEvent.GetInvocationList();
                foreach (var d in clientList)
                    ZoomTouchEvent -= (d as EventZoomTouchHandler);
            }
            if (ZoomCommandEvent is not null)
            {
                Delegate[] clientList = ZoomCommandEvent.GetInvocationList();
                foreach (var d in clientList)
                    ZoomCommandEvent -= (d as EventZoomCommandHandler);
            }

            await Destroy();


            DotNetHelper.Dispose();
            Console.WriteLine($"{nameof(CropperService)}.Dispose()");
        }
    }
}
