using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DarkWoods.Tests
{
    /// <summary>
    /// Tests for the game state.
    /// </summary>
    [TestClass]
    public class GameStateTests
    {
        /// <summary>
        /// Check that a new game starts in a valid state.
        /// </summary>
        [TestMethod]
        public void NewGameTests()
        {
            var myGame = new Data.GameState();

            Assert.IsTrue(myGame.CurrentPage != null, "A new game must start on a valid page.");
            Assert.IsFalse(string.IsNullOrWhiteSpace(myGame.CurrentPageName), "The current page must have a name.");
            Assert.IsTrue(myGame.CurrentPage.Transitions.Count > 0, "The page must have at least on transition.");
        }
    }
}
