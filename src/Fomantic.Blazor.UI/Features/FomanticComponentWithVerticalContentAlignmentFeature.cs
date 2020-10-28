namespace Fomantic.Blazor.UI.Features
{
    class FomanticComponentWithVerticalContentAlignmentFeature : UIFeatureDefinition<IFomanticComponentWithVerticalContentAlignment>
    {
        /// <summary>   class given to make component top aligned. </summary>
        const string TopAlignedClass = "top aligned";
        /// <summary>   class given to make component bottom aligned. </summary>
        const string BottomAlignedClass = "bottom aligned";
        /// <summary>   class given to make component center aligned. </summary>
        const string CenterAlignedClass = "";



        public override string ProvideCssClass(IFomanticComponentWithVerticalContentAlignment component)
        {
            return ToClass(component.ContentVerticalAlignment);
        }
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Convert <see cref="Fomantic.Blazor.UI.ContentVerticalAlignment"/> to given class. </summary>
        ///
        /// <param name="contentAlignment"> ContentSpace Value. </param>
        ///
        /// <returns>   Given class from <paramref name="contentAlignment"/> </returns>
        ///-------------------------------------------------------------------------------------------------
        public static string ToClass(ContentVerticalAlignment? contentAlignment)
        {
            if (!contentAlignment.HasValue)
            {
                return string.Empty;
            }
            return contentAlignment.Value switch
            {
                ContentVerticalAlignment.Center => CenterAlignedClass,
                ContentVerticalAlignment.Top => TopAlignedClass,
                ContentVerticalAlignment.Bottom => BottomAlignedClass,
                _ => string.Empty,
            };
        }
    }

}
