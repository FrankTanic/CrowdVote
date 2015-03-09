using System;
using System.Collections.Generic;

namespace CrowdVote.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Topic> Topics { get; set; }
    }
}