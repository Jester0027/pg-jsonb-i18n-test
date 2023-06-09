﻿using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TranslationKeysTest.Models;

namespace TranslationKeysTest.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Country> Countries { get; set; }

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}