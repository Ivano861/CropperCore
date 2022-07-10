using CropperCore.Classes;
using CropperCore.Classes.Events;
using CropperCore.Enumerates;
using CropperCore.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;

namespace CropperCoreTest.Pages
{
    public partial class CropperWrapper
    {
        [Inject]
        private CropperService CropperService { get; set; } = null!;

        [Inject]
        private IJSRuntime JS { get; set; } = null!;

        private ElementReference imgRef;
        private ElementReference imgPrev;

        private string imgUrl = null!;

        private string JsonIO { get; set; } = null!;

        private string Error { get; set; } = "";

        private bool IsHidden { get { return string.IsNullOrEmpty(Error); } }

        private void ResetError() => Error = "";

       protected override void OnInitialized()
        {
            imgUrl = "Bridge.jpg";

            base.OnInitialized();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await CreateCrop();

                await JS.InvokeVoidAsync("addTooltips");

                StateHasChanged();
            }

            base.OnAfterRender(firstRender);
        }

        private CropperOtions Options { get; set; } = new CropperOtions
        {
            AutoCrop = true,
            ViewMode = ViewMode.RestrictCrop,
            Preview = ".img-preview"
        };

        private async Task OnReady(object sender, EventArgs args)
        {
            await Task.Delay(100);
        }

        private async Task OnCropStartPointer(object sender, CropPointerEventArgs args)
        {
            await Task.Delay(100);
        }
        private async Task OnCropStartTouch(object sender, CropTouchEventArgs args)
        {
            await Task.Delay(100);
        }
        private async Task OnCropStartMouse(object sender, CropMouseEventArgs args)
        {
            await Task.Delay(100);
        }

        private async Task OnCropMovePointer(object sender, CropPointerEventArgs args)
        {
            await Task.Delay(100);
        }
        private async Task OnCropMoveMouse(object sender, CropMouseEventArgs args)
        {
            await Task.Delay(100);
        }
        private async Task OnCropMoveTouch(object sender, CropTouchEventArgs args)
        {
            await Task.Delay(100);
        }

        private async Task OnCropEndPointer(object sender, CropPointerEventArgs args)
        {
            await Task.Delay(100);
        }
        private async Task OnCropEndPointerCancel(object sender, CropPointerEventArgs args)
        {
            await Task.Delay(100);
        }
        private async Task OnCropEndMouse(object sender, CropMouseEventArgs args)
        {
            await Task.Delay(100);
        }
        private async Task OnCropEndTouch(object sender, CropTouchEventArgs args)
        {
            await Task.Delay(100);
        }
        private async Task OnCropEndTouchCancel(object sender, CropTouchEventArgs args)
        {
            await Task.Delay(100);
        }

        private async Task OnCrop(object sender, CropEventArgs args)
        {
            await Task.Delay(100);
        }

        private bool OnZoomMouse(object sender, ZoomMouseEventArgs args)
        {
            Task.Delay(100);

            return true;
        }
        private bool OnZoomPointer(object sender, ZoomPointerEventArgs args)
        {
            Task.Delay(100);

            return true;
        }
        private bool OnZoomWheel(object sender, ZoomWheelEventArgs args)
        {
            Task.Delay(100);

            return true;
        }
        private bool OnZoomTouch(object sender, ZoomTouchEventArgs args)
        {
            Task.Delay(100);

            return true;
        }
        private bool OnZoomCommand(object sender, ZoomCommandEventArgs args)
        {
            Task.Delay(100);

            return true;
        }

        public async Task SetResponsive(ChangeEventArgs args)
        {
            if (args is null) return;

            Options.Responsive = (bool?)args.Value ?? false;

            await CreateCrop();
        }
        public async Task SetRestore(ChangeEventArgs args)
        {
            if (args is null) return;

            Options.Restore = (bool?)args.Value ?? false;

            await CreateCrop();
        }
        public async Task SetCheckCrossOrigin(ChangeEventArgs args)
        {
            if (args is null) return;

            Options.CheckCrossOrigin = (bool?)args.Value ?? false;

            await CreateCrop();
        }
        public async Task SetCheckOrientation(ChangeEventArgs args)
        {
            if (args is null) return;

            Options.CheckOrientation = (bool?)args.Value ?? false;

            await CreateCrop();
        }
        public async Task SetModal(ChangeEventArgs args)
        {
            if (args is null) return;

            Options.Modal = (bool?)args.Value ?? false;

            await CreateCrop();
        }
        public async Task SetGuides(ChangeEventArgs args)
        {
            if (args is null) return;

            Options.Guides = (bool?)args.Value ?? false;

            await CreateCrop();
        }
        public async Task SetCenter(ChangeEventArgs args)
        {
            if (args is null) return;

            Options.Center = (bool?)args.Value ?? false;

            await CreateCrop();
        }
        public async Task SetHighlight(ChangeEventArgs args)
        {
            if (args is null) return;

            Options.Highlight = (bool?)args.Value ?? false;

            await CreateCrop();
        }
        public async Task SetBackground(ChangeEventArgs args)
        {
            if (args is null) return;

            Options.Background = (bool?)args.Value ?? false;

            await CreateCrop();
        }
        public async Task SetAutoCrop(ChangeEventArgs args)
        {
            if (args is null) return;

            Options.AutoCrop = (bool?)args.Value ?? false;

            await CreateCrop();
        }
        public async Task SetMovable(ChangeEventArgs args)
        {
            if (args is null) return;

            Options.Movable = (bool?)args.Value ?? false;

            await CreateCrop();
        }
        public async Task SetRotatable(ChangeEventArgs args)
        {
            if (args is null) return;

            Options.Rotatable = (bool?)args.Value ?? false;

            await CreateCrop();
        }
        public async Task SetScalable(ChangeEventArgs args)
        {
            if (args is null) return;

            Options.Scalable = (bool?)args.Value ?? false;

            await CreateCrop();
        }
        public async Task SetZoomable(ChangeEventArgs args)
        {
            if (args is null) return;

            Options.Zoomable = (bool?)args.Value ?? false;

            await CreateCrop();
        }
        public async Task SetZoomOnTouch(ChangeEventArgs args)
        {
            if (args is null) return;

            Options.ZoomOnTouch = (bool?)args.Value ?? false;

            await CreateCrop();
        }
        public async Task SetZoomOnWheel(ChangeEventArgs args)
        {
            if (args is null) return;

            Options.ZoomOnWheel = (bool?)args.Value ?? false;

            await CreateCrop();
        }
        public async Task SetCropBoxMovable(ChangeEventArgs args)
        {
            if (args is null) return;

            Options.CropBoxMovable = (bool?)args.Value ?? false;

            await CreateCrop();
        }
        public async Task SetCropBoxResizable(ChangeEventArgs args)
        {
            if (args is null) return;

            Options.CropBoxResizable = (bool?)args.Value ?? false;

            await CreateCrop();
        }
        public async Task SetToggleDragModeOnDblclick(ChangeEventArgs args)
        {
            if (args is null) return;

            Options.ToggleDragModeOnDblclick = (bool?)args.Value ?? false;

            await CreateCrop();
        }

        private async Task CreateCrop()
        {
            ResetError();

            try
            {
                CropperService.ReadyEvent -= OnReady;
                CropperService.ReadyEvent += OnReady;
                CropperService.CropStartPointerDownEvent -= OnCropStartPointer;
                CropperService.CropStartPointerDownEvent += OnCropStartPointer;
                CropperService.CropStartMouseDownEvent -= OnCropStartMouse;
                CropperService.CropStartMouseDownEvent += OnCropStartMouse;
                CropperService.CropStartTouchStartEvent -= OnCropStartTouch;
                CropperService.CropStartTouchStartEvent += OnCropStartTouch;

                CropperService.CropMovePointerMoveEvent -= OnCropMovePointer;
                CropperService.CropMovePointerMoveEvent += OnCropMovePointer;
                CropperService.CropMoveMouseMoveEvent -= OnCropMoveMouse;
                CropperService.CropMoveMouseMoveEvent += OnCropMoveMouse;
                CropperService.CropMoveTouchMoveEvent -= OnCropMoveTouch;
                CropperService.CropMoveTouchMoveEvent += OnCropMoveTouch;

                CropperService.CropEndPointerUpEvent -= OnCropEndPointer;
                CropperService.CropEndPointerUpEvent += OnCropEndPointer;
                CropperService.CropEndPointerCancelEvent -= OnCropEndPointerCancel;
                CropperService.CropEndPointerCancelEvent += OnCropEndPointerCancel;
                CropperService.CropEndMouseUpEvent -= OnCropEndMouse;
                CropperService.CropEndMouseUpEvent += OnCropEndMouse;
                CropperService.CropEndTouchEndEvent -= OnCropEndTouch;
                CropperService.CropEndTouchEndEvent += OnCropEndTouch;
                CropperService.CropEndTouchCancelEvent -= OnCropEndTouchCancel;
                CropperService.CropEndTouchCancelEvent += OnCropEndTouchCancel;

                CropperService.CropEvent -= OnCrop;
                CropperService.CropEvent += OnCrop;

                CropperService.ZoomMouseMoveEvent -= OnZoomMouse;
                CropperService.ZoomMouseMoveEvent += OnZoomMouse;
                CropperService.ZoomPointerMoveEvent -= OnZoomPointer;
                CropperService.ZoomPointerMoveEvent += OnZoomPointer;
                CropperService.ZoomWheelEvent -= OnZoomWheel;
                CropperService.ZoomWheelEvent += OnZoomWheel;
                CropperService.ZoomTouchMoveEvent -= OnZoomTouch;
                CropperService.ZoomTouchMoveEvent += OnZoomTouch;
                CropperService.ZoomCommandEvent -= OnZoomCommand;
                CropperService.ZoomCommandEvent += OnZoomCommand;

                await CropperService.Create(imgRef, Options);
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }

        private async Task SetViewMode(ViewMode value)
        {
            Options.ViewMode = value;

            await CreateCrop();
        }

        public async Task SetAspectRatio(double value)
        {
            Options.AspectRatio = value;

            await CreateCrop();
        }

        public async Task SetDragMode(DragMode mode)
        {
            ResetError();

            try
            {
                await CropperService.SetDragMode(mode);
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }

        private async Task Zoom(double value)
        {
            ResetError();

            try
            {
                await CropperService.Zoom(value);
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }

        private async Task Move(double x, double y)
        {
            ResetError();

            try
            {
                await CropperService.Move(x, y);
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }

        public async Task Rotate(double value)
        {
            ResetError();

            try
            {
                if (Options.ViewMode > ViewMode.NoRestriction)
                {
                    await CropperService.Clear();
                }
                await CropperService.Rotate(value);
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }

        public async Task Scale(double x, double y)
        {
            ResetError();

            try
            {
                await CropperService.Scale(x, y);
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }

        public async Task ScaleX(double value)
        {
            ResetError();

            try
            {
                await CropperService.ScaleX(value);
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }
        public async Task ScaleY(double value)
        {
            ResetError();

            try
            {
                await CropperService.ScaleY(value);
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }

        public async Task Crop()
        {
            ResetError();

            try
            {
                await CropperService.Crop();
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }

        public async Task Clear()
        {
            ResetError();

            try
            {
                await CropperService.Clear();
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }

        private async Task Disable()
        {
            ResetError();

            try
            {
                await CropperService.Disable();
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }

        private async Task Enable()
        {
            ResetError();

            try
            {
                await CropperService.Enable();
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }

        private async Task Reset()
        {
            ResetError();

            try
            {
                await CropperService.Reset();
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }

        private async Task Destroy()
        {
            ResetError();

            try
            {
                await CropperService.Destroy();
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }

        public async Task<CropperData?> GetData()
        {
            ResetError();

            try
            {
                var result = await CropperService.GetData();
                JsonIO = System.Text.Json.JsonSerializer.Serialize(result);

                return result;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return null;
            }
        }
        public async Task SetData()
        {
            ResetError();

            try
            {
                if (string.IsNullOrEmpty(JsonIO)) return;

                var output = System.Text.Json.JsonSerializer.Deserialize<CropperData>(JsonIO);
                if (output is not null)
                {
                    await CropperService.SetData(output);
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }

        public async Task<CropperContainerData> GetContainerData()
        {
            ResetError();

            try
            {
                var result = await CropperService.GetContainerData();
                JsonIO = System.Text.Json.JsonSerializer.Serialize(result);

                return result;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return null!;
            }
        }

        public async Task<CropperImageData> GetImageData()
        {
            ResetError();

            try
            {
                var result = await CropperService.GetImageData();
                JsonIO = System.Text.Json.JsonSerializer.Serialize(result);

                return result;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return null!;
            }
        }

        public async Task<CropperGetCanvasData> GetCanvasData()
        {
            ResetError();

            try
            {
                var result = await CropperService.GetCanvasData();
                JsonIO = System.Text.Json.JsonSerializer.Serialize(result);
                return result;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return null!;
            }
        }

        public async Task SetCanvasData()
        {
            ResetError();

            try
            {
                if (string.IsNullOrEmpty(JsonIO)) return;

                var output = System.Text.Json.JsonSerializer.Deserialize<CropperGetCanvasData>(JsonIO);
                if (output is not null)
                {
                    await CropperService.SetCanvasData(output);
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }
        public async Task<CropperCropBoxData> GetCropBoxData()
        {
            ResetError();

            try
            {
                var result = await CropperService.GetCropBoxData();
                JsonIO = System.Text.Json.JsonSerializer.Serialize(result);
                return result;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return null!;
            }
        }

        public async Task SetCropBoxData()
        {
            ResetError();

            try
            {
                if (string.IsNullOrEmpty(JsonIO)) return;

                var output = System.Text.Json.JsonSerializer.Deserialize<CropperCropBoxData>(JsonIO);
                if (output is not null)
                {
                    await CropperService.SetCropBoxData(output);
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }

        private async Task MoveTo(double value)
        {
            ResetError();

            try
            {
                await CropperService.MoveTo(value);
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }

        private async Task ZoomTo(double value)
        {
            ResetError();

            try
            {
                //await CropperService.ZoomTo(value, new CropperZoomSchema { X = 20, Y = 50 });
                await CropperService.ZoomTo(value);
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }

        public async Task RotateTo(double value)
        {
            ResetError();

            try
            {
                await CropperService.RotateTo(value);
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }

        private async Task GetCroppedCanvas(double width, double height, double maxWidth = double.PositiveInfinity, double maxHeight = double.PositiveInfinity)
        {
            ResetError();

            try
            {
                CropperCroppedCanvas options = new()
                {
                    Width = width,
                    Height = height,
                    FillColor = "#fff",
                    MaxHeight = maxHeight,
                    MaxWidth = maxWidth,
                    //MinHeight = 100,
                    //MinWidth = 100,   
                    ImageSmoothingEnabled = false,
                    ImageSmoothingQuality = ImageSmoothingQuality.High
                };

                await OpenDialog();

                //await CropperService.GetCroppedCanvas(imgPrev, options);
                await CropperService.GetCroppedCanvas("imagePrev", options);
                //await CropperService.GetCroppedCanvas(options);
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }


        private async Task DisplayImageUsingStreaming(InputFileChangeEventArgs e)
        {
            ResetError();

            try
            {
                using (Stream reader = e.File.OpenReadStream(maxAllowedSize: 4000000))
                {
                    var buffer = new byte[e.File.Size];
                    await reader.ReadAsync(buffer);
                    var imageType = e.File.ContentType;
                    imgUrl = $"data:{imageType};base64,{Convert.ToBase64String(buffer)}";
                }

                StateHasChanged();

                await CreateCrop();
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }

        //public async ValueTask DisposeAsync()
        //{
        //    await CropperService?.DisposeAsync();
        //}

        public bool IsDialogOpen { get; set; } = false;

        private async Task OnDialogClose(bool accepted)
        {
            IsDialogOpen = false;
            StateHasChanged();

            await Task.CompletedTask;
        }

        private async Task OpenDialog()
        {
            IsDialogOpen = true;
            await InvokeAsync(StateHasChanged).ContinueWith((_) => Task.CompletedTask);
        }
    }
}
