using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CrowdVote.Models
{
    public class CrowdVoteDbContext : DbContext
    {
        public CrowdVoteDbContext()
            : base("CrowdVoteDbContext")
        {
        }

        public DbSet<Category> Categories { get; set; }

    }
}