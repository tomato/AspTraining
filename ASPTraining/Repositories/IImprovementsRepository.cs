using ASPTraining.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPTraining.Repositories
{
    public interface IImprovementsRepository
    {
        IEnumerable<Improvement> SelectAll();
        Improvement SelectByID(int id);
        void Insert(Improvement improvement);
        void Update(Improvement improvement);
        void Delete(int id);
        void Save();
    }
}
