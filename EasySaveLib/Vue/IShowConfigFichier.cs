using EasySaveLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveLib.Vue
{
    public interface IShowConfigFichier : IVue
    {
        public void ShowConfigFichier(StockageLanguage stockageLanguage);
    }
}
