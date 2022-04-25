namespace DAO;
using Microsoft.EntityFrameworkCore;

public class DAOContext:DbContext
{
    public DbSet<Address> Address { get; set; }
    public DbSet<Client> Client {get; set;}
    public DbSet<Owner> Owner { get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<Purchase> Purchase { get; set; }
    public DbSet<Stocks> Stock { get; set; }
    public DbSet<Store> Store { get;set;}
    public DbSet<WishList> WishList {get;set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=JVLPC0506;Initial Catalog=Marketplace;Integrated Security=True;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.id);
            entity.Property(e => e.street).IsRequired();
            entity.Property(e => e.city).IsRequired();
            entity.Property(e => e.state).IsRequired();
            entity.Property(e => e.country).IsRequired();
            entity.Property(e => e.postal_code).IsRequired();
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.id);
            entity.Property(e => e.name).IsRequired();
            entity.Property(e => e.bar_code).IsRequired();
            entity.HasOne(d => d.store);
        });

        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.HasKey(e => e.id);
            entity.Property(e => e.date_purchase).IsRequired();
            entity.Property(e => e.payment_type).IsRequired();
            entity.Property(e => e.purchase_status).IsRequired();
            entity.Property(e => e.number_confirmation).IsRequired();
            entity.Property(e => e.number_nf).IsRequired();
            entity.HasOne(d => d.client);
            entity.HasOne(d => d.store);
            entity.HasOne(d => d.product);
        });

        modelBuilder.Entity<Stocks>(entity =>
        {
            entity.HasKey(e => e.id);
            entity.Property(e => e.quantity).IsRequired();
            entity.Property(e => e.unit_price).IsRequired();
            entity.HasOne(d => d.store);
            entity.HasOne(d => d.product);
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.id);
            entity.Property(e => e.name).IsRequired();
            entity.Property(e => e.date_of_birth).IsRequired();
            entity.Property(e => e.passwd).IsRequired();
            entity.Property(e => e.email).IsRequired();
            entity.Property(e => e.phone).IsRequired();
            entity.Property(e => e.login).IsRequired();
            entity.HasOne(e => e.address);
        });

        modelBuilder.Entity<Owner>(entity =>
        {
            entity.HasKey(e => e.id);
            entity.Property(e => e.name).IsRequired();
            entity.Property(e => e.date_of_birth).IsRequired();
            entity.Property(e => e.passwd).IsRequired();
            entity.Property(e => e.email).IsRequired();
            entity.Property(e => e.phone).IsRequired();
            entity.Property(e => e.login).IsRequired();
            entity.HasOne(e => e.address);
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasKey(e => e.id);
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.CNPJ).IsRequired();
            entity.HasOne(e => e.owner);
        });

        modelBuilder.Entity<WishList>(entity =>
        {
            entity.HasNoKey();
            entity.HasOne(e => e.product);
            entity.HasOne(e => e.client);
        });
        }}