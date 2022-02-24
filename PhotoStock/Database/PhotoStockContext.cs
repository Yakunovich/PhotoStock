using Pomelo.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PhotoStock.Data.Models;
using System;

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
  
            modelBuilder.Entity<Photo>().HasData(
                new Photo[]
                {
                new Photo { Id=Guid.NewGuid(),Name="Photo by Alexey", Size = "16x16", CreationDate = System.DateTime.Today, AuthorId = Guid.Parse("2dfa80cd-8337-444f-8bf6-fbea906975bb")  ,Price = 10, CountOfPurchases = 10, ContentUri = ".", Rating = 2},
                new Photo { Id=Guid.NewGuid(),Name="Photo by Ivan", Size = "16x16", CreationDate = System.DateTime.Today, AuthorId = Guid.Parse("2dfa80cd-8337-444f-8bf6-fbea906975bc")  ,Price = 10, CountOfPurchases = 10, ContentUri = ".", Rating = 2},
                });

            modelBuilder.Entity<Text>().HasData(
               new Text[]
               {
               new Text { Id=Guid.NewGuid(), AuthorId = Guid.Parse("2dfa80cd-8337-444f-8bf6-fbea906975bb"), Content = "Simple content", CountOfPurchases = 2, CreationDate = DateTime.Today, Price = 10, Name = "Simple name", Rating = 5, Size = ("Simple content").Length},
               new Text { Id=Guid.NewGuid(), AuthorId = Guid.Parse("2dfa80cd-8337-444f-8bf6-fbea906975bb"), Content = "Simple content 2", CountOfPurchases = 2, CreationDate = DateTime.Today, Price = 10, Name = "Simple name", Rating = 5, Size = ("Simple content").Length},
               });
        }
    }
}
