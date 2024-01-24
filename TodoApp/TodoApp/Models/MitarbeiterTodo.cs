using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TodoApp.Models
{
    public partial class MitarbeiterTodo
    {
        public int MitarbeiterTodoId { get; set; }
        public int? MitarbeiterId { get; set; }
        public int? TodoId { get; set; }

        public virtual Mitarbeiter Mitarbeiter { get; set; }
        public virtual Todos Todo { get; set; }
    }
}
