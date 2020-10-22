using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;

namespace Fomantic.Blazor.UI
{
    /// <summary>
    /// Base interface for all Fomantic Blazor Components that has class attribute
    /// </summary>
    public interface IFomanticComponentWithClass : IFomanticComponent
    {
        /// <summary>
        /// List of main element class
        /// </summary>
        /// <returns></returns>
        public List<string> CssClasses { get;  }

        /// <summary>
        /// The value of main element class (this should be used to bind on ui)
        /// </summary>
        public string CssClass { get; }

        /// <summary>
        /// Occures when Css Class Changed
        /// </summary>
        [Parameter]
        public EventCallback<ParamterChangedArgs<string>> OnClassChanged { get; set; }

        /// <summary>
        /// Occures when Css Class Changed
        /// </summary>
        public event ElementClassChanged OnClassChangedEvent;

    }
}