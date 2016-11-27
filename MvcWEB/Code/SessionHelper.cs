using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWEB.Code
{
    public class SessionHelper
    {
        public static void SetSession(UserSession session)
        {
            //HttpContext.Current.Session["loginSession"] = session;
            HttpContext.Current.Session["examSession"] = session;
        }
        public static UserSession GetSession()
        {
            var session = HttpContext.Current.Session["examSession"];
            if (session == null)
            {
                return null;
            }
            else
            {
                return session as UserSession;
            }
        }
        public static UserSession GetInfo()
        {
            var session = HttpContext.Current.Session["examSession"];
            var sessionObj= session as UserSession;
            if (session == null)
            {
                return null;
            }
            else
            {
                return sessionObj;
            }
        }
    }
}