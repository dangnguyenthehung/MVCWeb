using Model.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class IndividualExamModel
    {
        private d38dbContext context = null;
        public IndividualExamModel()
        {
            context = new d38dbContext();
        }
        public List<ViewIndividualExam> ListAll()
        {
            int id = 0;
            object[] sqlParams =
            {
                new SqlParameter("@IDQN",id)
            };
            var list = context.Database.SqlQuery<ViewIndividualExam>("Sp_GetIndividualExam @IDQN", sqlParams).ToList();
            return list;
        }
        public ViewIndividualExam GetOne(int id)
        {

            object[] sqlParams =
            {
                new SqlParameter("@IDQN",id)
            };
            var obj = context.Database.SqlQuery<ViewIndividualExam>("Sp_GetIndividualExam @IDQN", sqlParams).SingleOrDefault();
            return obj;
        }
        public void SetIndividualExams(int ID, int examNumber)
        {
            object[] sqlParams =
            {
                new SqlParameter("@IDQN",ID),
                new SqlParameter("@IndividualExam",examNumber)
            };
            var res = context.Database.ExecuteSqlCommand("Sp_SetIndividualExam @IDQN,@IndividualExam", sqlParams);

        }
        public void Refresh(int ID)
        {
            object[] sqlParams =
            {
                new SqlParameter("@IDQN",ID)
            };
            var res = context.Database.ExecuteSqlCommand("Sp_RenewAllIndividualExam @IDQN", sqlParams);

        }
    }
}
