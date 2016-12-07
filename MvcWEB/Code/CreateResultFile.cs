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
            string beginFile = "@{\nLayout = \"~/Views/Shared/_ResultLayout.cshtml\";\n} \n" +
                "@model MvcWEB.Models.ShowResultModel \n" +
                "<div class=\"info\">" +
                "<h1>" + userInfo.UserName + "</h1>\n" +
                "<h3>Điểm: <h2>@Model.mark</h2></h3> \n" +
                "<h3>Xếp loại: <h2>@Model.quality</h2></h3> \n" +
                "</div>\n" +
                "<div class=\"wrongAns\">\n" +
                "<h1>Các câu trả lời sai:</h1>\n";

            string finalStr = beginFile;
            try
            {
                if (File.Exists(SavePath))
                {
                    File.Delete(SavePath);
                }
                // check result folder exist
                if (Directory.Exists(ResultPath))
                {
                    //File.Delete(SavePath);
                }
                else
                {
                    Directory.CreateDirectory(ResultPath);
                }
                //end check

                using (FileStream fs = File.Create(SavePath))
                {
                }
                using (StreamWriter file = new StreamWriter(SavePath, false, Encoding.UTF8))
                {
                    string[] seperate = CopyContent.Split(new string[] { "<div class=\"question\">" }, StringSplitOptions.None);

                    //the number of array is from 0-100 (0 is the content before the first <div>, the needed contents is from 1 to 100)
                    var i = 1;

                    int[] wrong = model.WrongNumber;
                    string[] dapan = model.TrueAns;
                    int falseNumber = wrong.Length;
                    for (i = 0; i < falseNumber; i++)
                    {
                        // get the wrong answer number
                        var j = wrong[i];

                        string oldStr = "<div id=\"DapAn" + j + "\">";
                        string trueAns = oldStr + "<h2 class='false'><b>Đáp án : " + dapan[i] + "</b></h2>";
                        string oldClass = "checkBox";
                        string newClass = "checkBox invisible";

                        seperate[j] = seperate[j].Replace(oldStr, trueAns);
                        seperate[j] = seperate[j].Replace(oldClass, newClass);
                        finalStr += ("<div class=\"question\">" + seperate[j]);      
                    }
                    finalStr += "</div>";
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