///-------------------------------------------------------------------------------------------------
// file:	Interfaces\IFomanticComponentWithTooltip.cs
//
// summary:	Declares the IFomanticComponentWithTooltip interface
///-------------------------------------------------------------------------------------------------

namespace Fomantic.Blazor.UI
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>
    /// Base interface for all Fomantic Blazor Components that could have a tooltip.
    /// </summary>
    ///-------------------------------------------------------------------------------------------------

    public interface IFomanticComponentWithTooltip : IFomanticComponent
    {
        /// <summary>   Determine if the tooltop should be on top Left of the component. </summary>
        const string TopLeftClass = "top left";
        /// <summary>   The top center class. </summary>
        const string TopCenterClass = "top center";
        /// <summary>   The top right class. </summary>
        const string TopRightClass = "top right";
        /// <summary>   The bottom left class. </summary>
        const string BottomLeftClass = "bottom left";
        /// <summary>   The bottom center class. </summary>
        const string BottomCenterClass = "bottom center";
        /// <summary>   The bottom right class. </summary>
        const string BottomRightClass = "bottom right";
        /// <summary>   The right center class. </summary>
        const string RightCenterClass = "right center";
        /// <summary>   The left center class. </summary>
        const string LeftCenterClass = "left center";

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets a value indicating whether this  is tooltip hidden. </summary>
        ///
        /// <value> True if this  is tooltip hidden, false if not. </value>
        ///-------------------------------------------------------------------------------------------------

        bool IsTooltipHidden { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets a value indicating whether this  is tooltip basic format. </summary>
        ///
        /// <value> True if this  is tooltip basic format, false if not. </value>
        ///-------------------------------------------------------------------------------------------------

        bool IsTooltipBasicFormat { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the is tooltip inverted. </summary>
        ///
        /// <value> The is tooltip inverted. </value>
        ///-------------------------------------------------------------------------------------------------

        bool? IsTooltipInverted { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the tooltip text. </summary>
        ///
        /// <value> The tooltip text. </value>
        ///-------------------------------------------------------------------------------------------------
        string TooltipText { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the tooltip position. </summary>
        ///
        /// <value> The tooltip position. </value>
        ///-------------------------------------------------------------------------------------------------
        TooltipPosition TooltipPosition { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the tooltip size. </summary>
        ///
        /// <value> The size of the tooltip. </value>
        ///-------------------------------------------------------------------------------------------------

        Size TooltipSize { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Convert <see cref="Fomantic.Blazor.UI.TooltipPosition"/> to given class. </summary>
        ///
        /// <param name="tooltipPosition">  tooltip Position Value. </param>
        ///
        /// <returns>   Given class from <paramref name="tooltipPosition"/> </returns>
        ///-------------------------------------------------------------------------------------------------

        public static string ToClass(TooltipPosition tooltipPosition)
        {
            return tooltipPosition switch
            {
                TooltipPosition.TopLeft => TopLeftClass,
                TooltipPosition.TopCenter => TopCenterClass,
                TooltipPosition.TopRight => TopRightClass,
                TooltipPosition.BottomLeft => BottomLeftClass,
                TooltipPosition.BottomCenter => BottomCenterClass,
                TooltipPosition.BottomRight => BottomRightClass,
                TooltipPosition.RightCenter => RightCenterClass,
                TooltipPosition.LeftCenter => LeftCenterClass,
                _ => string.Empty,
            };
        }
    }
}