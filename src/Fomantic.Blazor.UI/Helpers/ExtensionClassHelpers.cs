// file:	Helpers\IFomanticComponentWithClassHelpers.cs
//
// summary:	Declares the IFomanticComponentWithClassHelpers interface


using Microsoft.AspNetCore.Components;
///-------------------------------------------------------------------------------------------------
///-------------------------------------------------------------------------------------------------
namespace Fomantic.Blazor.UI
{
    /// <summary>   An extension class helpers. </summary>
    public static class ExtensionClassHelpers
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// An IFomanticComponentExtension extension method that adds an additional fragment.
        /// </summary>
        ///
        /// <param name="extension">        The extension to act on. </param>
        /// <param name="loc">              The location. </param>
        /// <param name="renderFragment">   The render fragment. </param>
        ///
        /// <returns>   An IFomanticComponentExtension. </returns>
        ///-------------------------------------------------------------------------------------------------

        public static IFomanticComponentExtension AddComponentAdditionalFragment(this IFomanticComponentExtension extension, string loc, RenderFragment renderFragment)
        {
            extension.ComponentAdditionalFragments.Add(
            new ComponentFragment()
            {
                Location = loc,
                Fragment = d => renderFragment
            });
            return extension;
        }
    }
}
