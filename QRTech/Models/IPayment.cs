using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRTech.Models
{
    interface IPayment
    {
        int KKNo1 { get; set; }
        int KKNo2 { get; set; }
        int KKNo3 { get; set; }
        int KKNo4 { get; set; }
        string KKSahip { get; set; }
        int KKSonTarihAy { get; set; }
        int KKSonTarihYıl { get; set; }
        int KKCVV { get; set; }
    }
}
