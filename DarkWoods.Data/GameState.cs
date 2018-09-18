using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DarkWoods.Data
{
    /// <summary>
    /// The state of the current game.
    /// </summary>
    public class GameState
    {
        /// <summary>
        /// Lookup of all pages in the game.
        /// </summary>
        protected Dictionary<string, GamePage> pages = new Dictionary<string, GamePage>();

        /// <summary>
        /// The name of the current page.
        /// </summary>
        public string CurrentPageName;

        /// <summary>
        /// The current page.
        /// </summary>
        public GamePage CurrentPage
        {
            get
            {
                return pages[CurrentPageName];
            }
        }

        /// <summary>
        /// Build the initial game state.
        /// </summary>
        public GameState()
        {
            AddPage("Woods",
                "Woods",
                "You are in a dark woods",
                new List<Transition> {
                    new Transition() { Name = "Clearing", Text = "Clearing" },
                    new Transition() { Name = "House" , Text="House"}
            });

            AddPage("Clearing",
                "Clearing",
                "You are in a clearing",
                new List<Transition> {
                    new Transition() {Name = "Woods", Text = "Woods" },
                    new Transition() {Name = "Circle", Text = "Stone Circle" }
            });

            AddPage("Circle",
                "Stone Circle",
                "You are standing inside a stone circle",
                new List<Transition> {
                    new Transition() {Name = "Clearing", Text = "Clearing" }
            });

            AddPage("House",
                "Sinister House",
                "You are outside a sinister house",
                new List<Transition> {
                    new Transition() { Name = "Woods", Text = "Woods" }
            });

            CurrentPageName = "Woods";
        }

        /// <summary>
        /// Add a page to the game world.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="heading"></param>
        /// <param name="text"></param>
        /// <param name="pageTransitions"></param>
        protected void AddPage(string name, string heading, string text, List<Transition> pageTransitions)
        {
            pages.Add(name, new GamePage()
            {
                Name = name,
                Heading = heading,
                Text = text,
                Transitions = pageTransitions
            });
        }
    }
}