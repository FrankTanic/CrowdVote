using System;
using System.ComponentModel.DataAnnotations;

namespace CrowdVote.Models
{
    public class Link
    {
        public int ID { get; set; }

        [Display(Name = "Title of the page")]
        public string Title { get; set; }

        [Required(ErrorMessage = "You need to specify the URL, otherwise people can't visit the page you found")]
        [Display(Name = "URL of the page")]
        [Url(ErrorMessage = "This is not a valid Url")]
        public string Url { get; set; }

        public int VoteCount { get; set; }
    }
}