namespace Fomantic.Blazor.UI.Features
{
    class FomanticComponentWithContentSpacingFeature : UIFeatureDefinition<IFomanticComponentWithContentSpacing>
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

        public override string ProvideCssClass(IFomanticComponentWithContentSpacing component)
        {
            return ToClass(component.ContentSpace);
        }

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
