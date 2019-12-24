using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRTech.Models
{
    public class Admin:Person
    {
        public int yoneticiID { get; set; }
        public string kullanıcıAdi { get; set; }
        public int ilID { get; set; }
    }
}