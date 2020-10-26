///-------------------------------------------------------------------------------------------------
// file:	Interfaces\IFomanticComponentWithClass.cs
//
// summary:	Declares the IFomanticComponentWithClass interface
///-------------------------------------------------------------------------------------------------

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;

namespace Fomantic.Blazor.UI
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>
    /// Base interface for all Fomantic Blazor Components that has class attribute.
    /// </summary>
    ///-------------------------------------------------------------------------------------------------

    public interface IFomanticComponentWithClass : IFomanticComponent,IAsyncDisposable
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   List of main element class. </summary>
        ///
        /// <value> The CSS classes. </value>
        ///-------------------------------------------------------------------------------------------------

        public List<string> CssClasses { get;  }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   The value of main element class (this should be used to bind on ui) </summary>
        ///
        /// <value> The CSS class. </value>
        ///-------------------------------------------------------------------------------------------------

        public string CssClass { get; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Occures when Css Class Changed. </summary>
        ///
        /// <value> The on class changed. </value>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        public EventCallback<ParamterChangedArgs<string>> OnClassChanged { get; set; }

        /// <summary>   Occures when Css Class Changed. </summary>
        public event ElementClassChanged OnClassChangedEvent;

    }
}