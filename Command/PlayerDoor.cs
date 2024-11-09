using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using LegendOfZelda.Sounds;
using System.Threading;

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
                string roomName = door.getRoom();
                Debug.WriteLine($"Room is {roomName}");
  
                if (roomName != "closed")
                {
                    SoundMachine.Instance.GetSound("throughDoor").Play();
                    String currentDoor = door.doorSprite;
                    Debug.WriteLine($"Current door is {currentDoor}");
                    switch (currentDoor[0])
                    {
                        case 'R':
                            Camera2D.Instance.slideRight();
                            link.position.X += 200;
                            break;
                        case 'L':
                            Camera2D.Instance.slideLeft();
                            link.position.X -= 200;
                            break;
                        case 'U':
                            Camera2D.Instance.slideUp();
                            link.position.Y -= 200;
                            break;
                        case 'D':
                            Camera2D.Instance.slideDown();
                            link.position.Y += 200;
                            break;
                    }
                    LevelLoader.Instance.changeCurrentRoom(roomName);
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
                    //pause the game to play sound and see door change
                    String currentDoor = door.doorSprite;
                    Debug.WriteLine($"Current door is {currentDoor}");
                    switch (currentDoor[0]) {
                        case 'R':
                            door.doorSprite = "RightDoorOpen";
                            break;
                        case 'L':
                            door.doorSprite = "LeftDoorOpen";
                            break;
                        case 'U':
                            Debug.WriteLine("Swapping to open door");
                            door.doorSprite = "UpDoorOpen";
                            break;
                        case 'D':
                            door.doorSprite = "DownDoorOpen";
                            break;
                    }
                    currentDoor = door.doorSprite;
                    Debug.WriteLine($"Updated door is {currentDoor}");
                    Thread.Sleep(1500);
                    door.setLocked(false);
                    link.inventory.removeKey();
                }
            }
        }
    }
}
