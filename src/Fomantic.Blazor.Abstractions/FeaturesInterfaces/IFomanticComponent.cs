///-------------------------------------------------------------------------------------------------
// file:	Interfaces\IFomanticComponent.cs
//
// summary:	Declares the IFomanticComponent interface
///-------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Fomantic.Blazor.UI
{

    /// <summary>   Base interface for all Fomantic Blazor Components. </summary>
    public interface IFomanticComponent : IAsyncDisposable
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Js runtime object to run javascript interops functions. </summary>
        ///
        /// <value> The js runtime. </value>
        ///-------------------------------------------------------------------------------------------------

        public IJSRuntime JsRuntime { get; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Root element reference. </summary>
        ///
        /// <value> The root element. </value>
        ///-------------------------------------------------------------------------------------------------

        public ElementReference RootElement { get; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   All other Html attributes on the element. </summary>
        ///
        /// <value> The attributes. </value>
        ///-------------------------------------------------------------------------------------------------

        Dictionary<string, object> Attributes { get; }


        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the additional fragment. </summary>
        ///
        /// <value> The additional fragment. </value>
        ///-------------------------------------------------------------------------------------------------

        List<ComponentFragment> AdditionalFragments { get; set; }

    }
}
