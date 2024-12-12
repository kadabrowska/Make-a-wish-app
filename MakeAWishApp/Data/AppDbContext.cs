namespace MakeAWishApp.Data;

using MakeAWishApp.Data.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
    {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Gift> Gifts { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<UserGift> UserGifts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .Property(u => u.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Gift>()
            .Property(g => g.Price)
            .HasPrecision(10, 2);

        modelBuilder.Entity<UserGift>(b =>
        {
            b.ToTable("UserGifts");
            b.HasKey(x => x.Id);

            b.HasOne(ug => ug.User)
            .WithMany(u => u.UserGifts)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.NoAction);


            b.HasOne(ug => ug.Gift)
            .WithMany(g => g.UserGifts)
            .HasForeignKey(x => x.GiftId)
            .OnDelete(DeleteBehavior.NoAction);
        });

    }

}
