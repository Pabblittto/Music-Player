using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Player.Models
{
    [JsonObject(MemberSerialization.OptOut)]
    public class Song
    {
        public string title { get; set; }
        public string artist { get; set; }
        public DateTime releaseDate { get; set; }
        public TimeSpan duration { get; set; }
        public string album { get; set; }
        public string path { get; set; }
    }
}
