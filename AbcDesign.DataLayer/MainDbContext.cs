using Microsoft.EntityFrameworkCore;

namespace AbcDesign.DataLayer;


/*
	Should only contain configurations.
	Internal within data layer.
*/
internal class MainDbContext : DbContext
{
	private readonly string _dbstr;

	public MainDbContext(string dbstr)
	{
		_dbstr = dbstr;
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		base.OnConfiguring(optionsBuilder);
		optionsBuilder.UseSqlServer(_dbstr);
	}


	public DbSet<Entities.Catalog.Category> Categories { get; set; }
	public DbSet<Entities.Catalog.Product> Products { get; set; }
	
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		// relationships
		modelBuilder.Entity<Entities.Catalog.Category>()			
			.HasMany(c => c.Products)			
			.WithOne(p => p.Category)
			.HasForeignKey(p => p.CategoryId)
			.IsRequired();
														
	}
}
