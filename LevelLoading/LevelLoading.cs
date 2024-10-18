using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Enumeration;
using System.Xml;
namespace LegendOfZelda
{
    internal class LevelLoading
    {

        List<string> fileNameList;
        public LevelLoading()

        {
            // Can find a better way to hold this data
            fileNameList = new List<string>();
            fileNameList.Add("Room1.xml");
            fileNameList.Add("Room2.xml");

            // Sorts through each item in the list and parses through.
            // Mainly testing by parsing through all rooms, but eventually have only cetain rooms have their information loaded.
            foreach (string x in fileNameList)
            {
                Parsing parse = new Parsing(x);
            }
        }

    }
}
