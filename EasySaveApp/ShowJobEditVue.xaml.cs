using EasySaveLib.Model;
using EasySaveLib.Controller;
using EasySaveLib.Vue;
using System.IO;
using System.Collections.Generic;
using System.Windows;


namespace EasySaveApp
{
    /// <summary>
    /// Logique d'interaction pour Page1.xaml
    /// </summary>
    public partial class ShowJobEditVue : Window, IShowJobEditVue
    {
        public ShowJobEditController Controller { get; set; }
        public List<Save> ListJob { get; set; }
        public Stockage stockage { get; set; }
        public StockageLanguage stockLanguage { get; set; }
        public ShowJobEditVue(List<Save> save, Stockage stock)
        {
            InitializeComponent();
            stockLanguage = new StockageLanguage();
            stockage = stock;
            Controller = new ShowJobEditController(stockage, stockLanguage);
            setController(Controller);
            ListJob = save;
            dgListJob.ItemsSource = ListJob;
        }

        public void ReturnMenu()
        {
        }

        public void setController(object controller)
        {
            Controller = (ShowJobEditController)controller;
        }

        private void return_menu_Click(object sender, RoutedEventArgs e)
        {
            ShowJobVue view = new ShowJobVue(ListJob, stockage);
            view.Show();
            Close();
        }

        public string[] ShowJobsEdit()
        {
            return null;
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("serial.xml"))
            {
                File.Delete("serial.xml");
                Controller.Services.serial();
            }
            else
            {
                Controller.Services.serial();
            }
        }
    }
}
