using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcAdmin.Models
{
    public class PermissionObj
    {
        public int IDQN { get; set; }

        [Display(Name = "Họ tên")]
        public string Hoten { get; set; }

        [Display(Name = "Quyền truy cập")]
        public int? Permission { get; set; }

        [Display(Name = "Lượt truy cập")]
        public int? LogStatus { get; set; }

        //[Display(Name = "Thành phần")]
        //public string ThanhPhan { get; set; }

        //[Display(Name = "Đơn vị")]
        //public string DonVi { get; set; }
    }
}