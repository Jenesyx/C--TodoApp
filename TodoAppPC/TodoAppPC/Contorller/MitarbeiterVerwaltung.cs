using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppPC.Models;

namespace TodoAppPC.Contorller
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

        // This work!
        public Mitarbeiter GetUserByUsername(string username)
        {
            return ctx.Mitarbeiter.FirstOrDefault(m => m.Name == username);
        }

        public bool IsAdmin(string username)
        {
            var user = ctx.Mitarbeiter.FirstOrDefault(m => m.Name == username);
            return user != null && user.Admin == 1;
        }

        public void UpdateProject(Projekte project)
        {
            var existingProject = ctx.Projekte.Find(project.ProjektId);
            if (existingProject != null)
            {
                existingProject.Name = project.Name;
                existingProject.Beschreibung = project.Beschreibung;
                ctx.SaveChanges();
            }
        }

        public void DeleteProject(int projectId)
        {
            var project = ctx.Projekte.Find(projectId);
            if (project != null)
            {
                ctx.Projekte.Remove(project);
                ctx.SaveChanges();
            }
        }
    }
}
