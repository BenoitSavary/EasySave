using EasySaveLib.Vue;
using EasySaveLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveLib.Controller
{
    public class ShowJobRemoveController
    {
        public IShowJobRemoveVue Vue { get; set; }

        public Stockage Stockage { get; set; }

        public Services Services { get; set; }

        public StockageLanguage stockLanguage { get; set; }

        public ShowJobRemoveController(Stockage Stockage, StockageLanguage stockLanguage)
        {
            this.Stockage = Stockage;
            this.stockLanguage = stockLanguage;
            Services = new Services(Stockage, stockLanguage);
        }
        public void init(String index)
        {
            Services.DeleteJob(index);
            Stockage.NumberOfJob--;
            Vue.ReturnMenu();
        }
        public void ShowJobs(IShowJobVue vue)
        {
            ShowJobController c = new ShowJobController(Stockage, stockLanguage);
            c.Vue = vue;
            vue.setController(c);
            c.init();
        }
    }
}
