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
    public class ShowConfigFichierController
    {
        public IShowConfigFichier Vue { get; set; }

        public StockageLanguage stockLanguage { get; set; }

        public Stockage Stockage { get; set; }

        public ShowConfigFichierController(Stockage stockage,StockageLanguage stockLanguage)
        {
            this.stockLanguage = stockLanguage;
            this.Stockage = stockage;
        }

        public void init()
        {
            Vue.ShowConfigFichier(stockLanguage);
        }

        public void ShowMenu(IHomeVue vue)
        {
            HomeController c = new HomeController(vue, null, stockLanguage);
            c.Vue = vue;
            vue.setController(c);
            c.init();
        }
        public void ShowConfig(IShowConfigVue vue)
        {
            ShowConfigController c = new ShowConfigController(Stockage, stockLanguage);
            c.Vue = vue;
            vue.setController(c);
            c.init();
        }



    }

}

