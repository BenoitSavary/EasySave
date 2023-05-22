using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace EasySaveLib.Service
{
    public class MonoInstance
    {
        private static Mutex mutex = null;

        public void mono()
        {
            const string appName = "EasySave";
            bool createdNew;

            mutex = new Mutex(true, appName, out createdNew);

            if (!createdNew)
            {
                Environment.Exit(0);
                return;
            }
            Console.WriteLine("EasySave started !");
        }
    }
}

