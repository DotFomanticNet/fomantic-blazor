///-------------------------------------------------------------------------------------------------
// file:	Interfaces\IFomanticComponentWithBlurEffect.cs
//
// summary:	Declares the IFomanticComponentWithBlurEffect interface
///-------------------------------------------------------------------------------------------------

using Fomantic.Blazor.UI;
using Microsoft.AspNetCore.Components;

namespace Fomantic
{
    /// <summary>   Base interface for all fomantic component that can have blur effect. </summary>
    public interface IFomanticComponentWithBlurEffect : IFomanticComponentWithClass
    {



        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Determine if the component should has blur effect or not. </summary>
        ///
        /// <value> True if this  is blurring, false if not. </value>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        bool IsBlurring { get; set; }
    }
}
