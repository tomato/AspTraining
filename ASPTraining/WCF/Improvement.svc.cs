using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ASPTraining.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Improvement" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Improvement.svc or Improvement.svc.cs at the Solution Explorer and start debugging.
    public class Improvement : IImprovement
    {

        public Models.Improvement GetImprovement(int id)
        {
            var repo = new Repositories.ImprovementsRepository();
            return repo.SelectByID(id);
        }
    }
}
