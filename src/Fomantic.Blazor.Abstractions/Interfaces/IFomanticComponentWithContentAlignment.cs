///-------------------------------------------------------------------------------------------------
// file:	Interfaces\IFomanticComponentWithContentAlignment.cs
//
// summary:	Declares the IFomanticComponentWithContentAlignment interface
///-------------------------------------------------------------------------------------------------

using Microsoft.AspNetCore.Components;

namespace Fomantic.Blazor.UI
{
    /// <summary>   Base interface for all fomantic component  align thier content. </summary>
    public interface IFomanticComponentWithContentAlignment : IFomanticComponentWithClass
    {
      

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Determine how the component should  align its content. </summary>
        ///
        /// <value> The content alignment. </value>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        public ContentAlignment? ContentAlignment { get; set; }

     
    }
}
