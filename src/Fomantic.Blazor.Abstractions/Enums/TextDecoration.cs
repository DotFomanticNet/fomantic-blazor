///-------------------------------------------------------------------------------------------------
// file:	Enums\StaticAnimation.cs
//
// summary:	Implements the static animation class
///-------------------------------------------------------------------------------------------------

namespace Fomantic.Blazor.UI
{
    /// <summary>   Type of text decoration that used to style text components. </summary>

    public enum TextDecoration
    {/// <summary>
     ///Decorat text with  over line 
     /// </summary>
        OverLine = 0,
        /// <summary>
        ///Decorat text with  line through
        /// </summary>
        LineThrough = 1,

        /// <summary>
        ///  Decorat text with under  line  
        /// </summary>
        UnderLine = 2,

        /// <summary>
        /// Decorat text with  under and over line 
        /// </summary>
        UnderLineOverline = 3
    }
}
