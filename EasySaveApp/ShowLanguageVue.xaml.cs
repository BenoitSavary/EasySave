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
    /// <summary>
    /// Logique d'interaction pour Page1.xaml
    /// </summary>
    public partial class ShowLanguageVue : Window, IShowLangueVue
    {
        public LangueController Controller { get; set; }
        public StockageLanguage stockLanguage { get; set; }
        public Stockage stockage { get; set; }
        public ShowLanguageVue(Stockage stock)
        {
            InitializeComponent();
            stockLanguage= new StockageLanguage();
            stockage= stock;
            Controller = new LangueController(stockage ,stockLanguage);
            setController(Controller);
        }

        public void setController(object controller)
        {
            Controller = (LangueController)controller;
        }

        public void ShowLangue(StockageLanguage stockageLanguage)
        {
        }

        private void return_menu_Click(object sender, RoutedEventArgs e)
        {
            ShowConfigVue view = new ShowConfigVue();
            Controller.ShowConfig(view);
            view.Show();
            Close();
        }
    }
}
