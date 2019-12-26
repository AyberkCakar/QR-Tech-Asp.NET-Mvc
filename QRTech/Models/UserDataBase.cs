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

        public static void UserPayment(User Entity, int hatID)
        {
            SqlCommand User = new SqlCommand("select yolcuStatusu from TBL_Kullanici where tc = @p1 ", sql.baglanti());
            User.Parameters.AddWithValue("@p1",Entity.TC);
            SqlDataReader dtUser = User.ExecuteReader();
            if (dtUser.Read())
            {
                User user = new User();
                user.yolcuTip = Convert.ToInt32(dtUser[0]);

                SqlCommand UserPayment = new SqlCommand("select F.ogrenciFiyat,F.ogrenciOran,F.tamFiyat,F.tamOran,F.engelliFiyat,F.engelliOran,F.yasliFiyat,F.yasliOran,H.hatID  from TBL_Hat H inner join TBL_Fiyatlar F on F.fiyatID = H.fiyatID where hatID = @p2 ", sql.baglanti());
                UserPayment.Parameters.AddWithValue("@p2", hatID);
                SqlDataReader dtUserPayment = UserPayment.ExecuteReader();
                if (dtUserPayment.Read())
                {
                    if (Convert.ToInt32(dtUser[0]) == 1)
                    {
                        Entity.Bakiye = Entity.Bakiye - (Convert.ToDouble(dtUserPayment[0]) * Convert.ToDouble(dtUserPayment[1]));
                    }
                    else if (Convert.ToInt32(dtUser[0]) == 2)
                    {
                        Entity.Bakiye = Entity.Bakiye - (Convert.ToDouble(dtUserPayment[2]) * Convert.ToDouble(dtUserPayment[3]));
                    }
                    else if (Convert.ToInt32(dtUser[0]) == 3)
                    {
                        Entity.Bakiye = Entity.Bakiye - (Convert.ToDouble(dtUserPayment[4]) * Convert.ToDouble(dtUserPayment[5]));
                    }
                    else if (Convert.ToInt32(dtUser[0]) == 4)
                    {
                        Entity.Bakiye = Entity.Bakiye - (Convert.ToDouble(dtUserPayment[6]) * Convert.ToDouble(dtUserPayment[7]));
                    }
                    else
                    {
                        throw new Exception();

                    }
                        if (Entity.Bakiye >=0)
                        {
                            SqlCommand payUp = new SqlCommand("update TBL_Kullanici set bakiye=@p2 where tc=@p1", sql.baglanti());
                            payUp.Parameters.AddWithValue("@p1", Entity.TC);
                            payUp.Parameters.AddWithValue("@p2", Entity.Bakiye);
                            payUp.ExecuteNonQuery();
                            sql.baglanti().Close();

                            SqlCommand userLog = new SqlCommand("insert into TBL_KullaniciLog (tarih,hatID,kullaniciID) values (@p3,@p4,@p5)", sql.baglanti());
                            userLog.Parameters.AddWithValue("@p3", DateTime.Now);
                            userLog.Parameters.AddWithValue("@p4", Convert.ToInt32(dtUserPayment[8]));
                            userLog.Parameters.AddWithValue("@p5", Entity.kullanıcıID);
                            userLog.ExecuteNonQuery();
                            sql.baglanti().Close();
                        }
                        else
                        {
                            throw new Exception();

                        }
                }
                else
                {
                    throw new Exception();
                }
            }

            UserControl(Entity);
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

        public static void UserCreate(User Entity)
        {
            try
            {
                int iletisimID = 0;
                SqlCommand UserAdd = new SqlCommand("insert into TBL_IletisimBilgi (telefonNo,mail,adres) values(@p1,@p2,@p3) ", sql.baglanti());
                UserAdd.Parameters.AddWithValue("@p1", Entity.Telefon);
                UserAdd.Parameters.AddWithValue("@p2", Entity.Mail);
                UserAdd.Parameters.AddWithValue("@p3", Entity.Adres);
                UserAdd.ExecuteNonQuery();
                sql.baglanti().Close();

                SqlCommand User = new SqlCommand("select iletisimID from TBL_IletisimBilgi order by iletisimID desc ", sql.baglanti());
                SqlDataReader dtUser = User.ExecuteReader();
                if (dtUser.Read())
                {
                    iletisimID = Convert.ToInt32(dtUser[0]);
                }

                SqlCommand userCreate = new SqlCommand("insert into TBL_Kullanici (bakiye,tc,sifre,yolcuStatusu,isim,soyisim,iletisimID) values (@p4,@p5,@p6,@p7,@p8,@p9,@p10)", sql.baglanti());
                userCreate.Parameters.AddWithValue("@p4", 0);
                userCreate.Parameters.AddWithValue("@p5", Entity.TC);
                userCreate.Parameters.AddWithValue("@p6", Entity.Sifre);
                userCreate.Parameters.AddWithValue("@p7", Entity.yolcuTip);
                userCreate.Parameters.AddWithValue("@p8", Entity.AD);
                userCreate.Parameters.AddWithValue("@p9", Entity.Soyad);
                userCreate.Parameters.AddWithValue("@p10", iletisimID);
                userCreate.ExecuteNonQuery();
                sql.baglanti().Close();

            }
            catch (Exception)
            {
            }

        }
    }
}