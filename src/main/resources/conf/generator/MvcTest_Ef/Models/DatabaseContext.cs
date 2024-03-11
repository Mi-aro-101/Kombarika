using Microsoft.EntityFrameworkCore;
using MvcTest_Ef.Models;

namespace Repository;

public class DatabaseContext : DbContext
{

    public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
    {}

    public DbSet<MatierePremiere> MatierePremieres {get; set;}
}