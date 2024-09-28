namespace LegendOfZelda
{
    internal class CommLinkLeftM : ICommand
    {
        Game1 myGame;
        public CommLinkLeftM(Game1 game)
        {
            myGame = game;



        }
        public void Execute()
        {
            myGame.LinkCharacter.xCord -= 1;
        }

    }
}
