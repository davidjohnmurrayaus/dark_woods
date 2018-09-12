using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DarkWoods
{
    /// <summary>
    /// A page within the game world.
    /// </summary>
    public class GamePage
    {
        /// <summary>
        /// Name of this page
        /// </summary>
        public string Name;

        /// <summary>
        /// Heading to display
        /// </summary>
        public string Heading;

        /// <summary>
        /// Text to display
        /// </summary>
        public string Text;

        /// <summary>
        /// Transitions to other pages from this one.
        /// </summary>
        public List<Transition> Transitions;
    }
}