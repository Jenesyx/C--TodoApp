using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TodoApp.Models
{
    public partial class Projekte
    {
        public Projekte()
        {
            Todos = new HashSet<Todos>();
        }

        public int ProjektId { get; set; }
        public string Name { get; set; }
        public string Beschreibung { get; set; }
        public int? MitarbeiterId { get; set; }

        public virtual Mitarbeiter Mitarbeiter { get; set; }
        public virtual ICollection<Todos> Todos { get; set; }
    }
}
