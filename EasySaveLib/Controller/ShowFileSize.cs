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
    public class ShowFileSizeController
    {
        public IShowFileSizeVue Vue { get; set; }

        public StockageLanguage stockLanguage { get; set; }

        public Stockage stockage { get; set; }
        public Services services { get; set; }

        public ShowFileSizeController(Stockage stockage,StockageLanguage stockLanguage)
        {
            this.stockLanguage = stockLanguage;
            this.stockage = stockage;
            services = new Services(stockage, stockLanguage);
        }

        public void init()
        {
 
        }

        public void ShowConfig(IShowConfigVue vue)
        {
            ShowConfigController c = new ShowConfigController(stockage,stockLanguage);
            c.Vue = vue;
            vue.setController(c);
            c.init();
        }

    }
}
