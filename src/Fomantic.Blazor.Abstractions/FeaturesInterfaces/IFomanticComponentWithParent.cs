using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fomantic.Blazor.UI
{

    /// <summary>  Base interface for all fomantic component can has parent component.  </summary>
    public interface IFomanticComponentWithParent : IFomanticComponent
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets a list of types of the allowed parents. </summary>
        ///
        /// <value> A list of types of the allowed parents. </value>
        ///-------------------------------------------------------------------------------------------------
        public IEnumerable<Type> AllowedParentTypes { get; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets a value indicating whether this object is parent optional.
        /// </summary>
        ///
        /// <value> True if this object is parent optional, false if not. </value>
        ///-------------------------------------------------------------------------------------------------

        public bool IsParentOptional { get; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets a value indicating whether this object is unique. </summary>
        ///
        /// <value> True if this object is unique, false if not. </value>
        ///-------------------------------------------------------------------------------------------------

        public bool IsUnique { get; }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the function that trigger the parent state has changed.  </summary>
        ///
        /// <value> The function trigger the parent state has changed. </value>
        ///-------------------------------------------------------------------------------------------------

        Action ParentStateHasChanged { get; set; }
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Gets or sets the parent. </summary>
        ///
        /// <value> The parent. </value>
        ///-------------------------------------------------------------------------------------------------
        [CascadingParameter(Name = "Parent")]
        public IFomanticComponent Parent { get; set; }
    }
}
