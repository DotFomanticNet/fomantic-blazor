///-------------------------------------------------------------------------------------------------
// file:	Interfaces\IFomanticComponentWithContentAlignment.cs
//
// summary:	Declares the IFomanticComponentWithContentAlignment interface
///-------------------------------------------------------------------------------------------------

using Microsoft.AspNetCore.Components;

namespace Fomantic.Blazor.UI
{
    /// <summary>   Base interface for dimmer with shade degree. </summary>
    public interface IFomanticDimmerWithShadeDegree : IFomanticComponentWithClass
    {


        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Determine how dark the dimmer shade is. </summary>
        ///
        /// <value> The dimmer shade. </value>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        public DimmerShade? Shade { get; set; }


    }
}
