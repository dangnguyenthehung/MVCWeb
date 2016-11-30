using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAdmin.Models
{
    public class StatisticModel
    {
        public int IDQN { get; set; }
        public string HoTen { get; set; }
        public DateTime NgayKT { get; set; }
        public int DeSo { get; set; }
        public decimal KQ { get; set; }
        public string XepLoai { get; set; }
    }
}