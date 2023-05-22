using EasySaveLib.Vue;
using EasySaveLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveLib.Controller
{
    public class ShowJobStartController
    {
        public IShowJobStartVue Vue { get; set; }

        public Stockage Stockage { get; set; }

        public Services Services { get; set; }
        public SoftwarePackage SoftwarePackage { get; set; }

        public StockageLanguage stockLanguage { get; set; }
        public ShowJobStartController(Stockage Stockage)
        {
            this.Stockage = Stockage;
            Services = new Services(Stockage,stockLanguage);
            SoftwarePackage = new SoftwarePackage(Stockage, stockLanguage);
        }

        public void init(Save jobselected)
        {
            if (!SoftwarePackage.checkprocess())
            {
                Services.copy(jobselected);
            }
        }
    }
}
