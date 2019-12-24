using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace QRTech.Models
{
    public static class UserDataBase
    {
        public static User _user;
        private static sql sql = new sql();

        public static User GetUser
        {
            get { return _user; }
        }

        public static void BalanceUpdate(User Entity)
        {
            SqlCommand BalanceUpdate = new SqlCommand("update TBL_Kullanici set bakiye = bakiye + @p2 where tc=@p1 ", sql.baglanti());
            BalanceUpdate.Parameters.AddWithValue("@p1", Entity.TC);
            BalanceUpdate.Parameters.AddWithValue("@p2", Entity.Bakiye);
            BalanceUpdate.ExecuteNonQuery();
            sql.baglanti().Close();
            SqlCommand BalanceUpdate2 = new SqlCommand("insert into TBL_Odeme ( KrediKartNo ,KKSahip ,KKAyYıl , KKCVV, OdemeTarih, kullaniciID) values (@p1,@p2,@p3,@p4,@p5,@p6) ", sql.baglanti());
            BalanceUpdate2.Parameters.AddWithValue("@p1", Entity.KKNo1 +" - "+Entity.KKNo2+" - "+Entity.KKNo3+" - "+Entity.KKNo4 );
            BalanceUpdate2.Parameters.AddWithValue("@p2", Entity.KKSahip);
            BalanceUpdate2.Parameters.AddWithValue("@p3", Entity.KKSonTarihAy+"/"+Entity.KKSonTarihYıl);
            BalanceUpdate2.Parameters.AddWithValue("@p4", Entity.KKCVV);
            BalanceUpdate2.Parameters.AddWithValue("@p5", DateTime.Now);
            BalanceUpdate2.Parameters.AddWithValue("@p6", Entity.kullanıcıID);
            BalanceUpdate2.ExecuteNonQuery();
            sql.baglanti().Close();
        }
        public static void BalanceSend(User Entity)
        {
            SqlCommand BalanceUpdate = new SqlCommand("update TBL_Kullanici set bakiye = bakiye + @p2 where tc=@p1 ", sql.baglanti());
            BalanceUpdate.Parameters.AddWithValue("@p1", Entity.TC);
            BalanceUpdate.Parameters.AddWithValue("@p1", Entity.Bakiye);
            BalanceUpdate.ExecuteNonQuery();
            sql.baglanti().Close();
            SqlCommand BalanceUpdate2 = new SqlCommand("update TBL_Kullanici set bakiye = bakiye - @p2 where kullaniciID=@p1 ", sql.baglanti());
            BalanceUpdate2.Parameters.AddWithValue("@p1", Entity.kullanıcıID);
            BalanceUpdate2.Parameters.AddWithValue("@p1", Entity.Bakiye);
            BalanceUpdate2.ExecuteNonQuery();
            sql.baglanti().Close();
        }

        public static void InformationUpdate(User Entity)
        {
            SqlCommand InformationUpdate = new SqlCommand("update TBL_IletisimBilgi set mail = @p2, adres = @p4, telefonNo=@p3 where iletisimID = (select iletisimID from TBL_Kullanici where tc=@p1)", sql.baglanti());
            InformationUpdate.Parameters.AddWithValue("@p1", Entity.TC);
            InformationUpdate.Parameters.AddWithValue("@p2", Entity.Mail);
            InformationUpdate.Parameters.AddWithValue("@p3", Entity.Telefon);
            InformationUpdate.Parameters.AddWithValue("@p4", Entity.Adres);
            InformationUpdate.ExecuteNonQuery();
            sql.baglanti().Close();
        }
        public static void InformationPasswordUpdate(User Entity)
        {
            SqlCommand InformationUpdate = new SqlCommand("update TBL_Kullanici set sifre = @p2 where tc=@p1 ", sql.baglanti());
            InformationUpdate.Parameters.AddWithValue("@p1", Convert.ToInt64(Entity.TC));
            InformationUpdate.Parameters.AddWithValue("@p2", Entity.Sifre);
            InformationUpdate.ExecuteNonQuery();
            sql.baglanti().Close();
        }

        public static bool UserPayment(User Entity, string QRCode)
        {
            bool durum=false;
            SqlCommand UserPayment = new SqlCommand("select ..... where QRCode = @p1 ", sql.baglanti());
            UserPayment.Parameters.AddWithValue("@p1", QRCode);
            SqlDataReader dtUserPayment = UserPayment.ExecuteReader();
            if (dtUserPayment.Read())
            {
                User user = new User();
                user.Bakiye = user.Bakiye-Convert.ToInt32(dtUserPayment[0]); // bakiyeyi çıkar
                //BalanceUpdate(user);
                return durum = true;
            }
            else
            {
                return durum = false;
            }
        }

        public static bool UserControl(User Entity)
        {
            bool varYok = false;
            SqlConnection connection = sql.baglanti();
            SqlCommand UserControl = new SqlCommand("select * from TBL_Kullanici K inner join TBL_IletisimBilgi I on K.iletisimID = I.iletisimID where  K.tc = @p1 and K.sifre=@p2", connection);
            UserControl.Parameters.AddWithValue("@p1", Entity.TC);
            UserControl.Parameters.AddWithValue("@p2", Entity.Sifre);
            SqlDataReader dtUser = UserControl.ExecuteReader();
            if (dtUser.Read())
            {
                User user = new User();
                user.kullanıcıID = Convert.ToInt32(dtUser[0]);
                user.Bakiye = Convert.ToDouble(dtUser[1]);
                user.TC = dtUser[2].ToString();
                user.Sifre = dtUser[3].ToString();
                user.yolcuTip = Convert.ToInt32(dtUser[4]);
                user.AD = dtUser[5].ToString();
                user.Soyad = dtUser[6].ToString();
                user.Adres = dtUser[11].ToString();
                user.Mail = dtUser[10].ToString();
                user.Telefon = dtUser[9].ToString();
                SqlCommand logGet = new SqlCommand("exec userLog @p1", sql.baglanti());
                logGet.Parameters.AddWithValue("@p1", Convert.ToInt64(user.TC));
                SqlDataReader dtLog = logGet.ExecuteReader();
                while (dtLog.Read())
                {
                    _UserLog _UserLog = new _UserLog();
                    _UserLog.line.HatNo = Convert.ToInt32(dtLog[0]);
                    _UserLog.line.BaslangıçDurak = dtLog[1].ToString();
                    _UserLog.line.BitişDurak = dtLog[2].ToString();
                    _UserLog.line.ilAD = dtLog[3].ToString();
                    _UserLog.Tarih = Convert.ToDateTime(dtLog[4]);
                    user._UserLogs.Add(_UserLog);
                }
                _user = user;
                return varYok = true;
            }
            else
            {
                return varYok = false;
            }
        }
    }
}