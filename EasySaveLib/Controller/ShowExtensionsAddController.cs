using EasySaveLib.Model;
using EasySaveLib.Service;
using EasySaveLib.Vue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveLib.Controller
{
    public class ShowExtensionsAddController
    {
        public IShowExtensionsAddVue Vue { get; set; }

        public Stockage Stockage { get; set; }

        public StockageLanguage stockLanguage { get; set; }

        public Services Services { get; set; }

        public Ext Extensions { get; set; }

        public ShowExtensionsAddController(Stockage Stockage, StockageLanguage stockLanguage)
        {
            this.Stockage = Stockage;
            this.stockLanguage = stockLanguage;
            Services = new Services(Stockage, stockLanguage);

            this.Extensions = new Ext(Stockage);
        }

        public void init()
        {
            string extension = Vue.ShowExtensionAdd();
            /*Extensions.GetExtensions(new extension() { Name = extension});*/
            Vue.ReturnMenu();
        }
        public void ShowConfigExtensions(IShowExtensionsVue vue)
        {
            ShowExtensionsController c = new ShowExtensionsController(Stockage, stockLanguage);
            c.Vue = vue;
            vue.setController(c);
            c.init();
        }
    }
}
