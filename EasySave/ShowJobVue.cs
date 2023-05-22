using EasySaveLib;
using EasySaveLib.Controller;
using EasySaveLib.Model;
using EasySaveLib.Vue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasySaveLib.Model;

namespace EasySave
{
    internal class ShowJobVue : IShowJobVue
    {
        public ShowJobController Controller { get; set; }

        public void setController(object controller)
        {
            Controller = (ShowJobController)controller;
        }

        public void ShowJobs(List<Save> jobs)
        {
            int i = 0;
            foreach (var job in jobs)
            {
                i++;
                Console.WriteLine(i + ". " + job.Name);

            }

            Console.WriteLine(Controller.stockLanguage.create_save + Controller.stockLanguage.run_all_save + Controller.stockLanguage.back + Controller.stockLanguage.select);
            string choice = Console.ReadLine();



            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Controller.ShowJobsSelection(new ShowJobSelectionVue(), choice);
                    break;
                case "2":
                    Console.Clear();
                    Controller.ShowJobsSelection(new ShowJobSelectionVue(), choice);
                    break;
                case "3":
                    Console.Clear();
                    Controller.ShowJobsSelection(new ShowJobSelectionVue(), choice);
                    break;
                case "4":
                    Console.Clear();
                    Controller.ShowJobsSelection(new ShowJobSelectionVue(), choice);
                    break;
                case "5":
                    Console.Clear();
                    Controller.ShowJobsSelection(new ShowJobSelectionVue(), choice);
                    break;
                case "C":
                    Console.Clear();
                    Controller.ShowJobsAdd(new ShowJobAddVue());
                    break;
                case "A":
                    Console.Clear();
                    Console.WriteLine(Controller.stockLanguage.fonct);
                    ShowJobs(jobs);
                    break;
                case "E":
                    Controller.ShowMenu(new HomeVue());
                    break;
                default:
                    Console.Clear();
                    Controller.ShowJobsSelection(new ShowJobSelectionVue(), "" + choice);
                    break;
            }
        }
    }
}
