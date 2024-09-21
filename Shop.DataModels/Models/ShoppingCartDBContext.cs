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
		//以下内容为脚手架自动生成
		//Scaffold-DbContext "Data Source=D:\Projects\BlazorServerApp_ShoppingCart\DB\ShoppingCartDB.db" Microsoft.EntityFrameworkCore.Sqlite -OutputDir Models -Context ShoppingCartDBContext -Force
		public virtual DbSet<AdminInfo> AdminInfos { get; set; } = null!;

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
				//########    这里注释掉了，改为使用 appsettings.json 来配置连接字符串
				//optionsBuilder.UseSqlite("Data Source=../DB/ShoppingCartDB.db");
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<AdminInfo>(entity =>
			{
				entity.HasNoKey();

				entity.ToTable("AdminInfo");

				entity.Property(e => e.CreatedOn).HasColumnType("nvarchar](25");

				entity.Property(e => e.Email).HasColumnType("nvarchar](30");

				entity.Property(e => e.Id).HasColumnType("int] IDENTITY(1,1");

				entity.Property(e => e.LastLogin).HasColumnType("nvarchar](25");

				entity.Property(e => e.Name).HasColumnType("nvarchar](100");

				entity.Property(e => e.Password).HasColumnType("nvarchar](6");

				entity.Property(e => e.UpdatedOn).HasColumnType("nvarchar](25");
			});

			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}
