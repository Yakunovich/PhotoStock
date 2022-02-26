using Pomelo.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PhotoStock.Data.Models;
using System;
using System.Collections.Generic;

namespace PhotoStock.Database
{
    public class PhotoStockContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Text> Texts { get; set; }
        public PhotoStockContext(DbContextOptions<PhotoStockContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Author>().HasData(
                new Author[]
                {
                new Author { Id=new Guid("2dfa80cd-8337-444f-8bf6-fbea906975bb"),Name="Alexey Nikolaenkov", Age=21, AccountCreationDate = System.DateTime.Today, Nickname = "Humlled"},
                new Author { Id=new Guid("2dfa80cd-8337-444f-8bf6-fbea906975bc"),Name="Ivan Denisyuk", Age=21, AccountCreationDate = System.DateTime.Today, Nickname = "vnvanya"},
                new Author { Id=new Guid("2dfa80cd-8337-444f-8bf6-fbea906975bd"),Name="Alexandr Yakunovich", Age=20, AccountCreationDate = System.DateTime.Today, Nickname = "yakunovich.png"},
                new Author { Id=new Guid("2dfa80cd-8337-444f-8bf6-fbea906975be"),Name="Maxim Olentsevich", Age=20, AccountCreationDate = System.DateTime.Today, Nickname = "fuuuri_kuri"},
                });

            modelBuilder.Entity<Rating>().HasData(
                new Rating[]
                {
                new Rating { Id =  Guid.Parse("1dfa80cc-8337-444f-8bf6-fbea906975bd"), RatingValues = new List<RatingValue>(){ } },
                new Rating { Id =  Guid.Parse("2dfa80cc-8337-444f-8bf6-fbea906975bd"), RatingValues = new List<RatingValue>(){ } },
                new Rating { Id =  Guid.Parse("3dfa80cc-8337-444f-8bf6-fbea906975bd"), RatingValues = new List<RatingValue>(){ } },
                });

            modelBuilder.Entity<RatingValue>().HasData(
                new RatingValue[]
                {
                new RatingValue { Id = Guid.NewGuid(), Value = 5, RatingId = Guid.Parse("1dfa80cc-8337-444f-8bf6-fbea906975bd") },
                new RatingValue { Id = Guid.NewGuid(), Value = 4, RatingId = Guid.Parse("1dfa80cc-8337-444f-8bf6-fbea906975bd") },
                new RatingValue { Id = Guid.NewGuid(), Value = 5, RatingId = Guid.Parse("2dfa80cc-8337-444f-8bf6-fbea906975bd") },
                new RatingValue { Id = Guid.NewGuid(), Value = 4, RatingId = Guid.Parse("2dfa80cc-8337-444f-8bf6-fbea906975bd") },
                new RatingValue { Id = Guid.NewGuid(), Value = 5, RatingId = Guid.Parse("3dfa80cc-8337-444f-8bf6-fbea906975bd") },
                new RatingValue { Id = Guid.NewGuid(), Value = 4, RatingId = Guid.Parse("3dfa80cc-8337-444f-8bf6-fbea906975bd") }
                });

            modelBuilder.Entity<Photo>().HasData(
                new Photo[]
                {
                new Photo { Id=Guid.Parse("2dfa80cc-8337-444f-8bf6-fbea906975bb"),RatingId = Guid.Parse("1dfa80cc-8337-444f-8bf6-fbea906975bd"),Name="Photo by Alexey", Size = "16x16", CreationDate = System.DateTime.Today, AuthorId = Guid.Parse("2dfa80cd-8337-444f-8bf6-fbea906975bb")  ,Price = 10, CountOfPurchases = 10, ContentUri = "." },
               // new Photo { Id=Guid.Parse("2dfa80cc-8337-444f-8bf6-fbea906975bd"),Name="Photo by Ivan", Size = "16x16", CreationDate = System.DateTime.Today, AuthorId = Guid.Parse("2dfa80cd-8337-444f-8bf6-fbea906975bc")  ,Price = 10, CountOfPurchases = 10, ContentUri = "." },
                });

            modelBuilder.Entity<Text>().HasData(
               new Text[]
               {
               new Text { Id=Guid.Parse("1dfa80cc-8337-444f-8bf6-fbea906975bb"), RatingId = Guid.Parse("2dfa80cc-8337-444f-8bf6-fbea906975bd"),AuthorId = Guid.Parse("2dfa80cd-8337-444f-8bf6-fbea906975bb"), Content = "Simple content", CountOfPurchases = 2, CreationDate = DateTime.Today, Price = 10, Name = "Simple name", Size = ("Simple content").Length},
               new Text { Id=Guid.Parse("1dfa80cc-8337-444f-8bf6-fbea906975bd"), RatingId = Guid.Parse("3dfa80cc-8337-444f-8bf6-fbea906975bd"),AuthorId = Guid.Parse("2dfa80cd-8337-444f-8bf6-fbea906975bb"), Content = "Simple content 2", CountOfPurchases = 2, CreationDate = DateTime.Today, Price = 10, Name = "Simple name", Size = ("Simple content").Length},
               });

        }
    }
}
