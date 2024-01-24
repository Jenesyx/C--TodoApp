using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Models;

namespace TodoApp.Controller
{
    internal class ProjektVerwaltung
    {
        private TodoAppContext ctx;
        public ProjektVerwaltung(TodoAppContext ctx)
        {
            this.ctx = ctx;
        }

        public List<Projekte> GetProjekte()
        {
            var projekt = ctx.Projekte.ToList();
            return projekt;
        }
    }

}
