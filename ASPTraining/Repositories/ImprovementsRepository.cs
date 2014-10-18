﻿using ASPTraining.Models;
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

        public IEnumerable<Models.IImprovement> SelectAll()
        {
            return db.Improvements.ToList();
        }

        public Models.IImprovement SelectByID(int id)
        {
            return db.Improvements.Find(id);
        }

        public void Insert(Models.IImprovement improvement)
        {
            db.Improvements.Add((Improvement)improvement);
        }

        public void Update(Models.IImprovement improvement)
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


        public IEnumerable<IStatus> AllStati()
        {
            return db.Statuses.ToList();
        }
    }
}