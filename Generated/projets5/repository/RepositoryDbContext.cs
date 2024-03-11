namespace projets5.repository;

using entity;
using Microsoft.EntityFrameworkCore;

public class RepositoryDbContext : DbContext {
	public DbSet<Activite> Activite { get; set; }
	public DbSet<Bouquet> Bouquet { get; set; }
	public DbSet<BouquetActivite> BouquetActivite { get; set; }
	public DbSet<Client> Client { get; set; }
	public DbSet<CompositionVoyageBouquet> CompositionVoyageBouquet { get; set; }
	public DbSet<Mouvement> Mouvement { get; set; }
	public DbSet<Parametre> Parametre { get; set; }
	public DbSet<Personnel> Personnel { get; set; }
	public DbSet<Reservation> Reservation { get; set; }
	public DbSet<TypeDuree> TypeDuree { get; set; }
	public DbSet<TypeMainOeuvre> TypeMainOeuvre { get; set; }
	public DbSet<TypeMainOeuvreDuree> TypeMainOeuvreDuree { get; set; }
	public DbSet<Voyage> Voyage { get; set; }




}
