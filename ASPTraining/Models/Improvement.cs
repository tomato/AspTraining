using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ASPTraining.Models
{
    
    [DataContract]
    public class Improvement
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Description { get; set; }

        [IgnoreDataMember]
        public int StatusID { get; set; }

        [DataMember]
        public virtual Status Status { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }

    public class Status : IComparable<Status>
    {
        public int ID { get; set; }
        public string Description { get; set; }

        public int CompareTo(Status other)
        {
            return this.ID.CompareTo(other.ID);
        }
    }
}