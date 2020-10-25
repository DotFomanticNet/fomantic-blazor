namespace Fomantic.Blazor.UI.Features
{
    class FomanticComponentWithFittedStyleFeature : UIFeatureDefinition<IFomanticComponentWithFittedStyle>
    {
        /// <summary>   class given to make component fitted. </summary>
        const string FittedClass = "fitted";

        public override string ProvideCssClass(IFomanticComponentWithFittedStyle component)
        {
            if (component.IsFitted)
            {
                return FittedClass;
            }
            else
            {
                return string.Empty;
            }
        }

    }

}
