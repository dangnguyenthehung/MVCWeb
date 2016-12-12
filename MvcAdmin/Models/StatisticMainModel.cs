using Model.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAdmin.Models
{
    public class StatisticMainModel
    {
        public List<ViewKQ> listKQ { get; set; }
        public int month { get; set; }
    }
}