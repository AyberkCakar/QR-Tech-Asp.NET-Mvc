using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QRTech.Models
{
    public class sql
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglanti = new SqlConnection("Data Source = qrtech20191224112838dbserver.database.windows.net; Initial Catalog = QRTech20191224112838_db; User Id = awProject; Password = soaProject123;");
            //new SqlConnection(@"Data Source=DESKTOP-CCP65NT\SQLEXPRESS;Initial Catalog=QRTech;Integrated Security=True");
            baglanti.Open();
            return baglanti;
        }
        
    }
}