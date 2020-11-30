using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fomantic.Blazor.UI
{
    /// <summary> Specifies the top-level model object for the form. An edit context will be constructed for this model. If using this parameter, do not also supply a value for <see cref="EditContext"/>. </summary>
    public partial class SampleTextField : FomanticInputBase<string>
    {

        /// <inheritdoc/>
        protected override bool TryParseValueFromString(string value, [MaybeNullWhen(false)] out string result, [NotNullWhen(false)] out string validationErrorMessage)
        {
            result = value;
            validationErrorMessage = string.Empty;


            return true;
        }
    }
}
