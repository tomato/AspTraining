using ASPTraining.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASPTraining.Repositories
{
    public class ImprovementsRepository : IImprovementsRepository
    {
        private ApplicationDbContext db = null;

        public ImprovementsRepository()
        {
            db = new ApplicationDbContext();
        }

        public IEnumerable<Models.Improvement> SelectAll()
        {
            return db.Improvements.ToList();
        }

        public Models.Improvement SelectByID(int id)
        {
            return db.Improvements.Find(id);
        }

        public void Insert(Models.Improvement improvement)
        {
            db.Improvements.Add(improvement);
        }

        public void Update(Models.Improvement improvement)
        {
            db.Entry(improvement).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Improvement existing = db.Improvements.Find(id);
            db.Improvements.Remove(existing);
        }

        public void Save()
        {
            db.SaveChanges();
        }


        public IEnumerable<Status> AllStati()
        {
            return db.Status.ToList();
        }
    }
}