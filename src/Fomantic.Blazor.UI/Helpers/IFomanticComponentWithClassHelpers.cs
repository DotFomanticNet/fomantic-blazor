using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Fomantic.Blazor.UI
{
    static class IFomanticComponentWithClassHelpers
    {
        internal static T AddHiddenClass<T>(this T component, int? index = null) where T : IVisibleFomanticComponent
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
        internal static T AddColorClass<T>(this T component, int? index = null) where T : IFomanticComponentWithColor
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
        internal static T AddISegmentStyleClass<T>(this T component, int? index = null) where T : ISegmentStyledFomanticComponent
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
        internal static T AddSizeClass<T>(this T component, int? index = null) where T : IFomanticComponentWithSize
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
        internal static T AddAlignmentClass<T>(this T component, int? index = null) where T : IFomanticComponentWithAlignment
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
        internal static T AddContentAlignmentClass<T>(this T component, int? index = null) where T : IFomanticComponentWithContentAlignment
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
        internal static T AddContentSpacingClass<T>(this T component, int? index = null) where T : IFomanticComponentWithContentSpacing
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
        internal static T AddDisabledClass<T>(this T component, int? index = null) where T : IFomanticComponentCanBeDisabled
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
        internal static T AddInvertedClass<T>(this T component, int? index = null) where T : IFomanticComponentWithInvertedStyle
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
        internal static T AddLoadingIndicatorClass<T>(this T component, int? index = null) where T : IFomanticComponentWithLoadingIndicator
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
        internal static T AddCompactClass<T>(this T component, int? index = null) where T : IFomanticComponentWithCompactStyle
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
        internal static T AddAttachClass<T>(this T component, int? index = null) where T : IAttachableFomanticComponent
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
        internal static T AddUnselectableClass<T>(this T component, int? index = null) where T : IFomanticComponentCanBeUnselectable
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

        internal static T AddFittedClass<T>(this T component, int? index = null) where T : IFomanticComponentWithFittedStyle
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

        internal static T AddCircularClass<T>(this T component, int? index = null) where T : IFomanticComponentWithCircularStyle
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

        internal static T AddDividingClass<T>(this T component, int? index = null) where T : IFomanticComponentWithDividingStyle
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
