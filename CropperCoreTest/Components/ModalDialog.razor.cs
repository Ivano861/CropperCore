using Microsoft.AspNetCore.Components;

namespace CropperCoreTest.Components
{
    public  partial class ModalDialog
    {
		[Parameter]
		public string Title { get; set; } = null!;

		[Parameter]
		public EventCallback<bool> OnClose { get; set; }

		[Parameter]
		public RenderFragment ChildContent { get; set; } = null!;

		private Task ModalCancel()
		{
			return OnClose.InvokeAsync(false);
		}

		private Task ModalOk()
		{
			return OnClose.InvokeAsync(true);
		}
	}
}
