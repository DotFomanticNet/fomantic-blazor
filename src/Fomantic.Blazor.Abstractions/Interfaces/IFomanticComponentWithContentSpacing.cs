///-------------------------------------------------------------------------------------------------
// file:	Interfaces\IFomanticComponentWithContentSpacing.cs
//
// summary:	Declares the IFomanticComponentWithContentSpacing interface
///-------------------------------------------------------------------------------------------------

using Microsoft.AspNetCore.Components;

namespace Fomantic.Blazor.UI
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>
    /// Base interface for all fomantic component that has space around its content.
    /// </summary>
    ///-------------------------------------------------------------------------------------------------

    public interface IFomanticComponentWithContentSpacing : IFomanticComponentWithClass
    {
        /// <summary>   class given to make component content padded. </summary>
        const string PaddedClass = "padded";
        /// <summary>   class given to make component content very padded. </summary>
        const string VeryPaddedClass = "very padded";
        /// <summary>   class given to remove component content padding. </summary>
        const string FittedClass = "fitted";
        /// <summary>   class given to remove component content horizontal padding only. </summary>
        const string HorizontallyFittedClass = "horizontally fitted";
        /// <summary>   class given to remove component content vertical padding only. </summary>
        const string VerticallyFittedClass = "vertically fitted";

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Determine the space between  the component and its content. </summary>
        ///
        /// <value> The content space. </value>
        ///-------------------------------------------------------------------------------------------------

        [Parameter]
        ContentSpace? ContentSpace { get; set; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Convert <see cref="Fomantic.Blazor.UI.ContentSpace"/> to given class. </summary>
        ///
        /// <param name="contentSpace"> ContentSpace Value. </param>
        ///
        /// <returns>   Given class from <paramref name="contentSpace"/> </returns>
        ///-------------------------------------------------------------------------------------------------

        public static string ToClass(ContentSpace? contentSpace)
        {
            if (!contentSpace.HasValue)
            {
                return string.Empty;
            }
            return contentSpace.Value switch
            {
                UI.ContentSpace.Padded => PaddedClass,
                UI.ContentSpace.VeryPadded => VeryPaddedClass,
                UI.ContentSpace.Fitted => FittedClass,
                UI.ContentSpace.HorizontallyFitted => HorizontallyFittedClass,
                UI.ContentSpace.VerticallyFitted => VerticallyFittedClass,
                _ => string.Empty,
            };
        }
    }
}


