using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRTech.Models
{
    public static class TFuncAdmin
    {
        public static Func<int,string, string, float, float, bool> HatEkleKontrol = (p1, p2, p3, p4, p5) =>
        {
            if (p1 == 0 || p2 =="" || p3 == "" || p4 == 0 || p5== 0 )
            {
                return false;
            }
            else
                return true;
        };

        public static Func<int, string, string, float, float,int, bool> HatGuncelleKontrol = (p1, p2, p3, p4, p5,p6) =>
        {
            if (p1 == 0 || p2 == "" || p3 == "" || p4 == 0 || p5 == 0 || p6 ==0)
            {
                return false;
            }
            else
                return true;
        };

        public static Func< string, string, float, float, bool> DurakEkleKontrol = ( p2, p3, p4, p5) =>
        {
            if (p2 == "" || p3 == "" || p4 == 0 || p5 == 0)
            {
                return false;
            }
            else
                return true;
        };

        public static Func<int, string, string, float, float, bool> DurakGuncelleKontrol = (p1, p2, p3, p4, p5) =>
        {
            if (p1 == 0 || p2 == "" || p3 == "" || p4 == 0 || p5 == 0 )
            {
                return false;
            }
            else
                return true;
        };

        public static Func<string, string,string,int, float,string,string,string,string , bool> SoforEkleKontrol = (p1, p2, p3, p4, p5, p6, p7, p8, p9) =>
        {
            if (p1== "" || p2 == "" || p3 == "" || p4 == 0 || p5 == 0 || p6 == "" || p7 == "" || p8 == "" || p9 == "")
            {
                return false;
            }
            else
                return true;
        };

        public static Func<string, string, string, int, float, string, string, string, string,int, bool> SoforGuncelleKontrol = (p1, p2, p3, p4, p5, p6, p7, p8, p9,p10) =>
        {
            if (p1 == "" || p2 == "" || p3 == "" || p4 == 0 || p5 == 0 || p6 == "" || p7 == "" || p8 == "" || p9 == "" || p10 ==0)
            {
                return false;
            }
            else
                return true;
        };

        public static Func<string, string, string, string, string,  int, bool> AracEkleKontrol = (p1, p2, p3, p4, p5, p6) =>
        {
            if (p1 == "" || p2 == "" || p3 == "" || p4 == "" || p5 == "" || p6 == 0 )
            {
                return false;
            }
            else
                return true;
        };

        public static Func<string, string, string, string, string, int, int, bool> AracGuncelleKontrol = (p1, p2, p3, p4, p5, p6, p7) =>
        {
            if (p1 == "" || p2 == "" || p3 == "" || p4 == "" || p5 == "" || p6 == 0 || p7 == 0)
            {
                return false;
            }
            else
                return true;
        };
    }
}