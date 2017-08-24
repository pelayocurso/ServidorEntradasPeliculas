using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ServidorEntradasPeliculas.Models;
using System.Web.Http.Cors;

namespace ServidorEntradasPeliculas.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EntradasController : ApiController
    {
        public IEntradasService entradasService;
        public EntradasController(IEntradasService entradasService)
        {
            this.entradasService = entradasService;
        }

        // POST: api/Entradas
        [ResponseType(typeof(Entrada))]
        public IHttpActionResult PostEntrada(Entrada entrada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            entrada = entradasService.Create(entrada);
            return CreatedAtRoute("DefaultApi", new { id = entrada.Id }, entrada);
        }

        // GET: api/Entradas/5
        [ResponseType(typeof(Entrada))]
        public IHttpActionResult GetEntrada(long id)
        {
            Entrada entrada = entradasService.Read(id);
            if (entrada == null)
            {
                return NotFound();
            }

            return Ok(entrada);
        }

        // GET: api/Entradas
        public IQueryable<Entrada> GetEntradas()
        {
            return entradasService.ReadAll();
        }

        // PUT: api/Entradas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEntrada(long id, Entrada entrada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != entrada.Id)
            {
                return BadRequest();
            }

            try
            {
                entradasService.Update(id, entrada);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Entradas/5
        [ResponseType(typeof(Entrada))]
        public IHttpActionResult DeleteEntrada(long id)
        {
            Entrada entrada;

            try
            {
                entrada = entradasService.Delete(id);
            }
            catch (Exception)
            {
                return NotFound();
            }
            return Ok(entrada);
        }
    }