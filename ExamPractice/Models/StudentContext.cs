using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPractice.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext() : base("MyConnection") { }

        public DbSet<Student> Students { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasIndex(e => e.PassNumber).IsUnique();
        }
    }
}
