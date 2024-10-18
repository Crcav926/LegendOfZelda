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
        private Tuple <String,String,Vector2> objectData { get; set; }
        public List<Tuple<string, string, Vector2>> objectList { get; set; } = new List<Tuple<string, string, Vector2>>();
        private ConstructorInfo con;
        private List<Block> blocks = new List<Block>();
        private Type type;
        int w = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        int h = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

        public Parsing(string fileName)
        {
            LoadObjects(fileName);
        }

        public List<Block> getBlocks() { return blocks; }
        public float normalizeX(float x) { return x*(800/209); }
        public float normalizeY(float y) { return y*(480/129); }

        private void LoadObjects(string fileName)
        {
            // Finds files in content and loads it.
            XmlDocument doc = new XmlDocument();
            // This will get the current WORKING directory (i.e. \bin\Debug)
            string workingDirectory = Environment.CurrentDirectory;
            // or: Directory.GetCurrentDirectory() gives the same result
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string filePath = Path.Combine(projectDirectory, "Rooms", fileName);
            doc.Load(filePath);

            Debug.WriteLine("Now Loading: " + fileName);
            // Foreach through each node in the document.
            foreach (XmlNode node in doc.DocumentElement)
            {

                // Checks for node with same name
                XmlNode objectTypeNode = node.SelectSingleNode("ObjectType");
                XmlNode objectNameNode = node.SelectSingleNode("ObjectName");
                XmlNode locationNode = node.SelectSingleNode("Location");
                
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
                    }
                    else
                    {
                        type = Type.GetType("LegendOfZelda." + objectTypeNode.InnerText);
                        // con = type.GetConstructor(new[] { typeof(Vector2)});
                    }
                }
                if (objectNameNode != null)
                {
                    objectName = objectNameNode.InnerText;
                }
                if (locationNode != null)
                {
                    // Splits the string into 2 separated by the space.
                    string[] coords = locationNode.InnerText.Split(' ');
                    if (coords.Length == 2)
                    {
                        // x = first num. y = second num.
                        float x = normalizeX((float)int.Parse(coords[0]));
                        float y = normalizeY((float)int.Parse(coords[1]));

                        // Sets position to a vector.
                        position = new Vector2((int)x, (int)y);
                    }
                }
                if (con != null && objectTypeNode != null && objectTypeNode.InnerText == "Block")
                {
                    blocks.Add((Block)con.Invoke(new object[] { position, objectName }));
                }
                else if (con != null)
                {

                }

                // data is held in a tuple added to an object list.
                objectData = new Tuple<string, string, Vector2>(objectType, objectName, position);

                objectList.Add(objectData);


            }
            // Debug line to check items in objectList.
            foreach (Tuple<String,String,Vector2> t in objectList)
            {
                // Debug.WriteLine(t.ToString());
            }
        }
    }
}
