using CropperCore.Classes;
using CropperCore.Classes.Events;
using CropperCore.Enumerates;
using CropperCore.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CropperCoreTest.Pages
{
    public partial class CropperWrapper //: IAsyncDisposable
    {
        [Inject]
        public CropperService CropperService { get; set; }

        ElementReference imgRef;
        ElementReference imgPrev;

        string imgUrl;

        string jsonIO { get; set; }

        private CropperOtions Options { get; set; } = new CropperOtions
        {
            AutoCrop = true,
            ViewMode = CropperCore.Enumerates.ViewMode.RestrictCrop,
            Preview = ".img-preview"
        };

        private async Task OnReady(object sender, EventArgs args)
        {
            await Task.Delay(100);
            int a = 1;
        }

        private async Task OnCropStart(object sender, EventCropChangeArgs args)
        {
            await Task.Delay(100);
            int a = 1;
        }

        private async Task OnCropMove(object sender, EventCropChangeArgs args)
        {
            await Task.Delay(100);
            int a = 1;
        }

        private async Task OnCropEnd(object sender, EventCropChangeArgs args)
        {
            await Task.Delay(100);
            int a = 1;
        }

        private async Task OnCrop(object sender, EventCropArgs args)
        {
            await Task.Delay(100);
            int a = 1;
        }

        private async Task OnZoom(object sender, EventZoomChangeArgs args)
        {
            await Task.Delay(100);
            int a = 1;

            //        layerX: 122
            //layerY: 187
            //metaKey: false
            //movementX: 0
            //movementY: 0
            //wheelDelta: 120
            //wheelDeltaX: 0
            //wheelDeltaY: 120
            //which: 0
            //x: 172
            //y: 302
        }

        public async Task SetResponsive(ChangeEventArgs args)
        {
            if (args is null) return;

            Options.Responsive = (bool)args.Value;

            await CreateCrop();
        }
        public async Task SetRestore(ChangeEventArgs args)
        {
            if (args is null) return;

            Options.Restore = (bool)args.Value;

            await CreateCrop();
        }
        public async Task SetCheckCrossOrigin(ChangeEventArgs args)
        {
            if (args is null) return;

            Options.CheckCrossOrigin = (bool)args.Value;

            await CreateCrop();
        }
        public async Task SetCheckOrientation(ChangeEventArgs args)
        {
            if (args is null) return;

            Options.CheckOrientation = (bool)args.Value;

            await CreateCrop();
        }
        public async Task SetModal(ChangeEventArgs args)
        {
            if (args is null) return;

            Options.Modal = (bool)args.Value;

            await CreateCrop();
        }
        public async Task SetGuides(ChangeEventArgs args)
        {
            if (args is null) return;

            Options.Guides = (bool)args.Value;

            await CreateCrop();
        }
        public async Task SetCenter(ChangeEventArgs args)
        {
            if (args is null) return;

            Options.Center = (bool)args.Value;

            await CreateCrop();
        }
        public async Task SetHighlight(ChangeEventArgs args)
        {
            if (args is null) return;

            Options.Highlight = (bool)args.Value;

            await CreateCrop();
        }
        public async Task SetBackground(ChangeEventArgs args)
        {
            if (args is null) return;

            Options.Background = (bool)args.Value;

            await CreateCrop();
        }
        public async Task SetAutoCrop(ChangeEventArgs args)
        {
            if (args is null) return;

            Options.AutoCrop = (bool)args.Value;

            await CreateCrop();
        }
        public async Task SetMovable(ChangeEventArgs args)
        {
            if (args is null) return;

            Options.Movable = (bool)args.Value;

            await CreateCrop();
        }
        public async Task SetRotatable(ChangeEventArgs args)
        {
            if (args is null) return;

            Options.Rotatable = (bool)args.Value;

            await CreateCrop();
        }
        public async Task SetScalable(ChangeEventArgs args)
        {
            if (args is null) return;

            Options.Scalable = (bool)args.Value;

            await CreateCrop();
        }
        public async Task SetZoomable(ChangeEventArgs args)
        {
            if (args is null) return;

            Options.Zoomable = (bool)args.Value;

            await CreateCrop();
        }
        public async Task SetZoomOnTouch(ChangeEventArgs args)
        {
            if (args is null) return;

            Options.ZoomOnTouch = (bool)args.Value;

            await CreateCrop();
        }
        public async Task SetZoomOnWheel(ChangeEventArgs args)
        {
            if (args is null) return;

            Options.ZoomOnWheel = (bool)args.Value;

            await CreateCrop();
        }
        public async Task SetCropBoxMovable(ChangeEventArgs args)
        {
            if (args is null) return;

            Options.CropBoxMovable = (bool)args.Value;

            await CreateCrop();
        }
        public async Task SetCropBoxResizable(ChangeEventArgs args)
        {
            if (args is null) return;

            Options.CropBoxResizable = (bool)args.Value;

            await CreateCrop();
        }
        public async Task SetToggleDragModeOnDblclick(ChangeEventArgs args)
        {
            if (args is null) return;

            Options.ToggleDragModeOnDblclick = (bool)args.Value;

            await CreateCrop();
        }

        private async Task CreateCrop()
        {
            try
            {
                //Options = new CropperOtions
                //{
                //    AutoCrop = true,
                //    ViewMode = CropperCore.Enumerates.ViewMode.RestrictCrop,
                //    AspectRatio = 4.0 / 3.0,
                //    Preview = ".img-preview"
                //};

                CropperService.Events.Ready -= OnReady;
                CropperService.Events.Ready += OnReady;
                CropperService.Events.CropStart -= OnCropStart;
                CropperService.Events.CropStart += OnCropStart;
                CropperService.Events.CropMove -= OnCropMove;
                CropperService.Events.CropMove += OnCropMove;
                CropperService.Events.CropEnd -= OnCropEnd;
                CropperService.Events.CropEnd += OnCropEnd;
                CropperService.Events.Crop -= OnCrop;
                CropperService.Events.Crop += OnCrop;
                CropperService.Events.Zoom -= OnZoom;
                CropperService.Events.Zoom += OnZoom;

                await CropperService.Create(imgRef, Options);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
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
            try
            {
                await CropperService.SetDragMode(mode);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }
        }

        private async Task Zoom(double value)
        {
            try
            {
                await CropperService.Zoom(value);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }

        private async Task Move(double x, double y)
        {
            try
            {
                await CropperService.Move(x, y);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }

        public async Task Rotate(double value)
        {
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
                string message = ex.Message;
            }
        }

        public async Task Scale(double x, double y)
        {
            try
            {
                await CropperService.Scale(x, y);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }

        public async Task ScaleX(double value)
        {
            try
            {
                await CropperService.ScaleX(value);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
        public async Task ScaleY(double value)
        {
            try
            {
                await CropperService.ScaleY(value);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }

        public async Task Crop()
        {
            try
            {
                await CropperService.Crop();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }

        public async Task Clear()
        {
            try
            {
                await CropperService.Clear();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }

        private async Task Disable()
        {
            try
            {
                await CropperService.Disable();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }

        private async Task Enable()
        {
            try
            {
                await CropperService.Enable();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }

        private async Task Reset()
        {
            try
            {
                await CropperService.Reset();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }

        private async Task Destroy()
        {
            try
            {
                await CropperService.Destroy();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }

        public async Task<CropperData> GetData()
        {
            try
            {
                //var y = await CropperService.GetData(true);

                var result = await CropperService.GetData();
                jsonIO = System.Text.Json.JsonSerializer.Serialize(result);

                return result;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return null;
            }
        }
        public async Task SetData()
        {
            try
            {
                if (string.IsNullOrEmpty(jsonIO)) return;

                var output = System.Text.Json.JsonSerializer.Deserialize<CropperData>(jsonIO);
                await CropperService.SetData(output);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }

        public async Task<CropperContainerData> GetContainerData()
        {
            try
            {
                var result = await CropperService.GetContainerData();
                jsonIO = System.Text.Json.JsonSerializer.Serialize(result);

                return result;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return null;
            }
        }

        public async Task<CropperImageData> GetImageData()
        {
            try
            {
                var result = await CropperService.GetImageData();
                jsonIO = System.Text.Json.JsonSerializer.Serialize(result);

                return result;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return null;
            }
        }

        public async Task<CropperGetCanvasData> GetCanvasData()
        {
            try
            {
                var result = await CropperService.GetCanvasData();
                jsonIO = System.Text.Json.JsonSerializer.Serialize(result);
                return result;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return null;
            }
        }

        public async Task SetCanvasData()
        {
            try
            {
                if (string.IsNullOrEmpty(jsonIO)) return;

                var output = System.Text.Json.JsonSerializer.Deserialize<CropperGetCanvasData>(jsonIO);
                await CropperService.SetCanvasData(output);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }
        public async Task<CropperCropBoxData> GetCropBoxData()
        {
            try
            {
                var result = await CropperService.GetCropBoxData();
                jsonIO = System.Text.Json.JsonSerializer.Serialize(result);
                return result;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return null;
            }
        }

        public async Task SetCropBoxData()
        {
            try
            {
                if (string.IsNullOrEmpty(jsonIO)) return;

                var output = System.Text.Json.JsonSerializer.Deserialize<CropperCropBoxData>(jsonIO);
                await CropperService.SetCropBoxData(output);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }

        private async Task MoveTo(double value)
        {
            try
            {
                await CropperService.MoveTo(value);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }

        private async Task ZoomTo(double value)
        {
            try
            {
                //await CropperService.ZoomTo(value, new CropperZoomSchema { X = 20, Y = 50 });
                await CropperService.ZoomTo(value);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }

        public async Task RotateTo(double value)
        {
            try
            {
                await CropperService.RotateTo(value);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }

        private async Task GetCroppedCanvas(double width, double height, double maxWidth = double.PositiveInfinity, double maxHeight = double.PositiveInfinity)
        {
            try
            {
                CropperCroppedCanvas options = new CropperCroppedCanvas
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

                await CropperService.GetCroppedCanvas(imgPrev, options);
                //await CropperService.GetCroppedCanvas(options);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }


        private async Task DisplayImageUsingStreaming(InputFileChangeEventArgs e)
        {
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
                string message = ex.Message;
            }
        }

        //public async ValueTask DisposeAsync()
        //{
        //    await CropperService?.DisposeAsync();
        //}
    }
}
