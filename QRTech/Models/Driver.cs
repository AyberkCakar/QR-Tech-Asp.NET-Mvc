using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRTech.Models
{
    public class Driver : Person, IContactInfo
    {
        public int soforID { get; set; }
        public int ehliyetSeriNo { get; set; }
        public string Telefon { get; set; }
        public string Mail { get; set; }
        public string Adres { get; set; }
        public float Maas { get; set; }
        public int HatNo { get; set; }
        public string AracPlaka { get; set; }
    }
}