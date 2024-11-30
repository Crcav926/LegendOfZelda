using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    internal class CommChangeRoom: ICommand
    {
        List<String> _rooms = new List<String>() 
        { 
            "Room1.xml", "Room2.xml", "Room3.xml", "Room4.xml", "Room5.xml", 
            "Room6.xml", "Room7.xml", "Room8.xml", "Room9.xml", "Room10.xml", "Room11.xml", "Room12.xml", "Room13.xml", 
            "Room14.xml", "Room15.xml", "Room16.xml", "Room17.xml", "Room18.xml", "Room20.xml" 
        };
        int currIndex = 0;

        public CommChangeRoom()
        {
        }
        public void Execute()
        {

            currIndex++;
            if (currIndex < _rooms.Count)
            {
                // LevelLoader.Instance.changeCurrentRoom(_rooms[currIndex]);
            }
            else
            {
                currIndex = 0;
                // LevelLoader.Instance.changeCurrentRoom(_rooms[currIndex]);
            }
        }
    }
}
