using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRTech.Models
{
    public class Price
    {
        public int fiyatID { get; set; }
        public int ogrenciFiyat { get; set; }
        public float ogrenciOran{ get; set; }
        public int tamFiyat { get; set; }
        public float tamOran { get; set; }
        public int engelliFiyat { get; set; }
        public float engelliOran { get; set; }
        public int yasliFiyat { get; set; }
        public float yasliOran { get; set; }

    }
}