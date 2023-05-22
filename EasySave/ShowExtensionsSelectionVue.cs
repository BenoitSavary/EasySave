using EasySaveLib.Controller;
using EasySaveLib.Vue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySave
{
    public class ShowExtensionsSelectionVue : IShowExtensionsSelectionVue
    {
        public ShowExtensionsSelectionController Controller { get; set; }
        public void setController(object controller)
        {
            Controller = (ShowExtensionsSelectionController)controller;

        }

        public void ShowExtensionsSelection(String index)
        {
            Console.Clear();
            Console.WriteLine("Que voulez vous faire avec l'extensions" + index + '\n' + "Appuyez sur 0 pour le supprimer" + '\n' + "Appuyez sur E pour retourner en arriere");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "0":
                    Console.Clear();
                    Controller.ShowExtensionsRemove(new ShowExtensionsRemoveVue(), index);
                    break;
                case "1":
                    Console.Clear();
                    break;
                case "2":
                    Console.Clear();
                    break;
                case "3":
                    Console.Clear();
                    break;
                case "E":
                    Console.Clear();
                    Controller.ShowExtensions(new ShowExtensionsVue());
                    break;
            }
        }
    }
}
