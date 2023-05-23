using Microsoft.AspNetCore.Components;

namespace Psyche.Component
{
    public partial class ConfirmDelete
    {
        [Parameter]
        public string ConfirmationTitle { get; set; } = "Delete Confirmation";
        [Parameter]
        public string ConfirmationMessage { get; set; } = "Are you sure you want to delete";

        [Parameter]
        public EventCallback<bool> ConfirmationChanged { get; set; }

        public bool showComfirm { get; set; }
        public void Show()
        {
            showComfirm = true;
            StateHasChanged();
        }
        protected async Task OnConfirmationChange(bool value)
        {
            showComfirm = false;
            await ConfirmationChanged.InvokeAsync(value
                );
        }
    }
}
