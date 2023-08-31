using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recreation.Music
{
    class Comment
    {
        private string username;
        private string avatarUrl;
        private string content;
        private string time;

        public string Username { get => username; set => username = value; }
        public string AvatarUrl { get => avatarUrl; set => avatarUrl = value; }
        public string Content { get => content; set => content = value; }
        public string Time { get => time; set => time = value; }

        public Comment(string username, string avatarUrl, string content, string time)
        {
            Username = username;
            AvatarUrl = avatarUrl;
            Content = content;
            Time = time;
        }
    }
}
