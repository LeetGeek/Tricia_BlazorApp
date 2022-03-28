using Microsoft.JSInterop;

namespace BlazorApp_Tricia.Other
{
    public static class ConfirmExtensions
    {
        public static ValueTask<bool> Confirm(this IJSRuntime jsRuntime, string message)
        {
            return jsRuntime.InvokeAsync<bool>("confirm", message);
        }
    }
}
