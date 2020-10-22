using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fomantic.Blazor.UI
{
    public class JqueryOffset
    {

        public double Top { get; set; }
        public double Left { get; set; }
    }
    public static class JQueryHelpers
    {
        public static async Task<T> Jump<T>(this T component, int margintop = 0, int jumpTime = 600) where T : IVisibleFomanticComponent, IFomanticComponentWithJQuery
        {
            var bodyJQueryElementRef = await component.JsRuntime.InvokeAsync<IJSObjectReference>("$", "html, body");
            JqueryOffset offset = await component.JQueryElementRef.InvokeAsync<JqueryOffset>("offset");

            if (offset != null)
            {
                double elementTop = offset.Top + margintop;
                await bodyJQueryElementRef.InvokeVoidAsync("animate", new { scrollTop = elementTop }, jumpTime);
            }
            return component;
        }

        public static async Task<ElementReference> JumpToTopOf(this ElementReference element, IJSRuntime jSRuntime, int margintop = 0, int jumpTime = 600)
        {
            var jQueryElementRef = await jSRuntime.InvokeAsync<IJSObjectReference>("$", element);
            var bodyJQueryElementRef = await jSRuntime.InvokeAsync<IJSObjectReference>("$", "html, body");
            JqueryOffset offset = await jQueryElementRef.InvokeAsync<JqueryOffset>("offset");

            if (offset != null)
            {
                double elementTop = offset.Top + margintop;
                await bodyJQueryElementRef.InvokeVoidAsync("animate", new { scrollTop = elementTop }, jumpTime);
            }
            return element;
        }
    }
}
