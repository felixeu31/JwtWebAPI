using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Exercise.WebAPI_JWT.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Exercise.WebAPI_JWT.DbContext
{
    public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        //private readonly IHttpContextAccessor _httpContextAccessor;

        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor httpContextAccessor)
        //    : base(options)
        //{
        //    _httpContextAccessor = httpContextAccessor;
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    //// Add entity configurations in a structured way using 'TypeConfiguration’ classes
        //    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=WebApiJwt;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public DbSet<User> Users { get; set; }

    }
}
