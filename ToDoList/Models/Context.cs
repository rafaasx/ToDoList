namespace ToDoList.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class Context : DbContext
    {
        public Context() : base("name=Todolist")
        {
        }

        public DbSet<Tarefa> Tarefa { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
