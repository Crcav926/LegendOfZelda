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

        private List<string> fileNameList;
        private List<ICollideable> getEm;
        private List<ICollideable> getEm2;
        private String room;

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
            this.room = room;
            Parsing parseIt = new Parsing(room);
            getEm = parseIt.getBlocks();
            getEm2 = parseIt.getMovers();
            // Sorts through each item in the list and parses through.
            // Mainly testing by parsing through all rooms, but eventually have only cetain rooms have their information loaded.
        }
        public List<ICollideable> getBlocks()
        {
            return getEm;
        }
        public List<ICollideable> getMovers()
        {
            return getEm2;
        }
        public string getRoom()
        {
            return room;
        }
    }
}
