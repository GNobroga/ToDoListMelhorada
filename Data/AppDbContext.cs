using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using to_do_list.Models;

namespace to_do_list.Data;

public class AppDbContext : IdentityDbContext<IdentityUser>
{

    public DbSet<Lista> Listas { get; set; }

    public DbSet<Tarefa> Tarefas { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Lista>()
            .HasKey(l => l.Id);

        modelBuilder.Entity<Lista>()
            .HasMany(l => l.Tarefas)
            .WithOne(t => t.Lista)
            .HasForeignKey(t => t.ListaId)
            .OnDelete(DeleteBehavior.Cascade);
        
        base.OnModelCreating(modelBuilder);
    }

}