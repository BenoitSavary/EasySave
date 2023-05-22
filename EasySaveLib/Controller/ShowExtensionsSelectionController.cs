using EasySaveLib.Model;
using EasySaveLib.Vue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveLib.Controller
{
    public class ShowExtensionsSelectionController
    {
        public IShowExtensionsSelectionVue Vue { get; set; }

        public Stockage Stockage { get; set; }

        public StockageLanguage stockLanguage { get; set; }

        public ShowExtensionsSelectionController(Stockage Stockage, StockageLanguage stockLanguage)
        {
            this.Stockage = Stockage;
            this.stockLanguage = stockLanguage;
        }

        public void init(String index)
        {
            if (int.Parse(index)<=Stockage.ListOfExtensions.Count & index!="0") { 
            Vue.ShowExtensionsSelection(index);
            }else
            { 
                    }
        }
        public void ShowExtensionsRemove(IShowExtensionsRemoveVue vue, String jobselected)
        {
            ShowExtensionsRemoveController c = new ShowExtensionsRemoveController(Stockage, stockLanguage);
            c.Vue = vue;
            vue.setController(c);
            c.init(jobselected);
        }
        public void ShowExtensions(IShowExtensionsVue vue)
        {
            ShowExtensionsController c = new ShowExtensionsController(Stockage, stockLanguage);
            c.Vue = vue;
            vue.setController(c);
            c.init();
        }
    }
}
