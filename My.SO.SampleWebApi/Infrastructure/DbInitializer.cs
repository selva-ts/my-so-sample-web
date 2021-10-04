using My.SO.SampleWebApi.Models;
using System;
using System.Linq;

namespace My.SO.SampleWebApi.Infrastructure
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Students.Any())
            {
                return;
            }

            var students = new Student[]
            {
                new Student { FirstMidName = "Carson", LastName = "Alexander", EnrollmentDate = DateTime.Parse("2015-09-01") },
                new Student { FirstMidName = "Meredith",  LastName = "Alonso", EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Student { FirstMidName = "Arturo", LastName = "Anand", EnrollmentDate = DateTime.Parse("2013-09-01") },
                new Student { FirstMidName = "Gytis", LastName = "Barzdukas", EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Student { FirstMidName = "Yan", LastName = "Li", EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Student { FirstMidName = "Peggy", LastName = "Justice", EnrollmentDate = DateTime.Parse("2011-09-01") },
                new Student { FirstMidName = "Laura", LastName = "Norman", EnrollmentDate = DateTime.Parse("2013-09-01") },
                new Student { FirstMidName = "Nino", LastName = "Olivetto", EnrollmentDate = DateTime.Parse("2015-09-01") }
            };
            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();
        }
    }
}
