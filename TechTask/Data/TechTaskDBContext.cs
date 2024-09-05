using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using TechTask.Models;

namespace TechTask.Data
{
    public class TechTaskDBContext : DbContext
    {
        public TechTaskDBContext(DbContextOptions<TechTaskDBContext> options) :base(options) { }

        public DbSet<AdminModel> Admins { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<UrlModel> Urls { get; set; }
    }
}
