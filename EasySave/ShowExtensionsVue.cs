using EasySaveLib.Controller;
using EasySaveLib.Vue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySave
{
    public class ShowExtensionsVue : IShowExtensionsVue
    {
        public ShowExtensionsController Controller { get; set; }

        public void setController(object controller)
        {
            Controller = (ShowExtensionsController)controller;
        }

        public void ShowExtensions()
        {
            Console.WriteLine("Entrez le numéro de l'extension pour le sélectionner \nEntrez C pour en créer un nouveau et E pour retourner en arrière");


            string process = WriteExtension();
            switch (process)
            {
                case "C":
                    Controller.ShowExtensionsAdd(new ShowExtensionsAddVue());
                    break;
                case "E":
                    ReturnMenu();
                    break;
                default:
                    Controller.ShowExtensionsSelection(new ShowExtensionsSelectionVue(), process);
                    break;
            }

        }

        public string WriteExtension()
        {
            return Console.ReadLine();
        }
        public void ReturnMenu()
        {
            Console.Clear();
            Controller.ShowMenu(new ShowConfigVue());
        }
    }
}
