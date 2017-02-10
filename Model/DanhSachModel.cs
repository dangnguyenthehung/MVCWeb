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
        public List<DanhSach> List_ThanhPhan(string ThanhPhan)
        {
            object[] sqlParams =
            {
                new SqlParameter("@ThanhPhan", ThanhPhan)
            };
            var list = context.Database.SqlQuery<DanhSach>("Sp_ChooseType @ThanhPhan", sqlParams).ToList();
            return list;
        }
        public List<DanhSach> List_ID(int? ID)
        {
            if (ID == null)
            {
                var l = new List<DanhSach>();
                //
                return l;
            }
            object[] sqlParams =
            {
                new SqlParameter("@IDQN", ID)
            };
            var list = context.Database.SqlQuery<DanhSach>("Sp_GetDanhSachTable @IDQN", sqlParams).ToList();
            return list;
        }
        public void Insert (DanhSach user)
        {
            object[] sqlParams =
            {
                new SqlParameter("@HoTen", user.HoTen),
                new SqlParameter("@CB", user.CB),
                new SqlParameter("@CV", user.CV),
                new SqlParameter("@DonVi", user.DonVi),
                new SqlParameter("@ThanhPhan", user.ThanhPhan)
            };
            var command = context.Database.ExecuteSqlCommand("Sp_InsertDanhSach @HoTen,@CB,@CV,@DonVi,@ThanhPhan", sqlParams);  
        }
        public void Edit(DanhSach user)
        {
            object[] sqlParams =
            {
                new SqlParameter("@IDQN", user.IDQN),
                new SqlParameter("@HoTen", user.HoTen),
                new SqlParameter("@CB", user.CB),
                new SqlParameter("@CV", user.CV),
                new SqlParameter("@DonVi", user.DonVi),
                new SqlParameter("@ThanhPhan", user.ThanhPhan)
            };
            var command = context.Database.ExecuteSqlCommand("Sp_EditDanhSach @IDQN,@HoTen,@CB,@CV,@DonVi,@ThanhPhan", sqlParams);
        }
        public List<ViewKQ> List_Statistic_ID(int? id)
        {
            if (id == null)
            {
                var l = new List<ViewKQ>();
                //
                return l;
            }
            object[] sqlParams =
            {
                new SqlParameter("@IDQN",id)
            };
            var list = context.Database.SqlQuery<ViewKQ>("Sp_Statistic @IDQN", sqlParams).ToList();
            return list;
        }
        public void Delete_user (int? id)
        {
            if (id == null)
            {
                // do nothing
            }
            else
            {
                object[] sqlParams =
                {
                    new SqlParameter("@IDQN",id)
                };
                var command = context.Database.ExecuteSqlCommand("Sp_MoveUser @IDQN", sqlParams);
            }

        }

    }
}
