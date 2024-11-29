using System.Threading;
using System.Diagnostics;
namespace LegendOfZelda
{
    internal class CommMode : ICommand
    {
        Game1 myGame;
        public CommMode(Game1 game) 
        {
            myGame = game;
        }
        public void Execute()
        {
            //swap the button choice
            int modeChoice = myGame.menu.mode;
            if (modeChoice == 0)
            {
                myGame.menu.mode = 1;
            }
            else
            {
                myGame.menu.mode = 0;
            }

           
        }
    }
}
