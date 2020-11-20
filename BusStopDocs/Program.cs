using System;
using System.IO;
using System.Diagnostics;
using System.Web;

//Icon:
//      Send Document by Antonio Vicién Faure from the Noun Project

namespace BusStopDocs
{
    class Program
    {
        static void Main(string[] args)
        {
            string argument = String.Join(" ", args);
            //Console.WriteLine(argument);
            string file = HttpUtility.UrlDecode(argument);
            if (System.Text.RegularExpressions.Regex.IsMatch(file, ".[.]exe [a-z]*", System.Text.RegularExpressions.RegexOptions.IgnoreCase))
            {
                file = file.Substring(file.IndexOf(":") + 1, file.Length - file.IndexOf(":") - 1).Replace("/", "\\");
                string exefile = file.Substring(0, file.IndexOf(".exe ") + 4);
                string exeargs = file.Substring(exefile.Length + 1, file.Length - exefile.Length - 1);
                new Process
                {
                    StartInfo = new ProcessStartInfo(exefile,exeargs)
                    {
                        UseShellExecute = true
                    }
                }.Start();
            }
            else
            {
                file = file.Split(":")[1].Replace("/", "\\");
                //Console.WriteLine(file);
                new Process
                {
                    StartInfo = new ProcessStartInfo(file)
                    {
                        UseShellExecute = true
                    }
                }.Start();
            }
        }
    }
}
