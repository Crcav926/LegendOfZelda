using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;
using System.Xml;
namespace LegendOfZelda
{
    internal class Parsing
    {
        public string objectType { get; set; }
        public string objectName { get; set; }
        public Vector2 position { get; set; }
        
        public Parsing()

        {
            LoadObjects();
        }

        private void LoadObjects()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("C:\\Users\\linwi\\source\\repos\\Sprint3\\XMLParsing\\Room1.xml");

            foreach (XmlNode node in doc.DocumentElement)
            {

                XmlNode objectTypeNode = node.SelectSingleNode("ObjectType");
                XmlNode objectNameNode = node.SelectSingleNode("ObjectName");
                XmlNode locationNode = node.SelectSingleNode("Location");
                if (objectTypeNode != null)
                
                    objectType = objectTypeNode.InnerText;
                
                if (objectNameNode != null) 
                    objectName = objectNameNode.InnerText;
                
                if (locationNode != null)
                {
                    string[] coords = locationNode.InnerText.Split(' ');
                    if (coords.Length == 2)
                    {
                        int x = int.Parse(coords[0]);
                        int y = int.Parse(coords[1]);

                        position = new Vector2(x, y);
                    }
                }


                // DELETE LATER
                Debug.WriteLine($"Gathered info: {objectType}, {objectName}, {position}");
            }

        }
    }
}
