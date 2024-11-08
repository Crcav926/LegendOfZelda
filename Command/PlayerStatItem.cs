﻿using System;
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
            if (itemType == "OrangeRupee" || itemType == "BlueRupee" )
            {
                _link.inventory.addCoins(1);
            }
            //I'm still adding the keys to the inventory because they should probably show up in the HUD?
            //Debug.WriteLine($"Added {item.getItemType()} to inventory");
            _link.inventory.addItem(item);

            //doing both to be safe
            item.makeContact();
            RoomObjectManager.Instance.staticItems.Remove(item);
        }
    }
}