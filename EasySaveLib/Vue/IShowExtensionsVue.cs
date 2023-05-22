using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveLib.Vue
{
    public interface IShowExtensionsVue : IVue
    {
        public void ShowExtensions();
        public string WriteExtension();
        public void ReturnMenu();
    }
}
