using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QRTech.Models
{
    public class User:Person,IContactInfo,IPayment
    {
        [Required]
        public int kullanıcıID { get; set; }
        [Required]
        public double Bakiye { get; set; }
        [Required]
        public int yolcuTip { get; set; }
        [Required]
        public string Telefon { get ; set; }
        [Required]
        public string Mail { get; set; }
        [Required]
        public string Adres { get; set; }
        [Required]
        public string KKSahip { get; set; }
        [Required]
        public int KKSonTarihAy { get; set; }
        [Required]
        public int KKSonTarihYıl { get; set; }
        [Required]
        public int KKCVV { get; set; }
        [Required]
        public int KKNo1 { get; set; }
        [Required]
        public int KKNo2 { get; set; }
        [Required]
        public int KKNo3 { get; set; }
        [Required]
        public int KKNo4 { get; set; }

        public int islem;
        public List<_UserLog> _UserLogs = new List<_UserLog>();


    }

}