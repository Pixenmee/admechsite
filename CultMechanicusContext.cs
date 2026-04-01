using AdMechSite.Models;
using System.Collections.Generic;
using System.Data.Entity;

public class CultMechanicusContext : DbContext
{
    public CultMechanicusContext() : base("CultMechanicusContext")
    {
    }

    public DbSet<Seguidor> Seguidores { get; set; }
    public DbSet<Escritura> Escrituras { get; set; }
    public DbSet<Dogma> Dogmas { get; set; }
    public DbSet<Louvor> Louvores { get; set; }
}