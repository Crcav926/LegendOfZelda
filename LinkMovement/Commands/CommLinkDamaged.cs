
namespace LegendOfZelda.LinkMovement
{
    internal class CommLinkDamaged : ICommand
    {
        Game1 myGame;
        public CommLinkDamaged(Game1 game)
        {
            myGame = game;

        }
        public void Execute()
        {
            myGame.LinkCharacter.TakeDamage();
        }
    }
}
