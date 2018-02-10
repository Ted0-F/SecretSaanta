using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecretSantaa.Models
{
    public class Invitation
    {
        public string groupName { get; set; }
        public string username { get; set; }
        public DateTime date { get; set; }
        public string groupAdminName { get; set; }
        public string id { set; get; }
    }
}