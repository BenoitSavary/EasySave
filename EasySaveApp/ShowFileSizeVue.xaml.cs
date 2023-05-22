using EasySaveLib.Controller;
using EasySaveLib.Vue;
using EasySaveLib.Model;
using System;
using System.IO;
using System.Windows;


namespace EasySaveApp
{
    public partial class ShowFileSizeVue : Window, IShowFileSizeVue
    {
        public ShowFileSizeController Controller { get; set; }
        public StockageLanguage stockLanguage { get; set; }
        public Stockage stockage { get; set; }
        public Services Services { get; set; }
        public FileSize fileSize { get; set; }
        public ShowFileSizeVue(Stockage stock)
        {
            InitializeComponent();
            stockLanguage= new StockageLanguage();
            stockage = stock;
            Services = new Services(stockage, stockLanguage);
            Controller = new ShowFileSizeController(stockage, stockLanguage);
            fileSize = new FileSize(stockage, stockLanguage);
            setController(Controller);
        }

        public void setController(object controller)
        {
            Controller = (ShowFileSizeController)controller;
        }

        private void return_menu_Click(object sender, RoutedEventArgs e)
        {
            ShowConfigVue view = new ShowConfigVue();
            view.Show();
            Close();
        }

        private void config_filesize_Click(object sender, RoutedEventArgs e)
        {
            long UserEntry = Convert.ToInt64(txtFileSize.Text);
            if (File.Exists("serialFileSize.xml"))
            {
       
                File.Delete("serialFileSize.xml");
                fileSize.GetFileSizeMax(UserEntry);
            }
            else
            {
                fileSize.GetFileSizeMax(UserEntry); ;
            }

            ShowConfigVue view = new ShowConfigVue();
            view.Show();
            Close();
        }
    }
}
