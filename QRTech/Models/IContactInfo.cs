using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRTech.Models
{
    interface IContactInfo
    {
        string Telefon { get; set; }
        string Mail { get; set; }
        string Adres { get;set; }
    }
}
