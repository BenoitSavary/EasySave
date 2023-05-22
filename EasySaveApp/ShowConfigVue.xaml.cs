using EasySaveLib.Controller;
using EasySaveLib.Vue;
using EasySaveLib.Model;
using System.IO;
using System.Windows;


namespace EasySaveApp
{

    public partial class ShowConfigVue : Window, IShowConfigVue
    {
        public ShowConfigController Controller { get; set; }
        public Stockage stockage { get; set; }
        public StockageLanguage stockLanguage { get; set; }
        public ShowConfigVue()
        {
            InitializeComponent();
            stockage = new Stockage();
            stockLanguage= new StockageLanguage();
            Controller = new ShowConfigController(stockage,stockLanguage);
            setController(Controller);

        }

        public void setController(object controller)
        {
            Controller = (ShowConfigController)controller;
        }

        public void ShowConfig(StockageLanguage stockageLanguage)
        {
        }

        private void return_menu_Click(object sender, RoutedEventArgs e)
        {
            HomeVue view = new HomeVue();
            Controller.ShowMenu(view);
            view.Show();
            Close();
        }

        private void config_lang_Click(object sender, RoutedEventArgs e)
        {
            ShowLanguageVue view = new ShowLanguageVue(stockage);
            Controller.ShowLanguage(view);
            view.Show();
            Close();
        }

        private void config_log_Click(object sender, RoutedEventArgs e)
        {
            ShowLogVue view = new ShowLogVue(stockage);
            Controller.ShowLog(view);
            view.Show();
            Close();
        }

        private void config_process_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("serialString.xml"))
            {
                stockage.ListOfProcess=Controller.Services.deserialString();
            }
            ShowProcessVue view = new ShowProcessVue(stockage.ListOfProcess,stockage);
            view.Show();
            Close();
        }

        private void config_extprio_Click(object sender, RoutedEventArgs e)
        {
            ShowExtPrioVue view = new ShowExtPrioVue(stockage);
            view.Show();
            Close();
        }

        private void config_ext_Click(object sender, RoutedEventArgs e)
        {
            ShowExtensionVue view = new ShowExtensionVue(stockage);
            view.Show();
            Close();
        }

        private void config_filesize_Click(object sender, RoutedEventArgs e)
        {
            ShowFileSizeVue view = new ShowFileSizeVue(stockage);
            view.Show();
            Close();
        }
    }
}
