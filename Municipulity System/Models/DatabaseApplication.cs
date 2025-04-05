using Microsoft.EntityFrameworkCore;
using Municipulity_System.Models;
using System.Collections;
using System.Collections.Generic;

public class DatabaseApplicationDbcontext : DbContext
{
    public DatabaseApplicationDbcontext(DbContextOptions<DatabaseApplicationDbcontext> options) : base(options) { }
    public DbSet<Citizen> Citizens { get; set; } = null!;
    public DbSet<ServicesRequested> servicesRequesteds { get; set; } = null!;
    public DbSet<Staff> Staff { get; set; } = null!;
    public DbSet<Reports> Reports { get; set; } = null!;
}