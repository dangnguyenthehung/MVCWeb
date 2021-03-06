﻿using Model.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class KetQuaKiemTraModel
    {
        private d38dbContext context = null;
        public KetQuaKiemTraModel()
        {
            context = new d38dbContext();
        }
        public int InsertResult(int IDQN, decimal KQ, string XepLoai, int DeSo, string TraLoi, string DapAn )
        {
            object[] sqlParams =
            {
                new SqlParameter("@IDQN", IDQN),
                new SqlParameter("@KQ", KQ),
                new SqlParameter("@XepLoai", XepLoai),
                new SqlParameter("@DeSo", DeSo),
                new SqlParameter("@TraLoi", TraLoi),
                new SqlParameter("@DapAn", DapAn)
            };
            var res = context.Database.ExecuteSqlCommand("Sp_InsertKQKT @IDQN,@KQ,@XepLoai,@DeSo,@TraLoi,@DapAn",sqlParams);
            return res;
        }
        public void DeleteResult(int? IDKQ)
        {
            if (IDKQ != null)
            {
                object[] sqlParams =
                {
                    new SqlParameter("@IDKQ", IDKQ)
                };
                var res = context.Database.ExecuteSqlCommand("Sp_DeleteKQKT @IDKQ", sqlParams);
            }
            else
            {
                //
            }
           
        }
        public ViewKQ GetResult(int? IDKQ, int? IDQN)
        {
            if (IDKQ != null && IDQN != null)
            {
                object[] sqlParams =
                {
                    new SqlParameter("@IDKQ", IDKQ),
                    new SqlParameter("@IDQN", IDQN)
                };
                var res = context.Database.SqlQuery<ViewKQ>("Sp_GetKQKT @IDKQ, @IDQN", sqlParams).SingleOrDefault();
                return res;
            }
            else
            {
                //
                return null;
            }
        }
    }
}
