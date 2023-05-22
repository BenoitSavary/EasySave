namespace EasySaveLib.Model
{
    public class Save
    {
        public string Name { get; set; }


        public string Src { get; set; }


        public string Dst { get; set; }

        public bool IsActive { get; set; }

        public long Filesize { get; set; }

        
        public long timetransfert { get; set; }

        public int nbfile { get; set; }

        public int nbfilescopied { get; set; }

        public int pourcent { get; set; }
        public string date { get; set; }

        public string Type { get; set; }

        public string Etat { get; set; }

    }
}
