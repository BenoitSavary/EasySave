using EasySaveLib.Controller;
using EasySaveLib.Vue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySave
{
    internal class ShowJobStartVue : IShowJobStartVue
    {
        public ShowJobStartController Controller { get; set; }
        public void setController(object controller)
        {
            Controller = (ShowJobStartController)controller;
        }
    }
}
