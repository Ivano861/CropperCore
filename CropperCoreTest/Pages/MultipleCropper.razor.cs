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
    public partial class MultipleCropper
    {
        [Inject]
        private CropperService CropperService { get; set; } = null!;

        [Inject]
        private IJSRuntime JS { get; set; } = null!;

        private ElementReference imgRef1;
        private ElementReference imgRef2;

        private string imgUrl = null!;

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
            //AutoCrop = true,
            //ViewMode = ViewMode.RestrictCrop
        };

        private async Task CreateCrop()
        {
            try
            {
                await CropperService.Create(imgRef1, Options, "image1");
                await CropperService.Create(imgRef2, Options, "image2");
            }
            catch (Exception /*ex*/)
            {
                //Error = ex.Message;
            }
        }

        //public async ValueTask DisposeAsync()
        //{
        //    await CropperService?.DisposeAsync();
        //}
    }
}
