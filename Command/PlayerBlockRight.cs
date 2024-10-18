using Microsoft.Xna.Framework;

namespace LegendOfZelda.Command
{
    class PlayerBlockRight : ICommand
    {
        private readonly Link _link;

        public PlayerBlockRight(Link link) => _link = link;

        public void Execute()
        {
            _link.position = new Vector2(_link.position.X + 4, _link.position.Y);
        }
    }
}