using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveLib.Vue
{
    public interface IShowProcessVue : IVue
    {
        public void ShowProcess();
        public string WriteProcess();

        public void ReturnMenu();
    }
}
