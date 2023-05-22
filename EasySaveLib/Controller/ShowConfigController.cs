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
    public class ShowConfigController
    {
        public IShowConfigVue Vue { get; set; }

        public StockageLanguage stockLanguage { get; set; }

        public Stockage Stockage { get; set; }
        public Services Services { get; set; }

        public ShowConfigController(Stockage stockage,StockageLanguage stockLanguage)
        {
            this.stockLanguage = stockLanguage;
            this.Stockage = stockage;
            Services = new Services(stockage,stockLanguage);
        }

        public void init()
        {
            Vue.ShowConfig(stockLanguage);
        }

        public void ShowMenu(IHomeVue vue)
        {
            HomeController c = new HomeController(vue, Stockage, stockLanguage);
            c.Vue = vue;
            vue.setController(c);
            c.init();
        }

        public void ShowLanguage(IShowLangueVue vue)
        {
            LangueController c = new LangueController(Stockage,stockLanguage);
            c.Vue = vue;
            vue.setController(c);
            c.init();
        }

        public void ShowLog(IShowLogVue vue)
        {
            ShowLogController c = new ShowLogController(Stockage,stockLanguage);
            c.Vue = vue;
            vue.setController(c);
            c.init();
        }

        public void ShowExtensions(IShowExtensionsVue vue)
        {
            ShowExtensionsController c = new ShowExtensionsController(Stockage,stockLanguage);
            c.Vue = vue;
            vue.setController(c);
            c.init();
        }

        public void ShowProcess (IShowProcessVue vue)
        {
            ShowProcessController c = new ShowProcessController(Stockage,stockLanguage);
            c.Vue = vue;
            vue.setController(c);
            c.init();
        }

        public void ShowConfigFichier(IShowConfigFichier vue)
        {
            ShowConfigFichierController c = new ShowConfigFichierController(Stockage, stockLanguage);
            c.Vue = vue;
            vue.setController(c);
            c.init();
        }
    }
}
