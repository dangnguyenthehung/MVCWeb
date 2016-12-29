using Model.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PermissionModel
    {
        private d38dbContext context = null;
        public PermissionModel()
        {
            context = new d38dbContext();
        }
        public List<ViewPermission> ListAll()
        {
            int ID = 0;
            object[] sqlParams =
            {
                new SqlParameter("@IDQN",ID)
            };
            var list = context.Database.SqlQuery<ViewPermission>("Sp_GetPermission @IDQN", sqlParams).ToList();
            return list;
        }
        public ViewPermission GetOne(int id)
        {
            
            object[] sqlParams =
            {
                new SqlParameter("@IDQN",id)
            };
            var obj = context.Database.SqlQuery<ViewPermission>("Sp_GetPermission @IDQN", sqlParams).SingleOrDefault();
            return obj;
        }
        public void Accept(int ID)
        {
            object[] sqlParams =
            {
                new SqlParameter("@IDQN",ID)
            };
            var res = context.Database.ExecuteSqlCommand("Sp_EditPermission @IDQN",sqlParams);  
            
        }
        public void Refresh(int ID)
        {
            object[] sqlParams =
            {
                new SqlParameter("@IDQN",ID)
            };
            var res = context.Database.ExecuteSqlCommand("Sp_RenewAllPermission @IDQN", sqlParams);

        }
        public void SetLogStatus(int ID)
        {
            object[] sqlParams =
            {
                new SqlParameter("@IDQN",ID)
            };
            var res = context.Database.ExecuteSqlCommand("Sp_SetLogStatus @IDQN", sqlParams);

        }
        public ViewPermission CheckPermission(int ID)
        {
            object[] sqlParams =
            {
                new SqlParameter("@IDQN",ID)
            };

            var list = context.Database.SqlQuery<ViewPermission>("Sp_GetPermission @IDQN", sqlParams).ToList();

            ViewPermission res = new ViewPermission();
            res.Permission = list[0].Permission;
            res.LogStatus = list[0].LogStatus;
            return res;
        }
        public void InitPermission()
        {
            var res = context.Database.ExecuteSqlCommand("Sp_InitPermission");
        }

        public ViewIndividualExam CheckIndividualExam(int ID)
        {
            object[] sqlParams =
            {
                new SqlParameter("@IDQN",ID)
            };

            var list = context.Database.SqlQuery<ViewIndividualExam>("Sp_GetIndividualExam @IDQN", sqlParams).ToList();

            ViewIndividualExam res = new ViewIndividualExam();
            res.IndividualExam = list[0].IndividualExam;
            return res;
        }
    }
}
