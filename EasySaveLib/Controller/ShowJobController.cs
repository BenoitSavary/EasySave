using EasySaveLib.Vue;
using EasySaveLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveLib.Controller
{
    public class ShowJobController
    {
        public IShowJobVue Vue { get; set; }

        public Stockage Stockage { get; set; }

        public StockageLanguage stockLanguage { get; set; }

        public Services Services { get; set; }

        public ShowJobController(Stockage Stockage, StockageLanguage stockLanguage)
        {
            this.Stockage = Stockage;
            this.stockLanguage= stockLanguage;
            Services = new Services(Stockage, stockLanguage);
        }

        public void init()
        {
            Vue.ShowJobs(Stockage.JobList);
        }
        public void ShowJobsAdd(IShowJobAddVue vue)
        {
            ShowJobAddController c = new ShowJobAddController(Stockage, stockLanguage);
            c.Vue = vue;
            vue.setController(c);
            Stockage.NumberOfJob++;
            c.init();
        }

        public void ShowMenu(IHomeVue vue)
        {
            HomeController c = new HomeController(vue,Stockage, stockLanguage);
            c.Vue = vue;
            vue.setController(c);
            c.init();
        }
        public void ShowJobsSelection(IShowJobSelectionVue vue, string jobselected)
        {
            ShowJobSelectionController c = new ShowJobSelectionController(Stockage, stockLanguage);
            c.Vue = vue;
            vue.setController(c);
            Save saveselected = Services.GetSave(jobselected);
            c.init(saveselected,jobselected);
        }
        



    }
}
