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
    internal class ShowLanguageVue : IShowLangueVue
    {
        public LangueController Controller { get; set; }

        public void setController(object controller)
        {
            Controller = (LangueController)controller;
        }

        // ShowMenu after choosing the language 
        // Take the choice of the language
        public void ShowLangue (StockageLanguage stockageLanguage)
        {
            Console.WriteLine(Controller.stockLanguage.select_language + Controller.stockLanguage.lang_1 + Controller.stockLanguage.lang_2 + Controller.stockLanguage.lang_3 + Controller.stockLanguage.back);
            string choice = Console.ReadLine();
            int choiceLang;
            switch (choice)
            {
                case "1":
                    choiceLang = 1;
                    Controller.ChoiceLanguage(choiceLang);
                    Controller.ShowMenu(new HomeVue());
                    break;
                case "2":
                    choiceLang = 2;
                    Controller.ChoiceLanguage(choiceLang);
                    Controller.ShowMenu(new HomeVue());
                    break;
                case "3":
                    choiceLang = 3;
                    Controller.ChoiceLanguage(choiceLang);
                    Controller.ShowMenu(new HomeVue());
                    break;
/*                case "4":
                    choiceLang = 4;
                    Controller.ChoiceLanguage(choiceLang);
                    Controller.ShowMenu(new HomeVue());
                    break;*/
                case "E":
                    Console.Clear();
                    Controller.ShowConfig(new ShowConfigVue());
                    break;
                default:
                    Console.Clear();
                    ShowLangue(stockageLanguage);
                    break;
            }
        }
    }
}
