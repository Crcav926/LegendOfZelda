using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    internal class RoomObjectManager
    {
        private static RoomObjectManager instance = new RoomObjectManager();

        public static RoomObjectManager Instance
        {
            get
            {
                return instance;
            }
        }
        public RoomObjectManager() 
        {

        }

    }
}
