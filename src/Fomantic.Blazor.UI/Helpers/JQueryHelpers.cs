///-------------------------------------------------------------------------------------------------
// file:	Helpers\JQueryHelpers.cs
//
// summary:	Implements the query helpers class
///-------------------------------------------------------------------------------------------------

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fomantic.Blazor.UI
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   A jquery offset. </summary>
    ///  
    ///-------------------------------------------------------------------------------------------------

    public class JqueryOffset
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the top. </summary>
        ///
        /// <value> The top. </value>
        ///-------------------------------------------------------------------------------------------------

        public double Top { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the left. </summary>
        ///
        /// <value> The left. </value>
        ///-------------------------------------------------------------------------------------------------

        public double Left { get; set; }
    }

    ///-------------------------------------------------------------------------------------------------
    /// <summary>   A query helpers. </summary>
    ///    
    ///-------------------------------------------------------------------------------------------------

    public static class JQueryHelpers
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Make Viewport animated scroll to a component </summary>
        ///       
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="component">    The component to act on. </param>
        /// <param name="margintop">    (Optional) The margintop. </param>
        /// <param name="jumpTime">     (Optional) The jump time. </param>
        ///
        /// <returns>   An asynchronous result that yields a T. </returns>
        ///-------------------------------------------------------------------------------------------------

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

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   An ElementReference extension method that jump to top of. </summary>
        ///      
        ///
        /// <param name="element">      The element to act on. </param>
        /// <param name="jSRuntime">    The s runtime. </param>
        /// <param name="margintop">    (Optional) The margintop. </param>
        /// <param name="jumpTime">     (Optional) The jump time. </param>
        ///
        /// <returns>   An asynchronous result that yields an ElementReference. </returns>
        ///-------------------------------------------------------------------------------------------------

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
