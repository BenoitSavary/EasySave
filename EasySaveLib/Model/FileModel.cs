using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveLib.Model
{
    public class FileModel
    {
        public string Name { get; set; }
        public string PathDst { get; set; }
        public string PathSrc { get; set; }
        public long Size { get; set; }
    }
}
