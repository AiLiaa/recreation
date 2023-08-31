using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recreation.Login
{
    public class User
    {
        private string name;
        private string uid;
        private string avatarUrl;

        public string Name { get => name; set => name = value; }
        public string Uid { get => uid; set => uid = value; }
        public string AvatarUrl { get => avatarUrl; set => avatarUrl = value; }

        public User(string name, string uid, string avatarUrl)
        {
            Name = name;
            Uid = uid;
            AvatarUrl = avatarUrl;
        }
    }
}
