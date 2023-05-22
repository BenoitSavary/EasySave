using EasySaveLib;
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
    internal class ShowConfigFichierVue : IShowConfigFichier
    {
        public ShowConfigFichierController Controller { get; set; }

        public void setController(object controller)
        {
           Controller = (ShowConfigFichierController)controller;
        }
        public void ShowConfigFichier(StockageLanguage stockageLanguage)
        {
            Console.WriteLine(Controller.stockLanguage.prio_file + Controller.stockLanguage.ext1 + Controller.stockLanguage.ext2 + Controller.stockLanguage.ext3 + Controller.stockLanguage.ext4 + Controller.stockLanguage.ext5 + Controller.stockLanguage.ext6 + Controller.stockLanguage.ext7 + Controller.stockLanguage.ext8 + Controller.stockLanguage.back + Controller.stockLanguage.select);
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Clear();
                    break;
                case "2":
                    Console.Clear();
                    break;
                case "3":
                    Console.Clear();
                    break;
                case "4":
                    Console.Clear();
                    break;
                case "5":
                    Console.Clear();
                    break;
                case "6":
                    Console.Clear();
                    break;
                case "7":
                    Console.Clear();
                    break;
                case "8":
                    Console.Clear();
                    break;
                case "E":
                    Console.Clear();
                    Controller.ShowConfig(new ShowConfigVue());
                    break;
                default:
                    Console.Clear();
                    ShowConfigFichier(stockageLanguage);
                    break;
            }
        }
    }
}
