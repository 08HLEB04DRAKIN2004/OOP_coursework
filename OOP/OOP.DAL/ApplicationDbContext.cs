using Microsoft.EntityFrameworkCore;
using OOP.Domain.Entity;
using OOP.Domain.Enum;
using OOP.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace OOP.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
          //  Database.EnsureDeleted();
           //
           Database.EnsureCreated();
        }

        public DbSet<Client> clients { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Orders> orders { get; set; }
        public DbSet<Department> department { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<EmployeeInProject> employeesInProject { get; set; }
        public DbSet<MediaResource> mediaResources { get; set; }
        public DbSet<Project> projects { get; set; }
        public DbSet<ProjectRole> projectRoles { get; set; }
     //   public DbSet<Profile> profiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(builder =>
            {
                builder.ToTable("users").HasKey(x => x.user_id);

                builder.HasData(new User[]
                {
                    new User()
                    {
                        user_id = 1,
                        Name = "Admin",
                        Password = HashPasswordHelper.HashPassowrd("123456"),
                        Role = Role.Admin,
                        Email="g_drakin@mail.ru",
                        PhoneNumber="803335876"

                    },
                    new User()
                    {
                        user_id = 2,
                        Name = "Moderator",
                        Password = HashPasswordHelper.HashPassowrd("654321"),
                        Role = Role.Moderator,
                        Email="g_drakin@mail.ru",
                        PhoneNumber="803335876"
                    }
                });

                builder.Property(x => x.user_id).ValueGeneratedOnAdd();

                builder.Property(x => x.Password).IsRequired();
                builder.Property(x => x.Name).HasMaxLength(100).IsRequired();

                //builder.HasOne(x => x.Profile)
                //    .WithOne(x => x.User)
                //    .HasPrincipalKey<User>(x => x.user_id)
                //    .OnDelete(DeleteBehavior.Cascade);
            });

            //modelBuilder.Entity<Profile>(builder =>
            //{
            //    builder.ToTable("profiles").HasKey(x => x.profile_id);

            //    builder.Property(x => x.profile_id).ValueGeneratedOnAdd();
            //    builder.Property(x => x.Age);
            //    builder.Property(x => x.Address).HasMaxLength(200).IsRequired(false);

            //    builder.HasData(new Profile()
            //    {
            //        profile_id = 1,
            //        user_id = 1
            //    });
            //});

     
   
        }
    }
}
