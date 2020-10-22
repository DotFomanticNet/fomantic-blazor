namespace Fomantic.Blazor.UI
{
    /// <summary>
    /// A segment or segment group may be formatted to be in different style 
    /// </summary>
    public enum SegmentStyle
    {
        /// <summary>
        /// Normal Style of segment or segment group 
        /// </summary>
        Normal=0,
        /// <summary>
        /// A basic segment or segment group has no special formatting
        /// </summary>
        Basic,
        /// <summary>
        /// A segment or segment group may be formatted to raise above the page.
        /// </summary>
        Raised,
        /// <summary>
        /// A segment or segment group can be formatted to show it contains multiple pages
        /// </summary>
        Stacked,
        /// <summary>
        /// A segment can be formatted to show it contains multiple pages
        /// </summary>
        TallStacked,
        /// <summary>
        /// A segment can be formatted to look like a pile of pages
        /// </summary>
        Piled
    }
}
