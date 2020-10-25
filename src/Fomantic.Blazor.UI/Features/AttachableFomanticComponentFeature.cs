namespace Fomantic.Blazor.UI.Features
{
    class AttachableFomanticComponentFeature : UIFeatureDefinition<IAttachableFomanticComponent>
    {
        /// <summary>   class given to attached. </summary>
        const string AttachedClass = "attached";

        /// <summary>   class given to attached. </summary>
        const string TopAttachedClass = "top attached";


        /// <summary>   class given to attached. </summary>
        const string BottomAttachedClass = "bottom attached";
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Convert <see cref="AttachingDirection"/> to given class. </summary>
        ///
        /// <param name="attachingDirection">   attaching direction Value. </param>
        ///
        /// <returns>   given class from <paramref name="attachingDirection"/> </returns>
        ///-------------------------------------------------------------------------------------------------

        public static string ToClass(AttachingDirection? attachingDirection)
        {
            if (!attachingDirection.HasValue)
            {
                return string.Empty;
            }
            return attachingDirection switch
            {
                AttachingDirection.Middle => AttachedClass,
                AttachingDirection.Top => TopAttachedClass,
                AttachingDirection.Bottom => BottomAttachedClass,
                _ => string.Empty,
            };
        }

        public override string ProvideCssClass(IAttachableFomanticComponent component)
        {
            return ToClass(component.Attaching);
        }
    }

}
