using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRTech.Models
{
    public class Line
    {
        public int HatID { get; set; }
        public int HatNo { get; set; }
        public double KazanılanTutar { get; set; }
        public string BaslangıçDurak { get; set; }
        public string BitişDurak { get; set; }
        public string QRKod { get; set; }
        public string ilAD { get; set; }
        public int ogrenciFiyat { get; set; }
        public int tamFiyat { get; set; }

        public List<Line> Lines = new List<Line>();
    }
}