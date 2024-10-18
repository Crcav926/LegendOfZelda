using Microsoft.Xna.Framework;

namespace LegendOfZelda.Command
{
    class PlayerBlockBottom : ICommand
    {
        private readonly Link _link;

        public PlayerBlockBottom(Link link) => _link = link;

        public void Execute()
        {
            //move link down one b/c he hit the bottom of a block
            _link.position = new Vector2(_link.position.X, _link.position.Y + 4);
        }
    }
}