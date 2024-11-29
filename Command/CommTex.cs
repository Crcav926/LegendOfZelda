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
            int textureChoice = Globals.tex;
            if (textureChoice == 0)
            {
                Globals.tex = 1;
            }
            else
            {
                Globals.tex = 0;
            }

        }
    }
}
