using EasySaveLib.Controller;
using EasySaveLib.Vue;
using EasySaveLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySave
{
    public class ShowProcessRemoveVue : IShowProcessRemoveVue
    {
        public ShowProcessRemoveController Controller { get; set; }
        public void setController(object controller)
        {
            Controller = (ShowProcessRemoveController)controller;
        }

        public void ReturnMenu()
        {
            Console.Clear();
            Controller.ShowProcess(new ShowProcessVue());
        }
    }
}
