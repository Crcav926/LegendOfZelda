using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace LegendOfZelda.Command
{
    internal class PlayerDoor: ICommand
    {
        
        private Door door;
        private Link link;

        public PlayerDoor(Link l, Door d)
        {
            link = l; 
            door = d;
        }

        public void Execute()
        {
            Debug.WriteLine("Door Command Triggered");

            string roomName = door.getRoom();
            Debug.WriteLine($"Room is {roomName}");
            if (roomName != "closed")
            {
                LevelLoader.Instance.Load(roomName);
            }
            link.position = door.getNewPosition();

        }
    }
}
