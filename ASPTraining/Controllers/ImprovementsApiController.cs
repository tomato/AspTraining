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
using ASPTraining.Models;

namespace ASPTraining.Controllers
{
    public class ImprovementsApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ImprovementsApi
        public IQueryable<Improvement> GetImprovements()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.Improvements.Include(i => i.Status).Include(i => i.Comments).AsNoTracking();
        }

        // GET: api/ImprovementsApi/5
        [ResponseType(typeof(Improvement))]
        public IHttpActionResult GetImprovement(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            Improvement improvement = db.Improvements.Include("Status").First(i => i.ID == id);
            if (improvement == null)
            {
                return NotFound();
            }

            return Ok(improvement);
        }

        // PUT: api/ImprovementsApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutImprovement(int id, Improvement improvement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != improvement.ID)
            {
                return BadRequest();
            }

            db.Entry(improvement).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImprovementExists(id))
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

        // POST: api/ImprovementsApi
        [ResponseType(typeof(Improvement))]
        public IHttpActionResult PostImprovement(Improvement improvement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Improvements.Add(improvement);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = improvement.ID }, improvement);
        }

        // DELETE: api/ImprovementsApi/5
        [ResponseType(typeof(Improvement))]
        public IHttpActionResult DeleteImprovement(int id)
        {
            Improvement improvement = db.Improvements.Find(id);
            if (improvement == null)
            {
                return NotFound();
            }

            db.Improvements.Remove(improvement);
            db.SaveChanges();

            return Ok(improvement);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ImprovementExists(int id)
        {
            return db.Improvements.Count(e => e.ID == id) > 0;
        }
    }
}