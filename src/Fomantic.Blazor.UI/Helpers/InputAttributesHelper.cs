using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Fomantic.Blazor.UI
{
    internal static class InputAttributesHelper
    {
        public static IEnumerable<KeyValuePair<string, object>> GetMainElementAttributes(this Dictionary<string, object> attributes)
        {
           
            return attributes.Where(d => !d.Key.Contains("."));
        }
        public static IEnumerable<KeyValuePair<string, object>> GetMainElementAttributes(this Dictionary<string, object> attributes, string element)
        {
            var x = attributes.Where(d => d.Key.ToLower().StartsWith($"{element.ToLower()}."))
                .Select(d => new KeyValuePair<string, object>(d.Key.Replace($"{element.ToLower()}.", ""), d.Value));

            return x;
        }

        internal static T AddOrUpdateAttribute<T>(this T component, string key, object value) where T : IFomanticComponentWithTooltip
        {


            if (component.Attributes.ContainsKey(key))
            {

                component.Attributes[key] = value;
            }
            else
            {
                component.Attributes.Add(key, value);
            }

            return component;
        }

        internal static T RemoveAttribute<T>(this T component, string key) where T : IFomanticComponentWithTooltip
        {


            if (component.Attributes.ContainsKey(key))
            {

                component.Attributes.Remove(key);
            }


            return component;
        }
    }
}
