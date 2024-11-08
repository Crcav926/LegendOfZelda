using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using LegendOfZelda.Sounds;

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
            //Debug.WriteLine($"Door Command Triggered, door lock is {door.lockedS}");
            if (door.lockedS == false)
            {
                SoundMachine.Instance.GetSound("throughDoor").Play();
                string roomName = door.getRoom();
                Debug.WriteLine($"Room is {roomName}");
  
                if (roomName != "closed")
                {
                    LevelLoader.Instance.Load(roomName);
                    link.position = door.getNewPosition();
                    //lemme just clear the dropped items too...
                    RoomObjectManager.Instance.staticItems.Clear();
                    //reset the room by room death counter.
                    RoomObjectManager.Instance.Localcounter = 0;
                }
            }
            else
            {
                //Debug.WriteLine($"Door Locked Miku has {link.inventory.getNumKeys()} keys");
                // if link has keys and it's unlockable unlock the door and play the unlock sound
                if (door.unlockable && link.inventory.getNumKeys() > 0)
                {
                    SoundMachine.Instance.GetSound("unlock").Play();
                    door.setLocked(false);
                    link.inventory.removeKey();
                }
            }
        }
    }
}
