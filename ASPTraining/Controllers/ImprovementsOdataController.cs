using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using ASPTraining.Models;

namespace ASPTraining.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using ASPTraining.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Improvement>("ImprovementsOdata");
    builder.EntitySet<Comment>("Comments"); 
    builder.EntitySet<Status>("Statuses"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class ImprovementsOdataController : ODataController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: odata/ImprovementsOdata
        [EnableQuery]
        public IQueryable<Improvement> GetImprovementsOdata()
        {
            return db.Improvements;
        }

        // GET: odata/ImprovementsOdata(5)
        [EnableQuery]
        public SingleResult<Improvement> GetImprovement([FromODataUri] int key)
        {
            return SingleResult.Create(db.Improvements.Where(improvement => improvement.ID == key));
        }

        // PUT: odata/ImprovementsOdata(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Improvement> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Improvement improvement = db.Improvements.Find(key);
            if (improvement == null)
            {
                return NotFound();
            }

            patch.Put(improvement);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImprovementExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(improvement);
        }

        // POST: odata/ImprovementsOdata
        public IHttpActionResult Post(Improvement improvement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Improvements.Add(improvement);
            db.SaveChanges();

            return Created(improvement);
        }

        // PATCH: odata/ImprovementsOdata(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Improvement> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Improvement improvement = db.Improvements.Find(key);
            if (improvement == null)
            {
                return NotFound();
            }

            patch.Patch(improvement);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImprovementExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(improvement);
        }

        // DELETE: odata/ImprovementsOdata(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Improvement improvement = db.Improvements.Find(key);
            if (improvement == null)
            {
                return NotFound();
            }

            db.Improvements.Remove(improvement);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/ImprovementsOdata(5)/Comments
        [EnableQuery]
        public IQueryable<Comment> GetComments([FromODataUri] int key)
        {
            return db.Improvements.Where(m => m.ID == key).SelectMany(m => m.Comments);
        }

        // GET: odata/ImprovementsOdata(5)/Status
        [EnableQuery]
        public SingleResult<Status> GetStatus([FromODataUri] int key)
        {
            return SingleResult.Create(db.Improvements.Where(m => m.ID == key).Select(m => m.Status));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ImprovementExists(int key)
        {
            return db.Improvements.Count(e => e.ID == key) > 0;
        }
    }
}
