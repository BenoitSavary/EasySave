using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EasySaveApp
{
    public class DisplayError: IDataErrorInfo
    {
        private String valeur;
        public String Valeur
        {
            get { return valeur; }
            set { valeur = value; }
        }

        private String chemin;
        public String Chemin
        {
            get { return chemin ; }
            set { chemin = value; }
        }

        public String Chemin2
        {
            get { return chemin; }
            set { chemin = value; }
        }

        public string this[string IfEmpty]
        {
            get
            {
                Regex rx = new Regex(@"^(?<ParentPath>(?:[a-zA-Z]\:|\\\\[\w\s\.]+\\[\w\s\.$]+)\\(?:[\w\s\.]+\\)*)(?<BaseName>[\w\s\.]*?)$");
/*                if (String.IsNullOrWhiteSpace(valeur))
                {
                    return "Valeur invalide";
                }
                else 
                {
                    return null;
                }*/
                if (!rx.IsMatch(chemin))
                {
                    return "Entrez un chemin de fichier valide";
                }
                else
                {
                    return null;
                }

            }
        }

    public string Error
        {
            get
            {
                return "";
            }
        }
    }
}
