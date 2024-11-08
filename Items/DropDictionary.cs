using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

public class DropDictionary
{
    public static Dictionary<(int, char), string>  theDropDictionary = new Dictionary<(int, char), string>()
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


    public static Dictionary<(int, int), string> DropkeyDictionary = new Dictionary<(int, int), string>()
        {
            {(2, 3), "Key"},
            //{(3, 5), "Key"},
            {(5, 5), "Key"},
            //{(11, 2), "Key"},
            {(12, 3), "Key"},
            //for the last one it just automaticly spawn a key, so I am not sure if zero local deathcount is appropriate
            //{(16, 0), "Key"}
    };

    public static string GetDropKey((int i, int c) key)
    {
        if (DropkeyDictionary.TryGetValue(key, out var value))
        {
            return value; // Return the corresponding value
        }
        else
        {
            Debug.WriteLine("No item found in drop table");
            return "noItem";
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
