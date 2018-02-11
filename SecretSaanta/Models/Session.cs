using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecretSantaa.Models
{
    public class Session
    {
        public string authToken { get; set; }
        public User mUser { get; set; }
    }
}