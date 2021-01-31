using Context.Model;
using Microsoft.EntityFrameworkCore;

namespace Context {
    public class Connection : DbContext {
        string _connectedline { get; set; }
        public Connection(string connectedline) {
            this._connectedline = connectedline;
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
           => optionsBuilder.UseSqlServer(_connectedline);
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Ingredients> Ingredients { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Recipts> Recipts { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<Units> Units { get; set; }
        public DbSet<User> User { get; set; }
    }
}
