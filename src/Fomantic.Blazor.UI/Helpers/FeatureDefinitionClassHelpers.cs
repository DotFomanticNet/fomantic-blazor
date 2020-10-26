///-------------------------------------------------------------------------------------------------
// file:	Helpers\IFomanticComponentWithClassHelpers.cs
//
// summary:	Declares the IFomanticComponentWithClassHelpers interface
///-------------------------------------------------------------------------------------------------

using Fomantic.Blazor.UI.Features;
using Microsoft.AspNetCore.Components;
using System;

namespace Fomantic.Blazor.UI
{
    /// <summary>   A feature definition class helpers. </summary>
    public static class FeatureDefinitionClassHelpers
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// An UIFeatureDefinition&lt;T&gt; extension method that adds an additional fragment.
        /// </summary>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="feature">  The feature to act on. </param>
        /// <param name="loc">      The location to render fragment. </param>
        /// <param name="func">     The fragment function. </param>
        ///
        /// <returns>   An UIFeatureDefinition&lt;T&gt; </returns>
        ///-------------------------------------------------------------------------------------------------

        public static UIFeatureDefinition<T> AddAdditionalFragment<T>(this UIFeatureDefinition<T> feature, string loc, Func<T, RenderFragment> func) where T : IFomanticComponent
        {
            feature.AdditionalFragments.Add(
            new ComponentFragment()
            {
                Location = loc,
                Fragment = d => func((T)d)
            });
            return feature;
        }
    }
}
