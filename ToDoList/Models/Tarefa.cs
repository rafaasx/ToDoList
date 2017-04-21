using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ToDoList.Models
{
    [Table("Tarefa")]
    public class Tarefa
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        [Required]
        public string Titulo { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataConclusao { get; set; }
        public DateTime? DataExclusao { get; set; }
        public DateTime? DataEdicao { get; set; }
        public bool Status { get; set; }
    }
}