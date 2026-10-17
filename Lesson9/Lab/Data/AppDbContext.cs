using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreLA7.Models;

namespace NetCoreLA7.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Banner> Banners => Set<Banner>();
    public DbSet<Blog> Blogs => Set<Blog>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Configure(modelBuilder.Entity<Category>(), "CATEGORY");
        Configure(modelBuilder.Entity<Product>(), "PRODUCT");
        Configure(modelBuilder.Entity<Banner>(), "BANNER");
        Configure(modelBuilder.Entity<Blog>(), "BLOG");
        modelBuilder.Entity<Category>().Property(x => x.CreatedDate).HasColumnType("date").HasDefaultValueSql("CONVERT(date, GETDATE())");
        modelBuilder.Entity<Product>().Property(x => x.CreatedDate).HasColumnType("date").HasDefaultValueSql("CONVERT(date, GETDATE())");
        modelBuilder.Entity<Blog>().Property(x => x.CreatedDate).HasColumnType("date").HasDefaultValueSql("CONVERT(date, GETDATE())");
        modelBuilder.Entity<Product>().Property(x => x.Price).HasColumnType("float").IsRequired();
        modelBuilder.Entity<Product>().Property(x => x.SalePrice).HasColumnName("salePrice").HasColumnType("float").HasDefaultValue(0d);
        modelBuilder.Entity<Banner>().Property(x => x.Prioty).HasDefaultValue(0);
        modelBuilder.Entity<Product>().HasOne(x => x.Category).WithMany().HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Restrict);
    }

    private static void Configure<T>(EntityTypeBuilder<T> entity, string table) where T : class
    {
        entity.ToTable(table);
        entity.HasKey("Id");
        entity.Property<int>("Id").UseIdentityColumn();
        entity.Property<string>("Name").HasMaxLength(100).IsRequired().UseCollation("SQL_Latin1_General_CP1_CI_AS");
        entity.HasIndex("Name").IsUnique();
        entity.Property<byte>("Status").HasColumnType("tinyint").HasDefaultValue((byte)1).HasSentinel(byte.MaxValue);
        entity.Property<string>("Image").HasColumnType("varchar(100)");
        entity.Property<string>("Description").HasMaxLength(350);
    }
}
