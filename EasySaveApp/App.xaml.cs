using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using AdonisUI.Controls;
using AdonisUI.Extensions;
using EasySaveLib.Model;
using EasySaveLib.Service;

namespace EasySaveApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            HomeVue vue = new HomeVue();
            MonoInstance mono = new MonoInstance();
            mono.mono();
            HomeController controller = new HomeController(vue);

            vue.setController(controller);
            controller.init();
            controller.initlang();
            vue.Show();
        }
    }
}
