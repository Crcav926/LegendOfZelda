using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Enumeration;
using System.Xml;

namespace LegendOfZelda
{
    internal class LevelLoader
    {

        List<string> fileNameList;
        List<Block> getEm;
        List<ICollideable> getEm2;

        public LevelLoader() { }

        private static LevelLoader instance = new LevelLoader();

        public static LevelLoader Instance
        {
            get
            {
                return instance;
            }
        }
        public void Load(String room)

        {

            Parsing parseIt = new Parsing(room);
            getEm = parseIt.getBlocks();
            getEm2 = parseIt.getMovers();
            foreach (ICollideable collideable in getEm2)
            {
                Debug.WriteLine(collideable.getHitbox().ToString());
            }
            // Sorts through each item in the list and parses through.
            // Mainly testing by parsing through all rooms, but eventually have only cetain rooms have their information loaded.
        }
        public List<Block> getBlocks()
        {
            return getEm;
        }
        public List<ICollideable> getMovers()
        {
            return getEm2;
        }

    }
}
