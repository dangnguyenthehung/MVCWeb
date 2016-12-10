using Model.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcAdmin.Models
{
    public class DanhSachMainModel
    {
        public DanhSach user {get; set;}

        public List<ViewKQ> listKQ { get; set; }
    }
}