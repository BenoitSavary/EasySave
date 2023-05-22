using EasySaveLib.Controller;
using EasySaveLib.Vue;
using EasySaveLib.Model;
using System.IO;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;


namespace EasySaveApp
{

    public partial class ShowProcessAddVue : Window, IShowProcessAddVue
    {
        public ShowProcessAddController Controller { get; set; }
        public Stockage stockage { get; set; }
        public StockageLanguage stockLanguage { get; set; }
        public List<process> ListOfProcess { get; set; }
        public process process { get; set; }
        public DisplayError Error { get; set; }
        public ShowProcessAddVue(Stockage stock)
        {
            InitializeComponent();
            Error = new DisplayError();
            stockage = stock;
            stockLanguage = new StockageLanguage();
            Controller = new ShowProcessAddController(stockage, stockLanguage);
            setController(Controller);
        }

        public void setController(object controller)
        {
            Controller = (ShowProcessAddController)controller;
        }

        public string ShowProcessAdd()
        {
            return null;
        }

        public void ReturnMenu()
        {
        }

        private void config_processadd_Click(object sender, RoutedEventArgs e)
        {
            Controller.SoftwarePackages.GetProcess(SaveWork.Text);
            Controller.SoftwarePackages.WriteProcess();

            ShowProcessVue view = new ShowProcessVue(stockage.ListOfProcess, stockage);
            view.Show();
            Close();
        }

        private void return_menu_Click(object sender, RoutedEventArgs e)
        {
            ShowProcessVue view = new ShowProcessVue(stockage.ListOfProcess, stockage);
            view.Show();
            Close();
        }
    }
}
