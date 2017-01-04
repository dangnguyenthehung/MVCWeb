using Model;
using Model.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAdmin.Code
{
    public class func_SyncResult
    {
        
        private static int oldNumber = 0;
        private static byte flag = 0;

        private static void initFlag (StatisticModel model)
        {            
            if (flag == 0)
            {
                var list = model.ListAll();
                oldNumber = list.Count;
                flag = 1;
            }
            else
            {
                //
            }
        }
        private static int compare (List<ViewKQ> list)
        {
            int number = 0;
            int newNumber = list.Count;
            if (newNumber > oldNumber)
            {
                number = newNumber - oldNumber;
            }
            oldNumber = newNumber;
            return number;
        }
        public static List<ViewKQ> show_New_Result()
        {
            StatisticModel model = new StatisticModel();
            List<ViewKQ> newList = new List<ViewKQ>();
            initFlag(model);
            string[] text = new string[2];
            var list = model.ListAll();
            int number = compare(list);
            if (number == 0)
            {
                return null;
            }
            else
            {
                var i = number;
                for (i = number; i >= 1; i--)
                {
                    int index = list.Count - i;
                    newList.Add(list[index]);
                }

                return newList;
            }
        }
        
    }
}