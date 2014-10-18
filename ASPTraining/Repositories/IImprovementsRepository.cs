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
        IEnumerable<IImprovement> SelectAll();
        IImprovement SelectByID(int id);
        void Insert(IImprovement improvement);
        void Update(IImprovement improvement);
        void Delete(int id);
        void Save();
        IEnumerable<IStatus> AllStati();
    }
}
