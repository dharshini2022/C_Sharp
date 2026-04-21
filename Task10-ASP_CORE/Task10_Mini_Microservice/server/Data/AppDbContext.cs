using System;
using Microsoft.EntityFrameworkCore;
using Task10_Mini_Microservice.server.Models;

namespace Task10_Mini_Microservice.server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Student> Students => Set<Student>();

        public DbSet<LogEntry> Logs => Set<LogEntry>();
    }
}