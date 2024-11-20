using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
namespace LegendOfZelda
{
    internal class Parsing
    {

        private XmlNode objectTypeNode;
        private XmlNode objectNameNode;
        private XmlNode locationNode;
        private XmlNode linkLocationX;
        private XmlNode linkLocationY;
        private XmlNode hasKey;
        private XmlNode locked;
        private XmlNode room;
        private XmlNode offSetX;
        private XmlNode offSetY;
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
           // newPosition = new Vector2(0, 0);


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
                objectTypeNode = node.SelectSingleNode("ObjectType");
                objectNameNode = node.SelectSingleNode("ObjectName");
                locationNode = node.SelectSingleNode("Location");
                linkLocationX = node.SelectSingleNode("LinkLocationX");
                linkLocationY = node.SelectSingleNode("LinkLocationY");
                hasKey = node.SelectSingleNode("HasKey");
                locked = node.SelectSingleNode("Locked");
                room = node.SelectSingleNode("Room");
                offSetX = node.SelectSingleNode("OffsetX");
                offSetY = node.SelectSingleNode("OffsetY");
                if (offSetX != null)
                {
                    offSet = new Vector2(int.Parse(offSetX.InnerText), int.Parse(offSetY.InnerText));
                }
                // Checks for null, if not null find the inner text.
                if (objectTypeNode != null)
                {
                    objectType = objectTypeNode.InnerText;
                    if (objectTypeNode.InnerText == "Block" || objectTypeNode.InnerText == "Floor")
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
                    else if(objectTypeNode.InnerText == "WallSprite")
                    {
                        type = Type.GetType("LegendOfZelda." + objectTypeNode.InnerText);
                        con = type.GetConstructor(new[] { typeof(Vector2), typeof(String) });
                        //Debug.WriteLine(type.FullName);
                        //Debug.WriteLine(con.ToString());
                    }
                    else if(objectTypeNode.InnerText == "ClassItems")
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
                if (locked != null)
                {
                    lockedDoor = bool.Parse(locked.InnerText);
                    Debug.WriteLine(locked.InnerText);
                }

                if (con != null && objectTypeNode != null && objectTypeNode.InnerText == "Block")
                {
                    // Populates list of non-moving collideable objects
                    blocks.Add((ICollideable)con.Invoke(new object[] { position, objectName }));
                }
                if (con != null && objectTypeNode != null && objectTypeNode.InnerText == "Floor")
                {
                    // Populates list of non-moving collideable objects
                    blocks.Add((ICollideable)con.Invoke(new object[] { position, objectName }));
                }
                else if (con != null && objectTypeNode != null && objectTypeNode.InnerText == "PushableBlock")
                {
                    // Populates list of non-moving collideable objects
                    blocks.Add((ICollideable)con.Invoke(new object[] { position, objectName }));
                }
                else if (con != null && objectTypeNode != null && objectTypeNode.InnerText == "WallSprite")
                {
                    // Populates list of non-moving collideable objects
                    blocks.Add((ICollideable)con.Invoke(new object[] { position, objectName }));
                }
                else if (con != null && objectTypeNode != null && objectTypeNode.InnerText == "Floor")
                {
                    // Populates list of non-moving collideable objects
                    blocks.Add((ICollideable)con.Invoke(new object[] { position, objectName }));
                }
                else if (con != null && objectTypeNode != null && objectTypeNode.InnerText == "ClassItems")
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
                    Debug.WriteLine("populating");
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
            collideWall top1 = new collideWall(new Microsoft.Xna.Framework.Rectangle((int)positions.X, (int)positions.Y, (int)Constants.horizontalWallSize.X, (int)Constants.horizontalWallSize.Y));
            positions = Constants.top2Position + offSet * multiplier;
            collideWall top2 = new collideWall(new Microsoft.Xna.Framework.Rectangle((int)positions.X, (int)positions.Y, (int)Constants.horizontalWallSize.X, (int)Constants.horizontalWallSize.Y));
            positions = Constants.bot1Position + offSet * multiplier;
            collideWall bot1 = new collideWall(new Microsoft.Xna.Framework.Rectangle((int)positions.X, (int)positions.Y, (int)Constants.horizontalWallSize.X, (int)Constants.horizontalWallSize.Y));
            positions = Constants.bot2Position + offSet * multiplier;
            collideWall bot2 = new collideWall(new Microsoft.Xna.Framework.Rectangle((int)positions.X, (int)positions.Y, (int)Constants.horizontalWallSize.X, (int)Constants.horizontalWallSize.Y));
            positions = Constants.left1Position + offSet * multiplier;
            collideWall left1 = new collideWall(new Microsoft.Xna.Framework.Rectangle((int)positions.X, (int)positions.Y, (int)Constants.verticalWallSize.X, (int)Constants.verticalWallSize.Y));
            positions = Constants.left2Position + offSet * multiplier;
            collideWall left2 = new collideWall(new Microsoft.Xna.Framework.Rectangle((int)positions.X, (int)positions.Y, (int)Constants.verticalWallSize.X, (int)Constants.verticalWallSize.Y));
            positions = Constants.right1Position + offSet * multiplier;
            collideWall right1 = new collideWall(new Microsoft.Xna.Framework.Rectangle((int)positions.X, (int)positions.Y, (int)Constants.verticalWallSize.X, (int)Constants.verticalWallSize.Y));
            positions = Constants.right2Position + offSet * multiplier;
            collideWall right2 = new collideWall(new Microsoft.Xna.Framework.Rectangle((int)positions.X, (int)positions.Y, (int)Constants.verticalWallSize.X, (int)Constants.verticalWallSize.Y));
            positions = Constants.topMiddlePosition + offSet * multiplier;
            collideWall topMiddle = new collideWall(new Microsoft.Xna.Framework.Rectangle((int)positions.X, (int)positions.Y, (int)Constants.horizontalMiddleSize.X, (int)Constants.horizontalMiddleSize.Y));
            positions = Constants.botMiddlePosition + offSet * multiplier;
            collideWall botMiddle = new collideWall(new Microsoft.Xna.Framework.Rectangle((int)positions.X, (int)positions.Y, (int)Constants.horizontalMiddleSize.X, (int)Constants.horizontalMiddleSize.Y));
            positions = Constants.leftMiddlePosition + offSet * multiplier;
            collideWall leftMiddle = new collideWall(new Microsoft.Xna.Framework.Rectangle((int)positions.X, (int)positions.Y, (int)Constants.verticalMiddleSize.X, (int)Constants.verticalMiddleSize.Y));
            positions = Constants.rightMiddlePosition + offSet * multiplier;
            collideWall rightMiddle = new collideWall(new Microsoft.Xna.Framework.Rectangle((int)positions.X, (int)positions.Y, (int)Constants.verticalMiddleSize.X, (int)Constants.verticalMiddleSize.Y));

            blocks.Add(top1);
            blocks.Add(top2);
            blocks.Add(bot1);
            blocks.Add(bot2);
            blocks.Add(left1);
            blocks.Add(left2);
            blocks.Add(right1);
            blocks.Add(right2);
            blocks.Add(topMiddle);
            blocks.Add(botMiddle);
            blocks.Add(leftMiddle);
            blocks.Add(rightMiddle);
        }
    }
}
