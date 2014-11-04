using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ASPTraining.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IImprovement" in both code and config file together.
    [ServiceContract(Namespace="//Computacenter.com")]
    public interface IImprovement
    {
        [OperationContract(ProtectionLevel=ProtectionLevel.None)]
        Models.Improvement GetImprovement(int id);
    }
}
