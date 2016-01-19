using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCTest.Helper
{
    public class SessionHelper
    {
        public static object GetSession(string key)
        {
            //check session 
            if (HttpContext.Current.Session[key] != null)
            {
                //return session value
                return HttpContext.Current.Session[key];
            }
            else
            {
                //return empty string
                return string.Empty;
            }
        }

        public static void SetSession(string key, object val)
        {
            HttpContext.Current.Session[key] = val;
        }
    }
}