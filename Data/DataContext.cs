using Microsoft.EntityFrameworkCore;

namespace USUARIOSAPI.Data
{
    public class DataContext : DbContext 
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public  DbSet<Usuarios> Usuarios { get; set; }
    }
}
