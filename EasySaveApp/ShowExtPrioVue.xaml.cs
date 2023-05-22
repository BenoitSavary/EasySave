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
    public partial class ShowExtPrioVue : Window, IShowExtPrioVue
    {
        public ShowExtPrioController Controller { get; set; }
        public StockageLanguage stockLanguage { get; set; }
        public Stockage stockage { get; set; }
        public Services Services { get; set; }
        public ExtensionsPrio ExtensionsPrio { get; set; }
        public List<CheckBox> extensions { get; set; }
        public List<extensionprio> listextension { get; set; }
        public ShowExtPrioVue(Stockage stock)
        {
            InitializeComponent();
            stockLanguage= new StockageLanguage();
            stockage = stock;
            extensions = new List<CheckBox>();
            listextension = new List<extensionprio>();
            Services = new Services(stockage, stockLanguage);
            ExtensionsPrio = new ExtensionsPrio(stockage, Services, stockLanguage);
            Controller = new ShowExtPrioController(stockage ,stockLanguage);
            checkbox_add();
            setController(Controller);
            check_list();
        }

        public void setController(object controller)
        {
            Controller = (ShowExtPrioController)controller;
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
            if (File.Exists("serialExtensionPrio.xml"))
            {
                if (File.ReadAllBytes("serialExtensionPrio.xml") != null)
                {
                    listextension = Services.deserialExtensionPrio();
                }
            }
            foreach (extensionprio a in listextension)
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
                    extensionprio b = new extensionprio() {Name = a.Name };
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
            ExtensionsPrio.GetExtensionPrio(listextension);
            ShowConfigVue view = new ShowConfigVue();
            view.Show();
            Close();

        }
    }
}
