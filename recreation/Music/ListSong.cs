using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recreation.Music
{
    public class ListSong
    {
        private string id;
        private string name;
        private string artists;
        private string time;
        private string coverImage;

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Artists { get => artists; set => artists = value; }
        public string Time { get => time; set => time = value; }
        public string CoverImage { get => coverImage; set => coverImage = value; }

        public ListSong(string id, string name, string artists, string time, string coverImage)
        {
            Id = id;
            Name = name;
            Artists = artists;
            Time = time;
            CoverImage = coverImage;
        }
    }
}
