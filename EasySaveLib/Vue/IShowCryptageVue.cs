using System;
using System.Collections.Generic;
using EasySaveLib.Model;
using EasySaveLib.Service;
using EasySaveLib.Controller;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveLib.Vue
{
    public interface IShowCryptageVue : IVue
    {
        void ShowCryptage(StockageLanguage stockageLanguage);
    }
}
