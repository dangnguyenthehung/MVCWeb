using Model;
using Model.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWEB.Models
{
    public class ChooseTypeModel
    {

        public string ID { get; set; }

        // This property will hold a type, name selected by user
        [Required]
        [Display(Name = "Thành phần")]
        public string ThanhPhan { get; set; }

        [Required]
        [Display(Name = "Họ tên")]
        public string HoTen { get; set; }

        // This property will hold all available Type for selection
        public IEnumerable<SelectListItem> Type { get; set; }

        // This property will hold all available Name for selection
        public IEnumerable<SelectListItem> Name { get; set; }

    }
}