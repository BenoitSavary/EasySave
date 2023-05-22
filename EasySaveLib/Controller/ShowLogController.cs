using EasySaveLib.Vue;
using EasySaveLib.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveLib.Controller
{
    public class ShowLogController
    {
        public IShowLogVue Vue { get; set; }

        public StockageLanguage stockLanguage { get; set; }

        public Stockage stockage { get; set; }

        public ShowLogController(Stockage stockage,StockageLanguage stockLanguage)
        {
            this.stockLanguage = stockLanguage;
            this.stockage = stockage;
        }

        public void init()
        {
            Vue.ShowLog(stockLanguage);
        }

        public void ShowConfig(IShowConfigVue vue)
        {
            ShowConfigController c = new ShowConfigController(stockage,stockLanguage);
            c.Vue = vue;
            vue.setController(c);
            c.init();
        }
        public void ShowMenu(IHomeVue vue)
        {
            HomeController c = new HomeController(vue, null, stockLanguage);
            c.Vue = vue;
            vue.setController(c);
            c.init();
        }

        public void ChoiceFormatLog(int numformat)
        {
           // dynamic choiceformatlog;
            string formatlog;

            switch (numformat)
            {
                case 1:
                  //  choiceformatlog = stockLanguage.data.FR;
                    formatlog = "JSON";
                  //  stockLanguage.lang = choiceformatlog;
                    stockLanguage.EcritureEtatLog(formatlog);
                   // stockLanguage.ChangeLanguage();
                    break;
                case 2:
                    //choiceformatlog = stockLanguage.data.EN;
                    formatlog = "XML";
                  //  stockLanguage.lang = choiceformatlog;
                    stockLanguage.EcritureEtatLog(formatlog);
                  //  stockLanguage.ChangeLanguage();
                    break;
                default:
                    break;
            }
        }
    }
}
