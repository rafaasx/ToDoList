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
        /// <summary>
        /// Id da Tarefa
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Título da Tarefa
        /// </summary>
        [StringLength(50)]
        [Required]
        public string Titulo { get; set; }
        /// <summary>
        ///  Descrição da Tarefa
        /// </summary>
        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string Descricao { get; set; }
        /// <summary>
        /// Data de Criação da Tarefa
        /// </summary>
        public DateTime DataCriacao { get; set; }
        /// <summary>
        /// Data de Conclusão da Tarefa
        /// </summary>
        public DateTime? DataConclusao { get; set; }
        /// <summary>
        /// Data de Exclusão da Tarefa
        /// </summary>
        public DateTime? DataExclusao { get; set; }
        /// <summary>
        /// Data de Edição da Tarefa
        /// </summary>
        public DateTime? DataEdicao { get; set; }
        /// <summary>
        /// Status concluído
        /// </summary>
        public bool Status { get; set; }
    }
}