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

        public PlayerDoor(Door d) => door = d;


        public void Execute()
        {
            Debug.WriteLine("Door Command Triggered");

            string roomName = door.getRoom();
            Debug.WriteLine($"Room is {roomName}");
            
            LevelLoader.Instance.Load(roomName);
            

        }
    }
}
