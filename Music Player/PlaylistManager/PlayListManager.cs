using Music_Player.Models;
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
        public Playlist LoadPlaylist(string directory)
        {
            return LoadFormat(directory);
        }
        public void SavePlaylist(string directory, Playlist data)
        {

            SaveFormat(directory, data);
        }
        protected abstract void SaveFormat(string directory, Playlist data);
        protected abstract Playlist LoadFormat(string directory);

        
    }
    class XMLPlaylistManager : PlaylistManager
    {
        protected override Playlist LoadFormat(string directory)
        {
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(Playlist));
            StreamReader reader = new StreamReader(directory);
            Playlist playlist = new Playlist();
            playlist = (Playlist)serializer.Deserialize(reader);
            return playlist;
        }

        protected override void SaveFormat(string directory, Playlist data)
        {
           System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(Playlist));
           FileStream file = File.Create(directory);
           writer.Serialize(file, data);
           file.Close();
        }
    }
    class JSONPlaylistManager : PlaylistManager
    {
        protected override Playlist LoadFormat(string directory)
        {
            string jsonInput = File.ReadAllText(directory);
            Playlist flight = JsonConvert.DeserializeObject<Playlist>(jsonInput);
            return flight;
        }
        
        protected override void SaveFormat(string directory, Playlist data)
        {
            using (StreamWriter file = new StreamWriter(directory, false))
            {
                JsonSerializer serializer = new JsonSerializer();
                var jsonString = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);
                file.Write(jsonString);
                file.Close();
            }
        }
    }

}
