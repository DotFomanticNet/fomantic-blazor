///-------------------------------------------------------------------------------------------------
// file:	Interfaces\IFomanticComponentExtension.cs
//
// summary:	Declares the IFomanticComponentExtension interface
///-------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Fomantic.Blazor.UI
{
    /// <summary>   Base interface for all Fomantic Component Extensions. </summary>
    public interface IFomanticComponentExtension : IDisposable
    {
        //
        // Summary:
        //    
        //
        // Parameters:
        //   firstRender:

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Remarks:
        ///      The Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender(System.Boolean)
        ///      and Microsoft.AspNetCore.Components.ComponentBase.OnAfterRenderAsync(System.Boolean)
        ///      lifecycle methods are useful for performing interop, or interacting with values received
        ///      from @ref. Use the firstRender parameter to ensure that initialization work is only
        ///      performed once.
        /// / <summary>
        /// /  Method invoked after each time the component has been rendered. / </summary>
        /// / <param name="firstRender">  Set to true if this is the first time
        /// Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender(System.Boolean) has been invoked
        /// on this component instance; otherwise false.</param>
        /// </summary>
        ///
        /// <param name="firstRender">  Set to true if this is the first time
        ///                             Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender(System.Boolean)
        ///                             has been invoked on this component instance; otherwise false. </param>
        /// <param name="component">    The component. </param>
        ///-------------------------------------------------------------------------------------------------

        void OnAfterRender(bool firstRender, ComponentBase component);

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Summary:
        ///     Method invoked after each time the component has been rendered. Note that the component
        ///     does not automatically re-render after the completion of any returned
        ///     System.Threading.Tasks.Task, because that would cause an infinite render loop.
        /// 
        /// Parameters:
        ///   firstRender:
        ///     Set to true if this is the first time
        ///     Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender(System.Boolean)
        ///     has been invoked on this component instance; otherwise false.
        /// 
        /// Returns:
        ///     A System.Threading.Tasks.Task representing any asynchronous operation.
        /// 
        /// Remarks:
        ///     The Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender(System.Boolean)
        ///     and Microsoft.AspNetCore.Components.ComponentBase.OnAfterRenderAsync(System.Boolean)
        ///     lifecycle methods are useful for performing interop, or interacting with values received
        ///     from @ref. Use the firstRender parameter to ensure that initialization work is only
        ///     performed once.
        /// </summary>
        ///
        /// <param name="firstRender">  Set to true if this is the first time
        ///                             Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender(System.Boolean)
        ///                             has been invoked on this component instance; otherwise false. </param>
        /// <param name="component">    The component. </param>
        ///
        /// <returns>   An asynchronous result. </returns>
        ///-------------------------------------------------------------------------------------------------

        Task OnAfterRenderAsync(bool firstRender, ComponentBase component);

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Summary:
        ///     Method invoked when the component is ready to start, having received its initial
        ///     parameters from its parent in the render tree.
        /// </summary>
        ///
        /// <param name="component">    The component. </param>
        ///-------------------------------------------------------------------------------------------------

        void OnInitialized( ComponentBase component);

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Summary:
        ///     Method invoked when the component is ready to start, having received its initial
        ///     parameters from its parent in the render tree. Override this method if you will perform
        ///     an asynchronous operation and want the component to refresh when that operation is
        ///     completed.
        /// 
        /// Returns:
        ///     A System.Threading.Tasks.Task representing any asynchronous operation.
        /// </summary>
        ///
        /// <param name="component">    The component. </param>
        ///
        /// <returns>   An asynchronous result. </returns>
        ///-------------------------------------------------------------------------------------------------

        Task OnInitializedAsync( ComponentBase component);

    }
}
