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
            Console.WriteLine(argument);
            string file = HttpUtility.UrlDecode(argument.Split(":")[1].Replace("/", "\\"));
            Console.WriteLine(file);



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
