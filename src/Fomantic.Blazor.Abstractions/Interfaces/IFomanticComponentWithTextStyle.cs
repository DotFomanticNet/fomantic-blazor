///-------------------------------------------------------------------------------------------------
// file:	Interfaces\IFomanticComponentWithTextStyle.cs
//
// summary:	Declares the IFomanticComponentWithTextStyle interface
///-------------------------------------------------------------------------------------------------

using Fomantic.Blazor.UI;

using Microsoft.AspNetCore.Components;

using System.Net.Http.Headers;

namespace Fomantic
{
    /// <summary>   Base interface for all fomantic component can be with text style. </summary>
    public interface IFomanticComponentWithTextStyle : IFomanticComponentWithClass
    {
        /// <summary>   class given to make component bold. </summary>
        const string BoldClass = "bold";

        /// <summary>   class given to make component bold. </summary>
        const string TextOverLine = "textoverline";

        /// <summary>   class given to make component bold. </summary>
        const string TextlineThrough = "textlinethrough";

        /// <summary>   class given to make component bold. </summary>
        const string Textunderline = "textunderline";

        /// <summary>   class given to make component bold. </summary>
        const string TextUnderOverline = "textunderoverline";

        /// <summary>   class given to make component bold. </summary>
        const string ItalicClass = "italic";


        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Determine if the component font should be bold  or not. </summary>
        ///
        /// <value> True if this  is bold, false if not. </value>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        public bool IsBold { get; set; }


        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Determine if the component font should be italic  or not. </summary>
        ///
        /// <value> True if this  is italic, false if not. </value>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        public bool IsItalic { get; set; }
        ///-------------------------------------------------------------------------------------------------
        /// <summary>  Determine what kind of text decoration apply  on text  </summary>
        ///
        /// <value> Type of decuration  should be applied</value>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        public TextDecoration? TextDecoration { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Convert <see cref="Fomantic.Blazor.UI.TextDecoration"/> to given class. </summary>
        ///
        /// <param name="textDecoration"> Text decoration Value. </param>
        ///
        /// <returns>   Given class from <paramref name="textDecoration"/> </returns>
        ///-------------------------------------------------------------------------------------------------

        public static string ToClass(TextDecoration? textDecoration)
        {
            if (!textDecoration.HasValue) return string.Empty;
            return textDecoration switch
            {
                Fomantic.Blazor.UI.TextDecoration.OverLine => TextOverLine,
                Fomantic.Blazor.UI.TextDecoration.LineThrough => TextlineThrough,
                Fomantic.Blazor.UI.TextDecoration.UnderLine => Textunderline,
                Fomantic.Blazor.UI.TextDecoration.UnderLineOverline => TextUnderOverline,
                _ => string.Empty,
            };
        }
    }
}
