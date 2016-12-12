using Model.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class StatisticModel
    {
        private d38dbContext context = null;
        public StatisticModel()
        {
            context = new d38dbContext();
        }
        public List<ViewKQ> ListAll()
        {
            var id = 0;
            object[] sqlParams =
            {
                new SqlParameter("@IDQN",id)
            };
            var list = context.Database.SqlQuery<ViewKQ>("Sp_Statistic @IDQN",sqlParams).ToList();
            return list;
        }
        public List<ViewKQ> List_Month(int month)
        {           
            object[] sqlParams =
            {
                new SqlParameter("@Month",month)
            };
            var list = context.Database.SqlQuery<ViewKQ>("Sp_GetStatistic_Month @Month", sqlParams).ToList();

            return list;
        }

    }
}
