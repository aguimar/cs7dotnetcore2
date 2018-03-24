using Microsoft.EntityFrameworkCore;

namespace Packt.CS7
{
    
    // this manages the connection to the database
    public class Northwind : DbContext
    {
        // these properties map to tables in the database
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    
    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // to use Microsoft SQL Server, uncomment the following
                optionsBuilder.UseSqlServer(
                //@"Data Source=(localdb)\mssqllocaldb;" +
                //@"Data Source=172.17.0.2;" +
                @"Data Source=localhost,1401;" +
                "Initial Catalog=Northwind;" +
                "User ID=SA;Password=Mat9807632;" );
                //"Integrated Security=true;" + // );
                //"MultipleActiveResultSets=true;");

            // to use SQLite, uncomment the following
            //string path = System.IO.Path.Combine(
            //    System.Environment.CurrentDirectory, "Northwind.db"
            //);
            //optionsBuilder.UseSqlite($"Filename={path}");
        }
    }
}