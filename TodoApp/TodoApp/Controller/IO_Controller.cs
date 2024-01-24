using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Models;

namespace TodoApp.Controller
{
    internal class IO_controller
    {
        private TodoAppContext ctx = new TodoAppContext();
        public MitarbeiterVerwaltung Mv;
        public ProjektVerwaltung Pv;
        public IO_controller()
        {
            Mv = new MitarbeiterVerwaltung(ctx);
            Pv = new ProjektVerwaltung(ctx);
        }
    }

}
