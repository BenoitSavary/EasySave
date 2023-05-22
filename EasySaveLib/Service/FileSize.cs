using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using EasySaveLib.Model;
using System.Xml.Serialization;
using System.IO;


public class FileSize
{
    public Stockage Stockage { get; set; }
    public StockageLanguage stockLanguage { get; set; }

    public Services Services { get; set; }

    public FileSize(Stockage stockage, StockageLanguage? stockLang = null)
    {
        Stockage = stockage;
        stockLanguage = stockLang ?? new StockageLanguage();
        Services = new Services(stockage, stockLang);
    }


    public void GetFileSizeMax(long filesize)
    {
        Stockage.FileSizeMax = filesize;
        if (File.Exists("serialFileSize.xml"))
        {
            File.Delete("serialFileSize.xml");
            serialFileSize();
        }
        else
        {
            serialFileSize();
        }

    }

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
    public void serialFileSize()
    {

        //Nouveau Serialiser avec comme argument le type de l'element racine, long
        XmlSerializer serialXml = new XmlSerializer(typeof(long));

        using (Stream flux = new FileStream("serialFileSize.xml", FileMode.OpenOrCreate, FileAccess.Write))
        {
            serialXml.Serialize(flux, Stockage.FileSizeMax);
            flux.Close();
        }

    }
    public long deserialFileSize()
    {
        long taListe;
        XmlSerializer serializer = new XmlSerializer(typeof(long));
        Stream flux = File.OpenRead("serialFileSize.xml");
        taListe = (long)serializer.Deserialize(flux);
        flux.Close();

        return taListe;

    }
}



