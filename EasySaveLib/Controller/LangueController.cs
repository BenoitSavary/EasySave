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
    public class LangueController
    {
        public IShowLangueVue Vue { get; set; }

        public StockageLanguage stockLanguage { get; set; }

        public Stockage stockage { get; set; }

        public LangueController(Stockage stockage,StockageLanguage stockLanguage)
        {
            this.stockLanguage = stockLanguage;
            this.stockage= stockage;
        }

        public void init()
        {
            Vue.ShowLangue(stockLanguage);
        }

        public void ShowMenu(IHomeVue vue)
        {
            HomeController c = new HomeController(vue,null,stockLanguage);
            c.Vue = vue;
            vue.setController(c);
            c.init();
        }
        public void ShowConfig(IShowConfigVue vue)
        {
            ShowConfigController c = new ShowConfigController(stockage,stockLanguage);
            c.Vue = vue;
            vue.setController(c);
            c.init();
        }

        // Call EcritureEtatLangue to write etatlangue (ISO 3166-1 codes)
        // Call ChangeLanguage to update the language with choicelangage
        public void ChoiceLanguage(int numlangage)
        {
            dynamic choicelangage;
            string etatlangue;

            switch (numlangage)
            {
                case 1:
                    choicelangage = stockLanguage.data.FR;
                    etatlangue = "FR";
                    stockLanguage.lang = choicelangage;
                    stockLanguage.EcritureEtatLangue(etatlangue);
                    stockLanguage.ChangeLanguage();
                    break;
                case 2:
                    choicelangage = stockLanguage.data.EN;
                    etatlangue = "EN";
                    stockLanguage.lang = choicelangage;
                    stockLanguage.EcritureEtatLangue(etatlangue);
                    stockLanguage.ChangeLanguage();
                    break;
                case 3:
                    choicelangage = stockLanguage.data.ES;
                    etatlangue = "ES";
                    stockLanguage.lang = choicelangage;
                    stockLanguage.EcritureEtatLangue(etatlangue);
                    stockLanguage.ChangeLanguage();
                    break;
                case 4:
                    choicelangage = stockLanguage.data.CH;
                    etatlangue = "CH";
                    stockLanguage.lang = choicelangage;
                    stockLanguage.EcritureEtatLangue(etatlangue);
                    stockLanguage.ChangeLanguage();
                    break;
                default:
                    break;
            }          
        }
    }
}
