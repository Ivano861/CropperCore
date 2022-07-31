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
    public partial class CropperWrapper : IAsyncDisposable
    {
        [Inject]
        private CropperService CropperService { get; set; } = null!;

        [Inject]
        private IJSRuntime JS { get; set; } = null!;

        private ElementReference imgRef;

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
            await Task.Run(() =>
            {
                var obj = new
                {
                    Event = "OnReady",
                    Argument = args
                };

                JsonIO = System.Text.Json.JsonSerializer.Serialize(obj);
            });

            StateHasChanged();
        }

        private async Task OnCropStartPointer(object sender, CropPointerEventArgs args)
        {
            await Task.Run(() =>
            {
                var obj = new
                {
                    Event = "OnCropStartPointer",
                    Argument = args
                };

                JsonIO = System.Text.Json.JsonSerializer.Serialize(obj);
            });

            StateHasChanged();
        }
        private async Task OnCropStartTouch(object sender, CropTouchEventArgs args)
        {
            await Task.Run(() =>
            {
                var obj = new
                {
                    Event = "OnCropStartTouch",
                    Argument = args
                };

                JsonIO = System.Text.Json.JsonSerializer.Serialize(obj);
            });

            StateHasChanged();
        }
        private async Task OnCropStartMouse(object sender, CropMouseEventArgs args)
        {
            await Task.Run(() =>
            {
                var obj = new
                {
                    Event = "OnCropStartMouse",
                    Argument = args
                };

                JsonIO = System.Text.Json.JsonSerializer.Serialize(obj);
            });

            StateHasChanged();
        }

        private async Task OnCropMovePointer(object sender, CropPointerEventArgs args)
        {
            await Task.Run(() =>
            {
                var obj = new
                {
                    Event = "OnCropMovePointer",
                    Argument = args
                };

                JsonIO = System.Text.Json.JsonSerializer.Serialize(obj);
            });

            StateHasChanged();
        }




        private async Task OnCropMoveMouse(object sender, CropMouseEventArgs args)
        {
            await Task.Run(() =>
            {
                var obj = new
                {
                    Event = "OnCropMoveMouse",
                    Argument = args
                };

                JsonIO = System.Text.Json.JsonSerializer.Serialize(obj);
            });

            StateHasChanged();
        }
        private async Task OnCropMoveTouch(object sender, CropTouchEventArgs args)
        {
            await Task.Run(() =>
            {
                var obj = new
                {
                    Event = "OnCropMoveTouch",
                    Argument = args
                };

                JsonIO = System.Text.Json.JsonSerializer.Serialize(obj);
            });

            StateHasChanged();
        }

        private async Task OnCropEndPointer(object sender, CropPointerEventArgs args)
        {
            await Task.Run(() =>
            {
                var obj = new
                {
                    Event = "OnCropEndPointer",
                    Argument = args
                };

                JsonIO = System.Text.Json.JsonSerializer.Serialize(obj);
            });

            StateHasChanged();
        }
        private async Task OnCropEndPointerCancel(object sender, CropPointerEventArgs args)
        {
            await Task.Run(() =>
            {
                var obj = new
                {
                    Event = "OnCropEndPointerCancel",
                    Argument = args
                };

                JsonIO = System.Text.Json.JsonSerializer.Serialize(obj);
            });

            StateHasChanged();
        }
        private async Task OnCropEndMouse(object sender, CropMouseEventArgs args)
        {
            await Task.Run(() =>
            {
                var obj = new
                {
                    Event = "OnCropEndMouse",
                    Argument = args
                };

                JsonIO = System.Text.Json.JsonSerializer.Serialize(obj);
            });

            StateHasChanged();
        }
        private async Task OnCropEndTouch(object sender, CropTouchEventArgs args)
        {
            await Task.Run(() =>
            {
                var obj = new
                {
                    Event = "OnCropEndTouch",
                    Argument = args
                };

                JsonIO = System.Text.Json.JsonSerializer.Serialize(obj);
            });

            StateHasChanged();
        }
        private async Task OnCropEndTouchCancel(object sender, CropTouchEventArgs args)
        {
            await Task.Run(() =>
            {
                var obj = new
                {
                    Event = "OnCropEndTouchCancel",
                    Argument = args
                };

                JsonIO = System.Text.Json.JsonSerializer.Serialize(obj);
            });

            StateHasChanged();
        }

        private async Task OnCrop(object sender, CropEventArgs args)
        {
            await Task.Run(() =>
            {
                var obj = new
                {
                    Event = "OnCrop",
                    Argument = args
                };

                JsonIO = System.Text.Json.JsonSerializer.Serialize(obj);
            });

            StateHasChanged();
        }

        private bool OnZoomMouse(object sender, ZoomMouseEventArgs args)
        {
            var obj = new
            {
                Event = "OnZoomMouse",
                Argument = args
            };

            JsonIO = System.Text.Json.JsonSerializer.Serialize(obj);

            StateHasChanged();

            return true;
        }
        private bool OnZoomPointer(object sender, ZoomPointerEventArgs args)
        {
            var obj = new
            {
                Event = "OnZoomPointer",
                Argument = args
            };

            JsonIO = System.Text.Json.JsonSerializer.Serialize(obj);

            StateHasChanged();

            return true;
        }
        private bool OnZoomWheel(object sender, ZoomWheelEventArgs args)
        {
            var obj = new
            {
                Event = "OnZoomWheel",
                Argument = args
            };

            JsonIO = System.Text.Json.JsonSerializer.Serialize(obj);

            StateHasChanged();

            return true;
        }
        private bool OnZoomTouch(object sender, ZoomTouchEventArgs args)
        {
            var obj = new
            {
                Event = "OnZoomTouch",
                Argument = args
            };

            JsonIO = System.Text.Json.JsonSerializer.Serialize(obj);

            StateHasChanged();

            return true;
        }
        private bool OnZoomCommand(object sender, ZoomCommandEventArgs args)
        {
            var obj = new
            {
                Event = "OnZoomCommand",
                Argument = args
            };

            JsonIO = System.Text.Json.JsonSerializer.Serialize(obj);

            StateHasChanged();

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

        public enum EventNames
        {
            ready,

            cropStartPointerDown,
            cropStartTouchStart,
            cropStartMouseDown,

            cropMovePointerMove,
            cropMoveTouchMove,
            cropMoveMouseMove,

            cropEndPointerUp,
            cropEndPointerCancel,
            cropEndTouchEnd,
            cropEndTouchCancel,
            cropEndMouseUp,

            crop,

            zoomMouseMove,
            zoomPointerMove,
            zoomWheel,
            zoomTouchMove,
            zoomCommand
        }

        private bool OnReadyEnabled { get; set; } = true;

        private bool OnCropStartPointerDownEnabled { get; set; } = true;
        private bool OnCropStartTouchStartEnabled { get; set; } = true;
        private bool OnCropStartMouseDownEnabled { get; set; } = true;

        private bool OnCropMovePointerMoveEnabled { get; set; } = true;
        private bool OnCropMoveTouchMoveEnabled { get; set; } = true;
        private bool OnCropMoveMouseMoveEnabled { get; set; } = true;

        private bool OnCropEndPointerUpEnabled { get; set; } = true;
        private bool OnCropEndPointerCancelEnabled { get; set; } = true;
        private bool OnCropEndTouchEndEnabled { get; set; } = true;
        private bool OnCropEndTouchCancelEnabled { get; set; } = true;
        private bool OnCropEndMouseUpEnabled { get; set; } = true;

        private bool OnCropEnabled { get; set; } = true;

        private bool OnZoomMouseMoveEnabled { get; set; } = true;
        private bool OnZoomPointerMoveEnabled { get; set; } = true;
        private bool OnZoomWheelEnabled { get; set; } = true;
        private bool OnZoomTouchMoveEnabled { get; set; } = true;
        private bool OnZoomCommandEnabled { get; set; } = true;

        public /*async Task*/ void SetEvents(ChangeEventArgs args, EventNames ev)
        {
            if (args is null) return;

            switch (ev)
            {
                case EventNames.ready:
                    OnReadyEnabled = (bool?)args.Value ?? false;
                    if (OnReadyEnabled)
                    {
                        CropperService.ReadyEvent += OnReady;
                    }
                    else
                    {
                        CropperService.ReadyEvent -= OnReady;
                    }
                    break;

                case EventNames.cropStartPointerDown:
                    OnCropStartPointerDownEnabled = (bool?)args.Value ?? false;
                    if (OnCropStartPointerDownEnabled)
                    {
                        CropperService.CropStartPointerEvent += OnCropStartPointer;
                    }
                    else
                    {
                        CropperService.CropStartPointerEvent -= OnCropStartPointer;
                    }
                    break;
                case EventNames.cropStartTouchStart:
                    OnCropStartTouchStartEnabled = (bool?)args.Value ?? false;
                    if (OnCropStartTouchStartEnabled)
                    {
                        CropperService.CropStartTouchEvent += OnCropStartTouch;
                    }
                    else
                    {
                        CropperService.CropStartTouchEvent -= OnCropStartTouch;
                    }
                    break;
                case EventNames.cropStartMouseDown:
                    OnCropStartMouseDownEnabled = (bool?)args.Value ?? false;
                    if (OnCropStartMouseDownEnabled)
                    {
                        CropperService.CropStartMouseEvent += OnCropStartMouse;
                    }
                    else
                    {
                        CropperService.CropStartMouseEvent -= OnCropStartMouse; ;
                    }
                    break;

                case EventNames.cropMovePointerMove:
                    OnCropMovePointerMoveEnabled = (bool?)args.Value ?? false;
                    if (OnCropMovePointerMoveEnabled)
                    {
                        CropperService.CropMovePointerEvent += OnCropMovePointer;
                    }
                    else
                    {
                        CropperService.CropMovePointerEvent -= OnCropMovePointer; ;
                    }
                    break;
                case EventNames.cropMoveTouchMove:
                    OnCropMoveTouchMoveEnabled = (bool?)args.Value ?? false;
                    if (OnCropMoveTouchMoveEnabled)
                    {
                        CropperService.CropMoveTouchEvent += OnCropMoveTouch;
                    }
                    else
                    {
                        CropperService.CropMoveTouchEvent -= OnCropMoveTouch; ;
                    }
                    break;
                case EventNames.cropMoveMouseMove:
                    OnCropMoveMouseMoveEnabled = (bool?)args.Value ?? false;
                    if (OnCropMoveMouseMoveEnabled)
                    {
                        CropperService.CropMoveMouseEvent += OnCropMoveMouse;
                    }
                    else
                    {
                        CropperService.CropMoveMouseEvent -= OnCropMoveMouse;
                    }
                    break;

                case EventNames.cropEndPointerUp:

                    OnCropEndPointerUpEnabled = (bool?)args.Value ?? false;
                    if (OnCropEndPointerUpEnabled)
                    {
                        CropperService.CropEndPointerEvent += OnCropEndPointer;
                    }
                    else
                    {
                        CropperService.CropEndPointerEvent -= OnCropEndPointer;
                    }
                    break;
                case EventNames.cropEndPointerCancel:
                    OnCropEndPointerCancelEnabled = (bool?)args.Value ?? false;
                    if (OnCropEndPointerCancelEnabled)
                    {
                        CropperService.CropEndPointerCancelEvent += OnCropEndPointerCancel;
                    }
                    else
                    {
                        CropperService.CropEndPointerCancelEvent -= OnCropEndPointerCancel;
                    }
                    break;
                case EventNames.cropEndTouchEnd:
                    OnCropEndTouchEndEnabled = (bool?)args.Value ?? false;
                    if (OnCropEndTouchEndEnabled)
                    {
                        CropperService.CropEndTouchEvent += OnCropEndTouch;
                    }
                    else
                    {
                        CropperService.CropEndTouchEvent -= OnCropEndTouch;
                    }
                    break;
                case EventNames.cropEndTouchCancel:
                    OnCropEndTouchCancelEnabled = (bool?)args.Value ?? false;
                    if (OnCropEndTouchCancelEnabled)
                    {
                        CropperService.CropEndTouchCancelEvent += OnCropEndTouchCancel;
                    }
                    else
                    {
                        CropperService.CropEndTouchCancelEvent -= OnCropEndTouchCancel;
                    }
                    break;
                case EventNames.cropEndMouseUp:
                    OnCropEndMouseUpEnabled = (bool?)args.Value ?? false;
                    if (OnCropEndMouseUpEnabled)
                    {
                        CropperService.CropEndMouseEvent += OnCropEndMouse;
                    }
                    else
                    {
                        CropperService.CropEndMouseEvent -= OnCropEndMouse;
                    }
                    break;

                case EventNames.crop:
                    OnCropEnabled = (bool?)args.Value ?? false;
                    if (OnCropEnabled)
                    {
                        CropperService.CropEvent += OnCrop;
                    }
                    else
                    {
                        CropperService.CropEvent -= OnCrop;
                    }
                    break;

                case EventNames.zoomMouseMove:
                    OnZoomMouseMoveEnabled = (bool?)args.Value ?? false;
                    if (OnZoomMouseMoveEnabled)
                    {
                        CropperService.ZoomMouseEvent += OnZoomMouse;
                    }
                    else
                    {
                        CropperService.ZoomMouseEvent -= OnZoomMouse;
                    }
                    break;
                case EventNames.zoomPointerMove:
                    OnZoomPointerMoveEnabled = (bool?)args.Value ?? false;
                    if (OnZoomPointerMoveEnabled)
                    {
                        CropperService.ZoomPointerEvent += OnZoomPointer;
                    }
                    else
                    {
                        CropperService.ZoomPointerEvent -= OnZoomPointer;
                    }
                    break;
                case EventNames.zoomWheel:
                    OnZoomWheelEnabled = (bool?)args.Value ?? false;
                    if (OnZoomWheelEnabled)
                    {
                        CropperService.ZoomWheelEvent += OnZoomWheel;
                    }
                    else
                    {
                        CropperService.ZoomWheelEvent -= OnZoomWheel;
                    }
                    break;
                case EventNames.zoomTouchMove:
                    OnZoomTouchMoveEnabled = (bool?)args.Value ?? false;
                    if (OnZoomTouchMoveEnabled)
                    {
                        CropperService.ZoomTouchEvent += OnZoomTouch;
                    }
                    else
                    {
                        CropperService.ZoomTouchEvent -= OnZoomTouch;
                    }
                    break;
                case EventNames.zoomCommand:
                    OnZoomCommandEnabled = (bool?)args.Value ?? false;
                    if (OnZoomCommandEnabled)
                    {
                        CropperService.ZoomCommandEvent += OnZoomCommand;
                    }
                    else
                    {
                        CropperService.ZoomCommandEvent -= OnZoomCommand;
                    }
                    break;
                default:
                    break;
            }

            //await CreateCrop();
        }


        private async Task CreateCrop()
        {
            ResetError();

            try
            {
                CropperService.ReadyEvent -= OnReady;
                if (OnReadyEnabled)
                {
                    CropperService.ReadyEvent += OnReady;
                }

                CropperService.CropStartPointerEvent -= OnCropStartPointer;
                if (OnCropStartPointerDownEnabled)
                {
                    CropperService.CropStartPointerEvent += OnCropStartPointer;
                }
                CropperService.CropStartTouchEvent -= OnCropStartTouch;
                if (OnCropStartTouchStartEnabled)
                {
                    CropperService.CropStartTouchEvent += OnCropStartTouch;
                }
                CropperService.CropStartMouseEvent -= OnCropStartMouse;
                if (OnCropStartMouseDownEnabled)
                {
                    CropperService.CropStartMouseEvent += OnCropStartMouse;
                }

                CropperService.CropMovePointerEvent -= OnCropMovePointer;
                if (OnCropMovePointerMoveEnabled)
                {
                    CropperService.CropMovePointerEvent += OnCropMovePointer;
                }
                CropperService.CropMoveMouseEvent -= OnCropMoveMouse;
                if (OnCropMoveTouchMoveEnabled)
                {
                    CropperService.CropMoveTouchEvent += OnCropMoveTouch;
                }
                CropperService.CropMoveTouchEvent -= OnCropMoveTouch;
                if (OnCropMoveMouseMoveEnabled)
                {
                    CropperService.CropMoveMouseEvent += OnCropMoveMouse;
                }

                CropperService.CropEndPointerEvent -= OnCropEndPointer;
                if (OnCropEndPointerUpEnabled)
                {
                    CropperService.CropEndPointerEvent += OnCropEndPointer;
                }
                CropperService.CropEndPointerCancelEvent -= OnCropEndPointerCancel;
                if (OnCropEndPointerCancelEnabled)
                {
                    CropperService.CropEndPointerCancelEvent += OnCropEndPointerCancel;
                }
                CropperService.CropEndMouseEvent -= OnCropEndMouse;
                if (OnCropEndMouseUpEnabled)
                {
                    CropperService.CropEndMouseEvent += OnCropEndMouse;
                }
                CropperService.CropEndTouchEvent -= OnCropEndTouch;
                if (OnCropEndTouchEndEnabled)
                {
                    CropperService.CropEndTouchEvent += OnCropEndTouch;
                }
                CropperService.CropEndTouchCancelEvent -= OnCropEndTouchCancel;
                if (OnCropEndTouchCancelEnabled)
                {
                    CropperService.CropEndTouchCancelEvent += OnCropEndTouchCancel;
                }

                CropperService.CropEvent -= OnCrop;
                if (OnCropEnabled)
                {
                    CropperService.CropEvent += OnCrop;
                }

                CropperService.ZoomMouseEvent -= OnZoomMouse;
                if (OnZoomMouseMoveEnabled)
                {
                    CropperService.ZoomMouseEvent += OnZoomMouse;
                }
                CropperService.ZoomPointerEvent -= OnZoomPointer;
                if (OnZoomPointerMoveEnabled)
                {
                    CropperService.ZoomPointerEvent += OnZoomPointer;
                }
                CropperService.ZoomWheelEvent -= OnZoomWheel;
                if (OnZoomWheelEnabled)
                {
                    CropperService.ZoomWheelEvent += OnZoomWheel;
                }
                CropperService.ZoomTouchEvent -= OnZoomTouch;
                if (OnZoomTouchMoveEnabled)
                {
                    CropperService.ZoomTouchEvent += OnZoomTouch;
                }
                CropperService.ZoomCommandEvent -= OnZoomCommand;
                if (OnZoomCommandEnabled)
                {
                    CropperService.ZoomCommandEvent += OnZoomCommand;
                }

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

                await CropperService.GetCroppedCanvas("imagePrev", options);
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

        public async ValueTask DisposeAsync()
        {
            await CropperService.DisposeAsync();

            GC.SuppressFinalize(this);
        }
    }
}
