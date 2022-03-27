using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using FluentValidator;
using Demo.Domain.StoreContext.Entities;
using System;

namespace Demo.Infra.SQLContexts
{
    public class SQLDemoContext : DbContext
    {
        private readonly IConfiguration _config;
        public SQLDemoContext()
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }
        public SQLDemoContext(DbContextOptions<SQLDemoContext> options, IConfiguration config)
            : base(options)
        {
            _config = config;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SQLDemoContext).Assembly);
            modelBuilder.Ignore<Notifiable>();
            modelBuilder.Ignore<Notification>();

            EntityMapping(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private void EntityMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("tb_User").HasKey(e => e.Id);
                entity.Property(e => e.CreateAt).HasColumnName("createdAt").HasDefaultValue(DateTime.Now);
                entity.Property(e => e.UpdateAt).HasColumnName("updateAt");
                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .HasColumnName("name");
                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");
                entity.Property(e => e.Role)
                    .HasMaxLength(100)
                    .HasColumnName("role");
                entity.Property(e => e.SocialSecurityNumnber)
                    .HasMaxLength(100)
                    .HasColumnName("socialSecurityNumnber");
                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("integer");
                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("integer");
                entity.Property(e => e.Address)
                    .HasMaxLength(1000)
                    .HasColumnName("address");
            });
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("tb_Product").HasKey(e => e.Id);
                entity.Property(e => e.CreateAt).HasColumnName("createdAt").HasDefaultValue(DateTime.Now);
                entity.Property(e => e.UpdateAt).HasColumnName("updateAt");
                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .HasColumnName("name");
                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .HasColumnName("description");
                entity.Property(e => e.Quantity)
                        .HasColumnName("quantity")
                        .HasColumnType("integer");
                entity.Property(e => e.Price)
                    .HasColumnName("Price")
                    .HasColumnType("decimal"); 
            });

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.ToTable("tb_UserLogin").HasKey(e => e.Id);
                entity.Property(e => e.CreateAt).HasColumnName("createdAt").HasDefaultValue(DateTime.Now);
                entity.Property(e => e.UpdateAt).HasColumnName("updateAt");
                entity.Property(e => e.Login)
                    .HasMaxLength(100)
                    .HasColumnName("login");
                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .HasColumnName("password");
                entity.Property(e => e.status)
                    .HasColumnName("status")
                    .HasColumnType("integer");
                entity.HasOne<User>(u => u.user)
                        .WithMany(ul => ul.logins)
                        .HasForeignKey(fk => fk.userId);


            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("tb_Order").HasKey(e => e.Id);
                entity.Property(e => e.CreateAt).HasColumnName("createdAt").HasDefaultValue(DateTime.Now);
                entity.Property(e => e.UpdateAt).HasColumnName("updateAt");

                entity.Property(e => e.status)
                    .HasColumnName("status")
                    .HasColumnType("integer");
                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("integer");
                
                entity.Property(e => e.DeliveryAddress)
                    .HasMaxLength(1000)
                    .HasColumnName("deliveryAddress");

                entity.HasOne<User>(u => u.User)
                        .WithMany(ul => ul.Orders)
                        .HasForeignKey(fk => fk.UserId);

                entity.HasOne<Product>(u => u.Product)
                        .WithMany(ul => ul.Orders)
                        .HasForeignKey(fk => fk.UserId);

            });


        }

    }
}
