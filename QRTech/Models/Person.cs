using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QRTech.Models
{
    public abstract class Person
    {
        [Required]
        public string TC { get; set; }

        [Required]
        public string EskiSifre { get; set; }
        [Required]
        public string Sifre { get; set; }

        [Required]
        public string SifreTekrar { get; set; }
        [Required]
        public string AD { get; set; }
        [Required]
        public string Soyad { get; set; }
    }
}