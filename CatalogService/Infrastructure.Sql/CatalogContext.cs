﻿using Infrastructure.Sql.Categories;
using Infrastructure.Sql.Items;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Sql;

internal class CatalogContext : DbContext
{
    private const string ConnectionString = "";
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public CatalogContext() : base()
    {
    }
    public CatalogContext(DbContextOptions options) : base(options)
    {
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured)
        {
            return;
        }
        optionsBuilder.UseSqlServer(ConnectionString);
    }

    public DbSet<CategoryDb> Categories { get; set; }

    public DbSet<ItemDb> Items { get; set; }
}
