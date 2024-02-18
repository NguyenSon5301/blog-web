using FA.JustBlog.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTag> PostTags {  get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostTag>().HasKey(d => new { d.PostId, d.TagId }); 

            modelBuilder.Entity<Post>().HasData(new Post() { Id = 1, CreateAtDate = DateTime.Now, Decription = "sdsdsdsdsdsdsdsd2323", NumberView = 100, Rate = 4.5, Title = "This is my first post!!!", CategoryId = 1 }, new Post() { Id = 2, CreateAtDate = DateTime.Now, Decription = "23sdsd2323sd", NumberView = 200, Rate = 4.5, Title = "My second Post!!!", CategoryId = 2 });
            modelBuilder.Entity<Category>().HasData(new Category() { Id = 1, Controller = "Post", Action = "Index", Title = "Home" },
                new Category() { Id = 2, Controller = "Home", Action = "PartialAboutCard", Title = "About" },
                new Category() { Id = 3, Controller = "Home", Action = "PartialAboutCard", Title = "Entity Framework" },
                new Category() { Id = 4, Controller = "Home", Action = "PartialAboutCard", Title = "MVC" },
                new Category() { Id = 5, Controller = "Home", Action = "PartialAboutCard", Title = "Contact" });   
            modelBuilder.Entity<Tag>().HasData(new Tag() { Id = 1, Controller = "Post", Action = "Index", Title = "Home" },
                new Tag() { Id = 2, Controller = "Home", Action = "PartialAboutCard", Title = "About" },
                new Tag() { Id = 3, Controller = "Home", Action = "PartialAboutCard", Title = "Entity Framework" },
                new Tag() { Id = 4, Controller = "Home", Action = "PartialAboutCard", Title = "MVC" },
                new Tag() { Id = 5, Controller = "Home", Action = "PartialAboutCard", Title = "Contact" });
            modelBuilder.Entity<PostTag>().HasData(new PostTag() { PostId = 1, TagId = 1 },
                new PostTag() { PostId = 1, TagId = 2 },
                new PostTag() { PostId = 1, TagId = 3 },
                new PostTag() { PostId = 1, TagId = 4 },
                new PostTag() { PostId = 1, TagId = 5 },
                new PostTag() { PostId = 2, TagId = 1 },
                new PostTag() { PostId = 2, TagId = 2 },
                new PostTag() { PostId = 2, TagId = 3 },
                new PostTag() { PostId = 2, TagId = 4 },
                new PostTag() { PostId = 2, TagId = 5 });
            modelBuilder.Entity<Comment>().HasData(new Comment() { Id = 1, CommentDate = DateTime.Now, CommentDescription = "Bai viet hay 1", PostId = 1, UserId = "007910fb-160a-4f0f-a002-ba15095b68ed" },
                new Comment() { Id = 2, CommentDate = DateTime.Now, CommentDescription = "Bai viet hay 2", PostId = 1, UserId = "007910fb-160a-4f0f-a002-ba15095b68ed" },
                new Comment() { Id = 3, CommentDate = DateTime.Now, CommentDescription = "Bai viet hay 3", PostId = 1, UserId = "007910fb-160a-4f0f-a002-ba15095b68ed" },
                new Comment() { Id = 4, CommentDate = DateTime.Now, CommentDescription = "Bai viet hay 4", PostId = 2, UserId = "007910fb-160a-4f0f-a002-ba15095b68ed" },
                new Comment() { Id = 5, CommentDate = DateTime.Now, CommentDescription = "Bai viet hay 5", PostId = 2, UserId = "007910fb-160a-4f0f-a002-ba15095b68ed" }
                );
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser() {Id = "Anonymous",UserName = "Anonymous",NormalizedUserName = "Anonymous", Email = "Anonymous", NormalizedEmail= "Anonymous", EmailConfirmed = true, PasswordHash = "Anonymous", AboutMe = "Anonymous", Name = "Anonymous" });
            base.OnModelCreating(modelBuilder);
        }

    }
}
