namespace Fomantic.Blazor.UI.Features
{
    class FomanticComponentWithCircularStyleFeature : UIFeatureDefinition<IFomanticComponentWithCircularStyle>
    {  
        /// <summary>   class given to make component circular. </summary>
        const string CircularClass = "circular";

        public override string ProvideCssClass(IFomanticComponentWithCircularStyle component)
        {
            if (component.IsCircular)
            {
                return CircularClass;
            }
            else
            {
                return string.Empty;
            }
        }
    }

}
