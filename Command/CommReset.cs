
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
            // I'm not sure how to do this quite yet, calling game constructor again doesn't work so...
            myGame.Reset();
            //link.Reset(game);
            LevelLoader.Instance.Load("Room1.xml");
            RoomObjectManager.Instance.staticItems.Clear();
            RoomObjectManager.Instance.Update();
        }
    }
}
