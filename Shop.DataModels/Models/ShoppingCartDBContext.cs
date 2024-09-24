using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Shop.DataModels.Models
{
	public partial class ShoppingCartDBContext : DbContext
	{
		public ShoppingCartDBContext()
		{
		}

		public ShoppingCartDBContext(DbContextOptions<ShoppingCartDBContext> options)
			: base(options)
		{
		}

		public virtual DbSet<AdminInfo> AdminInfos { get; set; } = null!;
		public virtual DbSet<Category> Categories { get; set; } = null!;

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
				//optionsBuilder.UseSqlite("Data Source=D:\\Projects\\BlazorServerApp_ShoppingCart\\DB\\ShoppingCartDB.db");
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<AdminInfo>(entity =>
			{
				entity.ToTable("AdminInfo");

				entity.Property(e => e.CreatedOn).HasColumnType("nvarchar] (25");

				entity.Property(e => e.Email).HasColumnType("nvarchar] (30");

				entity.Property(e => e.LastLogin).HasColumnType("nvarchar] (25");

				entity.Property(e => e.Name).HasColumnType("nvarchar] (100");

				entity.Property(e => e.Password).HasColumnType("nvarchar] (6");

				entity.Property(e => e.UpdatedOn).HasColumnType("nvarchar] (25");
			});

			modelBuilder.Entity<Category>(entity =>
			{
				entity.ToTable("Category");
			});

			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}
