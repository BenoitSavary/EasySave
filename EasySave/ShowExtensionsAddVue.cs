using EasySaveLib.Controller;
using EasySaveLib.Vue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySave
{
    public class ShowExtensionsAddVue : IShowExtensionsAddVue
    {
        public ShowExtensionsAddController Controller { get; set; }


        public void setController(object controller)
        {
            Controller = (ShowExtensionsAddController)controller;
        }

        public string ShowExtensionAdd()
        {
            Console.WriteLine("Ecrivez l'extension");
            return Console.ReadLine();
        }

        public void ReturnMenu()
        {
            Console.Clear();
            Controller.ShowConfigExtensions(new ShowExtensionsVue());
        }
    }
}
