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
    internal class ItemDoor : ICommand
    {

        private Door door;
        private IItems item;

        public ItemDoor(Door door1, IItems items)
        {
            door = door1;
            item = items;
        }

        public void Execute()
        {
            
            if (item is Bomb) 
            {
                string doorType = door.doorSprite;
                switch (doorType)
                {
                    //if the bomb hit a bombable door, change it's sprite and unlock it.
                    case "UpDoorWall":
                        door.doorSprite = "UpDoorSecretBombableWall";
                        door.setLocked(false);
                        break;
                    case "LeftDoorWall":
                        door.doorSprite = "LeftDoorSecretBombableWall";
                        door.setLocked(false);
                        break;
                    case "RightDoorWall":
                        door.doorSprite = "RightDoorSecretBombableWall";
                        door.setLocked(false);
                        break;
                    case "DownDoorWall":
                        door.doorSprite = "DownDoorSecretBombableWall";
                        door.setLocked(false);
                        break;
                }

            }
            
              
        }
    }
}
