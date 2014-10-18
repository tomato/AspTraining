namespace ASPTraining.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Improvement
    {
        public Improvement()
        {
            Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        public string Description { get; set; }

        public int StatusID { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual Status Status { get; set; }
    }
}
