using Model.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        public List<DanhSach> ListAll(string ThanhPhan)
        {
            object[] sqlParams =
            {
                new SqlParameter("@ThanhPhan", ThanhPhan)
            };
            var list = context.Database.SqlQuery<DanhSach>("Sp_ChooseType @ThanhPhan", sqlParams).ToList();
            return list;
        }
       
    }
}
