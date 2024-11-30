using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace LegendOfZelda.Command
{
    class PlayerStatItem : ICommand
    {
        private readonly Link _link;
        private ClassItems item;
        public PlayerStatItem(Link link, ClassItems items)
        {
            _link = link;
            item = items;
        }

        public void Execute()
        {
            //Debug.WriteLine($"Miku picked up {item.getItemType()} ");
            String itemType = item.getItemType();
            //add the item to link's inventory and delete it off the screen
            if (itemType == "Key")
            {
                _link.inventory.addKey();
            }
            if (itemType == "Map")
            {
                _link.inventory.setMap(true);
            }
            if (itemType == "OrangeRupee" || itemType == "BlueRupee")
            {
                _link.inventory.addCoins(1);
            }
            if (itemType == "CreateBombSprite")
            {
                _link.inventory.addBomb();
            }
            if (itemType == "Triforce")
            {
                _link.Pickup();
                _link.win();
            }
            if (itemType == "HeartRed")
            {
               Debug.WriteLine($"Health was {_link.currentHealth}");
               if (!(_link.currentHealth == _link.maxHealth))
               {
                  _link.currentHealth += 2;
               }
                  Debug.WriteLine($"Health now is {_link.currentHealth}");
            }
                if (itemType == "Fairy")
                {
                    _link.currentHealth = _link.maxHealth;
                }

            //I'm still adding the keys to the inventory because they should probably show up in the HUD?
            //Debug.WriteLine($"Added {item.getItemType()} to inventory");
            if (itemType != "Triforce")
            {
                _link.inventory.addItem(item);
            }

                //doing both to be safe
                item.makeContact();
                RoomObjectManager.Instance.staticItems.Remove(item);
            
        }
    }
}