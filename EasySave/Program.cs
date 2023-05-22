using EasySave;
using EasySaveLib;
using EasySaveLib.Service;
using System.Net.Sockets;
using System.Reflection;


public class Program
{

    static void Main(string[] args)
    {
        MonoInstance mono = new MonoInstance();
        HomeVue vue = new HomeVue();
        HomeController controller = new HomeController(vue);
        mono.mono();
        vue.setController(controller);
        controller.initlang();
        controller.init();
    }
}