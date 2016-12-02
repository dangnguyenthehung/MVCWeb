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
        public List<PermissionObj> PerList { get; set; }
    }
}