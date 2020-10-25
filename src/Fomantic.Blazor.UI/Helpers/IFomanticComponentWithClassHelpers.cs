
using Fomantic.Blazor.UI.Features;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Fomantic.Blazor.UI
{
    /// <summary>   A fomantic component with class helpers. </summary>
    static class IFomanticComponentWithClassHelpers
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

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   A T extension method that adds the class to 'classes'. </summary>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="component">    The component to act on. </param>
        /// <param name="classes">      A variable-length parameters list containing classes to be added. </param>
        ///
        /// <returns>   A T. </returns>
        ///-------------------------------------------------------------------------------------------------

        public static T AddClass<T>(this T component, params string[] classes) where T : IFomanticComponentWithClass
        {
            foreach (var item in classes)
            {
                if (!component.CssClass.Contains(item))
                {
                    component.CssClasses.Add(item);
                }
            }
            return component;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   A T extension method that removes the class. </summary>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="component">    The component to act on. </param>
        /// <param name="classes">      A variable-length parameters list containing classes to be removed. </param>
        ///
        /// <returns>   A T. </returns>
        ///-------------------------------------------------------------------------------------------------

        public static T RemoveClass<T>(this T component, params string[] classes) where T : IFomanticComponentWithClass
        {
            foreach (var item in classes)
            {
                if (component.CssClass.Contains(item))
                {
                    component.CssClasses.Remove(item);
                }
            }
            return component;
        }
    }
}
