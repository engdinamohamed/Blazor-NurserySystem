using Microsoft.EntityFrameworkCore;
using MoralNursery.Data.Models;

namespace MoralNursery.Data.Context
{
	public class NurseryDbContext : DbContext
	{
        //      private readonly NurseryDbContext _nurseryDbContext;
        //      public NurseryDbContext(NurseryDbContext nurseryDbContext)
        //{
        //          _nurseryDbContext = nurseryDbContext;
        //      }

        public NurseryDbContext(DbContextOptions<NurseryDbContext> options) : base(options)
        {

        }

        // DbSet for each entity
        public DbSet<ClassRoom> ClassRooms { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<Function> Functions { get; set; }

		public DbSet<PaymentMethod> PaymentMethods { get; set; }
		public DbSet<FeeMethod> FeeMethods { get; set; }

		public DbSet<Student> Students { get; set; }
		public DbSet<Register> Registers { get; set; }
		public DbSet<Payment> Payments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            //-------------------------Register---------------------------------
            modelBuilder.Entity<Register>()
			.HasOne(r => r.User)
			.WithMany()
			.HasForeignKey(r => r.UserId)
			.OnDelete(DeleteBehavior.Restrict); // Set OnDelete behavior to Restrict

			modelBuilder.Entity<Register>()
			.HasOne(r => r.Student)
			.WithMany()
			.HasForeignKey(r => r.StudentId)
			.OnDelete(DeleteBehavior.Restrict); // Set OnDelete behavior to Restrict

			modelBuilder.Entity<Register>()
			.HasOne(r => r.FeeMethod)
			.WithMany()
			.HasForeignKey(r => r.FeeMethodId)
			.OnDelete(DeleteBehavior.Restrict); // Set OnDelete behavior to Restrict

			//-----------------------------Payment--------------------------------------------------------
            modelBuilder.Entity<Payment>()
			.HasOne(r => r.User)
			.WithMany()
			.HasForeignKey(r => r.UserId)
			.OnDelete(DeleteBehavior.Restrict); // Set OnDelete behavior to Restrict

			//modelBuilder.Entity<Payment>()
			//.HasOne(r => r.Student)
			//.WithMany()
			//.HasForeignKey(r => r.StudentId)
			//.OnDelete(DeleteBehavior.Restrict); // Set OnDelete behavior to Restrict

			modelBuilder.Entity<Payment>()
			.HasOne(r => r.PaymentMethod)
			.WithMany()
			.HasForeignKey(r => r.PaymentMethodId)
			.OnDelete(DeleteBehavior.Restrict); // Set OnDelete behavior to Restrict

			modelBuilder.Entity<Payment>()
			.HasOne(r => r.Register)
			.WithMany()
			.HasForeignKey(r => r.RegisterId)
			.OnDelete(DeleteBehavior.Restrict); // Set OnDelete behavior to Restrict

            // Add other entity configurations here

            //-----------------------Student--------------------------------------------------------
            modelBuilder.Entity<Student>()
            .HasOne(r => r.ClassRoom)
            .WithMany()
            .HasForeignKey(r => r.ClassRoomId)
            .OnDelete(DeleteBehavior.Restrict); // Set OnDelete behavior to Restrict

            modelBuilder.Entity<Student>()
           .HasOne(r => r.User)
           .WithMany()
           .HasForeignKey(r => r.UserId)
           .OnDelete(DeleteBehavior.Restrict); // Set OnDelete behavior to Restrict
           //----------------------------------Role & function m to m ---------------------------------------------
            modelBuilder.Entity<Role>()
            .HasMany(f => f.Functions)
            .WithMany(r => r.Roles)
            .UsingEntity<Dictionary<string, object>>(
                "FunctionRole",
                j => j
                    .HasOne<Function>()
                    .WithMany()
                    .HasForeignKey("FunctionsId")
                    .OnDelete(DeleteBehavior.Cascade),
                j => j
                    .HasOne<Role>()
                    .WithMany()
                    .HasForeignKey("RolesId")
                    .OnDelete(DeleteBehavior.Cascade));

            //-------------------------------------------------------------------------------------------

            base.OnModelCreating(modelBuilder);

            
           
        }



    }
}
