using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class TarefaController : ApiController
    {
        private Context db = new Context();
        /// <summary>
        /// /Get
        /// </summary>
        /// <returns></returns>
        public IQueryable<TarefaDTO> GetTarefas()
        {
            var model = db.Tarefa.AsQueryable();

            return model.Select(TarefaDTO.SELECT).Where(x => x.DataExclusao == null).OrderBy(x => x.Status);
        }

        /// <summary>
        /// Get/_id
        /// </summary>
        /// <param name="id">Id Tarefa</param>
        /// <returns></returns>
        [ResponseType(typeof(TarefaDTO))]
        public async Task<IHttpActionResult> GetTarefa(int id)
        {
            var model = await db.Tarefa.Select(TarefaDTO.SELECT).FirstOrDefaultAsync(x => x.Id == id);
            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        /// <summary>
        /// Put/_id
        /// </summary>
        /// <param name="id">Id Tarefa</param>
        /// <param name="model">Tarefa</param>
        /// <returns></returns>
        public async Task<IHttpActionResult> PutTarefa(int id, Tarefa model)
        {
            model.DataConclusao = model.Status == true ? (DateTime?)DateTime.Now : null;
            model.DataEdicao = DateTime.Now;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.Id)
            {
                return BadRequest();
            }

            db.Entry(model).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TarefaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Post/_id
        /// </summary>
        /// <param name="model">Tarefa</param>
        /// <returns></returns>
        [ResponseType(typeof(TarefaDTO))]
        public async Task<IHttpActionResult> PostTarefa(Tarefa model)
        {
            model.DataConclusao = null;
            model.DataEdicao = null;
            model.DataExclusao = null;
            model.DataCriacao = DateTime.Now;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            db.Tarefa.Add(model);
            await db.SaveChangesAsync();
            var ret = await db.Tarefa.Select(TarefaDTO.SELECT).FirstOrDefaultAsync(x => x.Id == model.Id);
            return CreatedAtRoute("DefaultApi", new { id = model.Id }, model);
        }

        /// <summary>
        /// Delete/_id
        /// </summary>
        /// <param name="id">Id Tarefa</param>
        /// <returns></returns>
        [ResponseType(typeof(TarefaDTO))]
        public async Task<IHttpActionResult> DeleteTarefa(int id)
        {
            Tarefa model = await db.Tarefa.FindAsync(id);

            if (model == null)
            {
                return NotFound();
            }
            model.DataExclusao = DateTime.Now;
            db.Entry(model).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TarefaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TarefaExists(int id)
        {
            return db.Tarefa.Count(e => e.Id == id) > 0;
        }

    }
}