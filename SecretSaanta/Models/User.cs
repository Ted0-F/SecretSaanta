using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace SecretSantaa.Models
{
    public class User
    {
        public string username { get;  set; }
        public string displayName { get; set; }
        public byte[] password { get; set; }

        public void setPassword(string password)
        {
            var sha512 = new SHA512CryptoServiceProvider();
            this.password = sha512.ComputeHash(Encoding.ASCII.GetBytes(password));
        }

        public string getPassword()
        {
            return BitConverter.ToString(password);
        }



    }
}