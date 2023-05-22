using EasySaveLib;
using System.Reflection.Metadata.Ecma335;
namespace EasySaveLib.Model
{
    public class Stockage
    {
        public Stockage()
        {
            this.JobList = new List<Save>();
            NumberOfJob=0;
            this.ListOfProcess = new List<process>();
            this.ListOfExtensions = new List<extension>();
            this.ListOfExtensionsPrio = new List<extensionprio>();
            this.ListOfFile = new List<FileModel>();
            this.ListPrio = new List<FileModel>();
            this.ListNoPrio = new List<FileModel>();
            FileSizeMax=0;
            this.EtatServeur = null;
        }

        public List<Save> JobList { get; set; }

        public int NumberOfJob { get; set; }
        public long FileSizeMax { get; set; }

        public List<process> ListOfProcess { get; set; }

        public List<extension> ListOfExtensions { get; set; }

        public List<extensionprio> ListOfExtensionsPrio { get; set; }
        public List<FileModel> ListOfFile { get; set; }
        public List<FileModel> ListPrio { get; set; }
        public List<FileModel> ListNoPrio { get; set; }
        public string EtatServeur { get; set; }
    }
}