///-------------------------------------------------------------------------------------------------
// file:	Interfaces\IFomanticComponent.cs
//
// summary:	Declares the IFomanticComponent interface
///-------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace Fomantic.Blazor.UI
{
    /// <summary>   Base interface for all Fomantic Blazor Components that allow extentions inside. </summary>
    public interface IFomanticComponentWithExtensions : IFomanticComponent
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   List Of Fomantic Component Extensions. </summary>
        ///
        /// <value> The extensions. </value>
        ///-------------------------------------------------------------------------------------------------

        public List<IFomanticExtension> Extensions { get; }

    }
}
