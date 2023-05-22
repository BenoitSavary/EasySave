using EasySaveLib.Controller;
using EasySaveLib.Vue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySave
{
    public class ShowExtensionsRemoveVue : IShowExtensionsRemoveVue
    {
        public ShowExtensionsRemoveController Controller { get; set; }
        public void setController(object controller)
        {
            Controller = (ShowExtensionsRemoveController)controller;
        }

        public void ReturnMenu()
        {
            Console.Clear();
            Controller.ShowExtensions(new ShowExtensionsVue());
        }
    }
}
