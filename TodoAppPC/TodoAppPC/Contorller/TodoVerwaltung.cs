using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppPC.Models;

namespace TodoAppPC.Contorller
{
    internal class TodoVerwaltung
    {
        private TodoAppContext ctx;

        public TodoVerwaltung(TodoAppContext ctx)
        {
            this.ctx = ctx;
        }

        public List<Todos> GetTodos()
        {
            var Todo = ctx.Todos.ToList();
            return Todo;
        }

        public void CreateTodo(string name, string description, int status, int projectId, int mitarbeiterId)
        {
            var newTodo = new Todos
            {
                Name = name,
                Beschreibung = description,
                Status = status,
                ProjektId = projectId
            };
            ctx.Todos.Add(newTodo);
            ctx.SaveChanges();

            var newMitarbeiterTodo = new MitarbeiterTodo
            {
                MitarbeiterId = mitarbeiterId,
                TodoId = newTodo.TodoId
            };
            ctx.MitarbeiterTodo.Add(newMitarbeiterTodo);
            ctx.SaveChanges();
        }
        public List<Todos> GetTodosByProjectId(int projectId)
        {
            return ctx.Todos.Where(t => t.ProjektId == projectId).ToList();
        }

        public void UpdateTodo(int todoId, string name, string description, int? status)
        {
            var todo = ctx.Todos.FirstOrDefault(t => t.TodoId == todoId);
            if (todo != null)
            {
                todo.Name = name;
                todo.Beschreibung = description;
                todo.Status = status;
                ctx.SaveChanges();
            }
        }


        public void DeleteTodo(int todoId)
        {
            var relatedEntries = ctx.MitarbeiterTodo.Where(mt => mt.TodoId == todoId).ToList();
            foreach (var entry in relatedEntries)
            {
                ctx.MitarbeiterTodo.Remove(entry);
            }
            ctx.SaveChanges();

            var todo = ctx.Todos.Find(todoId);
            if (todo != null)
            {
                ctx.Todos.Remove(todo);
                ctx.SaveChanges();
            }
        }

    }
}
