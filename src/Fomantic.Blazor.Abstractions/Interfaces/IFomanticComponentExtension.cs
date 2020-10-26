///-------------------------------------------------------------------------------------------------
// file:	Interfaces\IFomanticComponentExtension.cs
//
// summary:	Declares the IFomanticComponentExtension interface
///-------------------------------------------------------------------------------------------------

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Fomantic.Blazor.UI
{
    /// <summary>   Interface for fomantic component extension. </summary>
    public interface IFomanticComponentExtension : IFomanticComponentWithParent, IFomanticExtension
    {

    }
}
