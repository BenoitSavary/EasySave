using EasySaveLib;
using EasySaveLib.Controller;
using EasySaveLib.Model;
using EasySaveLib.Vue;
using EasySaveLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasySaveLib.Model;

namespace EasySave
{
    internal class ShowJobSelectionVue : IShowJobSelectionVue
    {
        public ShowJobSelectionController Controller { get; set; }

        public void setController(object controller)
        {
            Controller = (ShowJobSelectionController)controller;
        }

        public void ShowJobsSelection(Save jobselected, String index)
        {
            Console.Clear();
            Console.WriteLine(Controller.stockLanguage.save + Controller.stockLanguage.edit + Controller.stockLanguage.delete + Controller.stockLanguage.back + Controller.stockLanguage.select);
            string choice = Console.ReadLine();

            switch(choice)
            {
                case "0":
                    Console.Clear();
                    Controller.ShowJobs(new ShowJobVue());
                    break;
                case "1":
                    Console.Clear();
                    Controller.ShowJobsStart(new ShowJobStartVue(),jobselected);
                    Controller.ShowJobs(new ShowJobVue());
                    break;
                case "2":
                    Console.Clear();
                    Controller.ShowJobsEdit(new ShowJobEditVue(), jobselected, index);
                    break;
                case "3":
                    Console.Clear();
                    Controller.ShowJobsRemove(new ShowJobRemoveVue(), index);
                    break;
                case "E":
                    Console.Clear();
                    Controller.ShowJobs(new ShowJobVue());
                    break;
            }
        }
    }
}
