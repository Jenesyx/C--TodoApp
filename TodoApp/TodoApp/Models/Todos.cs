using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TodoApp.Models
{
    public partial class Todos
    {
        public Todos()
        {
            MitarbeiterTodo = new HashSet<MitarbeiterTodo>();
        }

        public int TodoId { get; set; }
        public string Name { get; set; }
        public string Beschreibung { get; set; }
        public int? Status { get; set; }
        public int? ProjektId { get; set; }

        public virtual Projekte Projekt { get; set; }
        public virtual ICollection<MitarbeiterTodo> MitarbeiterTodo { get; set; }
    }
}
