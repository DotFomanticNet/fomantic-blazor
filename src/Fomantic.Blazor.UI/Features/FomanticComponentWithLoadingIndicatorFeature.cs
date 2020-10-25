namespace Fomantic.Blazor.UI.Features
{
    class FomanticComponentWithLoadingIndicatorFeature : UIFeatureDefinition<IFomanticComponentWithLoadingIndicator>
    {
        /// <summary>   class given to make component appear as loading. </summary>
        const string LoadingClass = "loading";
        public override string ProvideCssClass(IFomanticComponentWithLoadingIndicator component)
        {
            if (component.IsLoading)
            {
                return LoadingClass;
            }
            else
            {
                return string.Empty;
            }
        }
    }

}
