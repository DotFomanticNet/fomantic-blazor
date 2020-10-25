namespace Fomantic.Blazor.UI.Features
{
    class FomanticComponentWithCompactStyleFeature : UIFeatureDefinition<IFomanticComponentWithCompactStyle>
    {
        /// <summary>   class given to make component compact. </summary>
        const string CompactClass = "compact";
        public override string ProvideCssClass(IFomanticComponentWithCompactStyle component)
        {
            if (component.IsCompact)
            {
                return CompactClass;
            }
            else
            {
                return string.Empty;
            }
        }

    }

}
