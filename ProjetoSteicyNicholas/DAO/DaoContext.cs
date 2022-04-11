namespace DAO;

using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

public class DaoContext
{
    public DbSet<Address> address { get; set; }
    public DbSet<Client> clients {get; set;}
    public DbSet<Owner> owners { get; set; }
    public DbSet<Product> products { get; set; }
    public DbSet<Purchase> purchases { get; set; }
    public DbSet<Stocks> stocks { get; set; }
    public DbSet<Store> stores {get; set;}
    public DbSet<WishList> wishLists {get;set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Test");
    }
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }