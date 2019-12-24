using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRTech.Models
{
    public class Town
    {
        public int ilceID { get; set; }
        public string ilceAd { get; set; }

        public List<Station> Station = new List<Station>();
    }
}