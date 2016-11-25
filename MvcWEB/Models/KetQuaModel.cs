using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWEB.Models
{
    public class KetQuaModel
    {
        public int IDQN { get; set; }
        public decimal KQ { get; set; }
        public string XepLoai { get; set; }
        public int DeSo { get; set; }
        public string TraLoi { get; set; }
        public string DapAn { get; set; }
    }
}