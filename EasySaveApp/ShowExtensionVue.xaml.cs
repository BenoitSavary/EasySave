using EasySaveLib.Controller;
using EasySaveLib.Vue;
using EasySaveLib.Model;
using EasySaveLib.Service;
using System.IO;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;


namespace EasySaveApp
{
    public partial class ShowExtensionVue : Window, IShowExtensionsVue
    {
        public ShowExtensionsController Controller { get; set; }
        public StockageLanguage stockLanguage { get; set; }
        public Stockage stockage { get; set; }
        public Services Services { get; set; }
        public Ext Ext { get; set; }
        public List<CheckBox> extensions { get; set; }
        public List<extension> listextension { get; set; }
        public ShowExtensionVue(Stockage stock)
        {
            InitializeComponent();
            stockLanguage= new StockageLanguage();
            stockage = stock;
            extensions = new List<CheckBox>();
            listextension = new List<extension>();
            Ext = new Ext(stockage, stockLanguage);
            Services = new Services(stockage, stockLanguage);
            Controller = new ShowExtensionsController(stockage ,stockLanguage);
            checkbox_add();
            setController(Controller);
            check_list();
        }

        public void setController(object controller)
        {
            Controller = (ShowExtensionsController)controller;
        }

        private void return_menu_Click(object sender, RoutedEventArgs e)
        {
            ShowConfigVue view = new ShowConfigVue();
            view.Show();
            Close();
        }
        private void checkbox_add()
        {
            extensions.Add(pdf);
            extensions.Add(docx);
            extensions.Add(jpg);
            extensions.Add(png);
            extensions.Add(zip);
            extensions.Add(rar);
            extensions.Add(xlsx);
            extensions.Add(pptx);
        }

        private void check_list()
        {
            if(!File.Exists("serialExtensions.xml"))
            {
                Ext.serial();
            }

            listextension = Ext.deserial();

            foreach (extension a in listextension)
            {
                foreach (CheckBox b in extensions)
                {
                    if(b.Name == a.Name)
                    {
                        b.IsChecked = true;
                    }
                    else
                    {
                        continue;
                    }
                }
              
            }
        }
        private void recup_list()
        {
            listextension.Clear();
            foreach (CheckBox a in extensions)
            {
                if(a.IsChecked == true)
                {
                    extension b = new extension() {Name = a.Name };
                    listextension.Add(b);
                }
                else
                {
                    continue;
                }
            }
        }

        private void config_log_Click(object sender, RoutedEventArgs e)
        {
            recup_list();
            Ext.GetExtensions(listextension);
            ShowConfigVue view = new ShowConfigVue();
            view.Show();
            Close();

        }

        public void ShowExtensions()
        {
        }

        public void ReturnMenu()
        {
        }

        public string WriteExtension()
        {
            return null;
        }
    }
}
