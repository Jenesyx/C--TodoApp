﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppPC.Models;

namespace TodoAppPC.Contorller
{
    internal class IO_controller
    {
        private TodoAppContext ctx = new TodoAppContext();
        public MitarbeiterVerwaltung Mv;
        public ProjektVerwaltung Pv;
        public TodoVerwaltung Tv;
        public IO_controller()
        {
            Mv = new MitarbeiterVerwaltung(ctx);
            Pv = new ProjektVerwaltung(ctx);
            Tv = new TodoVerwaltung(ctx);
        }
    }
}
