using System.Threading;
using System.Diagnostics;
namespace LegendOfZelda
{
    internal class CommStart : ICommand
    {
        Game1 myGame;
        public CommStart(Game1 game) 
        {
            myGame = game;
        }
        public void Execute()
        {
            Debug.WriteLine("Started Game");
            //UnPause the game and make menu disappear.
            myGame.setPause(false);
            myGame.menu.Start();

           
        }
    }
}
