using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveLib.Vue
{
    public interface IShowJobEditVue : IVue
    {
        string[] ShowJobsEdit();
        public void ReturnMenu();
        
    }
}
