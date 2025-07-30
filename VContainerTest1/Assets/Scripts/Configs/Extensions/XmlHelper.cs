using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

namespace Wolfdev.Configs.Extensions
{
    public static class XmlHelper
    {
        public static bool TryLoadXmlDocument(string path, out XmlDocument xmlDocument)
        {
            if (File.Exists(path))
            {
                try
                {
                    var doc = new XmlDocument();
                    doc.Load(path);
                    xmlDocument = doc;
                    return true;
                }
                catch (Exception e)
                {
                    Debug.LogError($"Failed to load config: {e.Message}");
                }
            }
            else
            {
                Debug.LogError($"File not found at path: {path}");
            }

            xmlDocument = null;
            return false;
        }

        public static bool TrySaveXmlDocument(this XmlDocument xmlDocument, string path)
        {
            try
            {
                xmlDocument.Save(path);
                return true;
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to load config: {e.Message}");
            }
            
            return false;
        }

        public static T DeserializeXmlDocument<T>(this XmlDocument xmlDoc)
        {
            var serializer = new XmlSerializer(typeof(T));
            using var reader = new XmlNodeReader(xmlDoc);
            return (T)serializer.Deserialize(reader);
        }

        public static XmlDocument SerializeToXmlDocument<T>(T obj)
        {
            var serializer = new XmlSerializer(typeof(T));
            var xmlDoc = new XmlDocument();

            using var memoryStream = new MemoryStream();
            serializer.Serialize(memoryStream, obj);
            memoryStream.Position = 0;
            xmlDoc.Load(memoryStream);

            return xmlDoc;
        }
        
        private static void Traverse(XmlNode node, string currentPath)
        {
            if (node == null) return;

            // Skip text nodes
            if (node.NodeType == XmlNodeType.Text || node.NodeType == XmlNodeType.Comment)
                return;

            string path = $"{currentPath}/{node.Name}";
            Debug.Log(path); // Or use Debug.Log in Unity

            // Process attributes (optional)
            if (node.Attributes != null)
            {
                foreach (XmlAttribute attr in node.Attributes)
                {
                    Debug.Log($"{path}/@{attr.Name} = {attr.Value}");
                }
            }

            // Recurse into children
            foreach (XmlNode child in node.ChildNodes)
            {
                Traverse(child, path);
            }
        }
    }
}