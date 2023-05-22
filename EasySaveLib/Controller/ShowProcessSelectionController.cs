using EasySaveLib.Vue;
using EasySaveLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveLib.Controller
{
    public class ShowProcessSelectionController
    {
        public IShowProcessSelectionVue Vue { get; set; }

        public Stockage Stockage { get; set; }

        public StockageLanguage stockLanguage { get; set; }

        public ShowProcessSelectionController (Stockage Stockage, StockageLanguage stockLanguage)
        {
            this.Stockage = Stockage;
            this.stockLanguage = stockLanguage;
        }

        public void init(String index)
        {
            Vue.ShowProcessSelection(index);
        }
        public void ShowProcessRemove(IShowProcessRemoveVue vue, String jobselected)
        {
            ShowProcessRemoveController c = new ShowProcessRemoveController(Stockage, stockLanguage);
            c.Vue = vue;
            vue.setController(c);
            c.init(jobselected);
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
