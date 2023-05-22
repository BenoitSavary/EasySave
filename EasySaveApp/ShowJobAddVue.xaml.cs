using EasySaveLib.Controller;
using EasySaveLib.Vue;
using EasySaveLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace EasySaveApp
{
    /// <summary>
    /// Logique d'interaction pour Page1.xaml
    /// </summary>
    public partial class ShowJobAddVue : Window, IShowJobAddVue
    {
        public ShowJobAddController Controller { get; set; }
        public Stockage stockage { get; set; }
        public StockageLanguage stockLanguage { get; set; }
        public DisplayError Error { get; set; }
        public Server server { get; set; }
        public ShowJobAddVue(Stockage stockage)
        {
            InitializeComponent();
            this.stockage = stockage;
            stockLanguage = new StockageLanguage();
            Error = new DisplayError();
            Controller = new ShowJobAddController(stockage, stockLanguage);
            setController(Controller);
        }

        public void ReturnMenu()
        {
        }

        public void setController(object controller)
        {
            Controller = (ShowJobAddController)controller;
        }

        public string[] ShowJobsAdd()
        {
            string[] a = new string[4];
            return a;
        }

        public void return_menu_Click(object sender, RoutedEventArgs e)
        {
            ShowJobVue view = new ShowJobVue(stockage.JobList, stockage);
            Controller.ShowJobs(view);
            view.Show();
            Close();
        }

        private void create_save_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("serial.xml"))
            {
                stockage.JobList=Controller.Services.deserial();
                File.Delete("serial.xml");
                Controller.Services.CreateJob("2", SaveName.Text, Source.Text, Destination.Text, Type.Text);
            }
            else
            {
                Controller.Services.CreateJob("2", SaveName.Text, Source.Text, Destination.Text, Type.Text);
            }
            ShowJobVue view = new ShowJobVue(stockage.JobList, stockage);
            Controller.ShowJobs(view);
            view.Show();
            Close();
        }

    }
}
