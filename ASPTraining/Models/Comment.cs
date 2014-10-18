namespace ASPTraining.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comment
    {
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        public string User { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int? Improvement_Id { get; set; }

        public virtual Improvement Improvement { get; set; }
    }
}
