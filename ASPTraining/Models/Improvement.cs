using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPTraining.Models
{
    public interface IImprovement
    {
        int ID  { get; set; }
        string Description { get; set; }
        int StatusID { get; set; }
        IStatus Status { get; set; } 
        ICollection<IComment> Comments { get; set; } 
    }

    public class Improvement : IImprovement
    {
        public int ID { get; set; }
        public string Description { get; set; }

        public int StatusID { get; set; }
        public virtual IStatus Status { get; set; }

        public ICollection<IComment> Comments { get; set; }
    }

    public interface IStatus : IComparable<IStatus>
    {
        int ID { get; set; }
        string Description { get; set; }
    }

    public class Status : IComparable<IStatus>, IStatus
    {
        public int ID { get; set; }
        public string Description { get; set; }

        public int CompareTo(IStatus other)
        {
            return this.ID.CompareTo(other.ID);
        }
    }
}