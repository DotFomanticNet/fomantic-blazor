///-------------------------------------------------------------------------------------------------
// file:	Interfaces\IFomanticGroupComponent.cs
//
// summary:	Declares the IFomanticGroupComponent interface
///-------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Fomantic.Blazor.UI
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   Base interface for all fomantic component that has children component. </summary>
    ///
    /// <typeparam name="TChild">   The parent component type. </typeparam>
    ///-------------------------------------------------------------------------------------------------

    public interface IFomanticGroupComponent<TChild> : IFomanticComponent where TChild : IFomanticComponent
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   List of Children <typeparamref name="TChild"/> </summary>
        ///
        /// <value> The children. </value>
        ///-------------------------------------------------------------------------------------------------

        ReadOnlyCollection<TChild> Children { get; }
    }
}
