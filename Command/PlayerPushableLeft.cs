using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using LegendOfZelda.Sounds;

namespace LegendOfZelda.Command
{
    class PlayerPushableLeft : ICommand
    {
        private PushableBlock _block;
        public PlayerPushableLeft(PushableBlock block)
        {
            _block = block;
        }

        public void Execute()
        {
            //push the block to the right because the collision is on the left side.
            SoundMachine.Instance.GetSound("moveBlock").Play();
            Debug.WriteLine("Collided with pusable on the left");
            _block.moveBlock(new Vector2(1, 0));
        }
    }
}