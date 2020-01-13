using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Music_Player.PlaylistManager
{
    abstract class PlaylistManager
    {
        public void LoadPlaylist(string directory)
        {
            LoadFormat(directory);
        }
        public void SavePlaylist(string directory, List<string> data)
        {

            SaveFormat(directory, data);
        }
        protected abstract void SaveFormat(string directory, List<string> data);
        protected abstract List<string> LoadFormat(string directory);

        
    }
    class XMLPlaylistManager : PlaylistManager
    {
        protected override List<string> LoadFormat(string directory)
        {
            XmlDocument doc = new XmlDocument();
            List<string> list = new List<string>();
            doc.Load(directory);
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                string text = node.InnerText;
                Console.WriteLine(text);
                list.Add(text);
            }
            return list;
        }

        protected override void SaveFormat(string directory, List<string> data)
        {
           System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(List<string>));
           FileStream file = File.Create(directory);
           writer.Serialize(file, data);
           file.Close();
        }
    }
    class JSONPlaylistManager : PlaylistManager
    {
        protected override List<string> LoadFormat(string directory)
        {
            string jsonInput = File.ReadAllText(directory);
            List<string> flight = JsonConvert.DeserializeObject<List<string>>(jsonInput);
            return flight;
        }

        protected override void SaveFormat(string directory, List<string> data)
        {
            using (StreamWriter file = File.CreateText(directory))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, data);
                file.Close();
            }
        }
    }

}
