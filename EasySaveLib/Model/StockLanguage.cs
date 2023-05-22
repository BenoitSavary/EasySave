using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasySaveLib;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;

namespace EasySaveLib.Model
{
    public class StockageLanguage
    {
        // #lang take stockLanguage.data.XX (ISO 3166-1 codes) to update the language choice on ChangeLanguage();
        public dynamic lang { get; set; }

        // #jsonlang  is use to read all the file language.json
        public string jsonlang { get; set; }

        // #data is use to Deserialize jsonlang
        public dynamic data { get; set; }

        // open language.json to store text data on our public String 
        public StockageLanguage()
        {
            jsonlang = File.ReadAllText("lang\\language.json");
            data = JsonConvert.DeserializeObject(jsonlang);
        }

        // open EtatLangue.txt to write the language codes ISO 3166-1
        public void EcritureEtatLangue(string etatlangue)
        {
            try
            {
                StreamWriter sw = new StreamWriter("etat\\EtatLangue.txt");
                sw.WriteLine(etatlangue);
                sw.Close();
            }
            catch (Exception e)
            {
            }
        }

        public void EcritureEtatLog(string etatlog)
        {
            try
            {
                StreamWriter sw = new StreamWriter("etat\\EtatLog.txt");
                sw.WriteLine(etatlog);
                sw.Close();
            }
            catch (Exception e)
            {
            }
        }

        public void EcritureEtatPriorite(string[] etatprio)
        {
            int i = 0;
            try
            {
                StreamWriter sw = new StreamWriter("etat\\EtatPriorite.txt");
                while(i < etatprio.Length)
                { 
                    sw.WriteLine(etatprio[i]);
                    i++;
                }
                sw.Close();
            }
            catch (Exception e)
            {
            }
        }

        public string LireEtatLog()
        {
            string etatlog = "";
            try
            {
                StreamReader sr = new StreamReader("etat\\EtatLog.txt");
                etatlog = sr.ReadLine();
                sr.Close();
            }
            catch (Exception e)
            {
            }
            return etatlog;
        }

        // open EtatLangue.txt to read the language codes ISO 3166-1
        public string LireEtatLangue(string etatlangue)
        {
            try
            {
                StreamReader sr = new StreamReader("etat\\EtatLangue.txt");
                etatlangue = sr.ReadLine();
                sr.Close();
            }
            catch (Exception e)
            {
            }
            return etatlangue;
        }

        public string[] LireEtatPriorite(string etatprio)
        {
            int i = 0;
            string[] etat = new string[20];
            try
            {
                StreamReader sr = new StreamReader("etat\\EtatPriorite.txt");

                while (sr.Peek() >= 0)
                {
                    etat[i] = sr.ReadLine();
                    i++;
                };
                sr.Close();
            }
            catch (Exception e)
            {
            }
            return etat;
        }

        // update the language choice with #lang and with the same attributes of language.json, these variables are use to update the text of the application
        public void ChangeLanguage()
        {
            //HOME MENU
            home = lang.home;
            save_menu = lang.save_menu;
            config_menu = lang.config_menu;
            exit = lang.exit;

             /*CONFIG MENU*/
             config_lang = lang.config_lang;
             config_log = lang.config_log;
             config_process = lang.config_process;
             config_extfile= lang.config_extfile;

            /*LOG MENU*/
            log_JSON = lang.log_JSON;
            log_XML = lang.log_XML;

            //SELECT LANG
            select_language = lang.select_language;
            lang_1 = lang.lang_1;
            lang_2 = lang.lang_2;
            lang_3 = lang.lang_3;
            lang_4 = lang.lang_4;

            //JOB ADD
            name_job = lang.name_job;
            file_src = lang.file_src;
            destination = lang.destination;
            jobtype = lang.jobtype;
            validpath = lang.validpath;
            validnumber = lang.validnumber;

            //JOB SELECTION
            save = lang.save;
            edit = lang.edit;
            delete = lang.delete;

            //JOB MENU
            file = lang.file;
            create_save = lang.create_save;
            run_all_save = lang.run_all_save;

            select = lang.select;
            back = lang.back;
            bye = lang.bye;

            /*JOB VUE*/
            fonct = lang.fonct;

            /*PROCESS VUE*/
            process_name= lang.process_name;
            process_select1 = lang.process_select1;
            process_select2 = lang.process_selected2;
            process_vue1 = lang.process_vue1;
            process_vue2 = lang.process_vue2;

            /*PRIO FILE*/
            prio_file = lang.prio_file;
            ext1 = lang.ext1;
            ext2 = lang.ext2;
            ext3 = lang.ext3;
            ext4 = lang.ext4;
            ext5 = lang.ext5;
            ext6 = lang.ext6;
            ext7 = lang.ext7;
            ext8 = lang.ext8;
        }

        //HOME MENU
        public String home { get; set; }
        public String save_menu { get; set; }
        public String config_menu { get; set; }
        public String exit { get; set; }

        /*CONFIG MENU*/

        public String config_lang { get; set; }
        public String config_log { get; set; }
        public String config_process { get; set; }
        public String config_extfile { get; set; }

        /*LOG MENU*/
        public String log_JSON { get; set; }
         public String log_XML { get; set; }

        //SELECT LANG
        public String select_language { get; set; }
        public String lang_1 { get; set; }
        public String lang_2 { get; set; }
        public String lang_3 { get; set; }
        public String lang_4 { get; set; }

        //JOB ADD
        public String name_job { get; set; }
        public String file_src { get; set; }
        public String destination { get; set; }
        public String jobtype { get; set; }
        public String validpath { get; set; }
        public String validnumber { get; set; }

        //JOB SELECTION
        public String save { get; set; }
        public String edit { get; set; }
        public String delete { get; set; }

        //JOB MENU
        public String file { get; set; }
        public String create_save { get; set; }
        public String run_all_save { get; set; }

        public String select { get; set; }
        public String back { get; set; }
        public String bye { get; set; }

        //JOB VUE
        public String fonct { get; set; }

        /*PROCESS VUE*/
        public String process_name { get; set; }
        public String process_select1 { get; set;}
        public String process_select2 { get; set; }
        public String process_vue1 { get; set; }
        public String process_vue2 { get; set; }

        /*PRIO FILE*/
        public String prio_file { get; set; }
        public String ext1 { get; set; }
        public String ext2 { get; set; }
        public String ext3 { get; set; }
        public String ext4 { get; set; }
        public String ext5 { get; set; }
        public String ext6 { get; set; }
        public String ext7 { get; set; }
        public String ext8 { get; set; }
    }
}
