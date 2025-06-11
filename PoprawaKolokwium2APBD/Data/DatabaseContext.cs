using Microsoft.EntityFrameworkCore;

namespace PoprawaKolokwium2APBD.Data;

public class DatabaseContext : DbContext
{
    
    
    
    
    protected DatabaseContext() { }
    public DatabaseContext(DbContextOptions options) : base(options) { }
}