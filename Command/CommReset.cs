
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    internal class CommReset : ICommand
    {
        Game1 myGame;
        Link link;
        public CommReset(Game1 game, Link link)
        {
            myGame = game;
            this.link = link;
        }
        public void Execute()
        {
            myGame.Reset();
        }
    }
}
