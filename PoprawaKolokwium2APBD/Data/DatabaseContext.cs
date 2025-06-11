using Microsoft.EntityFrameworkCore;
using PoprawaKolokwium2APBD.Models;

namespace PoprawaKolokwium2APBD.Data;

public class DatabaseContext : DbContext
{ 
    protected DatabaseContext() { }
    public DatabaseContext(DbContextOptions options) : base(options) { }
    
    public DbSet<Character> Characters { get; set; }


    public DbSet<Item> Items { get; set; }


    public DbSet<Backpack> Backpacks { get; set; }


    public DbSet<Title> Titles { get; set; }


    public DbSet<CharacterTitle> CharacterTitles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>().HasData(new Item
        { 
            ItemId = 1,
            Name = "Magic Sword",
            Weight = 10
        });
        modelBuilder.Entity<Character>().HasData(new Character
        {
            CharacterId = 1,
            FirstName = "Arthas",
            LastName = "Menethil",
            CurrentWeight = 10,
            MaxWeight = 50
        });
        modelBuilder.Entity<Title>().HasData(new Title
        { 
            TitleId = 1,
            Name = "Champion of the Light"
        });
        modelBuilder.Entity<Backpack>().HasData(new Backpack
        {
            CharacterId = 1,
            ItemId = 1,
            Amount = 1
        });
        modelBuilder.Entity<CharacterTitle>().HasData(new CharacterTitle
        {
            CharacterId = 1,
            TitleId = 1,
            AcquiredAt = new DateTime(2024, 1, 1)
        });
    }
}