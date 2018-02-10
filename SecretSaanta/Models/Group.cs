using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecretSantaa.Models
{
    public class Group
    {
        public string name { get; set; }
        public User mOwner { get; set; }
        public List<User> mMembers { get; set; }
        public bool mIsLinked { get; set; }
    }
}