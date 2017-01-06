using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWEB.Models
{
    public class ResultPageModel
    {
        public string ExamObj { get; set; }
        public int[] WrongNumber { get; set; }
        public string[] WrongAns { get; set; }
        public string[] TrueAns { get; set; }
    }
}