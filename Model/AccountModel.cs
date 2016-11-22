using Model.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class AccountModel
    {
        private d38dbContext context = null;
        public AccountModel()
        {
            context = new d38dbContext();
        }
        public bool Login(string userName, string pass)
        {
            object[] sqlParams =
            {
                new SqlParameter("@UserName", userName),
                new SqlParameter("@Pass", pass),
            };
            var res = context.Database.SqlQuery<bool>("Account_login @UserName,@Pass", sqlParams).SingleOrDefault();
            return res;
        }
    }
}
