using EasySaveLib;
using EasySaveLib.Controller;
using EasySaveLib.Vue;
using System;
using System.ComponentModel.Design;
using System.Text.RegularExpressions;
using EasySaveLib.Model;

public class HomeController
{
    public Services Services { get; set; }
    public Stockage Stockage { get; set; }

    public Server server { get; set; }
    public SoftwarePackage SoftwarePackage { get; set; }

    public StockageLanguage stockLanguage { get; set; }
    public HomeController(IHomeVue vue, Stockage? stock = null, StockageLanguage? stockLang = null)
    {
        this.Stockage = stock?? new Stockage();
        Services = new Services(Stockage,stockLanguage);
        SoftwarePackage = new SoftwarePackage(Stockage, stockLanguage);
        this.stockLanguage = stockLang?? new StockageLanguage();
        Vue = vue;
    }


    public IHomeVue Vue { get; set; }

    public string src;
    public string dst;

    public string etatlangue;
  


    public delegate void OnSaveDone(string fichier, long temps);
    public OnSaveDone onSaveDone { get; set; }


    public void init()
    {
        if (File.Exists("serialString.xml"))
        {
            if (File.ReadAllBytes("serialString.xml") != null)
            {
                Stockage.ListOfProcess = Services.deserialString();

            }
        }
        Vue.showMenu();
    }

    public void initlang()
    {
        etatlangue = stockLanguage.LireEtatLangue(etatlangue);
      
        switch (etatlangue)
        {
            case "FR":
                stockLanguage.lang = stockLanguage.data.FR;
                stockLanguage.ChangeLanguage();
                break;
            case "EN":
               stockLanguage.lang = stockLanguage.data.EN;
               stockLanguage.ChangeLanguage();
                break;
            case "ES":
                stockLanguage.lang = stockLanguage.data.ES;
                stockLanguage.ChangeLanguage();
                break;
            default:
                stockLanguage.lang = stockLanguage.data.EN;
                stockLanguage.ChangeLanguage();
                break;
        }
    }

   
    public void ShowJobs(IShowJobVue vue)
    {
        ShowJobController c = new ShowJobController(Stockage, stockLanguage);
        c.Vue = vue;
        vue.setController(c);
        if (System.IO.File.Exists("serial.xml"))
        {
            Stockage.JobList = Services.deserial();
        }
        c.init();
    }


    public void ShowConfig(IShowConfigVue vue)
    {
        ShowConfigController c = new ShowConfigController(Stockage, stockLanguage);
        c.Vue = vue;
        vue.setController(c);
        if (File.Exists("serialString.xml"))
        {
            if (File.ReadAllBytes("serialString.xml") != null)
            {
                Stockage.ListOfProcess = Services.deserialString();

            }
        }
        c.init();
    }

    public void ServerStart()
    {

        this.server = new Server(Stockage);
        
/*        int numberOfThreads = Environment.ProcessorCount; // Récupère le nombre de processeurs logiques du système
        ThreadPool.SetMaxThreads(numberOfThreads, numberOfThreads); // Définit le nombre maximum de threads qui peuvent s'exécuter en parallèle
        ThreadPool.QueueUserWorkItem(new WaitCallback(delegate
        {*/
            server.RunServer();
       // }));
    }


}