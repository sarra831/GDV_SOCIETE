using Microsoft.EntityFrameworkCore;

namespace GDV_SOCIETE.Data
{ //context de database !
    public class DataContext : DbContext  
    {
        public DataContext(DbContextOptions<DataContext>options) :base(options) { }
        public DbSet <Societe> societes { get; set; }
     
    }
    
  
}
 