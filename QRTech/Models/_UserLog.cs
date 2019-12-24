using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRTech.Models
{
    public class _UserLog
    {
        public int logID { get; set; }
        public DateTime Tarih { get; set; }

        public Line line = new Line();
        

    }
}