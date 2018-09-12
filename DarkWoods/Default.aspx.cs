using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DarkWoods
{
    /// <summary>
    /// Display a page of the virtual book.
    /// </summary>
    public partial class Default : System.Web.UI.Page
    {
        /// <summary>
        /// Key used to store game state in session.
        /// </summary>
        const string KEY_GAME_STATE = "GameState";

        /// <summary>
        /// Prefix to add to naviagtion button names.
        /// </summary>
        const string BUTTON_PREFIX = "Naviagte_To_";

        /// <summary>
        /// Get the current game state from the session.
        /// </summary>
        /// <returns></returns>
        private GameState GetGameState()
        {
            if (Session[KEY_GAME_STATE] == null)
            {
                return new GameState();
            }
            else
            {
                return Session[KEY_GAME_STATE] as GameState;
            }
        }

        /// <summary>
        /// Save the current game state to the session.
        /// </summary>
        /// <param name="value"></param>
        private void SaveGameState(GameState value)
        {
            Session[KEY_GAME_STATE] = value;
        }

        /// <summary>
        /// Load current game state and decide if we need to naviagte to next page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            var gameState = GetGameState();

            if (IsPostBack)
            {
                foreach (string key in Request.Params.Keys)
                {
                    if (key.StartsWith(BUTTON_PREFIX))
                    {
                        string nextPage = key.Substring(BUTTON_PREFIX.Length);
                        gameState.CurrentPageName = nextPage;
                        SaveGameState(gameState);
                    }
                }
            }
            
            var myPage = gameState.CurrentPage;
            DivPageHeading.InnerHtml = myPage.Heading;
            DivPageText.InnerHtml = myPage.Text;
            string[] buttons = (
                from t in gameState.CurrentPage.Transitions
                select "<button name=\"" + BUTTON_PREFIX + t.Name + "\">" + t.Text + "</button>"
                ).ToArray();
            DivPageNavigation.InnerHtml = string.Join("\n", buttons);
        }
    }
}