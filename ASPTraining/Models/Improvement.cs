using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPTraining.Models
{
    public enum Status
    {
        ToDo,
        InProgress,
        Done
    }

    public class Improvement
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
    }
}