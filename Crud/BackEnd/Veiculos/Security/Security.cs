using OnAuth2;
using OnAuth2.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHome.Security
{
    public class Configuration : IConfiguration
    {
        public Configuration()
        {
            SaltKey = "DcMy40M&";
            ValidIssuer = "studio.myapp.myhome";
            ValidAudience = "studio.myapp.myhome";
            IssuerSigningKey = "$tud10@My4pp5!2018";
        }

        public string SaltKey { get; set; }
        public string ValidIssuer { get; set; }
        public string ValidAudience { get; set; }
        public string IssuerSigningKey { get; set; }
    }
}
