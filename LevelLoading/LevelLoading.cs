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
        List<Block> getEm;
        List<ICollideable> getEm2;

        public LevelLoading() { }
        public List<Block> Load()

        {
            // Can find a better way to hold this data
            fileNameList = new List<string>();
            fileNameList.Add("Room1.xml");
            fileNameList.Add("Room2.xml");
            fileNameList.Add("Room3.xml");
            fileNameList.Add("Room4.xml");

            Parsing parseIt = new Parsing("Room6.xml");
            List<Block> getEm = parseIt.getBlocks();
            getEm2 = parseIt.getMovers();
            foreach (ICollideable collideable in getEm2)
            {
                Debug.WriteLine(collideable.getHitbox().ToString());
            }
            // Sorts through each item in the list and parses through.
            // Mainly testing by parsing through all rooms, but eventually have only cetain rooms have their information loaded.
            return getEm;
        }
        public List<ICollideable> getMovers()
        {
            return getEm2;
        }

    }
}
