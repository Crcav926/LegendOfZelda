using System;
using System.Xml;

namespace LegendOfZelda;

public class LevelLoader
{
    public LevelLoader()
    {

    }

    private XmlReaderSettings settings = new XmlReaderSettings(); //should this be in constructor?

    public void Parse(System.IO.Stream stream)//pass in stream
    {
        XmlReader reader = XmlReader.Create(stream, settings);
        while(reader.Read())//copied from the XML class 
        {
            switch (reader.NodeType) {
        case XmlNodeType.Element:
            Console.Write("<{0}>", reader.Name);
            break;
        case XmlNodeType.Text:
            Console.Write(reader.Value);
            break;
        case XmlNodeType.CDATA:
            Console.Write("<![CDATA[{0}]]>", reader.Value);
            break;
        case XmlNodeType.ProcessingInstruction:
            Console.Write("<?{0} {1}?>", reader.Name, reader.Value);
            break;
        case XmlNodeType.Comment:
            Console.Write("<!--{0}-->", reader.Value);
            break;
        case XmlNodeType.XmlDeclaration:
            Console.Write("<?xml version='1.0'?>");
            break;
        case XmlNodeType.Document:
            break;
        case XmlNodeType.DocumentType:
            Console.Write("<!DOCTYPE {0} [{1}]", reader.Name, reader.Value);
            break;
        case XmlNodeType.EntityReference:
            Console.Write(reader.Name);
            break;
        case XmlNodeType.EndElement:
            Console.Write("</{0}>", reader.Name);
            break;
        }
        }
    }

}
