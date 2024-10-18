using Microsoft.Xna.Framework;

namespace LegendOfZelda.Command
{
    class PlayerBlockTop : ICommand
    {
        private readonly Link _link;

        public PlayerBlockTop(Link link) => _link = link;

        public void Execute()
        {
            //move link up one b/c hit top of block
            _link.position = new Vector2(_link.position.X, _link.position.Y - 4);
        }
    }
}