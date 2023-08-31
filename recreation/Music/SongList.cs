using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recreation.Music
{
    class SongList
    {
        private string name;
        private string id;
        private string coverImage;

        public string Name { get => name; set => name = value; }
        public string Id { get => id; set => id = value; }
        public string CoverImage { get => coverImage; set => coverImage = value; }

        public SongList(string name, string id, string coverImage)
        {
            Name = name;
            Id = id;
            CoverImage = coverImage;
        }
    }
}
