using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

        public Parsing(string fileName)
        {
            LoadObjects(fileName);
        }


        private void LoadObjects(string fileName)
        {
            // Finds files in content and loads it.
            XmlDocument doc = new XmlDocument();
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(baseDirectory, "Content", fileName);
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
                        int x = int.Parse(coords[0]);
                        int y = int.Parse(coords[1]);
                        // Sets position to a vector.
                        position = new Vector2(x, y);
                    }
                }

                // data is held in a tuple added to an object list.
                objectData = new Tuple<string, string, Vector2>(objectType, objectName, position);

                objectList.Add(objectData);


            }
            // Debug line to check items in objectList.
            foreach (Tuple<String,String,Vector2> t in objectList)
            {
                Debug.WriteLine(t.ToString());
            }
        }
    }
}
