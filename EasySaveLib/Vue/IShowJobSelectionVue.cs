﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasySaveLib.Model;

namespace EasySaveLib.Vue
{
    public interface IShowJobSelectionVue: IVue
    {
        public void ShowJobsSelection(Save choice, String index);
    }
}