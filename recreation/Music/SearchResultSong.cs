using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recreation.Music
{
    class SearchResultSong
    {
        private string id;
        private string name;
        private string artists;
        private string source;

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Artists { get => artists; set => artists = value; }
        public string Source { get => source; set => artists = source; }

        public SearchResultSong(string id, string name, string artists, string source)
        {
            this.Id = id;
            this.Name = name;
            this.Artists = artists;
            this.source = source;
        }
    }
}
