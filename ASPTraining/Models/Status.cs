namespace ASPTraining.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Status : IComparable<Status>
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int CompareTo(Status other)
        {
            return this.Id.CompareTo(other.Id);
        }
    }
}
