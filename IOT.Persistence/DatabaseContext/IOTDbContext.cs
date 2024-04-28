using IOT.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Persistence.DatabaseContext
{
	public class IOTDbContext : DbContext
	{

		public IOTDbContext(DbContextOptions<IOTDbContext> options) : base(options)
		{

		}
		public DbSet<Area> Areas { get; set; }
		public DbSet<Detail> Detail { get; set; }
		public DbSet<DetailLog> DetailLog { get; set; }
		public DbSet<DetailPicture> DetailPicture { get; set; }
		public DbSet<Machine> Machine { get; set; }	
		public DbSet<MachineError> MachineError { get; set; }
		public DbSet<MachinePicture> MachinePicture { get; set; }
		public DbSet<ElectronicLog> ElectronicLog { get; set; }
		public DbSet<OEE> OEE { get; set; }
		public DbSet<Project> Project { get; set; }
		public DbSet<Worker> Worker { get; set; }
		public DbSet<WorkerPicture> WorkerPicture { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(IOTDbContext).Assembly);
			base.OnModelCreating(modelBuilder);
			// Xác định các thuộc tính làm key
			modelBuilder.Entity<Area>().HasKey(p => p.AreaId);
			modelBuilder.Entity<Detail>().HasKey(p => p.DetailId);
			modelBuilder.Entity<DetailLog>().HasKey(p => p.LogId);
			modelBuilder.Entity<DetailPicture>().HasKey(e => new { e.DetailPictureId, e.DetailId });
			modelBuilder.Entity<DetailPicture>().HasOne(e => e.Detail).WithMany(e => e.DetailPictures).HasForeignKey(e => e.DetailId);
			modelBuilder.Entity<Machine>().HasKey(e => e.MachineId);
			modelBuilder.Entity<MachineError>().HasKey(e =>  e.MachineErrorId );
			modelBuilder.Entity<MachinePicture>().HasKey(e => new { e.MachinePictureId, e.MachineName });
			modelBuilder.Entity<MachinePicture>().HasOne(e => e.Machine).WithMany(e => e.MachinePictures).HasForeignKey(e => e.MachineName);
			modelBuilder.Entity<ElectronicLog>().HasKey(e => e.LogId);
			modelBuilder.Entity<OEE>().HasKey(e => new { e.TimeStamp, e.MachineId });
			modelBuilder.Entity<Project>().HasKey(p => p.ProjectId);
			modelBuilder.Entity<Worker>().HasKey(e => e.WorkerId);
			modelBuilder.Entity<WorkerPicture>().HasKey(e => new { e.WorkerPictureId, e.WorkerId });
			modelBuilder.Entity<WorkerPicture>().HasOne(e => e.Worker).WithMany(e => e.WorkerPictures).HasForeignKey(e => e.WorkerId);
		}
	}
	
}
