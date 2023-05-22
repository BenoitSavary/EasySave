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

namespace EasySaveApp
{
    public partial class ShowLogVue : Window, IShowLogVue
    {
        public ShowLogController Controller { get; set; }
        public StockageLanguage stockLanguage { get; set; }
        public Stockage stockage { get; set; }
        public ShowLogVue(Stockage stock)
        {
            InitializeComponent();
            stockLanguage= new StockageLanguage();
            stockage = stock;
            Controller = new ShowLogController(stockage ,stockLanguage);
            setController(Controller);
        }

        public void setController(object controller)
        {
            Controller = (ShowLogController)controller;
        }


        public void ShowLog(StockageLanguage stockageLanguage)
        {
            string choice = stockageLanguage.LireEtatLog();
        }

        private void return_menu_Click(object sender, RoutedEventArgs e)
        {
            ShowConfigVue view = new ShowConfigVue();
            Controller.ShowConfig(view);
            view.Show();
            Close();
        }

        private void button_XML_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
