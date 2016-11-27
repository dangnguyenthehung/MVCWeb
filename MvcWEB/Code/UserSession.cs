using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWEB.Code
{
    [Serializable]
    public class UserSession
    {
        public string UserName { set; get; }
        public int ID { get; set; }
        public int DeSo { get; set; }
    }
}