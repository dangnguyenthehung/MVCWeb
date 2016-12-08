using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAdmin.Models
{
    public class PermissionMainModel
    {

        public int CaptID { get; set; }
        public string Action { get; set; }
        public List<PermissionObj> PerList_SQ { get; set; }
        public List<PermissionObj> PerList_QNCN { get; set; }
        public List<PermissionObj> PerList_HSQ_TS { get; set; }
        public List<PermissionObj> PerList_HSQ_TT { get; set; }
        public List<PermissionObj> PerList_HSQ_dB_BD { get; set; }
    }
}