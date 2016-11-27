using MvcWEB.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace MvcWEB.Code
{
    public class CreateResultFile
    {
        public static void Action(ResultPageModel model, string path)
        {
            var userInfo = SessionHelper.GetInfo();
            string Sourcepath = path + "/" + model.ExamObj + ".cshtml";
            string ResultPath = path.Replace("Views","Views\\Result");
            string SavePath = ResultPath + "\\" + userInfo.ID + "_" + model.ExamObj+ ".cshtml";
            string CopyContent = File.ReadAllText(Sourcepath);
            // init file
            string beginFile = "@{\nLayout = \"~/Views/Shared/_MainLayout.cshtml\";\n} \n" +
                "@model MvcWEB.Models.ShowResultModel \n" +
                "<h1>" + userInfo.UserName + "</h1>\n" +
                "<h2>Result</h2> \n" +
                "<h3>Điểm: @Model.mark</h3> \n" +
                "<h3>Xếp loại: @Model.quality</h3> \n";

            string finalStr = beginFile;
            try
            {
                if (File.Exists(SavePath))
                {
                    File.Delete(SavePath);
                }
                using (FileStream fs = File.Create(SavePath))
                {
                }
                using (StreamWriter file = new StreamWriter(SavePath, false, Encoding.UTF8))
                {
                    string[] seperate = CopyContent.Split(new string[] { "<div class=\"question\">" }, StringSplitOptions.None);

                    //the number of array is from 0-100 (0 is the content before the first <div>, the needed contents is from 1 to 100)
                    var i = 1;

                    //int[] wrong = { 5, 9, 13, 22, 50 };
                    //string[] dapan = { "A", "C", "A", "D", "B" };
                    int[] wrong = model.WrongNumber;
                    string[] dapan = model.TrueAns;
                    int falseNumber = wrong.Length;
                    for (i = 0; i < falseNumber; i++)
                    {
                        // get the wrong answer number
                        var j = wrong[i];

                        string oldStr = "<div id=\"DapAn" + j + "\">";
                        string trueAns = oldStr + "<h2 class='false'><b>Đáp án : " + dapan[i] + "</b></h2>";

                        seperate[j] = seperate[j].Replace(oldStr, trueAns);
                        finalStr += ("<div class=\"question\">" + seperate[j]);      
                    }
                    file.WriteLine(finalStr);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //Console.ReadKey();
            }
        }
    }
}