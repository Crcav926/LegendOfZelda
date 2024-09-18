namespace LegendOfZelda
{
    internal class CommLinkLeft : ICommand
    {
        Game1 myGame;
        public CommLinkLeft(Game1 game)
        {
            myGame = game;



        }
        public void Execute()
        {
            myGame.LinkCharacter.xCord -= 2;
            myGame.LinkCharacter.linkSprite = new LinkBasicAnimation(myGame.linkTexture, 0);
        }

    }
}
