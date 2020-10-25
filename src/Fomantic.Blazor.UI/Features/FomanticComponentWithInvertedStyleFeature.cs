namespace Fomantic.Blazor.UI.Features
{
    class FomanticComponentWithInvertedStyleFeature : UIFeatureDefinition<IFomanticComponentWithInvertedStyle>
    {
        /// <summary>   class given to the component to invert its color. </summary>
        const string InvertedClass = "inverted";
        public override string ProvideCssClass(IFomanticComponentWithInvertedStyle component)
        {
            if (component.IsInverted)
            {
                return InvertedClass;
            }
            else
            {
                return string.Empty;
            }
        }
    }

}
