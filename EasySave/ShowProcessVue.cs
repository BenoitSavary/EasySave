using EasySaveLib;
using EasySaveLib.Controller;
using EasySaveLib.Vue;
using EasySaveLib.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySave
{
    public class ShowProcessVue : IShowProcessVue
    {
        public ShowProcessController Controller { get; set; }

        public void setController(object controller)
        {
            Controller = (ShowProcessController)controller;
        }

        public void ShowProcess()
        {
            Console.WriteLine(Controller.stockLanguage.process_vue1+Controller.stockLanguage.process_vue2);

            
            string process = WriteProcess();
            switch (process)
            {
                case "C":
                    Console.Clear();
                    Controller.ShowProcessAdd(new ShowProcessAddVue());
                    break;
                case "E":
                    ReturnMenu();
                    break;

                default:
                    Console.Clear();
                    Controller.ShowProcessSelection(new ShowProcessSelectionVue(), process);
                    break;
            }

        }

        public string WriteProcess() 
        {
            return Console.ReadLine();
        }
        public void ReturnMenu()
        {
            Console.Clear();
            Controller.ShowMenu(new ShowConfigVue());
        }
    }
}
