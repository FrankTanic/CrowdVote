using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CrowdVote.Models
{
    public class Topic
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "You have to fill in a topic if you want people to find links for you")]
        public string Title { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Link> Links { get; set; }
    }
}