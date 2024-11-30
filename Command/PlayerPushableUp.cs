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
    class PlayerPushableUp : ICommand
    {
        private PushableBlock _block;
        public PlayerPushableUp(PushableBlock block)
        {
            _block = block;
        }

        public void Execute()
        {
            SoundMachine.Instance.PlaySound("moveBlock");
            Debug.WriteLine("Collided with pusable on top");
            _block.moveBlock(new Vector2(0, -1));
        }
    }
}