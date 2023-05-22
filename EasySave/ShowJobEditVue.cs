using EasySaveLib.Controller;
using EasySaveLib.Vue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EasySave
{
    internal class ShowJobEditVue : IShowJobEditVue
    {
        public ShowJobEditController Controller { get; set; }
        public void setController(object controller)
        {
            Controller = (ShowJobEditController)controller;
        }
        public void ReturnMenu()
        {
            Console.Clear();
            Controller.ShowJobs(new ShowJobVue());
        }

        public string[] ShowJobsEdit()
        {
            string[] choice = new string[4];

            Console.WriteLine(Controller.stockLanguage.name_job);
            choice[0] = Console.ReadLine();


            Console.WriteLine(Controller.stockLanguage.file_src);
            choice[1] = Console.ReadLine();

            while (!Regex.IsMatch(choice[1], @"^(?<ParentPath>(?:[a-zA-Z]\:|\\\\[\w\s\.]+\\[\w\s\.$]+)\\(?:[\w\s\.]+\\)*)(?<BaseName>[\w\s\.]*?)$"))  //Regex for valid windows folder path.
            {
                Console.WriteLine(Controller.stockLanguage.validpath);
                choice[1] = Console.ReadLine();
            }

            Console.WriteLine(Controller.stockLanguage.destination);
            choice[2] = Console.ReadLine();

            while (!Regex.IsMatch(choice[2], @"^(?<ParentPath>(?:[a-zA-Z]\:|\\\\[\w\s\.]+\\[\w\s\.$]+)\\(?:[\w\s\.]+\\)*)(?<BaseName>[\w\s\.]*?)$"))  //Regex for valid windows folder path.
            {
                Console.WriteLine(Controller.stockLanguage.validpath);
                choice[2] = Console.ReadLine();
            }

            Console.WriteLine(Controller.stockLanguage.jobtype);
            choice[3] = Controller.Type(Console.ReadLine());

            while ((String.Compare(choice[3], "1") & String.Compare(choice[3], "2")) != 1)
            {
                Console.WriteLine(Controller.stockLanguage.validnumber);
                choice[3] = Controller.Type(Console.ReadLine());
            }
            return choice;
        }
    }
}
