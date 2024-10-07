
namespace LegendOfZelda
{
    internal class CommReset : ICommand
    {
        Game1 myGame;
        public CommReset(Game1 game) 
        {
            myGame = game;
        }
        public void Execute()
        {
            // I'm not sure how to do this quite yet, calling game constructor again doesn't work so...
        }
    }
}
