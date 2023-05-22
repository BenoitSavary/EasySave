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
using EasySaveLib.Controller;
using System.Threading;

namespace EasySaveApp
{

    public partial class HomeVue : Window, IHomeVue
    {

        public HomeController Controller { get; set; }
        public StockageLanguage stockLanguage { get; set; }
        public Services Services { get; set; }  
        public Server server { get; set; }
        public HomeVue( )
        {
            InitializeComponent();
            stockLanguage = new StockageLanguage();
            Controller = new HomeController(this, null, stockLanguage);
            setController(Controller);
        }

        public void setController(object controller)
        {
            Controller = (HomeController)controller;
        }

        private void list_save_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("serial.xml"))
            {
                Controller.Stockage.JobList=Controller.Services.deserial();
            }
            ShowJobVue view = new ShowJobVue(Controller.Stockage.JobList, Controller.Stockage);
            Controller.ShowJobs(view);

            view.Show();
            Close();
        }


        void IHomeVue.showMenu()
        {
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void config_Click(object sender, RoutedEventArgs e)
        {
            ShowConfigVue view = new ShowConfigVue();
            Controller.ShowConfig(view);
            view.Show();
            Close();
        }

        private void config_serv_Click(object sender, RoutedEventArgs e)
        {
            int numberOfThreads = Environment.ProcessorCount; // Récupère le nombre de processeurs logiques du système
            ThreadPool.SetMaxThreads(numberOfThreads, numberOfThreads); // Définit le nombre maximum de threads qui peuvent s'exécuter en parallèle
            ThreadPool.QueueUserWorkItem(new WaitCallback(delegate
            {
                Controller.ServerStart();
            }));
            
        }

/*        private void config_serv_Click(object sender, RoutedEventArgs e)
        {

        }*/
    }
}

