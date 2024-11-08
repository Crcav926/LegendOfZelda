using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace LegendOfZelda
{
    public class DropDictionary
    {
        public static Dictionary<(int, char), string> theDropDictionary = new Dictionary<(int, char), string>()
        {
            {(1, 'B'), "CreateBombSprite"},
            {(2, 'B'), "OrangeRupee"},
            {(3, 'B'), "Clock"},
            {(4, 'B'), "OrangeRupee"},
            {(5, 'B'), "HeartRed"},
            {(6, 'B'), "CreateBombSprite"},
            {(7, 'B'), "OrangeRupee"},
            {(8, 'B'), "CreateBombSprite"},
            {(9, 'B'), "HeartRed"},
            {(0, 'B'), "HeartRed"},
            {(1, 'C'), "OrangeRupee"},
            {(2, 'C'), "HeartRed"},
            {(3, 'C'), "OrangeRupee"},
            {(4, 'C'), "BlueRupee"},
            {(5, 'C'), "HeartRed"},
            {(6, 'C'), "Clock"},
            {(7, 'C'), "OrangeRupee"},
            {(8, 'C'), "OrangeRupee"},
            {(9, 'C'), "OrangeRupee"},
            {(0, 'C'), "BlueRupee"},
            {(1, 'D'), "HeartRed"},
            {(2, 'D'), "Fairy"},
            {(3, 'D'), "OrangeRupee"},
            {(4, 'D'), "HeartRed"},
            {(5, 'D'), "Fairy"},
            {(6, 'D'), "HeartRed"},
            {(7, 'D'), "HeartRed"},
            {(8, 'D'), "HeartRed"},
            {(9, 'D'), "OrangeRupee"},
            {(0, 'D'), "HeartRed"}
    };

        // Stores room number, number of enemies, and what needs to be dropped, this is actually for any kill all the enemies to drop blank
        public static Dictionary<(string, int), string> DropkeyDictionary = new Dictionary<(string, int), string>()
        {
            //ALL THE NUMBER OF DEATHS IS 1 LESS TO WORK AND IDK WHY LMAO BUT IT WORKS
            {("Room2.xml", 2), "Key"},
            //{(3, 5), "Key"},
            {("Room5.xml", 4), "Key"},
            //{(11, 2), "Key"},
            {("Room12.xml", 2), "Key"},
            { ("Room15.xml",2), "CreateBoomerangSprite"}
            //for the last one it just automaticly spawn a key, so I am not sure if zero local deathcount is appropriate
            //{(16, 0), "Key"}
    };

        //gets info from the dictionary,
        public static string GetDropKey((string s, int c) key)
        {
            //Debug.WriteLine("Accessed Key Dictionary");
            if (DropkeyDictionary.TryGetValue(key, out var value))
            {
                return value; // Return the corresponding value
            }
            else
            {
                Debug.WriteLine($"Death Counter not reached yet count: {RoomObjectManager.Instance.Localcounter}");
                return null;
            }
        }


        public static string GetDropName((int i, char c) key)
        {
            if (theDropDictionary.TryGetValue(key, out var value))
            {
                return value; // Return the corresponding value
            }
            else
            {
                Debug.WriteLine("No item found in drop table");
                return "noItem";
            }
        }

    }
}