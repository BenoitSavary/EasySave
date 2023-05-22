using EasySaveLib.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EasySaveLib.Service
{
    public class Ext
    {
        public Stockage Stockage { get; set; }
        public StockageLanguage stockLanguage { get; set; }


        public Ext(Stockage stockage, StockageLanguage? stockLang = null)
        {
            this.Stockage = stockage;
            this.stockLanguage = stockLang ?? new StockageLanguage();
        }

        public void WriteExtensions()
        {
            if (System.IO.File.Exists("serialExtensions.xml"))
            {
                Stockage.ListOfExtensions=deserial();
            }
            Console.WriteLine("Extensions éligible au chiffrement :"+stockLanguage.ext1+stockLanguage.ext2+stockLanguage.ext3+stockLanguage.ext4 +
                stockLanguage.ext5 + stockLanguage.ext6 + stockLanguage.ext7 + stockLanguage.ext8+"\nExtensions actives");
            if (Stockage.ListOfExtensions != null)
            {
                foreach (extension extension in Stockage.ListOfExtensions)
                {
                    if (extension != null)
                    {
                        Console.WriteLine(extension.Name);
                    }
                }
            }
        }

        public void GetExtensions(List<extension> extension)
        {
             Stockage.ListOfExtensions = extension;
            if (File.Exists("serialExtensions.xml"))
            {
                File.Delete("serialExtensions.xml");
                serial();
            }
            else
            {
                serial();
            }
        }
         
        public void RemoveExtensions(string extension)
        {
            int index = int.Parse(extension)-1;
            Stockage.ListOfExtensions.RemoveAt(index);
            File.Delete("serialExtensions.xml");
            serial();
        }

        public bool checkExtensions(string source)
        {
            Stockage.ListOfExtensions = deserial();
            bool result = false;
            string extension = Path.GetExtension(source);
            extension = extension.Remove(0, 1);
            foreach (extension process in Stockage.ListOfExtensions)
            {
                if (extension == process.Name)
                {
                    return true;
                }
            }
            return result;

        }

        public void serial()
        {

            //Nouveau Serialiser avec comme argument le type de l'element racine, List<Save>
            XmlSerializer serialXml = new XmlSerializer(typeof(List<extension>));

            using (Stream flux = new FileStream("serialExtensions.xml", FileMode.OpenOrCreate, FileAccess.Write))
            {
                serialXml.Serialize(flux, Stockage.ListOfExtensions);
                flux.Close();
            }

        }
        public List<extension> deserial()
        {
            if (File.Exists("serialExtensions.xml"))
            {
                List<extension> taListe = null;
                XmlSerializer serializer = new XmlSerializer(typeof(List<extension>));
                Stream flux = File.OpenRead("serialExtensions.xml");
                taListe = (List<extension>)serializer.Deserialize(flux);
                flux.Close();

                return taListe;
            }
            else
            {
                return null;
            }
        }
    }
}
