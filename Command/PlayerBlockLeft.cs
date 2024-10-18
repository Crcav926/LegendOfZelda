using Microsoft.Xna.Framework;

namespace LegendOfZelda.Command
{
    class PlayerBlockLeft : ICommand
    {
        private readonly Link _link;
        public PlayerBlockLeft(Link link) => _link = link;

        public void Execute()
        {
            _link.position = new Vector2(_link.position.X - 4, _link.position.Y);
        }
    }
}