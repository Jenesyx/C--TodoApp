using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppPC.Models;

namespace TodoAppPC.Contorller
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

        public void CreateProject(string name, string description, int mitarbeiterId)
        {
            Projekte newProject = new Projekte
            {
                Name = name,
                Beschreibung = description,
                MitarbeiterId = mitarbeiterId
            };

            ctx.Projekte.Add(newProject);
            ctx.SaveChanges();
        }

    }
}
