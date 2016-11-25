using Model;
using MvcWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace MvcWEB.Code
{
    public class CorrectAnswerHelper
    {
        public static decimal Calculate (UserAnswer answer)
        {
            int count = 0;
            decimal mark = 0;
            var correctAnswer = answer.CorrectAnswer;
            var userAnswer = answer.UAnswer;
            string[] correctString = correctAnswer.Split('.');
            string[] userString = userAnswer.Split('.');
            // calculate mark
            var i = 0;
            for (i = 0; i < correctString.Length; i++)
            {
                if (userString[i] == correctString[i])
                {
                    count++;
                }
                System.Diagnostics.Debug.WriteLine(userString[i] + "------->" + correctString[i]);
            }
            mark =  (decimal)count * 10 / correctString.Length;
            //end calculate
            // test
            System.Diagnostics.Debug.WriteLine("------Begin------");
            System.Diagnostics.Debug.WriteLine("correctAnswer: " + correctAnswer);
            System.Diagnostics.Debug.WriteLine("userAnswer: " + userAnswer);
            System.Diagnostics.Debug.WriteLine("mark: " + mark);
            System.Diagnostics.Debug.WriteLine("------End------");
            // end test
            return mark;
        }
        public static string GetCorrectAnswer(string DoiTuong)
        {
            var CorrectString = System.IO.File.ReadAllText(HostingEnvironment.MapPath(@"~/App_Data/HSQ/HSQ1.txt"));
            return CorrectString;
        }
        public static void Insert(KetQuaModel model)
        {
            var insert = new KetQuaKiemTraModel();
            insert.InsertResult(model.IDQN, model.KQ, model.XepLoai, model.DeSo, model.TraLoi, model.DapAn);
        }
    }
}