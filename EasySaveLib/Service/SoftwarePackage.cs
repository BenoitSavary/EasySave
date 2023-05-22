using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using EasySaveLib.Model;


public class SoftwarePackage
{
    public Stockage Stockage { get; set; }
    public StockageLanguage stockLanguage { get; set; }

    public Services Services { get; set; }

    public SoftwarePackage(Stockage stockage, StockageLanguage? stockLang = null)
    {
        this.Stockage = stockage;
        this.stockLanguage = stockLang ?? new StockageLanguage();
    }

    public void WriteProcess()
    {Services= new Services(Stockage, stockLanguage);
        if (File.Exists("serialString.xml"))
        {
            if (File.ReadAllBytes("serialString.xml") != null)
            {
                Stockage.ListOfProcess = Services.deserialString();

            }
        }
        if (Stockage.ListOfProcess != null)
        {
            foreach (process process in Stockage.ListOfProcess)
            {
                if (process != null)
                {
                    Console.WriteLine(process.Name);
                }
            }
        }
    }

    public void GetProcess(string process)
    {
        Services = new Services(Stockage, stockLanguage);
        Stockage.ListOfProcess.Add(new process() { Name=process});
        Services.serialString();
    }

    public void RemoveProcess(string process)
    {
        int index = int.Parse(process);
        Stockage.ListOfProcess.RemoveAt(index);
        File.Delete("serialString.xml");
        Services.serialString();
    }

    public bool checkprocess ()
    {
        bool result = false;
        foreach(process process in Stockage.ListOfProcess)
        { 
            Process[] localByName = Process.GetProcessesByName(process.Name);
            if (localByName.Length != 0) 
            { 
                return true;
            }
        }
        return result;

    }
}



