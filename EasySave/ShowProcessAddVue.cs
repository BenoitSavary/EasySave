using EasySaveLib.Controller;
using EasySaveLib.Vue;
using EasySaveLib.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EasySave
{
    public class ShowProcessAddVue : IShowProcessAddVue
    {
        public ShowProcessAddController Controller { get; set; }


        public void setController(object controller)
        {
            Controller = (ShowProcessAddController)controller;
        }

        public string ShowProcessAdd()
        {
            Console.Clear();
            Console.WriteLine(Controller.stockLanguage.process_name);
            return Console.ReadLine();
        }

        public void ReturnMenu()
        {
            Console.Clear();
            Controller.ShowConfigProcess(new ShowProcessVue());
        }
    
}
}
