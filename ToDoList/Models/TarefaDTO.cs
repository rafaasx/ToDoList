using System;

namespace ToDoList.Models
{
	public class TarefaDTO
    {
		public System.Int32 Id { get; set; }
		public System.String Titulo { get; set; }
		public System.String Descricao { get; set; }
		public System.DateTime DataCriacao { get; set; }
		public System.DateTime? DataConclusao { get; set; }
		public System.DateTime? DataExclusao { get; set; }
		public System.DateTime? DataEdicao { get; set; }
		public System.Boolean Status { get; set; }

        public static System.Linq.Expressions.Expression<Func<Tarefa, TarefaDTO>> SELECT =
            x => new  TarefaDTO
            {
                Id = x.Id,
                Titulo = x.Titulo,
                Descricao = x.Descricao,
                DataCriacao = x.DataCriacao,
                DataConclusao = x.DataConclusao,
                DataExclusao = x.DataExclusao,
                DataEdicao = x.DataEdicao,
                Status = x.Status,
            };

	}
}