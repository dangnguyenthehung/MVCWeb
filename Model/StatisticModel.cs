using Model.Framework;
using System;
using System.Collections.Generic;
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
            var list = context.Database.SqlQuery<ViewKQ>("Sp_Statistic").ToList();
            return list;
        }
    }
}
