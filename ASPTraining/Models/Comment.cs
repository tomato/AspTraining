using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASPTraining.Models
{
    public interface IComment
    {
        int Id { get; set; }
        string Description { get; set; }
        string User { get; set; }
        DateTime CreatedDateTime { get; set; }
        IImprovement Improvement { get; set; }
    }

    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required(AllowEmptyStrings=false), MaxLength(500, ErrorMessage="Your comment is too long")]
        public string Description { get; set; }

        [Required]
        public string User { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDateTime { get; set; }

        public Improvement Improvement { get; set; }
    }
}