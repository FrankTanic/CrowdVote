using System;
using System.Collections.Generic;

namespace CrowdVote.Models
{
    public class Subject
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}