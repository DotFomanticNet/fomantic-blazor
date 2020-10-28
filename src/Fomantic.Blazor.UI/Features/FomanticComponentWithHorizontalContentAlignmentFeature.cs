namespace Fomantic.Blazor.UI.Features
{
    class FomanticComponentWithHorizontalContentAlignmentFeature : UIFeatureDefinition<IFomanticComponentWithHorizontalContentAlignment>
    {
        /// <summary>   class given to make component right aligned. </summary>
        const string RightAlignedClass = "right aligned";
        /// <summary>   class given to make component left aligned. </summary>
        const string LeftAlignedClass = "left aligned";
        /// <summary>   class given to make component center aligned. </summary>
        const string CenterAlignedClass = "center aligned";

        /// <summary>   class given to make component justified. </summary>
        const string JustifiedClass = "justified";

        public override string ProvideCssClass(IFomanticComponentWithHorizontalContentAlignment component)
        {
            return ToClass(component.ContentHorizontalAlignment);
        }
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Convert <see cref="Fomantic.Blazor.UI.ContentHorizontalAlignment"/> to given class. </summary>
        ///
        /// <param name="contentAlignment"> ContentSpace Value. </param>
        ///
        /// <returns>   Given class from <paramref name="contentAlignment"/> </returns>
        ///-------------------------------------------------------------------------------------------------
        public static string ToClass(ContentHorizontalAlignment? contentAlignment)
        {
            if (!contentAlignment.HasValue)
            {
                return string.Empty;
            }
            return contentAlignment.Value switch
            {
                UI.ContentHorizontalAlignment.Right => RightAlignedClass,
                UI.ContentHorizontalAlignment.Left => LeftAlignedClass,
                UI.ContentHorizontalAlignment.Center => CenterAlignedClass,
                UI.ContentHorizontalAlignment.justified => JustifiedClass,
                _ => string.Empty,
            };
        }
    }
}
