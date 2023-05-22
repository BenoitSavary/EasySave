using EasySaveLib.Controller;
using EasySaveLib.Vue;
using EasySaveLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySave
{
    public class ShowProcessSelectionVue : IShowProcessSelectionVue
    {

        public ShowProcessSelectionController Controller { get; set; }
        public void setController(object controller)
        {
            Controller = (ShowProcessSelectionController)controller;

        }

        public void ShowProcessSelection(String index)
        {
            Console.Clear();
            Console.WriteLine(Controller.stockLanguage.process_select1+index+Controller.stockLanguage.process_select2);
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "0":
                    Console.Clear();
                    Controller.ShowProcessRemove(new ShowProcessRemoveVue(), index);
                    break;
                case "1":
                    Console.Clear();
                    break;
                case "2":
                    Console.Clear();
                    break;
                case "3":
                    Console.Clear();
                    break;
                case "E":
                    Console.Clear();
                    ReturnMenu();
                    break;
            }
        }
        public void ReturnMenu()
        {
            Console.Clear();
            Controller.ShowProcess(new ShowProcessVue());
        }
    }
}
