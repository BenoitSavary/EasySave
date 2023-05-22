using EasySave;
using EasySaveLib.Vue;
using System;
using System.Text.RegularExpressions;

namespace EasySaveLib
{
    public class HomeVue : IHomeVue
    {
        
        public HomeVue()
        {
        }

        public HomeController Controller { get; set; }
        public void setController(object controller)
        {
            Controller = (HomeController)controller;
        }


        public void showMenu()
        {
            Console.Clear();
            Console.WriteLine(Controller.stockLanguage.home + Controller.stockLanguage.save_menu + Controller.stockLanguage.config_menu + Controller.stockLanguage.exit + Controller.stockLanguage.select);
            /*SoftwarePackage soft = new SoftwarePackage();
            soft.GetProcess();*/
            string choice = Console.ReadLine();

            
            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Controller.ShowJobs(new ShowJobVue());
                    break;
                case "2":
                    Console.Clear();
                    Controller.ShowConfig(new ShowConfigVue());
                    break;
                case "3":
                    Console.Clear();
                    Controller.ServerStart();
                    showMenu();
                    break;
                case "9":
                    Console.WriteLine(Controller.stockLanguage.bye);
                    break;
                default:
                    showMenu();
                    break;
            }

        }
    }
    }