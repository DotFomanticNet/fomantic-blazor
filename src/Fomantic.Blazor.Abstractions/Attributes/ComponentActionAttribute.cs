///-------------------------------------------------------------------------------------------------
// file:	Attributes\ComponentActionAttribute.cs
//
// summary:	Implements the component action attribute class
///-------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fomantic.Blazor.UI
{
    /// <summary>   Attribute for component action. </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class ComponentActionAttribute :Attribute
    {

    }
}
