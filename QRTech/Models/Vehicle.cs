using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRTech.Models
{
    public class Vehicle
    {
        public int aracID { get; set; }
        public string Plaka { get; set; }
        public bool engelliDestegi { get; set; }
        public string saseNumarasi { get; set; }
        public string Renk { get; set; }
        public string AracMarka { get; set; }
        public string Model { get; set; }

        public int HatNo { get; set; }
        private void Code()
        {
        }
    }
}