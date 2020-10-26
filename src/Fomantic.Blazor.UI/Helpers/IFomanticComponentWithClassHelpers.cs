///-------------------------------------------------------------------------------------------------
// file:	Helpers\IFomanticComponentWithClassHelpers.cs
//
// summary:	Declares the IFomanticComponentWithClassHelpers interface
///-------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Fomantic.Blazor.UI
{

    /// <summary>   A fomantic component with class helpers. </summary>
    public static class IFomanticComponentWithClassHelpers
    {
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
        /// <param name="classes">      A variable-length parameters list containing classes to be
        ///                             removed. </param>
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
