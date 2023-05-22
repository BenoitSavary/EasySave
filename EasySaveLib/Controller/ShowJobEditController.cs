using EasySaveLib.Vue;
using EasySaveLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveLib.Controller
{
    public class ShowJobEditController
    {
        public IShowJobEditVue Vue { get; set; }

        public Stockage Stockage { get; set; }

        public StockageLanguage stockLanguage { get; set; }

        public Services Services { get; set; }

        public ShowJobEditController(Stockage Stockage, StockageLanguage stockLanguage)
        {
            this.Stockage = Stockage;
            Services = new Services(Stockage,stockLanguage);
            this.stockLanguage = stockLanguage;
        }

        public void init(Save save,String index)
        {
            string[] job = Vue.ShowJobsEdit();
            Services.EditJob(job,index);
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
        public String Type(String choice)
        {
            string type = "";
            if (choice == "Differentielle") { type = "diff"; }
            if (choice == "Complete") { type = "comp"; }
            return type;
        }
    }
}
