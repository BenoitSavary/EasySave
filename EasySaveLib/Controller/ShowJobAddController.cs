using EasySaveLib.Vue;
using EasySaveLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveLib.Controller
{
    public class ShowJobAddController
    {
        public IShowJobAddVue Vue { get; set; }

        public Stockage Stockage { get; set; }

        public StockageLanguage stockLanguage { get; set; }

        public Services Services { get; set; }

        public ShowJobAddController(Stockage Stockage , StockageLanguage stockLanguage)
        {
            this.Stockage = Stockage;
            this.stockLanguage = stockLanguage;
            Services = new Services(Stockage, stockLanguage);
        }

        public void init()
        {
            string[] job = Vue.ShowJobsAdd();
            
            Services.CreateJob(""+Stockage.NumberOfJob, job[0], job[1], job[2], job[3]);
            Vue.ReturnMenu();
        }
        public void ShowJobs(IShowJobVue vue)
        {
            ShowJobController c = new ShowJobController(Stockage, stockLanguage);
            c.Vue = vue;
            vue.setController(c);
            c.init();
        }

        public String Type(String choice )
        {
            string type = "";
            if (choice == "Differentielle") { type = "Differentielle"; }
            if (choice == "Complete") { type = "Complete"; }
            return type;
        }

    }
}
