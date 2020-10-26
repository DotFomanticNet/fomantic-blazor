namespace Fomantic.Blazor.UI.Features
{
    class SegmentStyledFomanticComponentFeature : UIFeatureDefinition<ISegmentStyledFomanticComponent>
    {
        /// <summary>   class given to make segment styled raised. </summary>
        const string RaisedClass = "raised";
        /// <summary>   class given to make segment styled stacked. </summary>
        const string StackedClass = "stacked";
        /// <summary>   class given to make segment styled tall stacked. </summary>
        const string TallStackedClass = "tall stacked";
        /// <summary>   class given to make segment styled piled. </summary>
        const string PiledClass = "piled";
        /// <summary>   class given to make segment styled basic. </summary>
        const string BasicClass = "basic";


        public override string ProvideCssClass(ISegmentStyledFomanticComponent component)
        {
            return ToClass(component.SegmentStyle);
        }



        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Convert <see cref="Fomantic.Blazor.UI.SegmentStyle"/> to given class. </summary>
        ///
        /// <param name="style">    ContentSpace Value. </param>
        ///
        /// <returns>   Given class from <paramref name="style"/> </returns>
        ///-------------------------------------------------------------------------------------------------

        public static string ToClass(SegmentStyle style)
        {

            return style switch
            {
                SegmentStyle.Normal => string.Empty,
                SegmentStyle.Basic => BasicClass,
                SegmentStyle.Raised => RaisedClass,
                SegmentStyle.Stacked => StackedClass,
                SegmentStyle.TallStacked => TallStackedClass,
                SegmentStyle.Piled => PiledClass,
                _ => string.Empty,
            };
        }
    }
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
