using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TodoAppPC.Models
{
    public partial class Mitarbeiter
    {
        public Mitarbeiter()
        {
            MitarbeiterTodo = new HashSet<MitarbeiterTodo>();
            Projekte = new HashSet<Projekte>();
        }

        public int MitarbeiterId { get; set; }
        public string Name { get; set; }
        public int? Admin { get; set; }

        public virtual ICollection<MitarbeiterTodo> MitarbeiterTodo { get; set; }
        public virtual ICollection<Projekte> Projekte { get; set; }
    }
}
