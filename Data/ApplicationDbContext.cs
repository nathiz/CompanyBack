using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CompanyBack;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

    public DbSet<Area> Areas { get; set; }
    public DbSet<Process> Processos { get; set; }
    public DbSet<SubProcess> Subprocessos { get; set; }
    public DbSet<Responsavel> Responsaveis { get; set; }
    public DbSet<Ferramenta> Ferramentas { get; set; }
    public DbSet<Documento> Documentos { get; set; }
    public DbSet<DetalhamentoProcesso> DetalhamentoProcessos { get; set; }
}