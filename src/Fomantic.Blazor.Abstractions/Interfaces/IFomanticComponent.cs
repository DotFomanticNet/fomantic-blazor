using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Fomantic.Blazor.UI
{
    /// <summary>
    /// Base interface for all Fomantic Blazor Components
    /// </summary>
    public interface IFomanticComponent : IComponent, IDisposable
    {
        /// <summary>
        /// Js runtime object to run javascript interops functions
        /// </summary>
        public IJSRuntime JsRuntime { get; }

        /// <summary>
        /// Root element reference
        /// </summary>
        public ElementReference RootElement { get; }

        /// <summary>
        /// All other Html attributes on the element
        /// </summary>
        Dictionary<string, object> Attributes { get;  }

        /// <summary>
        /// List Of Fomantic Component Extensions
        /// </summary>
        public List<IFomanticComponentExtension> Extensions { get; }

    }
}
