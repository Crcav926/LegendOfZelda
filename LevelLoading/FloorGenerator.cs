using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace LegendOfZelda
{
    public class FloorGenerator
    {
        // Directions, 0: Left 1: Right 2: Down 3: Up
        public Dictionary<int, Vector2> directions = new Dictionary<int, Vector2>()
        {
            { 0, new Vector2(-1,0) },
            { 1, new Vector2(1,0) },
            { 2, new Vector2(0,-1) },
            { 3, new Vector2(0,1) }
        };
        private static FloorGenerator instance = new FloorGenerator();

        public static FloorGenerator Instance
        {
            get
            {
                return instance;
            }
        }
        public Random rand = new Random();
        private Dictionary<Vector2, Room> floor = new Dictionary<Vector2, Room>();
        public FloorGenerator()
        {

        }
        public Dictionary<Vector2, Room> MakeFloor(int i)
        {
            Vector2 offset = new Vector2(0, 0);
            int roomsLeft = i;
            int roomsInDirection = rand.Next(roomsLeft);
            int totalRooms = i;
            //Some sort of loop like
            while (roomsLeft > 0)
            {
                while (floor.ContainsKey(offset))
                {
                    offset = ChangeDirection(offset);
                    // Debug.WriteLine(offset);
                }
                roomsInDirection = rand.Next(1, roomsLeft);
                while (roomsInDirection > 0)
                {
                    if (roomsLeft == 1)
                    {
                        Room finalRoom = Parsing.Instance.LoadRoom("Room18.xml", offset);
                        floor.Add(offset, finalRoom);
                        roomsLeft--;
                        roomsInDirection--;
                    }
                    else
                    {
                        String roomName = GrabRoomName("Room");
                        Room newRoom = Parsing.Instance.LoadRoom(roomName, offset);
                        if (!floor.ContainsKey(offset))
                        {
                            floor.Add(offset, newRoom);
                        }
                        offset = ChangeDirection(offset);
                        roomsInDirection--;
                        roomsLeft--;
                    }
                }
                offset = new Vector2(0, 0);
            }
            PlaceDoors();
            return floor;

        }
        public Vector2 ChangeDirection(Vector2 direction)
        {
            Vector2 ret = direction;
            int move = rand.Next(Constants.roomDirections);
            ret += directions[move];
            return ret;
        }
        public String GrabRoomName(String room)
        {
            String roomNum = rand.Next(1, Constants.roomsCreated).ToString();
            while(roomNum == Constants.bannedRoom1 || roomNum == Constants.triforceRoom)
            {
                roomNum = rand.Next(1, Constants.roomsCreated).ToString();
            }
            return room + roomNum + ".xml";
        }
        public Dictionary<Vector2, Room> GetFloor()
        {
            return floor;
        }
        public void PlaceDoors()
        {
            foreach (Vector2 key in floor.Keys)
            {
                Debug.WriteLine("Key value "+ key);
                for (int i = 0; i < 4; i++)
                {
                    if (NeedsDoor(key, i))
                    {
                        floor[key].AddDoor(i);
                    }
                    else
                    {
                        floor[key].AddWall(i);
                    }
                }
            }
        }
        public Boolean NeedsDoor(Vector2 offset, int direction)
        {
            Vector2 check = offset + directions[direction];
            Debug.WriteLine(check);
            if (floor.ContainsKey(check))
            {
                Debug.WriteLine("PlacedDoor");
                return true;
            }
            return false;
        }

    }
}
