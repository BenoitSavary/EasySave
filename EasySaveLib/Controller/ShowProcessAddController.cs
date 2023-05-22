using EasySaveLib.Vue;
using EasySaveLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveLib.Controller
{
    public class ShowProcessAddController
    {
        public IShowProcessAddVue Vue { get; set; }

        public Stockage Stockage { get; set; }

        public StockageLanguage stockLanguage { get; set; }

        public Services Services { get; set; }

        public SoftwarePackage SoftwarePackages { get; set; }

        public ShowProcessAddController(Stockage Stockage, StockageLanguage stockLanguage)
        {
            this.Stockage = Stockage;
            this.stockLanguage = stockLanguage;
            Services = new Services(Stockage, stockLanguage);

            this.SoftwarePackages = new SoftwarePackage(Stockage);
        }

        public void init()
        {
            string process = Vue.ShowProcessAdd();
            SoftwarePackages.GetProcess(process);
            Vue.ReturnMenu();
        }
        public void ShowConfigProcess(IShowProcessVue vue)
        {
            ShowProcessController c = new ShowProcessController(Stockage, stockLanguage);
            c.Vue = vue;
            vue.setController(c);
            c.init();
        }
    }
}
