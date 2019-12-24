using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRTech.Models
{
    public class Province
    {
        public int ilID { get; set; }
        public string ilAd { get; set; }
        public List<Town> Town = new List<Town>();
    }
}