namespace Books.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Books.Data.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Books.Data.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            Repository repo = new Repository();

            int b = context.Books.Count();
            int g = context.Genres.Count();
            int s = context.Subjects.Count();
            if (b == 0 && g == 0 && s == 0)
            {
                context.Books.AddRange(repo.Books);
                context.Genres.AddRange(repo.GenresRep);
                context.Subjects.AddRange(repo.SubjectsRep);
                context.SaveChanges();
            }
        }
    }
}
