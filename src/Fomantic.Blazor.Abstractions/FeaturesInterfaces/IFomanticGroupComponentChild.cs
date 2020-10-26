///-------------------------------------------------------------------------------------------------
// file:	Interfaces\IFomanticGroupComponentChild.cs
//
// summary:	Declares the IFomanticGroupComponentChild interface
///-------------------------------------------------------------------------------------------------

using Microsoft.AspNetCore.Components;

namespace Fomantic.Blazor.UI
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   Base interface for all fomantic component that has parent component. </summary>
    ///
    /// <typeparam name="TParent">  The parent component type. </typeparam>
    ///-------------------------------------------------------------------------------------------------

    public interface IFomanticGroupComponentChild<TParent> : IFomanticComponent where TParent : IFomanticComponent
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Parent Group. </summary>
        ///
        /// <value> The parent group. </value>
        ///-------------------------------------------------------------------------------------------------

        [CascadingParameter]
        public TParent ParentGroup { get; }
    }
}
