using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveLib.Vue
{
    public interface IShowJobAddVue : IVue
    {
        public string[] ShowJobsAdd();
        public void ReturnMenu();
    }
}
