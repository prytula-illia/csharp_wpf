namespace ExamPractice.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    internal sealed class Configuration : DbMigrationsConfiguration<ExamPractice.Models.StudentContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ExamPractice.Models.StudentContext context)
        {
            context.Students.AddOrUpdate(x => x.Id,

                new Student() { Id = 1, Name = "Genadiy", Surname = "Gorin", DateOfBirth = new DateTime(1984, 5, 10), PassNumber = 12345 },
                new Student() { Id = 2, Name = "Victoria", Surname = "Lolik", DateOfBirth = new DateTime(2000, 2, 1), PassNumber = 12347 },
                new Student() { Id = 3, Name = "Joseph", Surname = "Stalin", DateOfBirth = new DateTime(1999, 6, 5), PassNumber = 12145 },
                new Student() { Id = 4, Name = "Erik", Surname = "Cartman", DateOfBirth = new DateTime(2006, 2, 15), PassNumber = 12325 },
                new Student() { Id = 5, Name = "Shrek", Surname = "Shrekovich", DateOfBirth = new DateTime(2010, 1, 3), PassNumber = 12655 }
            );
        }
    }
}
