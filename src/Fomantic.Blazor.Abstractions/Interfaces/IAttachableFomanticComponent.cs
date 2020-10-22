
using Fomantic.Blazor.UI;
using Microsoft.AspNetCore.Components;

namespace Fomantic
{
    /// <summary>
    /// Base interface for all fomantic component can be attached to other content on a page
    /// </summary>
    public interface IAttachableFomanticComponent : IFomanticComponentWithClass
    {
        /// <summary>
        /// class given to attached
        /// </summary>
        const string AttachedClass = "attached";

        /// <summary>
        /// class given to attached
        /// </summary>
        const string TopAttachedClass = "top attached";


        /// <summary>
        /// class given to attached
        /// </summary>
        const string BottomAttachedClass = "bottom attached";

        /// <summary>
        /// Determine if the comonent should be attached to other content on a page
        /// </summary>
        [Parameter]
        AttachingDirection? Attaching { get; set; }


        /// <summary>
        /// Convert <see cref="AttachingDirection"/> to given class
        /// </summary>
        /// <param name="attachingDirection">attaching direction Value</param>
        /// <returns> given class from <paramref name="attachingDirection"/> </returns>
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
    }
}
