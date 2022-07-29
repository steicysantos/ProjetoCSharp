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
        optionsBuilder.UseSqlServer(@"Server="+ Environment.MachineName +";Initial Catalog=MarketPlace_teste;Integrated Security=True;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           base.OnModelCreating(modelBuilder);
           
            modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.id);
            entity.Property(e => e.street);
            entity.Property(e => e.city);
            entity.Property(e => e.state);
            entity.Property(e => e.country);
            entity.Property(e => e.postal_code);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.id);
            entity.Property(e => e.name);
            entity.Property(e => e.bar_code);
            entity.Property(e => e.image);
            entity.Property(e => e.description);
        });

        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.HasKey(e => e.id);
            entity.Property(e => e.date_purchase);
            entity.Property(e => e.payment_type);
            entity.Property(e => e.purchase_status);
            entity.Property(e => e.number_confirmation);
            entity.Property(e => e.number_nf);
            entity.HasOne(d => d.client);
            entity.HasOne(d => d.store);
            entity.HasOne(d => d.product);
        });

        modelBuilder.Entity<Stocks>(entity =>
        {
            entity.HasKey(e => e.id);
            entity.Property(e => e.quantity);
            entity.Property(e => e.unit_price);
            entity.HasOne(d => d.store);
            entity.HasOne(d => d.product);
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.id);
            entity.Property(e => e.name);
            entity.Property(e => e.date_of_birth);
            entity.Property(e => e.document);
            entity.Property(e => e.passwd);
            entity.Property(e => e.email);
            entity.Property(e => e.phone);
            entity.Property(e => e.login);
            entity.HasOne(e => e.address);
        });

        modelBuilder.Entity<Owner>(entity =>
        {
            entity.HasKey(e => e.id);
            entity.Property(e => e.name);
            entity.Property(e => e.date_of_birth);
            entity.Property(e => e.document);
            entity.Property(e => e.passwd);
            entity.Property(e => e.email);
            entity.Property(e => e.phone);
            entity.Property(e => e.login);
            entity.HasOne(e => e.address);
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasKey(e => e.id);
            entity.Property(e => e.Name);
            entity.Property(e => e.CNPJ);
            entity.HasOne(d => d.owner);
        });

        modelBuilder.Entity<WishList>(entity =>
        {
            entity.HasKey(e=> e.id);
            entity.HasOne(d => d.stocks);
            entity.HasOne(d => d.client);
        });
        }}