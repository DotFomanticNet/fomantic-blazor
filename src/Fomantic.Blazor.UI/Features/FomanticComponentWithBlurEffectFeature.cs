namespace Fomantic.Blazor.UI.Features
{
    class FomanticComponentWithBlurEffectFeature : UIFeatureDefinition<IFomanticComponentWithBlurEffect>
    {

        /// <summary>   class given to make component appear as loading. </summary>
        public static string BlurringClass = "blurring";
        public override string ProvideCssClass(IFomanticComponentWithBlurEffect component)
        {
            if (component.IsBlurring)
            {
                return BlurringClass;
            }
            else
            {
                return string.Empty;
            }
        }
    }

}
