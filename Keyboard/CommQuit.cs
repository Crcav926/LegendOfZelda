
namespace LegendOfZelda
{
    internal class CommQuit : ICommand
    {
        Game1 myGame;
        public CommQuit(Game1 game) 
        {
            myGame = game;
        }
        public void Execute()
        {
            myGame.Exit();
        }
    }
}
