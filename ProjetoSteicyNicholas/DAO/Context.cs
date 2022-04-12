using System;
using Microsoft.EntityFrameworkCore;
namespace DAO;
public class Context:DbContext
{
    public DbSet<Address> address { get; set; }
    public DbSet<Client> clients {get; set;}
    public DbSet<Owner> owners { get; set; }
    public DbSet<Product> products { get; set; }
    public DbSet<Purchase> purchases { get; set; }
    public DbSet<Stocks> stocks { get; set; }
    public DbSet<Store> stores { get;set;}
    public DbSet<WishList> wishLists {get;set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=JVLPC0562;Initial Catalog=Marketplace;Integrated Security=True");
    }
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.id);
            entity.Property(e => e.street).IsRequired();
            entity.Property(e => e.city).IsRequired();
            entity.Property(e => e.state).IsRequired();
            entity.Property(e => e.country).IsRequired();
            entity.Property(e => e.poste_code).IsRequired();
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.id);
            entity.Property(e => e.name).IsRequired();
            entity.Property(e => e.unit_price).IsRequired();
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
            entity.HasOne(d => d.store);
            entity.HasOne(d => d.product);
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.id);
            entity.Property(e => e.name).IsRequired();
            entity.Property(e => e.age).IsRequired();
            entity.Property(e => e.password).IsRequired();
            entity.Property(e => e.email).IsRequired();
            entity.Property(e => e.phone).IsRequired();
            entity.Property(e => e.login).IsRequired();
            entity.HasOne(d => d.address);
        });

        modelBuilder.Entity<Owner>(entity =>
        {
            entity.HasKey(e => e.id);
            entity.Property(e => e.name).IsRequired();
            entity.Property(e => e.age).IsRequired();
            entity.Property(e => e.passwd).IsRequired();
            entity.Property(e => e.email).IsRequired();
            entity.Property(e => e.phone).IsRequired();
            entity.Property(e => e.login).IsRequired();
            entity.HasOne(d => d.address);
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasKey(e => e.id);
            entity.Property(e => e.name).IsRequired();
            entity.Property(e => e.CNPJ).IsRequired();
            entity.HasOne(d => d.owner);
        });

        modelBuilder.Entity<WishList>(entity =>
        {
            entity.HasKey(e => e.id);
            entity.HasOne(d => d.product);
            entity.HasOne(d => d.client);
        });
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }}