using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using EasySaveLib.Model;
using System.IO;


public class ExtensionsPrio
{
    public Stockage Stockage { get; set; }
    public StockageLanguage stockLanguage { get; set; }

    public Services Services { get; set; }

    public ExtensionsPrio(Stockage stockage, Services services, StockageLanguage? stockLang = null)
    {
        Stockage = stockage;
        stockLanguage = stockLang ?? new StockageLanguage();
        Services = services;
    }

/*    public void WriteProcess()
    {
        if (File.Exists("serialExtensionPrio.xml"))
        {
            if (File.ReadAllBytes("serialExtensionPrio.xml") != null)
            {
                Stockage.ListOfExtensionsPrio = Services.deserialExtensionPrio();

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
    }*/

    public void GetExtensionPrio(List<extensionprio> extension)
    {
        Stockage.ListOfExtensionsPrio = extension;
        if (File.Exists("serialExtensionPrio.xml"))
        {
            File.Delete("serialExtensionPrio.xml");
            Services.serialExtensionPrio();
        }
        else
        {
            Services.serialExtensionPrio();
        }

    }

    /*    public void RemoveProcess(string process)
        {
            int index = int.Parse(process);
            Stockage.ListOfProcess.RemoveAt(index);
            File.Delete("serialString.xml");
            Services.serialString();
        }*/

    public bool checkExtensionsPrio(string source)
    {
        if (File.Exists("serialExtensionPrio.xml"))
        {
            if (File.ReadAllBytes("serialExtensionPrio.xml") != null)
            {
                Stockage.ListOfExtensionsPrio = Services.deserialExtensionPrio();
            }
        }
        bool result = false;
        string extensionprio = Path.GetExtension(source);
        extensionprio = extensionprio.Remove(0, 1);
        foreach (extensionprio process in Stockage.ListOfExtensionsPrio)
        {
            if (extensionprio == process.Name)
            {
                return true;
            }
        }
        return result;

    }
}



