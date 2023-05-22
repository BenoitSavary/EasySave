using EasySaveLib.Vue;
using EasySaveLib.Model;
using EasySaveLib.Service;
using EasySaveLib.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveLib.Controller
{
    public class CryptageController
    {
        public IShowCryptageVue Vue { get; set; }

        public Stockage Stockage { get; set; }

        public StockageLanguage stockLanguage { get; set; }

        public Services Services { get; set; }

        public CryptageController(StockageLanguage stockLanguage)
        {
            this.Stockage = Stockage;
            this.stockLanguage = stockLanguage;
            Services = new Services(Stockage, stockLanguage);
        }

        public void init()
        {
            Vue.ShowCryptage(stockLanguage);
        }

        public void EtatCryptage ()
        {

        }

        public void ShowCryptage(IShowCryptageVue vue)
        {
            CryptageController c = new CryptageController( stockLanguage);
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

        public void ShowMenu(IHomeVue vue)
        {
            HomeController c = new HomeController(vue, null, stockLanguage);
            c.Vue = vue;
            vue.setController(c);
            c.init();
        }
    }
}
