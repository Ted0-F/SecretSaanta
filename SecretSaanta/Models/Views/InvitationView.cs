using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecretSaanta.Models.Views
{
    public class InvitationView
    {
        public string groupName { get; set; }
        public string groupAdmin { get; set; }
        public DateTime received { get; set; } 
        public string id { get; set; }
    }
}