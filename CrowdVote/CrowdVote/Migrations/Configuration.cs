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
            context.Category.AddOrUpdate(
                i => i.ID,
                new Category { Title = "AJAX"},
                new Category { Title = "ASP.NET MVC"},
                new Category { Title = "C++"},
                new Category { Title = "Javascript"},
                new Category { Title = "Laravel"},
                new Category { Title = "Lua"},
                new Category { Title = "Node.js"},
                new Category { Title = "PHP"},
                new Category { Title = "Python"},
                new Category { Title = "Rails"},
                new Category { Title = "Ruby"},
                new Category { Title = "Small Basic"},
                new Category { Title = "Xamarin Forms"}
                );
        }
    }
}
