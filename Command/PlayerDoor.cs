﻿using System;
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
            //TODO: CHANGE SO THE CAMERA TRANSITIONS AND THE CURRENT ROOM CHANGES
            if (roomName != "closed")
            {
                LevelLoader.Instance.Load(roomName);
                link.position = door.getNewPosition();
            }
            //lemme just clear the dropped items too...
            RoomObjectManager.Instance.staticItems.Clear();
        }
    }
}
