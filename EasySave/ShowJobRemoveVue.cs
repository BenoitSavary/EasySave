using EasySaveLib.Controller;
using EasySaveLib.Vue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySave
{
    internal class ShowJobRemoveVue : IShowJobRemoveVue
    {
        public ShowJobRemoveController Controller { get; set; }
        public void setController(object controller)
        {
            Controller = (ShowJobRemoveController)controller;
        }

        public void ReturnMenu()
        {
            Console.Clear();
            Controller.ShowJobs(new ShowJobVue());
        }
    }
}
