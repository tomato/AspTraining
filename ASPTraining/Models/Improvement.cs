using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPTraining.Models
{
    

    public class Improvement
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public int Status_ID { get; set; }
        public virtual Status Status { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }

    public class Status : IComparable<Status>
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public int CompareTo(Status other)
        {
            return this.Id.CompareTo(other.Id);
        }
    }
}