using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;
namespace LegendOfZelda
{
    internal class Parsing
    {
        private string objectType { get; set; }
        private string objectName { get; set; }
        private Vector2 position { get; set; }
        private Vector2 newPosition { get; set; }
        private Vector2 offSet {  get; set; }
        private Tuple <String,String,Vector2> objectData { get; set; }
        public List<Tuple<string, string, Vector2>> objectList { get; set; } = new List<Tuple<string, string, Vector2>>();
        private ConstructorInfo con;
        private ConstructorInfo con2;
        private ConstructorInfo con3;
        private List<ICollideable> blocks = new List<ICollideable>();
        private List<ICollideable> colliders = new List<ICollideable>();
        private Type type;
        private string roomName;
        private bool keyBool;
        private bool lockedDoor;
        private Vector2 multiplier = new Vector2(Constants.OriginalWidth, Constants.OriginalHeight);
        public Parsing(string fileName)
        {
            LoadObjects(fileName);
        }

        public List<ICollideable> getBlocks() { return blocks; }
        public List<ICollideable> getMovers() { return colliders; }

        private void LoadObjects(string fileName)
        {
            //TODO: FOR DEBUGGING ONLY DELETE ONCE XML IS CREATED
            newPosition = new Vector2(0, 0);


            // Finds files in content and loads it.
            XmlDocument doc = new XmlDocument();
            // This will get the current WORKING directory
            string workingDirectory = Environment.CurrentDirectory;
            // This to get the project directory
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string filePath = Path.Combine(projectDirectory, "Rooms", fileName);
            doc.Load(filePath);

            // Debug.WriteLine("Now Loading: " + fileName);
            // Foreach through each node in the document.
            foreach (XmlNode node in doc.DocumentElement)
            {

                // Checks for node with same name
                XmlNode objectTypeNode = node.SelectSingleNode("ObjectType");
                XmlNode objectNameNode = node.SelectSingleNode("ObjectName");
                XmlNode locationNode = node.SelectSingleNode("Location");
                XmlNode linkLocationX = node.SelectSingleNode("LinkLocationX");
                XmlNode linkLocationY = node.SelectSingleNode("LinkLocationY");
                XmlNode hasKey = node.SelectSingleNode("HasKey");
                XmlNode locked = node.SelectSingleNode("Locked");
                XmlNode room = node.SelectSingleNode("Room");
                XmlNode offSetX = node.SelectSingleNode("OffsetX");
                XmlNode offSetY = node.SelectSingleNode("OffsetY");
                if (offSetX != null)
                {
                    offSet = new Vector2(int.Parse(offSetX.InnerText), int.Parse(offSetY.InnerText));
                }


                // Checks for null, if not null find the inner text.
                if (objectTypeNode != null)
                {
                    objectType = objectTypeNode.InnerText;
                    if (objectTypeNode.InnerText == "Block")
                    {
                        type = Type.GetType("LegendOfZelda." + objectTypeNode.InnerText);
                        con = type.GetConstructor(new[] { typeof(Vector2), typeof(String) });
                        // Debug.WriteLine(type.FullName);
                        // Debug.WriteLine(con.ToString());
                    } //THIS DOES NOT WORK AND IDK WHY
                    else if(objectTypeNode.InnerText == "PushableBlock")
                    {
                        type = Type.GetType("LegendOfZelda." + objectTypeNode.InnerText);
                        con = type.GetConstructor(new[] { typeof(Vector2), typeof(String) });
                        //Debug.WriteLine(type.FullName);
                        //Debug.WriteLine(con.ToString());
                    }
                    else if(objectTypeNode.InnerText == "ICollideable" && objectNameNode != null)
                    {
                        type = Type.GetType("LegendOfZelda." + objectNameNode.InnerText);
                        con2 = type.GetConstructor(new[] { typeof(Vector2), typeof(bool)});
                        // Debug.WriteLine(con2.ToString());
                        objectName = objectNameNode.InnerText;
                    }

                    else if (objectTypeNode.InnerText == "Door" && objectNameNode != null)
                    {
                        type = Type.GetType("LegendOfZelda." + objectTypeNode.InnerText);
                        con3 = type.GetConstructor(new[] { typeof(Vector2), typeof(String), typeof(String), typeof(Vector2) , typeof(bool) });
                        // Debug.WriteLine(con3.ToString());
                        objectName = objectNameNode.InnerText;
                        int x = int.Parse(linkLocationX.InnerText);
                        int y = int.Parse(linkLocationY.InnerText);
                        newPosition = new Vector2(x, y);
                        roomName = room.InnerText;
                        // Debug.WriteLine(newPosition.ToString());
                    }
                }
                if (objectNameNode != null)
                {
                    objectName = objectNameNode.InnerText;
                }
                if (locationNode != null)
                {
                    // Change this from split to 2 entries in the XML files
                    // Splits the string into 2 separated by the space.
                    string[] coords = locationNode.InnerText.Split(' ');
                    if (coords.Length == 2)
                    {
                        // x = first num. y = second num.
                        float x = (float)int.Parse(coords[0]);
                        float y = (float)int.Parse(coords[1]);

                        // Sets position to a vector.
                        position = new Vector2(x, y);
                        position += (offSet * multiplier);
                    }
                }
                if (hasKey != null)
                {
                    keyBool = bool.Parse(hasKey.InnerText);
                }


                if (con != null && objectTypeNode != null && objectTypeNode.InnerText == "Block")
                {
                    // Populates list of non-moving collideable objects
                    blocks.Add((ICollideable)con.Invoke(new object[] { position, objectName }));
                }
                else if (con2 != null && objectTypeNode != null && objectTypeNode.InnerText == "ICollideable")
                {
                    // Populates list of non-moving collideable objects
                    colliders.Add((ICollideable)con2.Invoke(new object[] { position, keyBool }));
                    // Debug.WriteLine("Lil guy added");
                }
                if (con3 != null && objectTypeNode != null && objectTypeNode.InnerText == "Door")
                {
                    // Populates list of non-moving collideable objects
                    blocks.Add((ICollideable)con3.Invoke(new object[] { position, objectName, roomName, newPosition, lockedDoor }));
                }
            }
            addWalls(offSet);
        }
        private void addWalls(Vector2 offSet)
        {
            Vector2 positions = Constants.top1Position;
            Vector2 size = Constants.horizontalWallSize;
            positions += offSet * multiplier;
            Wall top1 = new Wall(new Microsoft.Xna.Framework.Rectangle((int)positions.X, (int)positions.Y, (int)Constants.horizontalWallSize.X, (int)Constants.horizontalWallSize.Y));
            positions = Constants.top2Position + offSet * multiplier;
            Wall top2 = new Wall(new Microsoft.Xna.Framework.Rectangle((int)positions.X, (int)positions.Y, (int)Constants.horizontalWallSize.X, (int)Constants.horizontalWallSize.Y));
            positions = Constants.bot1Position + offSet * multiplier;
            Wall bot1 = new Wall(new Microsoft.Xna.Framework.Rectangle((int)positions.X, (int)positions.Y, (int)Constants.horizontalWallSize.X, (int)Constants.horizontalWallSize.Y));
            positions = Constants.bot2Position + offSet * multiplier;
            Wall bot2 = new Wall(new Microsoft.Xna.Framework.Rectangle((int)positions.X, (int)positions.Y, (int)Constants.horizontalWallSize.X, (int)Constants.horizontalWallSize.Y));
            positions = Constants.left1Position + offSet * multiplier;
            Wall left1 = new Wall(new Microsoft.Xna.Framework.Rectangle((int)positions.X, (int)positions.Y, (int)Constants.verticalWallSize.X, (int)Constants.verticalWallSize.Y));
            positions = Constants.left2Position + offSet * multiplier;
            Wall left2 = new Wall(new Microsoft.Xna.Framework.Rectangle((int)positions.X, (int)positions.Y, (int)Constants.verticalWallSize.X, (int)Constants.verticalWallSize.Y));
            positions = Constants.right1Position + offSet * multiplier;
            Wall right1 = new Wall(new Microsoft.Xna.Framework.Rectangle((int)positions.X, (int)positions.Y, (int)Constants.verticalWallSize.X, (int)Constants.verticalWallSize.Y));
            positions = Constants.right2Position + offSet * multiplier;
            Wall right2 = new Wall(new Microsoft.Xna.Framework.Rectangle((int)positions.X, (int)positions.Y, (int)Constants.verticalWallSize.X, (int)Constants.verticalWallSize.Y));

            blocks.Add(top1);
            blocks.Add(top2);
            blocks.Add(bot1);
            blocks.Add(bot2);
            blocks.Add(left1);
            blocks.Add(left2);
            blocks.Add(right1);
            blocks.Add(right2);
        }
    }
}
