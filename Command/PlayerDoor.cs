using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using LegendOfZelda.Sounds;
using System.Threading;
using LegendOfZelda.HUD;
using System.Numerics;

namespace LegendOfZelda.Command
{
    internal class PlayerDoor : ICommand
    {

        private Door door;
        private Link link;
        private HUDMap hudMap;
        public PlayerDoor(Link l, Door d)
        {
            link = l;
            door = d;
            hudMap = HUDMap.Instance;
        }

        public void Execute()
        {
            //Debug.WriteLine($"Door Command Triggered, door lock is {door.lockedS}");
            //Debug.WriteLine($"Texture value is {Globals.tex}");
            if (door.lockedS == false) 
                {
                if (!Camera2D.Instance.isSliding)
                {
                    string roomName = door.getRoom();
                    Debug.WriteLine($"Room is {roomName}");

                    if (roomName != "closed")
                    {
                        LevelLoader.Instance.changeCurrentRoom(roomName);
                        SoundMachine.Instance.PlaySound("throughDoor");
                        String currentDoor = door.doorSprite;
                        Debug.WriteLine($"Current door is {currentDoor}");
                        switch (currentDoor[0])
                        {
                            case 'R':
                                Camera2D.Instance.slideRight();
                                link.position.X += 200;
                                hudMap.miniMapPos.X += 24;
                                break;
                            case 'L':
                                Camera2D.Instance.slideLeft();
                                link.position.X -= 200;
                                hudMap.miniMapPos.X -= 24;
                                break;
                            case 'U':
                                Camera2D.Instance.slideUp();
                                link.position.Y -= 160;
                                hudMap.miniMapPos.Y -= 12;
                                break;
                            case 'D':
                                Camera2D.Instance.slideDown();
                                link.position.Y += 185;
                                hudMap.miniMapPos.Y += 12;
                                break;
                        }
                        //lemme just clear the dropped items too...
                        RoomObjectManager.Instance.staticItems.Clear();
                        //reset the room by room death counter.
                        RoomObjectManager.Instance.Localcounter = 0;
                    }
                }
            }else
            {
                //Debug.WriteLine($"Door Locked Miku has {link.inventory.getNumKeys()} keys");
                // if link has keys and it's unlockable unlock the door and play the unlock sound
                string doorType = door.doorSprite;
                if (door.unlockable && link.inventory.getNumKeys() > 0 && !(doorType == "UpDoorWall") && !(doorType== "DownDoorWall") && !(doorType == "LeftDoorWall") && !(doorType == "RightDoorWall"))
                {
                    SoundMachine.Instance.PlaySound("unlock");
                    //pause the game to play sound and see door change
                    String currentDoor = door.doorSprite;
                    Debug.WriteLine($"Current door is {currentDoor}");
                    switch (currentDoor[0])
                    {
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
                    Debug.WriteLine($"Updated door is {currentDoor}");
                   // Thread.Sleep(1500);
                    door.setLocked(false);
                    link.inventory.removeKey();
                }
            }
    
        }
    }
}
