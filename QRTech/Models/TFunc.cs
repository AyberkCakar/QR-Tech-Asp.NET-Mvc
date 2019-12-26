using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRTech.Models
{
    public static class TFunc
    {
        public static Func< string, string, string, string, string,string,string,int,bool> formBosKontrol = (Ad,Soyad,Telefon,Mail,Adres,Tc,Sifre,YolcuTip) =>
        {
            if (Ad == "" || Soyad == "" || Telefon == "" || Mail == "" || Adres == "" || Tc == "" || Sifre == "" || YolcuTip == 0)
            {
                return false;
            }
            else
                return true;
        };

        public static Func<string, double, int, int, int, int, string, int, int, int, bool> formOdemeBosKontrol = (Tc,Tutar,KartNo1,KartNo2,KartNo3,KartNo4,Sahip,Ay,Yıl,CVV) =>
        {
            if (Tc == "" || Tutar == 0 || KartNo1 == 0 || KartNo2 == 0 || KartNo3 == 0 || KartNo4 == 0 || Sahip=="" || Ay == 0 || Yıl == 0 || CVV == 0)
            {
                return false;
            }
            else
                return true;
        };
    }
}