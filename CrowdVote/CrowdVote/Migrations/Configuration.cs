namespace CrowdVote.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using CrowdVote.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<CrowdVote.Models.CrowdVoteDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CrowdVote.Models.CrowdVoteDbContext context)
        {
            context.Subjects.AddOrUpdate(
                i => i.ID,
                new Subject { Title = "AJAX"},
                new Subject { Title = "ASP.NET MVC"},
                new Subject { Title = "C++"},
                new Subject { Title = "Javascript"},
                new Subject { Title = "Laravel"},
                new Subject { Title = "Lua"},
                new Subject { Title = "Node.js"},
                new Subject { Title = "PHP"},
                new Subject { Title = "Python"},
                new Subject { Title = "Rails"},
                new Subject { Title = "Ruby"},
                new Subject { Title = "Small Basic"},
                new Subject { Title = "Xamarin Forms"}
                );
        }
    }
}
