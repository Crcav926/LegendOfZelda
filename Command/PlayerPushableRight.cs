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
    class PlayerPushableRight : ICommand
    {
        private PushableBlock _block;
        public PlayerPushableRight(PushableBlock block)
        {
            _block = block;
        }

        public void Execute()
        {
            SoundMachine.Instance.GetSound("moveBlock").Play();
            Debug.WriteLine("Collided with pusable on the right");
            _block.moveBlock(new Vector2(-1, 0));
        }
    }
}