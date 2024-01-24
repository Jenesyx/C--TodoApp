using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Models;

namespace TodoApp.Controller
{
    internal class MitarbeiterVerwaltung
    {
        private TodoAppContext ctx;
        public MitarbeiterVerwaltung(TodoAppContext ctx)
        {
            this.ctx = ctx;
        }

        public Array MitarbeiterName()
        {
            var Namen = ctx.Mitarbeiter.Select(m => m.Name).ToArray();
            return Namen;
        }
    }

}
