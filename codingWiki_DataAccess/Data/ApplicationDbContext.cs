using codingWiki_DataAccess.FluentConfig;
using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codingWiki_DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

}
        public DbSet<Book>Books { get; set; }
        public DbSet<Category>Categories { get; set; }
        public DbSet<Author>Authors { get; set; }
        public DbSet<Publisher>Publishers { get; set; }
        public DbSet<SubCategory>subCategories { get; set; }
        public DbSet<BookDetail>BookDetails { get; set; }
        

        //rename to Fluent
        public DbSet<Fluent_BookDetail>BookDetails_Fluent { get; set; }
        public DbSet<Fluent_Book>Books_Fluent { get; set; }

        public DbSet<Fluent_Author>Authors_Fluent { get; set; }

        public DbSet<Fluent_Publisher>Publisher_Fluent { get; set; }
        public DbSet<Fluent_BookAuthorMap>AuthorMaps_Fluent { get; set; }


      

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
           // options.UseSqlServer("Server=192.168.215.34;Database=Ef_CoreDb;User Id=sa;Password=P@ssw0rd@123;TrustServerCertificate=true;")
               // .LogTo(Console.WriteLine,new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            //.........Hybrid

        modelBuilder.Entity<BookAuthorMap>()
                .HasKey(bam => new { bam.Book_Id, bam.Author_Id });

        modelBuilder.Entity<Book>()
                .Property(u => u.Price).HasPrecision(10, 5);


           //...........Configurations
            modelBuilder.ApplyConfiguration(new FluentAuthorConfig());
            modelBuilder.ApplyConfiguration(new FluentBookAuthorMapConfig());
            modelBuilder.ApplyConfiguration(new FluentBookConfig());
            modelBuilder.ApplyConfiguration(new FluentBookDetailConfig());
            modelBuilder.ApplyConfiguration(new FluentPublisherConfig());

            //..........populating tables
            modelBuilder.Entity<Book>().HasData(
                new Book { BookID = 1, Title = "Spider without Duty",ISBN = "53SD4", Price= 10.99m, Publisher_Id = 4345 },
                new Book { BookID = 2, Title = "Fly without Duty", ISBN = "66FD3", Price = 11.99m, Publisher_Id = 2455 },
                new Book { BookID = 3, Title = "Roach without Duty", ISBN = "48ER2", Price = 22.23m, Publisher_Id= 2455}
             );

            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { Publisher_Id = 4345, Name = "Laith", Location="Amman" },
                new Publisher { Publisher_Id =  2455, Name = "Yousef", Location="Cyprus"}
               
             );
        }

        
    }
}
