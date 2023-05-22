using EasySaveLib.Controller;
using EasySaveLib.Vue;
using EasySaveLib.Model;
using System.IO;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;


namespace EasySaveApp
{

    public partial class ShowProcessVue : Window, IShowProcessVue
    {
        public ShowProcessController Controller { get; set; }
        public Stockage stockage { get; set; }
        public StockageLanguage stockLanguage { get; set; }
        public List<process> ListOfProcess { get; set; }
        public process process { get; set; }
        public ShowProcessVue(List<process> ListProcess,Stockage stock)
        {
            InitializeComponent();
            stockage = stock;
            stockLanguage = new StockageLanguage();
            Controller = new ShowProcessController(stockage, stockLanguage);
            setController(Controller);
            ListOfProcess = ListProcess;
            dgListProcess.ItemsSource = ListOfProcess;
        }

        public void setController(object controller)
        {
            Controller = (ShowProcessController)controller;
        }


        private void return_menu_Click(object sender, RoutedEventArgs e)
        {
            ShowConfigVue view = new ShowConfigVue();
            view.Show();
            Close();
        }
        private void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var selectObject = ((FrameworkElement)sender).DataContext;
            dgListProcess.SelectedItem = selectObject;

            process = (process)dgListProcess.SelectedItem;

        }

        public void ShowLog(StockageLanguage stockageLanguage)
        {
        }

        public void ShowProcess()
        {
        }

        public string WriteProcess()
        {
            return null;
        }

        public void ReturnMenu()
        {
        }

        private void config_processdelete_Click(object sender, RoutedEventArgs e)
        {
            int index = stockage.ListOfProcess.FindIndex(j => j.Name == process.Name);
            Controller.SoftwarePackages.RemoveProcess(index.ToString());
            if (File.Exists("serialString.xml"))
            {
                stockage.ListOfProcess=Controller.Services.deserialString();
            }
            ShowProcessVue view = new ShowProcessVue(stockage.ListOfProcess, stockage);
            view.Show();
            Close();
        }

        private void config_processadd_Click(object sender, RoutedEventArgs e)
        {
            ShowProcessAddVue view = new ShowProcessAddVue(stockage);
            view.Show();
            Close();
        }
    }
}
