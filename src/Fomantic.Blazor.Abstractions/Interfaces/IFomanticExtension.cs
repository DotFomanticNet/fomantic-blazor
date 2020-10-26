///-------------------------------------------------------------------------------------------------
// file:	Interfaces\IFomanticComponentExtension.cs
//
// summary:	Declares the IFomanticComponentExtension interface
///-------------------------------------------------------------------------------------------------

using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fomantic.Blazor.UI
{
    /// <summary>   Base interface for all Fomantic Component Extensions. </summary>
    public interface IFomanticExtension : IAsyncDisposable
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the parent state has changed. </summary>
        ///
        /// <value> The parent state has changed. </value>
        ///-------------------------------------------------------------------------------------------------

        Action ParentStateHasChanged { get; set; }
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the parent. </summary>
        ///
        /// <value> The parent. </value>
        ///-------------------------------------------------------------------------------------------------

        [CascadingParameter(Name ="Parent")]
        public IFomanticComponentWithExtensions Parent { get; set; }
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Executes the 'after each render' action. </summary>
        ///
        
        ///
        /// <returns>   A ValueTask&lt;bool&gt; </returns>
        ///-------------------------------------------------------------------------------------------------

        ValueTask<bool> OnComponentAfterEachRender();

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Executes the 'after first render' action. </summary>
        ///        
        ///
        /// <returns>   A ValueTask&lt;bool&gt; </returns>
        ///-------------------------------------------------------------------------------------------------

        ValueTask<bool> OnComponentAfterFirstRender();

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Executes the 'initialized' action. </summary>
        /// <returns>   A ValueTask. </returns>
        ///-------------------------------------------------------------------------------------------------

        ValueTask OnComponentInitialized();

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Provide CSS classes. </summary>
        ///
        ///
        /// <returns>   A string[]. </returns>
        ///-------------------------------------------------------------------------------------------------

        string[] ProvideComponentCssClasses();

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Provide CSS class. </summary>
        ///      
        ///
        /// <returns>   A string. </returns>
        ///-------------------------------------------------------------------------------------------------

        string ProvideComponentCssClass();

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the additional fragment. </summary>
        ///
        /// <value> The additional fragment. </value>
        ///-------------------------------------------------------------------------------------------------

        List<ComponentFragment> ComponentAdditionalFragments { get; }

    }
}
