namespace Fomantic.Blazor.UI
{
    /// <summary>
    /// Base interface for all Fomantic Blazor Components that could have a tooltip
    /// </summary>
    public interface IFomanticComponentWithTooltip : IFomanticComponent
    {
        /// <summary>
        /// Determine if the tooltop should be on top Left of the component
        /// </summary>
        const string TopLeftClass = "top left";
        const string TopCenterClass = "top center";
        const string TopRightClass = "top right";
        const string BottomLeftClass = "bottom left";
        const string BottomCenterClass = "bottom center";
        const string BottomRightClass = "bottom right";
        const string RightCenterClass = "right center";
        const string LeftCenterClass = "left center";
        bool IsTooltipHidden { get; set; }

        bool IsTooltipBasicFormat { get; set; }

        bool? IsTooltipInverted { get; set; }
        string? TooltipText { get; set; }

        TooltipPosition TooltipPosition { get; set; }

        Size TooltipSize { get; set; }


        /// <summary>
        /// Convert <see cref="Fomantic.Blazor.UI.TooltipPosition"/> to given class
        /// </summary>
        /// <param name="tooltipPosition">tooltip Position Value</param>
        /// <returns>Given class from <paramref name="tooltipPosition"/> </returns>
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