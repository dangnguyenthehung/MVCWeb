using Model.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcAdmin.Models
{
    public class IndividualExamMainModel
    {
        public int CaptID { get; set; }
        public string Action { get; set; }

        //store selected obj
        public IndividualExamObj ListObj  { get; set; }

       
        

        // store List obj render to View
        public List<ViewIndividualExam> ListView { get; set; }

        public IEnumerable<SelectListItem> TotalExam { get; set; }

    }
}