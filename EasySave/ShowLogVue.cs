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
    internal class ShowLogVue : IShowLogVue
    {
        public ShowLogController Controller { get; set; }

        public void setController(object controller)
        {
            Controller = (ShowLogController)controller;
        }

        public void ShowLog (StockageLanguage stockageLanguage)
        {
            Console.WriteLine(Controller.stockLanguage.log_JSON + Controller.stockLanguage.log_XML + Controller.stockLanguage.back + Controller.stockLanguage.select);
            string choice = Console.ReadLine();
            int choiceformatlog;
            switch (choice)
            {
                case "1":
                    Console.Clear();
                    choiceformatlog = 1;
                    Controller.ChoiceFormatLog(choiceformatlog);
                    Controller.ShowMenu(new HomeVue());
                    break;
                case "2":
                    Console.Clear();
                    choiceformatlog = 2;
                    Controller.ChoiceFormatLog(choiceformatlog);
                    Controller.ShowMenu(new HomeVue());
                    break;
                case "E":
                    Console.Clear();
                    Controller.ShowConfig(new ShowConfigVue());
                    break;
                default:
                    Console.Clear();
                    ShowLog(stockageLanguage);
                    break;
            }
        }
    }
}
