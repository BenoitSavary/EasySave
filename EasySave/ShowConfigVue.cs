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

namespace EasySave
{
    internal class ShowConfigVue : IShowConfigVue
    {
        public ShowConfigController Controller { get; set; }

        public void setController(object controller)
        {
            Controller = (ShowConfigController)controller;
        }

        public void ShowConfig (StockageLanguage stockageLanguage)
        {
            Console.WriteLine(Controller.stockLanguage.config_lang + Controller.stockLanguage.config_log + Controller.stockLanguage.config_process + "4. extensions à crypter\n"+Controller.stockLanguage.back + Controller.stockLanguage.select);
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Controller.ShowLanguage(new ShowLanguageVue());
                    break;
                case "2":
                    Console.Clear();
                    Controller.ShowLog(new ShowLogVue());
                    break;
                case "3":
                    Console.Clear();
                    Controller.ShowProcess(new ShowProcessVue());
                    break;
                case "4":
                    Console.Clear();
                    Controller.ShowConfigFichier(new ShowConfigFichierVue());
                    break;
                case "5":
                    Console.Clear();
                    Controller.ShowExtensions(new ShowExtensionsVue());
                    break;
                case "E":
                    Console.Clear();
                    Controller.ShowMenu(new HomeVue());
                    break;
                default:
                    Console.Clear();
                    ShowConfig(stockageLanguage);
                    break;
            }
        }
    }
}
