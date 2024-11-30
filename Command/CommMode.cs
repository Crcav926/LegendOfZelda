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
            int modeChoice = Globals.mode;
            int gameOverModeChoice = Globals.gameOverMode;
            if(Globals.menuType == 0)
            {
                if (modeChoice == 0)
                {
                    Globals.mode = 1;
                }
                else
                {
                    Globals.mode = 0;
                }
            }
            else if(Globals.menuType == 1)
            {
                if (gameOverModeChoice == 0)
                {
                    Globals.gameOverMode = 1;
                }
                else
                {
                    Globals.gameOverMode = 0;
                }
            }
        }
    }
}
