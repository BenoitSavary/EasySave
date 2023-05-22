using EasySaveLib.Controller;
using EasySaveLib.Vue;
using EasySaveLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
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

namespace EasySaveApp
{
    /// <summary>
    /// Logique d'interaction pour Page1.xaml
    /// </summary>
    /// 
    public partial class ShowJobVue : Window, IShowJobVue
    {
        public ShowJobController Controller { get; set; }
        public List<Save> JobList { get; set; }
        public Stockage stockage { get; set; }
        public StockageLanguage stockLanguage { get; set; }

        public ShowJobVue(List<Save> listJob, Stockage stock)
        {
            InitializeComponent();
            stockage = stock;
            stockLanguage = new StockageLanguage();
            JobList = listJob;
            Controller = new ShowJobController(stockage, stockLanguage);
            setController(Controller);
            dgListJob.ItemsSource = JobList;

        }

        public void setController(object controller)
        {
            Controller = (ShowJobController)controller;
        }

        public void ShowJobs(List<Save> jobs)
        {
        }

        private void return_menu_Click(object sender, RoutedEventArgs e)
        {
            HomeVue view = new HomeVue();
            Controller.ShowMenu(view);
            view.Show();
            Close();
            
        }

        private void create_save_Click(object sender, RoutedEventArgs e)
        {
            ShowJobAddVue view = new ShowJobAddVue(stockage);
            view.Show();
            Close();
        }
        private void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var selectObject = ((FrameworkElement)sender).DataContext;
            dgListJob.SelectedItem = selectObject;

            Save select = (Save)dgListJob.SelectedItem;

            ShowJobSelectionVue view = new ShowJobSelectionVue(select, stockage);
            view.Show();
            Close();

        }
        private void edit_Click(object sender, RoutedEventArgs e)
        {
            ShowJobEditVue view = new ShowJobEditVue(JobList, stockage);
            view.Show();
            Close();
        }
    }
}
