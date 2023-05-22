using EasySaveLib.Vue;
using EasySaveLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EasySaveLib.Controller
{
    public class ShowProcessController
    {
        public IShowProcessVue Vue { get; set; }

        public Stockage Stockage { get; set; }

        public StockageLanguage stockLanguage { get; set; }

        public Services Services { get; set; }

        public SoftwarePackage SoftwarePackages { get; set; }

        public ShowProcessController(Stockage Stockage, StockageLanguage stockLanguage)
        {
            this.Stockage = Stockage;
            this.stockLanguage = stockLanguage;
            Services = new Services(Stockage, stockLanguage);
            this.SoftwarePackages = new SoftwarePackage(Stockage);
        }

        public void init()
        {
            SoftwarePackages.WriteProcess();
            Vue.ShowProcess();
            //
            Services.serialString();
            Vue.ReturnMenu();
        }
        public void ShowProcessAdd(IShowProcessAddVue vue)
        {
            ShowProcessAddController c = new ShowProcessAddController(Stockage, stockLanguage);
            c.Vue = vue;
            vue.setController(c);
            c.init();
        }
        public void ShowMenu(IShowConfigVue vue)
        {
            ShowConfigController c = new ShowConfigController(Stockage, stockLanguage);
            c.Vue = vue;
            vue.setController(c);
            c.init();
        }
        public void ShowProcessSelection(IShowProcessSelectionVue vue, string jobselected)
        {
            ShowProcessSelectionController c = new ShowProcessSelectionController(Stockage, stockLanguage);
            c.Vue = vue;
            vue.setController(c);
            
                c.init(jobselected);
            
        }
    }
}
