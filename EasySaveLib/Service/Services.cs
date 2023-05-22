using EasySaveLib.Model;
using EasySaveLib.Controller;
using EasySaveLib.Vue;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Xml.Serialization;
using static HomeController;
using Newtonsoft.Json;
using System.IO;
using System.Xml.Serialization;
using System.Reflection;
using EasySaveLib.Service;
using static System.Net.Mime.MediaTypeNames;

public class Services
{
    public string jsonString;
    public string jsonString2;

    static JsonSerializer serializer;
    public IShowJobEditVue Vue { get; set; }
    public Stockage Stockage { get; set; }
    public StockageLanguage stockLanguage { get; set; }
    public Ext Extensions { get; set; }
    public ExtensionsPrio ExtPrio { get; set; }

    public SoftwarePackage SoftwarePackage { get; set; }


    public Services(Stockage stockage, StockageLanguage? stockLang = null)
    {
        Stockage = stockage;
        stockLanguage = stockLang ?? new StockageLanguage();
        Extensions = new Ext(Stockage, stockLanguage);
        ExtPrio = new ExtensionsPrio(Stockage, this, stockLanguage);
        SoftwarePackage = new SoftwarePackage(Stockage, stockLang);
    }

    public ShowJobController Controller { get; set; }

    public void setController(ShowJobController controller)
    {
        Controller = controller;
    }
    /* Description : Create Job by adding a new object Save to a List
     * Paramaters  : Name of the job
     *               Source of the job
     *               Destination of the job
     *               type diff or complete
     * 
     */
    public void CreateJob(string nb, string name, string source, string destination, string type)
    {
        var src = new DirectoryInfo(source);
        int nbFiles = DirectoryInfoController.GetNomberOfFileInDirectory(src);
        Stockage.JobList.Add(new Save() { Name = name, Src = source, Dst = destination, Type = type, nbfile = nbFiles });
        serial();
    }

    /* Description : Delete job using index in the List
     * Parameter   : Index
     * 
     * 
     */

    public void DeleteJob(String jobselected)
    {
        int index = int.Parse(jobselected);
        Stockage.JobList.RemoveAt(index);
        File.Delete("serial.xml");
        serial();
    }

    /* Description : Editing job
     * Parameters : Array with name, source, destination and type of job
     *            : index of the job we want to edit
     * 
     */
    public void EditJob(String[] job, String jobselected)
    {
        DeleteJob(jobselected);
        var src = new DirectoryInfo(job[1]);
        int nbFiles = DirectoryInfoController.GetNomberOfFileInDirectory(src);
        int index = int.Parse(jobselected) - 1;
        Stockage.JobList.Insert(index, new Save() { Name = job[0], Src = job[1], Dst = job[2],Type = job[3] ,nbfile = nbFiles });
        File.Delete("serial.xml");
        serial();
    }

    /* Description : Get the object Save from the joblist using the index
     * Parameter   : Index
     * Return      : Object Save
     */
    public Save GetSave(string Jobselected)
    {
        int index = int.Parse(Jobselected);
        Console.WriteLine(Stockage.JobList.Count);
        Console.WriteLine("index" + index);
        if (Stockage.JobList.Count != 0)
        {

            return Stockage.JobList[index - 1];
        }
        else
            return null;
    }

    /* Description : Start the copy of the file completly or differentialy
     * Parameter   : Object Save 
     * 
     */
    public void copy(Save jobselected)
    {
        string sourcePath = jobselected.Src;
        string destinationPath = jobselected.Dst;

        string filename = "";
        string destname = "";

        var source = new DirectoryInfo(sourcePath);
        var dest = new DirectoryInfo(destinationPath);

        if (jobselected.Type == "Complete")
        {
            AddListPrio(jobselected, source, dest, jobselected);
            CompleteCopyAll(jobselected, source, dest, jobselected);
        }

        if (jobselected.Type == "Differentielle")
        {
            AddListPrio(jobselected, source, dest, jobselected);
            DifferencialCopyAll(jobselected, source, dest, jobselected);
        }
        File.Delete("serial.xml");
        serial();
    }

    public void AddListPrio(Save jobselected, DirectoryInfo _source, DirectoryInfo _target, Save save)
    {
        //Stockage.ListOfFile = new List<FileModel>();
        string sourcePath = jobselected.Src;
        string destinationPath = jobselected.Dst;

        var source = new DirectoryInfo(sourcePath);
        var dest = new DirectoryInfo(destinationPath);
        int nbFiles = DirectoryInfoController.GetNomberOfFileInDirectory(source);
        long dirSize = DirectoryInfoController.GetSizeOfFileInDirectory(source);

        FileInfo[] test = _source.GetFiles();

        Directory.CreateDirectory(_target.FullName);
        foreach (FileInfo fi in test)
        {
            string targetPath = Path.Combine(_target.FullName, fi.Name);
            string sourcePth = Path.Combine(_source.FullName, fi.Name);
            if (ExtPrio.checkExtensionsPrio(sourcePth))
            {
                Stockage.ListPrio.Add(new FileModel() { PathSrc = sourcePth, PathDst = targetPath, Size = fi.Length, Name = fi.Name });
            }
            else
            {
                Stockage.ListNoPrio.Add(new FileModel() { PathSrc = sourcePth, PathDst = targetPath, Size = fi.Length, Name = fi.Name });
            }
        }


        // Copy each subdirectory using recursion.
        foreach (DirectoryInfo diSourceSubDir in _source.GetDirectories())
        {
            string targetDirectoryPath = Path.Combine(_target.FullName, diSourceSubDir.Name);
            //Check if the directory already exist to decide if it is required to create a new one or not
            if (!Directory.Exists(targetDirectoryPath))
            {
                DirectoryInfo nextTargetSubDir = _target.CreateSubdirectory(diSourceSubDir.Name);
                AddListPrio(save, diSourceSubDir, nextTargetSubDir, save);
            }
            else
            {
                DirectoryInfo nextTargetSubDir = new DirectoryInfo(targetDirectoryPath);
                AddListPrio(save, diSourceSubDir, nextTargetSubDir, save);
            }
        }
    }

    private void CompleteCopyAll(Save jobselected, DirectoryInfo _source, DirectoryInfo _target, Save save)
    {

        string sourcePath = jobselected.Src;
        string destinationPath = jobselected.Dst;

        var source = new DirectoryInfo(sourcePath);
        var dest = new DirectoryInfo(destinationPath);
        int nbFiles = DirectoryInfoController.GetNomberOfFileInDirectory(source);
        long dirSize = DirectoryInfoController.GetSizeOfFileInDirectory(source);


        Stockage.ListOfFile.AddRange(Stockage.ListPrio);
        Stockage.ListOfFile.AddRange(Stockage.ListNoPrio);

        foreach (FileModel fi in Stockage.ListOfFile)
        {
            if (jobselected.Etat == "start" & !SoftwarePackage.checkprocess())
            {

                if (!File.Exists(fi.PathDst))
                {
                    //Copy the file and measure execution time
                    Stopwatch watch = new Stopwatch();
                    long TempsAvant = DateTime.Now.Ticks;
                    if (Extensions.checkExtensions(fi.PathSrc))
                    {
                        CryptoSoft(fi.PathSrc, fi.PathDst);
                        jobselected.nbfilescopied++;
                        jobselected.pourcent = (jobselected.nbfilescopied * jobselected.nbfile) / 100;
                        if (jobselected.nbfilescopied==jobselected.nbfile)
                        {
                            jobselected.nbfilescopied = 0;
                            jobselected.pourcent = 0;
                        }
                    }
                    else
                    {
                        System.IO.File.Copy(fi.PathSrc, fi.PathDst, true);
                        jobselected.nbfilescopied++;
                        jobselected.pourcent = (jobselected.nbfilescopied * jobselected.nbfile) / 100;
                        if (jobselected.nbfilescopied == jobselected.nbfile)
                        {
                            jobselected.nbfilescopied = 0;
                            jobselected.pourcent = 0;
                        }
                    }


                    long TempsApres = DateTime.Now.Ticks;
                    long temps = TempsApres - TempsAvant;
                    jobselected.timetransfert = temps / 10000;
                    jobselected.date = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    jobselected.Filesize = fi.Size;
                    jsonString = JsonConvert.SerializeObject(jobselected, Formatting.Indented);
                    sauvetatjson(jobselected, sourcePath, destinationPath, nbFiles, dirSize);
                }
            }


        }
        while (jobselected.Etat != "stop") ;
        // Copy each subdirectory using recursion.
        foreach (DirectoryInfo diSourceSubDir in _source.GetDirectories())
        {
            string targetDirectoryPath = Path.Combine(_target.FullName, diSourceSubDir.Name);

            //Check if the directory already exist to decide if it is required to create a new one or not
            if (!Directory.Exists(targetDirectoryPath))
            {
                DirectoryInfo nextTargetSubDir = _target.CreateSubdirectory(diSourceSubDir.Name);
                CompleteCopyAll(save, diSourceSubDir, nextTargetSubDir, save);
            }
            else
            {
                DirectoryInfo nextTargetSubDir = new DirectoryInfo(targetDirectoryPath);
                CompleteCopyAll(save, diSourceSubDir, nextTargetSubDir, save);
            }
        }
    }
    private void DifferencialCopyAll(Save jobselected, DirectoryInfo _source, DirectoryInfo _target, Save save)
    {
        string sourcePath = jobselected.Src;
        string destinationPath = jobselected.Dst;

        string filename = "";
        string destname = "";
        var source = new DirectoryInfo(sourcePath);
        var dest = new DirectoryInfo(destinationPath);
        int nbFiles = 0;
        nbFiles = DirectoryInfoController.GetNomberOfFileInDirectory(source);
        long dirSize = DirectoryInfoController.GetSizeOfFileInDirectory(source);

        Directory.CreateDirectory(_target.FullName);
        int i = 0;

        string[] destfile = System.IO.Directory.GetFiles(_target.FullName);
        string[] sourcefiles = System.IO.Directory.GetFiles(_source.FullName);

        if (destfile.Length == 0)
        {
            destfile = new string[1];
            destfile[0] = "0";
        }

        if (jobselected.Etat == "start" & !SoftwarePackage.checkprocess())
        {
            if (destfile.Length > sourcefiles.Length)
            {
                Stockage.ListOfFile.AddRange(Stockage.ListNoPrio);

                foreach (FileModel fi in Stockage.ListOfFile)
                {
                    if (jobselected.Etat == "start" & !SoftwarePackage.checkprocess())
                    {


                        if (!File.Exists(fi.PathDst))
                        {
                            Stopwatch watch = new Stopwatch();
                            watch.Start();
                            long TempsAvant = DateTime.Now.Ticks;
                            if (Extensions.checkExtensions(fi.PathSrc))
                            {
                                CryptoSoft(fi.PathSrc, fi.PathDst);
                                jobselected.nbfilescopied++;
                                jobselected.pourcent = (jobselected.nbfilescopied * jobselected.nbfile) / 100;
                                if (jobselected.nbfilescopied == jobselected.nbfile)
                                {
                                    jobselected.nbfilescopied = 0;
                                    jobselected.pourcent = 0;
                                }
                            }
                            else
                            {
                                System.IO.File.Copy(fi.PathSrc, fi.PathDst, true);
                                jobselected.nbfilescopied++;
                                jobselected.pourcent = (jobselected.nbfilescopied * jobselected.nbfile) / 100;
                                if (jobselected.nbfilescopied == jobselected.nbfile)
                                {
                                    jobselected.nbfilescopied = 0;
                                    jobselected.pourcent = 0;
                                }
                            }
                            long TempsApres = DateTime.Now.Ticks;
                            long temps = TempsApres - TempsAvant;
                            jobselected.timetransfert = temps / 10000;
                            jobselected.Filesize = fi.Size;
                            jobselected.date = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                            jsonString = JsonConvert.SerializeObject(jobselected, Formatting.Indented);
                            sauvetatjson(jobselected, sourcePath, destinationPath, nbFiles, dirSize);
                        }
                        else
                        {
                            string sourcehash = SHA256CheckSum(fi.PathSrc);
                            string desthash = SHA256CheckSum(fi.PathDst);

                            if (sourcehash != desthash)
                            {
                                Stopwatch watch = new Stopwatch();
                                long TempsAvant = DateTime.Now.Ticks;
                                if (Extensions.checkExtensions(fi.PathSrc))
                                {
                                    CryptoSoft(fi.PathSrc, fi.PathDst);
                                    jobselected.nbfilescopied++;
                                    jobselected.pourcent = (jobselected.nbfilescopied * 100) / jobselected.nbfile;
                                    if (jobselected.nbfilescopied == jobselected.nbfile)
                                    {
                                        jobselected.nbfilescopied = 0;
                                        jobselected.pourcent = 0;
                                    }
                                }
                                else
                                {
                                    System.IO.File.Copy(fi.PathSrc, fi.PathDst, true);
                                    jobselected.nbfilescopied++;
                                    jobselected.pourcent = (jobselected.nbfilescopied * 100) / jobselected.nbfile;
                                    if (jobselected.nbfilescopied == jobselected.nbfile)
                                    {
                                        jobselected.nbfilescopied = 0;
                                        jobselected.pourcent = 0;
                                    }
                                }
                                long TempsApres = DateTime.Now.Ticks;
                                long temps = TempsApres - TempsAvant;
                                jobselected.timetransfert = temps / 10000;
                                jobselected.Filesize = fi.Size;
                                jobselected.date = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                                jsonString = JsonConvert.SerializeObject(jobselected, Formatting.Indented);
                                sauvetatjson(jobselected, sourcePath, destinationPath, nbFiles, dirSize);
                            }
                        }
                        foreach (FileInfo file in _target.GetFiles())
                        {
                            if (File.Exists(fi.PathSrc))
                            {
                                destfile[i] = "0";
                            }
                        }
                        i++;
                    }
                }
            }
            else
            {
                Stockage.ListOfFile.AddRange(Stockage.ListNoPrio);

                foreach (FileModel fi in Stockage.ListOfFile)
                {
                    if (jobselected.Etat == "start" & !SoftwarePackage.checkprocess())
                    {
                        string targetPath = Path.Combine(_target.FullName, fi.Name);

                        if (!File.Exists(fi.PathDst))
                        {
                            Stopwatch watch = new Stopwatch();
                            long TempsAvant = DateTime.Now.Ticks;
                            if (Extensions.checkExtensions(fi.PathSrc))
                            {
                                CryptoSoft(fi.PathSrc, fi.PathDst);
                                jobselected.nbfilescopied++;
                                jobselected.pourcent = (jobselected.nbfilescopied * 100) / jobselected.nbfile;
                                if (jobselected.nbfilescopied == jobselected.nbfile)
                                {
                                    jobselected.nbfilescopied = 0;
                                    jobselected.pourcent = 0;
                                }
                            }
                            else
                            {
                                System.IO.File.Copy(fi.PathSrc, fi.PathDst, true);
                                jobselected.nbfilescopied++;
                                jobselected.pourcent = (jobselected.nbfilescopied * 100) / jobselected.nbfile;
                                if (jobselected.nbfilescopied == jobselected.nbfile)
                                {
                                    jobselected.nbfilescopied = 0;
                                    jobselected.pourcent = 0;
                                }
                            }

                            long TempsApres = DateTime.Now.Ticks;
                            long temps = TempsApres - TempsAvant;
                            jobselected.timetransfert = temps / 10000;
                            jobselected.Filesize = fi.Size;
                            jobselected.date = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                            jsonString = JsonConvert.SerializeObject(jobselected, Formatting.Indented);
                            sauvetatjson(jobselected, sourcePath, destinationPath, nbFiles, dirSize);
                        }

                        else
                        {
                            string sourcehash = SHA256CheckSum(fi.PathSrc);
                            string desthash = SHA256CheckSum(fi.PathDst);

                            if (sourcehash != desthash)
                            {
                                Stopwatch watch = new Stopwatch();
                                watch.Start();
                                long TempsAvant = DateTime.Now.Ticks;
                                if (Extensions.checkExtensions(fi.PathSrc))
                                {
                                    CryptoSoft(fi.PathSrc, fi.PathDst);
                                    jobselected.nbfilescopied++;
                                    jobselected.pourcent = (jobselected.nbfilescopied * 100) / jobselected.nbfile;
                                    if (jobselected.nbfilescopied == jobselected.nbfile)
                                    {
                                        jobselected.nbfilescopied = 0;
                                        jobselected.pourcent = 0;
                                    }
                                }
                                else
                                {
                                    System.IO.File.Copy(fi.PathSrc, fi.PathDst, true);
                                    jobselected.nbfilescopied++;
                                    jobselected.pourcent = (jobselected.nbfilescopied * 100) / jobselected.nbfile;
                                    if (jobselected.nbfilescopied == jobselected.nbfile)
                                    {
                                        jobselected.nbfilescopied = 0;
                                        jobselected.pourcent = 0;
                                    }
                                }
                                long TempsApres = DateTime.Now.Ticks;
                                long temps = TempsApres - TempsAvant;
                                jobselected.timetransfert = temps / 10000;
                                jobselected.Filesize = fi.Size;
                                jobselected.date = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                                jsonString = JsonConvert.SerializeObject(jobselected, Formatting.Indented);
                                sauvetatjson(jobselected, sourcePath, destinationPath, nbFiles, dirSize);
                                watch.Stop();
                            }

                        }
                        foreach (FileInfo file in _target.GetFiles())
                        {
                            if (File.Exists(fi.PathSrc))
                            {
                                destfile[i] = "0";
                            }
                        }
                        if (destfile.Length - 1 > i & destfile.Length != 1)
                        {
                            i++;
                        }
                    }
                }

            }
            if (jobselected.Etat == "stop")
            {
                
                jobselected.pourcent = 0;
                DifferencialCopyAll(save, source, dest, save);
            }

            foreach (string file in destfile)
            {
                if (file != "0")
                {
                    File.Delete(file);
                }
            }
        }
        serial();
    }
    /* Description : Hash the file given with SHA256
     * Parameter   : FilePath
     */
    public string SHA256CheckSum(string filePath)
    {
        using (SHA256 SHA256 = System.Security.Cryptography.SHA256.Create())
        {
            using (FileStream fileStream = File.OpenRead(filePath))
                return Convert.ToBase64String(SHA256.ComputeHash(fileStream));
        }
    }
    /* Description : Serialize in XML the List
     * 
     */
    public void serial()
    {

        //Nouveau Serialiser avec comme argument le type de l'element racine, List<Save>
        XmlSerializer serialXml = new XmlSerializer(typeof(List<Save>));

        using (Stream flux = new FileStream("serial.xml", FileMode.OpenOrCreate, FileAccess.Write))
        {
            serialXml.Serialize(flux, Stockage.JobList);
            flux.Close();
        }

    }

    public void serialString()
    {
        
        //Nouveau Serialiser avec comme argument le type de l'element racine, List<process>
        XmlSerializer serialXml = new XmlSerializer(typeof(List<process>));

        using (Stream flux = new FileStream("serialString.xml", FileMode.OpenOrCreate, FileAccess.Write))
        {
            serialXml.Serialize(flux, Stockage.ListOfProcess);
            flux.Close();
        }

    }

    public void serialExtensionPrio()
    {

        //Nouveau Serialiser avec comme argument le type de l'element racine, List<extensionprio>
        XmlSerializer serialXml = new XmlSerializer(typeof(List<extensionprio>));

        using (Stream flux = new FileStream("serialExtensionPrio.xml", FileMode.OpenOrCreate, FileAccess.Write))
        {
            serialXml.Serialize(flux, Stockage.ListOfExtensionsPrio);
            flux.Close();
        }

    }

    /* Description : DeSerialize in XML the List
     * 
     */
    public List<Save> deserial()
    {
        List<Save> taListe = null;
        XmlSerializer serializer = new XmlSerializer(typeof(List<Save>));
        Stream flux = File.OpenRead("serial.xml");
        taListe = (List<Save>)serializer.Deserialize(flux);
        flux.Close();

        return taListe;

    }
    public List<process> deserialString()
    {
        List<process> taListe = null;
        XmlSerializer serializer = new XmlSerializer(typeof(List<process>));
        Stream flux = File.OpenRead("serialString.xml");
        taListe = (List<process>)serializer.Deserialize(flux);
        flux.Close();

        return taListe;

    }

    public List<extensionprio> deserialExtensionPrio()
    {
        List<extensionprio> taListe = null;
        XmlSerializer serializer = new XmlSerializer(typeof(List<extensionprio>));
        Stream flux = File.OpenRead("serialExtensionPrio.xml");
        taListe = (List<extensionprio>)serializer.Deserialize(flux);
        flux.Close();

        return taListe;

    }

    public void sauvetatjson(Save jobselected, string source, string destname, int nbFiles, long dirSize)
    {
        string formatlog = "";
        formatlog = stockLanguage.LireEtatLog();

        string folderPath = "log\\";
        DirectoryInfo directory = new DirectoryInfo(folderPath);
        FileInfo[] files = directory.GetFiles();
        string latestFileNameWithoutExtension = "01012000";

        if (files.Length != 0)
        {
            FileInfo latestFile = files.OrderByDescending(f => f.CreationTime).First();

            latestFileNameWithoutExtension = Path.GetFileNameWithoutExtension(latestFile.Name);
        }



        string date1 = latestFileNameWithoutExtension;
        string date2 = DateTime.Now.ToString("ddMMyyyy");

        if (date1 != date2)
        {
            date1 = date2;
        }

        if (formatlog == "JSON")
        {
            File.AppendAllText("log\\" + date1 + ".json", "\n");
            File.AppendAllText("log\\" + date1 + ".json", jsonString);
        }
        else
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Save));
            using (FileStream fs = new FileStream("log\\" + date1 + ".xml", FileMode.Append))
            {
                xmlSerializer.Serialize(fs, jobselected);
                byte[] newLine = System.Text.Encoding.UTF8.GetBytes(Environment.NewLine);
                fs.Write(newLine, 0, newLine.Length);
            }
        }


        File.AppendAllText("etat\\" + date1 + ".json", "{");
        File.AppendAllText("etat\\" + date1 + ".json", "\n" + "Name :" + jobselected.Name + ",");
        File.AppendAllText("etat\\" + date1 + ".json", "\n" + "SourceFilePath :" + source + ",");
        File.AppendAllText("etat\\" + date1 + ".json", "\n" + "TargetFilePath :" + destname + ",");
        File.AppendAllText("etat\\" + date1 + ".json", "\n" + "State :" + jobselected.IsActive.ToString() + ",");
        File.AppendAllText("etat\\" + date1 + ".json", "\n" + "TotalFilesToCopy :" + nbFiles + ",");
        File.AppendAllText("etat\\" + date1 + ".json", "\n" + "TotalFilesToSize :" + dirSize + ",");
        File.AppendAllText("etat\\" + date1 + ".json", "\n" + "TotalFilesToDo :" + nbFiles + ",");
        File.AppendAllText("etat\\" + date1 + ".json", "\n" + "Progression :" + ",");
        File.AppendAllText("etat\\" + date1 + ".json", "\n" + "}" + "\n");
    }

    public void CryptoSoft(string source, string destname)
    {
        List<string> arg = new List<string>();
        arg.Add(source);
        arg.Add(destname);
        arg.Add("benoit51");
        Process CryptoSoft = Process.Start("CryptoSoft.exe", arg);
        //CryptoSoft.Kill();
        //long time = CryptoSoft.StartTime.Ticks - CryptoSoft.ExitTime.Ticks;
    }
}



