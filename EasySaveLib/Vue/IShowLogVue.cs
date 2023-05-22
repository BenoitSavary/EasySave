using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasySaveLib.Model;

namespace EasySaveLib.Vue
{
    public interface IShowLogVue : IVue
    {
        public void ShowLog(StockageLanguage stockageLanguage);
    }
}
