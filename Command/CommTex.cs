using System.Threading;
using System.Diagnostics;
namespace LegendOfZelda
{
    internal class CommTex : ICommand
    {
        Game1 myGame;
        public CommTex(Game1 game) 
        {
            myGame = game;
        }
        public void Execute()
        {
            int textureChoice = myGame.menu.tex;
            if (textureChoice == 0)
            {
                myGame.menu.tex = 1;
            }
            else
            {
                myGame.menu.tex = 0;
            }

        }
    }
}
