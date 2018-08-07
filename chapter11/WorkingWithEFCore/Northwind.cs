using Microsoft.EntityFrameworkCore;

namespace Packt.CS7
{
    
    // create container
    //sudo docker run -e 'ACCEPT_EULA=Y' -e 'MSSQL_SA_PASSWORD=Mat9807632' -p 1401:1433 --name sql1 -v sql1data:/var/opt/mssql -d microsoft/mssql-server-linux:2017-latest

    // Copy backup to container
    //sudo docker cp Northwind4SQLServer.sql sql1:/var/opt/mssql/backup
    
    // this for load database structure
    //sudo docker exec -it sql1 /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P 'Mat9807632' -Q 'RESTORE FILELISTONLY FROM DISK = "/var/opt/mssql/backup/Northwind4SQLServer.sql"' | tr -s ' ' | cut -d ' ' -f 1-2

    // connect to container
    // sudo docker exec -it sql2 "bash"
    
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
                //"Integrated Security=true;" );
                //"MultipleActiveResultSets=true;");

            // to use SQLite, uncomment the following
            //string path = System.IO.Path.Combine(
            //    System.Environment.CurrentDirectory, "Northwind.db"
            //);
            //optionsBuilder.UseSqlite($"Filename={path}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // example of using Fluent API instead of attributes
            // to limit the length of a category name to under 40
            modelBuilder.Entity<Category>()
                .Property(category => category.CategoryName)
                .IsRequired()
                .HasMaxLength(40);
            
            // global filter to remove discontinued products
            modelBuilder.Entity<Product>().HasQueryFilter(p => !p.Discontinued);
        }
    }
}