using Microsoft.EntityFrameworkCore;

namespace GDV_SOCIETE.Data
{ //context de database !
    public class DataContext : DbContext  
    {
        public DataContext(DbContextOptions<DataContext>options) :base(options) { }
        //manich yaser fahmetha partie athiya ? ! 
        public DbSet <Societe> societes { get; set; }
        public DbSet <Prs_Sec> prs_securite { get; set; }
    }
    
    
}
 