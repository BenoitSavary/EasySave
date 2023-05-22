using EasySaveLib.Vue;
using EasySaveLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveLib.Controller
{
    public class ShowProcessRemoveController
    {
        public IShowProcessRemoveVue Vue { get; set; }

        public Stockage Stockage { get; set; }

        public Services Services { get; set; }

        public StockageLanguage stockLanguage { get; set; }
        public SoftwarePackage SoftwarePackage { get; set; }

        public ShowProcessRemoveController(Stockage Stockage, StockageLanguage stockLanguage)
        {
            this.Stockage = Stockage;
            this.stockLanguage = stockLanguage;
            Services = new Services(Stockage, stockLanguage);
            this.SoftwarePackage= new SoftwarePackage(Stockage);
        }
        public void init(String index)
        {
            SoftwarePackage.RemoveProcess(index);
            Vue.ReturnMenu();
        }
        public void ShowProcess(IShowProcessVue vue)
        {
            ShowProcessController c = new ShowProcessController(Stockage, stockLanguage);
            c.Vue = vue;
            vue.setController(c);
            c.init();
        }
    }
}
