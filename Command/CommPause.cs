using System.Threading;
namespace LegendOfZelda
{
    internal class CommPause : ICommand
    {
        Game1 myGame;
        public CommPause(Game1 game) 
        {
            myGame = game;
        }
        public void Execute()
        {
            //Pause Command
            if (myGame.paused == false)
            {
                myGame.setPause(true);
            }
            else
            {
                myGame.setPause(false);
            }
           
        }
    }
}
