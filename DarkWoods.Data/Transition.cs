using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DarkWoods.Data
{
    /// <summary>
    /// A transition from one page to another.
    /// </summary>
    public class Transition
    {
        /// <summary>
        /// Page name to transition to.
        /// </summary>
        public string Name;

        /// <summary>
        /// Text to display to user for this transition.
        /// </summary>
        public string Text;
    }
}