using Model.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DanhSachModel
    {
        private d38dbContext context = null;
        public DanhSachModel()
        {
            context = new d38dbContext();
        }
        public List<DanhSach> ListAll()
        {
            var list = context.Database.SqlQuery<DanhSach>("Sp_ChooseType").ToList();
            return list;
        }
        //public List<string> ListName()
        //{
        //    var list = context.Database.SqlQuery<DanhSach>("Sp_ChooseType").ToList();
        //    var listName = new List<string>();
        //    foreach(var item in list)
        //    {
        //        listName.Add(item.HoTen);
        //    }
        //    return listName;
        //}
    }
}
