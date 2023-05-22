using EasySaveLib.Vue;
using EasySaveLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveLib.Controller
{
    public class ShowJobSelectionController
    {
        public IShowJobSelectionVue Vue { get; set; }

        public Stockage Stockage { get; set; }

        public StockageLanguage stockLanguage { get; set; }

        public Services Services { get; set; }

        public ShowJobSelectionController(Stockage Stockage, StockageLanguage stockLanguage)
        {
            this.Stockage= Stockage;
            this.stockLanguage= stockLanguage;
            Services = new Services(Stockage, stockLanguage);
        }

        public void init(Save jobselected,String index)
        {
            Vue.ShowJobsSelection(jobselected, index);
        }

        public void ShowJobs(IShowJobVue vue)
        {
            ShowJobController c = new ShowJobController(Stockage, stockLanguage);
            c.Vue = vue;
            vue.setController(c);
            c.init();
        }

        public void ShowMenu(IHomeVue vue)
        {
            HomeController c = new HomeController(vue,Stockage, stockLanguage);
            c.Vue = vue;
            vue.setController(c);
            c.init();
        }
        public void ShowJobsStart(IShowJobStartVue vue, Save jobselected)
        {
            ShowJobStartController c = new ShowJobStartController(Stockage);
            c.Vue = vue;
            vue.setController(c);
            c.init(jobselected);
        }

        public void ShowJobsRemove(IShowJobRemoveVue vue,String jobselected)
        {
            ShowJobRemoveController c = new ShowJobRemoveController(Stockage, stockLanguage);
            c.Vue = vue;
            vue.setController(c);
            Stockage.NumberOfJob++;
            c.init(jobselected);
        }

        public void ShowJobsEdit(IShowJobEditVue vue, Save jobselected , String index)
        {
            ShowJobEditController c = new ShowJobEditController(Stockage, stockLanguage);
            c.Vue = vue;
            vue.setController(c);
            c.init(jobselected,index);
        }
        
    }
}
