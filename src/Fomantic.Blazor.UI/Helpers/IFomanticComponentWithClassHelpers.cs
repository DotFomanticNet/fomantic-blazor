///-------------------------------------------------------------------------------------------------
// file:	Helpers\IFomanticComponentWithClassHelpers.cs
//
// summary:	Declares the IFomanticComponentWithClassHelpers interface
///-------------------------------------------------------------------------------------------------

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
        /// <summary>   called on construct class to add/update features classess. </summary>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="component">    The component to act on. </param>
        ///
        /// <returns>   A T. </returns>
        ///-------------------------------------------------------------------------------------------------

        internal static T UpdateComponentFeaturesClasses<T>(this T component) where T : FomanticComponentBase
        {
            if (component is IVisibleFomanticComponent visibleFomanticComponent)
            {
                visibleFomanticComponent.AddHiddenClass();
            }
            if (component is IFomanticComponentWithColor fomanticComponentWithColor)
            {
                fomanticComponentWithColor.AddColorClass();
            }
            if (component is ISegmentStyledFomanticComponent segmentStyledFomanticComponent)
            {
                segmentStyledFomanticComponent.AddSegmentStyleClass();
            }
            if (component is IFomanticComponentWithSize fomanticComponentWithSize)
            {
                fomanticComponentWithSize.AddSizeClass();
            }
            if (component is IFomanticComponentWithAlignment fomanticComponentWithAlignment)
            {
                fomanticComponentWithAlignment.AddAlignmentClass();
            }
            if (component is IFomanticComponentWithContentAlignment fomanticComponentWithContentAlignment)
            {
                fomanticComponentWithContentAlignment.AddContentAlignmentClass();
            }
            if (component is IFomanticComponentWithContentSpacing fomanticComponentWithContentSpacing)
            {
                fomanticComponentWithContentSpacing.AddContentSpacingClass();
            }
            if (component is IFomanticComponentCanBeDisabled fomanticComponentCanBeDisabled)
            {
                fomanticComponentCanBeDisabled.AddDisabledClass();
            }
            if (component is IFomanticComponentWithInvertedStyle fomanticComponentWithInvertedStyle)
            {
                fomanticComponentWithInvertedStyle.AddInvertedClass();
            }
            if (component is IFomanticComponentWithLoadingIndicator fomanticComponentWithLoadingIndicator)
            {
                fomanticComponentWithLoadingIndicator.AddLoadingIndicatorClass();
            }
            if (component is IFomanticComponentWithCompactStyle fomanticComponentWithCompactStyle)
            {
                fomanticComponentWithCompactStyle.AddCompactClass();
            }
            if (component is IAttachableFomanticComponent attachableFomanticComponent)
            {
                attachableFomanticComponent.AddAttachClass();
            }
            if (component is IFomanticComponentCanBeUnselectable fomanticComponentCanBeUnselectable)
            {
                fomanticComponentCanBeUnselectable.AddUnselectableClass();
            }
            if (component is IFomanticComponentWithFittedStyle fomanticComponentWithFittedStyle)
            {
                fomanticComponentWithFittedStyle.AddFittedClass();
            }
            if (component is IFomanticComponentWithCircularStyle fomanticComponentWithCircularStyle)
            {
                fomanticComponentWithCircularStyle.AddCircularClass();
            }
            if (component is IFomanticComponentWithDividingStyle fomanticComponentWithDividingStyle)
            {
                fomanticComponentWithDividingStyle.AddDividingClass();
            }
            if (component is IFomanticComponentWithTextStyle fomanticComponentWithTextStyle)
            {
                fomanticComponentWithTextStyle.AddTextStyleClass();
            }
            
            return component;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   called on AfterRender to add/update features. </summary>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="component">    The component to act on. </param>
        ///
        /// <returns>   A T. </returns>
        ///-------------------------------------------------------------------------------------------------

        internal static T UpdateComponentFeaturesAfterRender<T>(this T component) where T : FomanticComponentBase
        {
            if (component is IFomanticComponentWithTooltip fomanticComponentWithTooltip)
            {
                fomanticComponentWithTooltip.AddTooltip();
            }
            return component;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   A T extension method that adds a tooltip. </summary>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="component">    The component to act on. </param>
        ///
        /// <returns>   A T. </returns>
        ///-------------------------------------------------------------------------------------------------

        static T AddTooltip<T>(this T component) where T : IFomanticComponentWithTooltip
        {

            if (component.HasTooltip())
            {
                component.AddOrUpdateAttribute("data-tooltip", component.TooltipText);
                if (component.IsTooltipInverted.HasValue && component.IsTooltipInverted.Value)
                {
                    component.AddOrUpdateAttribute("data-inverted", "");
                }
                else
                {
                    if (component is IFomanticComponentWithInvertedStyle && (component as IFomanticComponentWithInvertedStyle).IsInverted)
                    {
                        component.AddOrUpdateAttribute("data-inverted", "");
                    }

                }
                component.AddOrUpdateAttribute("data-position", IFomanticComponentWithTooltip.ToClass(component.TooltipPosition));
                string variation = "";
                variation += " " + IFomanticComponentWithSize.ToClass(component.TooltipSize);
                if (component.IsTooltipBasicFormat)
                {
                    variation += " basic";
                }
                component.AddOrUpdateAttribute("data-variation", variation);

            }
            else
            {
                component.RemoveAttribute("data-tooltip");
                component.RemoveAttribute("data-variation");
                component.RemoveAttribute("data-position");
            }
            return component;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   A T extension method that adds a hidden class to 'index'. </summary>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="component">    The component to act on. </param>
        /// <param name="index">        (Optional) Zero-based index of the. </param>
        ///
        /// <returns>   A T. </returns>
        ///-------------------------------------------------------------------------------------------------

        static T AddHiddenClass<T>(this T component, int? index = null) where T : IVisibleFomanticComponent
        {
            if (component.IsHidden)
            {
                if (index.HasValue)
                {
                    component.CssClasses.Insert(index.Value, IVisibleFomanticComponent.HiddenClass);
                }
                else
                {
                    component.CssClasses.Add(IVisibleFomanticComponent.HiddenClass);
                }
            }

            return component;
        }

        static T AddTextStyleClass<T>(this T component, int? index = null) where T : IFomanticComponentWithTextStyle
        {
            if (component.IsBold)
            {
                if (index.HasValue)
                {
                    component.CssClasses.Insert(index.Value, IFomanticComponentWithTextStyle.BoldClass);
                }
                else
                {
                    component.CssClasses.Add(IFomanticComponentWithTextStyle.BoldClass);
                }
            }
            if (component.TextDecoration.HasValue)
            {
                if (index.HasValue)
                {
                    component.CssClasses.Insert(index.Value, IFomanticComponentWithTextStyle.ToClass(component.TextDecoration));
                }
                else
                {
                    component.CssClasses.Add(IFomanticComponentWithTextStyle.ToClass(component.TextDecoration));
                }
            }
            if (component.IsItalic)
            {
                if (index.HasValue)
                {
                    component.CssClasses.Insert(index.Value, IFomanticComponentWithTextStyle.ItalicClass);
                }
                else
                {
                    component.CssClasses.Add(IFomanticComponentWithTextStyle.ItalicClass);
                }
            }
            return component;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   A T extension method that adds a color class to 'index'. </summary>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="component">    The component to act on. </param>
        /// <param name="index">        (Optional) Zero-based index of the. </param>
        ///
        /// <returns>   A T. </returns>
        ///-------------------------------------------------------------------------------------------------

        static T AddColorClass<T>(this T component, int? index = null) where T : IFomanticComponentWithColor
        {
            if (index.HasValue)
            {
                component.CssClasses.Insert(index.Value, IFomanticComponentWithColor.ToClass(component.Color));
            }
            else
            {
                component.CssClasses.Add(IFomanticComponentWithColor.ToClass(component.Color));
            }
            return component;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   A T extension method that adds a segment style class to 'index'. </summary>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="component">    The component to act on. </param>
        /// <param name="index">        (Optional) Zero-based index of the. </param>
        ///
        /// <returns>   A T. </returns>
        ///-------------------------------------------------------------------------------------------------

        static T AddSegmentStyleClass<T>(this T component, int? index = null) where T : ISegmentStyledFomanticComponent
        {
            if (index.HasValue)
            {
                component.CssClasses.Insert(index.Value, ISegmentStyledFomanticComponent.ToClass(component.SegmentStyle));
            }
            else
            {
                component.CssClasses.Add(ISegmentStyledFomanticComponent.ToClass(component.SegmentStyle));
            }
            return component;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   A T extension method that adds a size class to 'index'. </summary>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="component">    The component to act on. </param>
        /// <param name="index">        (Optional) Zero-based index of the. </param>
        ///
        /// <returns>   A T. </returns>
        ///-------------------------------------------------------------------------------------------------

        static T AddSizeClass<T>(this T component, int? index = null) where T : IFomanticComponentWithSize
        {
            if (index.HasValue)
            {
                component.CssClasses.Insert(index.Value, IFomanticComponentWithSize.ToClass(component.Size));
            }
            else
            {
                component.CssClasses.Add(IFomanticComponentWithSize.ToClass(component.Size));
            }
            return component;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   A T extension method that adds an alignment class to 'index'. </summary>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="component">    The component to act on. </param>
        /// <param name="index">        (Optional) Zero-based index of the. </param>
        ///
        /// <returns>   A T. </returns>
        ///-------------------------------------------------------------------------------------------------

        static T AddAlignmentClass<T>(this T component, int? index = null) where T : IFomanticComponentWithAlignment
        {
            if (index.HasValue)
            {
                component.CssClasses.Insert(index.Value, IFomanticComponentWithAlignment.ToClass(component.Alignment));
            }
            else
            {
                component.CssClasses.Add(IFomanticComponentWithAlignment.ToClass(component.Alignment));
            }
            return component;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   A T extension method that adds a content alignment class to 'index'. </summary>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="component">    The component to act on. </param>
        /// <param name="index">        (Optional) Zero-based index of the. </param>
        ///
        /// <returns>   A T. </returns>
        ///-------------------------------------------------------------------------------------------------

        static T AddContentAlignmentClass<T>(this T component, int? index = null) where T : IFomanticComponentWithContentAlignment
        {
            if (index.HasValue)
            {
                component.CssClasses.Insert(index.Value, IFomanticComponentWithContentAlignment.ToClass(component.ContentAlignment));
            }
            else
            {
                component.CssClasses.Add(IFomanticComponentWithContentAlignment.ToClass(component.ContentAlignment));
            }
            return component;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   A T extension method that adds a content spacing class to 'index'. </summary>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="component">    The component to act on. </param>
        /// <param name="index">        (Optional) Zero-based index of the. </param>
        ///
        /// <returns>   A T. </returns>
        ///-------------------------------------------------------------------------------------------------

        static T AddContentSpacingClass<T>(this T component, int? index = null) where T : IFomanticComponentWithContentSpacing
        {
            if (index.HasValue)
            {
                component.CssClasses.Insert(index.Value, IFomanticComponentWithContentSpacing.ToClass(component.ContentSpace));
            }
            else
            {
                component.CssClasses.Add(IFomanticComponentWithContentSpacing.ToClass(component.ContentSpace));
            }
            return component;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   A T extension method that adds a disabled class to 'index'. </summary>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="component">    The component to act on. </param>
        /// <param name="index">        (Optional) Zero-based index of the. </param>
        ///
        /// <returns>   A T. </returns>
        ///-------------------------------------------------------------------------------------------------

        static T AddDisabledClass<T>(this T component, int? index = null) where T : IFomanticComponentCanBeDisabled
        {
            if (component.IsDisabled)
            {
                if (index.HasValue)
                {
                    component.CssClasses.Insert(index.Value, IFomanticComponentCanBeDisabled.DisabledClass);
                }
                else
                {
                    component.CssClasses.Add(IFomanticComponentCanBeDisabled.DisabledClass);
                }
            }

            return component;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   A T extension method that adds an inverted class to 'index'. </summary>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="component">    The component to act on. </param>
        /// <param name="index">        (Optional) Zero-based index of the. </param>
        ///
        /// <returns>   A T. </returns>
        ///-------------------------------------------------------------------------------------------------

        static T AddInvertedClass<T>(this T component, int? index = null) where T : IFomanticComponentWithInvertedStyle
        {
            if (component.IsInverted)
            {
                if (index.HasValue)
                {
                    component.CssClasses.Insert(index.Value, IFomanticComponentWithInvertedStyle.InvertedClass);
                }
                else
                {
                    component.CssClasses.Add(IFomanticComponentWithInvertedStyle.InvertedClass);
                }
            }

            return component;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   A T extension method that adds a loading indicator class to 'index'. </summary>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="component">    The component to act on. </param>
        /// <param name="index">        (Optional) Zero-based index of the. </param>
        ///
        /// <returns>   A T. </returns>
        ///-------------------------------------------------------------------------------------------------

        static T AddLoadingIndicatorClass<T>(this T component, int? index = null) where T : IFomanticComponentWithLoadingIndicator
        {
            if (component.IsLoading)
            {
                if (index.HasValue)
                {
                    component.CssClasses.Insert(index.Value, IFomanticComponentWithLoadingIndicator.LoadingClass);
                }
                else
                {
                    component.CssClasses.Add(IFomanticComponentWithLoadingIndicator.LoadingClass);
                }
            }

            return component;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   A T extension method that adds a compact class to 'index'. </summary>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="component">    The component to act on. </param>
        /// <param name="index">        (Optional) Zero-based index of the. </param>
        ///
        /// <returns>   A T. </returns>
        ///-------------------------------------------------------------------------------------------------

        static T AddCompactClass<T>(this T component, int? index = null) where T : IFomanticComponentWithCompactStyle
        {
            if (component.IsCompact)
            {
                if (index.HasValue)
                {
                    component.CssClasses.Insert(index.Value, IFomanticComponentWithCompactStyle.CompactClass);
                }
                else
                {
                    component.CssClasses.Add(IFomanticComponentWithCompactStyle.CompactClass);
                }
            }

            return component;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   A T extension method that adds an attach class to 'index'. </summary>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="component">    The component to act on. </param>
        /// <param name="index">        (Optional) Zero-based index of the. </param>
        ///
        /// <returns>   A T. </returns>
        ///-------------------------------------------------------------------------------------------------

        static T AddAttachClass<T>(this T component, int? index = null) where T : IAttachableFomanticComponent
        {
            if (index.HasValue)
            {
                component.CssClasses.Insert(index.Value, IAttachableFomanticComponent.ToClass(component.Attaching));
            }
            else
            {
                component.CssClasses.Add(IAttachableFomanticComponent.ToClass(component.Attaching));
            }
            return component;

        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   A T extension method that adds an unselectable class to 'index'. </summary>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="component">    The component to act on. </param>
        /// <param name="index">        (Optional) Zero-based index of the. </param>
        ///
        /// <returns>   A T. </returns>
        ///-------------------------------------------------------------------------------------------------

        static T AddUnselectableClass<T>(this T component, int? index = null) where T : IFomanticComponentCanBeUnselectable
        {
            if (component.IsUnselectable)
            {
                if (index.HasValue)
                {
                    component.CssClasses.Insert(index.Value, IFomanticComponentCanBeUnselectable.UnselectableClass);
                }
                else
                {
                    component.CssClasses.Add(IFomanticComponentCanBeUnselectable.UnselectableClass);
                }
            }

            return component;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   A T extension method that adds a fitted class to 'index'. </summary>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="component">    The component to act on. </param>
        /// <param name="index">        (Optional) Zero-based index of the. </param>
        ///
        /// <returns>   A T. </returns>
        ///-------------------------------------------------------------------------------------------------

        static T AddFittedClass<T>(this T component, int? index = null) where T : IFomanticComponentWithFittedStyle
        {
            if (component.IsFitted)
            {
                if (index.HasValue)
                {
                    component.CssClasses.Insert(index.Value, IFomanticComponentWithFittedStyle.FittedClass);
                }
                else
                {
                    component.CssClasses.Add(IFomanticComponentWithFittedStyle.FittedClass);
                }
            }

            return component;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   A T extension method that adds a circular class to 'index'. </summary>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="component">    The component to act on. </param>
        /// <param name="index">        (Optional) Zero-based index of the. </param>
        ///
        /// <returns>   A T. </returns>
        ///-------------------------------------------------------------------------------------------------

        static T AddCircularClass<T>(this T component, int? index = null) where T : IFomanticComponentWithCircularStyle
        {
            if (component.IsCircular)
            {
                if (index.HasValue)
                {
                    component.CssClasses.Insert(index.Value, IFomanticComponentWithCircularStyle.CircularClass);
                }
                else
                {
                    component.CssClasses.Add(IFomanticComponentWithCircularStyle.CircularClass);
                }
            }

            return component;
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   A T extension method that adds a dividing class to 'index'. </summary>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="component">    The component to act on. </param>
        /// <param name="index">        (Optional) Zero-based index of the. </param>
        ///
        /// <returns>   A T. </returns>
        ///-------------------------------------------------------------------------------------------------

        static T AddDividingClass<T>(this T component, int? index = null) where T : IFomanticComponentWithDividingStyle
        {
            if (component.IsDividing)
            {
                if (index.HasValue)
                {
                    component.CssClasses.Insert(index.Value, IFomanticComponentWithDividingStyle.DividingClass);
                }
                else
                {
                    component.CssClasses.Add(IFomanticComponentWithDividingStyle.DividingClass);
                }
            }

            return component;
        }
    }
}
