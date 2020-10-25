namespace Fomantic.Blazor.UI.Features
{
    class FomanticComponentWithContentAlignmentFeature : UIFeatureDefinition<IFomanticComponentWithContentAlignment>
    {
        /// <summary>   class given to make component right aligned. </summary>
        const string RightAlignedClass = "right aligned";
        /// <summary>   class given to make component left aligned. </summary>
        const string LeftAlignedClass = "left aligned";
        /// <summary>   class given to make component center aligned. </summary>
        const string CenterAlignedClass = "center aligned";

        /// <summary>   class given to make component justified. </summary>
        const string JustifiedClass = "justified";

        public override string ProvideCssClass(IFomanticComponentWithContentAlignment component)
        {
            return ToClass(component.ContentAlignment);
        }
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Convert <see cref="Fomantic.Blazor.UI.ContentAlignment"/> to given class. </summary>
        ///
        /// <param name="contentAlignment"> ContentSpace Value. </param>
        ///
        /// <returns>   Given class from <paramref name="contentAlignment"/> </returns>
        ///-------------------------------------------------------------------------------------------------
        public static string ToClass(ContentAlignment? contentAlignment)
        {
            if (!contentAlignment.HasValue)
            {
                return string.Empty;
            }
            return contentAlignment.Value switch
            {
                UI.ContentAlignment.Right => RightAlignedClass,
                UI.ContentAlignment.Left => LeftAlignedClass,
                UI.ContentAlignment.Center => CenterAlignedClass,
                UI.ContentAlignment.justified => JustifiedClass,
                _ => string.Empty,
            };
        }
    }

}
