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
        public string BaslangicDurak { get; set; }
        public string BitisDurak { get; set; }
        public string ilAD { get; set; }
        public float ogrenciFiyat { get; set; }
        public float tamFiyat { get; set; }

        public List<Line> Lines = new List<Line>();
    }
}