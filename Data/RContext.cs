using GrowEasy.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;

namespace GrowEasy.Repository
	{

	public class RContext : DbContext
		{

		public DbSet<MainDesc> MainDescs { get; set; }
		public DbSet<Vivencia> Vivencias{ get; set; }
		public DbSet<Activitie> Activities { get; set; }

		public RContext(DbContextOptions option)
			: base(option) { }

		public RContext() { }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		=> optionsBuilder
		.ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.NavigationBaseIncludeIgnored, CoreEventId.NavigationBaseIncluded));

		protected override void OnModelCreating(ModelBuilder modelBuilder)
			{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<MainDesc>().HasData(new MainDesc
				{
				Id = 1,
				name = "Alexsandro Ramos",
				birhDate = new DateTime (1978, 10, 31),				
				email = "al-ramos@hotmail.com",
				linkedin = "progalexramos",
				about = "Excelente prossional"
				});

			modelBuilder.Entity<Vivencia>().HasData(new Vivencia
				{
				Id = 1,
				name = "Anlyst Programmer",
				client = "SysMap / Claro",
				beginDate = new DateTime(2022, 8, 1),				
				endDate = new DateTime(2023, 12, 23),				
				MainDescId = 1
				});


			modelBuilder.Entity<Activitie>().HasData(new Activitie
				{
				Id = 1,
				name = "Programmer .NET",
				description = "WCF / WebService / SOAP / WebForms / ASP.NET / C#",
				VivenciaId = 1
				});
			}


		}
	}
