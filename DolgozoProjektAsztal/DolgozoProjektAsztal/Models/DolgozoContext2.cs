﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DolgozoProjektKonzol.Models;

public partial class DolgozoContext2 : DbContext
{
    public DolgozoContext2()
    {
    }

    public DolgozoContext2(DbContextOptions<DolgozoContext2> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Manyworkers { get; set; }

    public virtual DbSet<Employee> Workers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=dolgozo.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("manyworker");

            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Salary)
                .HasColumnType("INT")
                .HasColumnName("salary");

            entity.HasKey(e => e.Email);
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
