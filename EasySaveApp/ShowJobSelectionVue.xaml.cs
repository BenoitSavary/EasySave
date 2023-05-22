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
using System.ComponentModel;
using System.Threading;

namespace EasySaveApp
{
    /// <summary>
    /// Logique d'interaction pour Page1.xaml
    /// </summary>
    public partial class ShowJobSelectionVue : Window, IShowJobSelectionVue
    {
        public ShowJobSelectionController Controller { get; set; }
        public Stockage stockage { get; set; }
        public StockageLanguage stockLanguage { get; set; }
        public Save ListJob { get; set; }

        public ShowJobSelectionVue(Save save, Stockage stock)
        {
            InitializeComponent();
            this.stockage = stock;
            this.stockLanguage = new StockageLanguage();
            Controller = new ShowJobSelectionController(stockage, stockLanguage);
            setController(Controller);
            ListJob = save;
            BindText();
            EtatClient();
        }

        public void BindText()
        {
            TxtShowName.Text = ListJob.Name;
            TxtShowSrc.Text = ListJob.Src;
            TxtShowDst.Text = ListJob.Dst;
        }

        public int SearchIndex()
        {
            return stockage.JobList.FindIndex(j => j.Name == ListJob.Name);
        }

        public void setController(object controller)
        {
            Controller = (ShowJobSelectionController)controller;
        }

        public void ShowJobsSelection(Save choice, string index)
        {
        }


        private void return_menu_Click(object sender, RoutedEventArgs e)
        {
            Return_Menu();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            int index = SearchIndex();
            Controller.Services.DeleteJob(index.ToString());
            Return_Menu();
        }

        public void Return_Menu()
        {
            stockage.JobList=Controller.Services.deserial();
            ShowJobVue view = new ShowJobVue(stockage.JobList, stockage);
            view.Show();
            Close();
        }
        
        public void EtatClient ()
        {
            
            string etatclient = stockage.EtatServeur;
            if (etatclient != null)
            { 
            
                switch (etatclient)
                {
                    case "play":
                        int index = SearchIndex();
                        Controller.Stockage.JobList[index].Etat = "start";

                        int numberOfThreads = Environment.ProcessorCount;
                        ThreadPool.SetMaxThreads(numberOfThreads, numberOfThreads);
                        ThreadPool.QueueUserWorkItem(new WaitCallback(delegate
                        {
                            Controller.Services.copy(Controller.Stockage.JobList[index]);
                        }));

                        // Mettre à jour la barre de progression en temps réel
                        Task.Run(() =>
                        {
                            while (Controller.Stockage.JobList[index].pourcent < 100)
                            {
                                Dispatcher.Invoke(() =>
                                {
                                    Progress.Value = Controller.Stockage.JobList[index].pourcent;
                                });
                                //Thread.Sleep(100);
                            }
                            Dispatcher.Invoke(() =>
                            {
                                Progress.Value = Controller.Stockage.JobList[index].pourcent;
                            });
                        });
                        break;
                    case "pause":
                        index = SearchIndex();
                        Controller.Stockage.JobList[index].Etat = "pause";
                        break;
                    case "stop":
                        index = SearchIndex();
                        Controller.Stockage.JobList[index].Etat = "stop";
                        break;
                }
            }
        }

        private void StopSave(object sender, RoutedEventArgs e)
        {
            int index = SearchIndex();
            Controller.Stockage.JobList[index].Etat = "stop";
        }

        private void StartSave(object sender, RoutedEventArgs e)
        {
            int index = SearchIndex();
            Controller.Stockage.JobList[index].Etat = "start";
            int numberOfThreads = Environment.ProcessorCount;
            ThreadPool.SetMaxThreads(numberOfThreads, numberOfThreads);
            ThreadPool.QueueUserWorkItem(new WaitCallback(delegate
            {
                Controller.Services.copy(Controller.Stockage.JobList[index]);
            }));

            // Mettre à jour la barre de progression en temps réel
            Task.Run(() =>
            {
                while (Controller.Stockage.JobList[index].pourcent < 100)
                {
                    Dispatcher.Invoke(() =>
                    {
                        Progress.Value = Controller.Stockage.JobList[index].pourcent;
                    });
                    Thread.Sleep(100);
                }
                Dispatcher.Invoke(() =>
                {
                    Progress.Value = Controller.Stockage.JobList[index].pourcent;
                });
            });
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            int index = SearchIndex();
            
                (sender as BackgroundWorker).ReportProgress(Controller.Stockage.JobList[index].pourcent);

                Thread.Sleep(1000);
            
        }

        private void ProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int index = SearchIndex();
            Progress.Value = Controller.Stockage.JobList[index].pourcent;
        }

        private void PauseSave(object sender, RoutedEventArgs e)
        {
            int index = SearchIndex();
            Controller.Stockage.JobList[index].Etat = "pause";
        }
    }
}
