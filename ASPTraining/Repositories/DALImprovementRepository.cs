using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASPTraining.Models;
using System.Data.Entity;

namespace ASPTraining.Repositories
{
    public class DALImprovementRepository : IImprovementsRepository
    {
        private ASPTraining.DAL.ASPTrainingEntities db = null;

        public DALImprovementRepository()
        {
            db = new ASPTraining.DAL.ASPTrainingEntities();
        }

        public IEnumerable<Models.IImprovement> SelectAll()
        {
            return (IEnumerable<Models.IImprovement>)db.Improvements.ToList();
        }

        public Models.IImprovement SelectByID(int id)
        {
            return (IImprovement)db.Improvements.Find(id);
        }

        public void Insert(Models.IImprovement improvement)
        {
            db.Improvements.Add((DAL.Improvement)improvement);
        }

        public void Update(Models.IImprovement improvement)
        {
            db.Entry(improvement).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            DAL.Improvement existing = db.Improvements.Find(id);
            db.Improvements.Remove(existing);
        }

        public void Save()
        {
            db.SaveChanges();
        }


        public IEnumerable<IStatus> AllStati()
        {
            return db.Status.ToList();
        }
    }
}