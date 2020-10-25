///-------------------------------------------------------------------------------------------------
// file:	Helpers\InputAttributesHelper.cs
//
// summary:	Implements the input attributes helper class
///-------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Fomantic.Blazor.UI
{
    /// <summary>   An input attributes helper. </summary>
    internal static class InputAttributesHelper
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the main element attributes in this collection. </summary>
        ///
        /// <param name="attributes">   The attributes to act on. </param>
        ///
        /// <returns>
        /// An enumerator that allows foreach to be used to process the main element attributes in this
        /// collection.
        /// </returns>
        ///-------------------------------------------------------------------------------------------------

        public static IEnumerable<KeyValuePair<string, object>> GetMainElementAttributes(this Dictionary<string, object> attributes)
        {

            return attributes.Where(d => !d.Key.Contains("."));
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets the main element attributes in this collection. </summary>
        ///
        /// <param name="attributes">   The attributes to act on. </param>
        /// <param name="element">      The element. </param>
        ///
        /// <returns>
        /// An enumerator that allows foreach to be used to process the main element attributes in this
        /// collection.
        /// </returns>
        ///-------------------------------------------------------------------------------------------------

        public static IEnumerable<KeyValuePair<string, object>> GetMainElementAttributes(this Dictionary<string, object> attributes, string element)
        {
            var x = attributes.Where(d => d.Key.ToLower().StartsWith($"{element.ToLower()}."))
                .Select(d => new KeyValuePair<string, object>(d.Key.Replace($"{element.ToLower()}.", ""), d.Value));

            return x;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   A T extension method that adds an or update attribute. </summary>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="component">    The component to act on. </param>
        /// <param name="key">          The key. </param>
        /// <param name="value">        The value. </param>
        /// <param name="hasChanged">will be true of the attribute value changed</param>
        ///
        /// <returns>   A T. </returns>
        ///-------------------------------------------------------------------------------------------------

        internal static T AddOrUpdateAttribute<T>(this T component, string key, object value, ref bool hasChanged) where T : IFomanticComponent
        {


            if (component.Attributes.ContainsKey(key))
            {
                if (component.Attributes[key] != value)
                {
                    component.Attributes[key] = value;
                    hasChanged = true;
                }
            }
            else
            {
                component.Attributes.Add(key, value);
                hasChanged = true;
            }

            return component;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   A T extension method that removes the attribute. </summary>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="component">    The component to act on. </param>
        /// <param name="key">          The key. </param>
        ///
        /// <returns>   A T. </returns>
        ///-------------------------------------------------------------------------------------------------

        internal static T RemoveAttribute<T>(this T component, string key) where T : IFomanticComponent
        {


            if (component.Attributes.ContainsKey(key))
            {

                component.Attributes.Remove(key);
            }


            return component;
        }
    }
}
