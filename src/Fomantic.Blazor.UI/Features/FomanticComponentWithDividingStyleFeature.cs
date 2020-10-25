namespace Fomantic.Blazor.UI.Features
{
    class FomanticComponentWithDividingStyleFeature : UIFeatureDefinition<IFomanticComponentWithDividingStyle>
    {
        /// <summary>   class given to the component to divide itself from the content below it. </summary>
        const string DividingClass = "dividing";
        public override string ProvideCssClass(IFomanticComponentWithDividingStyle component)
        {
            if (component.IsDividing)
            {
                return DividingClass;
            }
            else
            {
                return string.Empty;
            }
        }

    }

}
