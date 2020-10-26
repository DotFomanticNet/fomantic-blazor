///-------------------------------------------------------------------------------------------------
// file:	Interfaces\IFomanticComponentWithSize.cs
//
// summary:	Declares the IFomanticComponentWithSize interface
///-------------------------------------------------------------------------------------------------

using Microsoft.AspNetCore.Components;

namespace Fomantic.Blazor.UI
{
    /// <summary>   Base interface for all fomantic component that can have many sizes. </summary>
    public interface IFomanticComponentWithSize : IFomanticComponentWithClass
    {
      

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Determine the size of the component. </summary>
        ///
        /// <value> The size. </value>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        Size Size { get; set; }

       
    }
}


