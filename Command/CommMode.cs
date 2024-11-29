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
            if (modeChoice == 0)
            {
                Globals.mode = 1;
            }
            else
            {
                Globals.mode = 0;
            }

           
        }
    }
}
