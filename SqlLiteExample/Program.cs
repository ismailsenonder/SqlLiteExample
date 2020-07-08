using SqlLiteExample.Models;
using System;
using System.IO;
using System.Linq;

namespace SqlLiteExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string dbName = "ExamlpeDB.db";
            if (File.Exists(dbName))
            {
                File.Delete(dbName);
            }
            using (var dbContext = new ExampleDbContext())
            {
                //Ensure database is created
                dbContext.Database.EnsureCreated();
                if (!dbContext.Announements.Any())
                {
                    dbContext.Announements.AddRange(new Announement[]
                        {
                             new Announement{ Id=1, Title="Awesome Announcement", Description="Lorem ipsum", CreateDate = DateTime.Now },
                             new Announement{ Id=2, Title="Super Announcement", Description="Dolor sit amet", CreateDate = DateTime.Now },
                             new Announement{ Id=3, Title="Mega Announcement", Description="falan filan inter milan", CreateDate = DateTime.Now }
                        });
                    dbContext.SaveChanges();
                }
                foreach (var an in dbContext.Announements)
                {
                    Console.WriteLine($"AnnouncementId={an.Id}\tTitleAndDescription={an.Title}\t{an.Description}\tDate={an.CreateDate}");
                }
            }
            Console.ReadLine();
        }
    }
}
