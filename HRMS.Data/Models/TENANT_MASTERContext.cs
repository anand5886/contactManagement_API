using System;
using HRMS.Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HRMS.Data.Models
{
    public partial class TENANT_MASTERContext : DbContext
    {
        public TENANT_MASTERContext()
        {
        }
        public TENANT_MASTERContext(DbContextOptions<TENANT_MASTERContext> options)
    : base(options)
        {
        }
        public virtual DbSet<TblClient> TblClient { get; set; }
        public virtual DbSet<TblClientConfig> TblClientConfig { get; set; }
        public virtual DbSet<TblConfig> TblConfig { get; set; }
        public virtual DbSet<TblFunctionality> TblFunctionality { get; set; }
        public virtual DbSet<TblModules> TblModules { get; set; }
        public virtual DbSet<TblRole> TblRole { get; set; }
        public virtual DbSet<TblRoleFunctionality> TblRoleFunctionality { get; set; }
        public virtual DbSet<TblUser> TblUser { get; set; }
        public virtual DbSet<TblUserClient> TblUserClient { get; set; }
        public virtual DbSet<TblUserRole> TblUserRole { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblClient>(entity =>
            {
                entity.HasKey(e => e.ClientId);

                entity.ToTable("TBL_CLIENT");

                entity.Property(e => e.ClientId).HasColumnName("CLIENT_ID");

                entity.Property(e => e.ClientAutoId)
                    .HasColumnName("CLIENT_AUTO_ID")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComputedColumnSql("('CLIENT'+right('0000'+CONVERT([varchar](4),[CLIENT_ID]),(4)))");

                entity.Property(e => e.ClientName)
                    .IsRequired()
                    .HasColumnName("CLIENT_NAME")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDatetime)
                    .HasColumnName("CREATED_DATETIME")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .HasColumnName("IS_ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDatetime)
                    .HasColumnName("MODIFIED_DATETIME")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TblClientConfig>(entity =>
            {
                entity.HasKey(e => e.ClientConfigId)
                    .HasName("PK_tbl_client_config");

                entity.ToTable("TBL_CLIENT_CONFIG");

                entity.Property(e => e.ClientConfigId).HasColumnName("CLIENT_CONFIG_ID");

                entity.Property(e => e.ClientKey)
                    .IsRequired()
                    .HasColumnName("CLIENT_KEY")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDatetime)
                    .HasColumnName("CREATED_DATETIME")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DatabaseName)
                    .IsRequired()
                    .HasColumnName("DATABASE_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ServerName)
                    .IsRequired()
                    .HasColumnName("SERVER_NAME")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ServerPort).HasColumnName("SERVER_PORT");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("USER_ID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasColumnName("USER_PASSWORD")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblConfig>(entity =>
            {
                entity.HasKey(e => e.ConfigId);

                entity.ToTable("TBL_CONFIG");

                entity.Property(e => e.ConfigId).HasColumnName("CONFIG_ID");

                entity.Property(e => e.ConfigKey)
                    .IsRequired()
                    .HasColumnName("CONFIG_KEY")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ConfigType)
                    .IsRequired()
                    .HasColumnName("CONFIG_TYPE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ConfigValue)
                    .HasColumnName("CONFIG_VALUE")
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDatetime)
                    .HasColumnName("CREATED_DATETIME")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .HasColumnName("IS_ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDatetime)
                    .HasColumnName("MODIFIED_DATETIME")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TblFunctionality>(entity =>
            {
                entity.HasKey(e => e.FunctionalityIdPk);

                entity.ToTable("TBL_FUNCTIONALITY");

                entity.HasIndex(e => e.FuncName)
                    .HasName("ind_118")
                    .IsUnique();

                entity.Property(e => e.FunctionalityIdPk).HasColumnName("FUNCTIONALITY_ID_PK");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDatetime)
                    .HasColumnName("CREATED_DATETIME")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FuncDesc)
                    .HasColumnName("FUNC_DESC")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FuncName)
                    .IsRequired()
                    .HasColumnName("FUNC_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .HasColumnName("IS_ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDatetime)
                    .HasColumnName("MODIFIED_DATETIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModuleId).HasColumnName("MODULE_ID");

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.TblFunctionality)
                    .HasForeignKey(d => d.ModuleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_205");
            });

            modelBuilder.Entity<TblModules>(entity =>
            {
                entity.HasKey(e => e.ModuleId)
                    .HasName("PK_tbl_modules");

                entity.ToTable("TBL_MODULES");

                entity.HasIndex(e => e.ModuleName)
                    .HasName("ind_236")
                    .IsUnique();

                entity.Property(e => e.ModuleId).HasColumnName("MODULE_ID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDatetime)
                    .HasColumnName("CREATED_DATETIME")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .HasColumnName("IS_ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDatetime)
                    .HasColumnName("MODIFIED_DATETIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModuleDesc)
                    .HasColumnName("MODULE_DESC")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ModuleIcon)
                    .HasColumnName("MODULE_ICON")
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.ModuleName)
                    .IsRequired()
                    .HasColumnName("MODULE_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblRole>(entity =>
            {
                entity.HasKey(e => e.RoleIdPk);

                entity.ToTable("TBL_ROLE");

                entity.HasIndex(e => e.RoleName)
                    .HasName("ind_117")
                    .IsUnique();

                entity.Property(e => e.RoleIdPk).HasColumnName("ROLE_ID_PK");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDatetime)
                    .HasColumnName("CREATED_DATETIME")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .HasColumnName("IS_ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.MdifiedDatetime)
                    .HasColumnName("MDIFIED_DATETIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RoleDesc)
                    .HasColumnName("ROLE_DESC")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasColumnName("ROLE_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblRoleFunctionality>(entity =>
            {
                entity.HasKey(e => e.RoleFunctionalityId);

                entity.ToTable("TBL_ROLE_FUNCTIONALITY");

                entity.Property(e => e.RoleFunctionalityId).HasColumnName("ROLE_FUNCTIONALITY_ID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDatetime)
                    .HasColumnName("CREATED_DATETIME")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FunctionalityIdPk).HasColumnName("FUNCTIONALITY_ID_PK");

                entity.Property(e => e.IsActive)
                    .HasColumnName("IS_ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDatetime)
                    .HasColumnName("MODIFIED_DATETIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.RoleIdPk).HasColumnName("ROLE_ID_PK");

                entity.HasOne(d => d.FunctionalityIdPkNavigation)
                    .WithMany(p => p.TblRoleFunctionality)
                    .HasForeignKey(d => d.FunctionalityIdPk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_73");

                entity.HasOne(d => d.RoleIdPkNavigation)
                    .WithMany(p => p.TblRoleFunctionality)
                    .HasForeignKey(d => d.RoleIdPk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_69");
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.UserIdPk)
                    .HasName("PK_TBL_USER_1");

                entity.ToTable("TBL_USER");

                entity.HasIndex(e => e.UserName)
                    .HasName("ind_2356")
                    .IsUnique();

                entity.Property(e => e.UserIdPk).HasColumnName("USER_ID_PK");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDatetime)
                    .HasColumnName("CREATED_DATETIME")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("FIRST_NAME")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .HasColumnName("IS_ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsConsentGiven)
                    .HasColumnName("IS_CONSENT_GIVEN")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LastLogin)
                    .HasColumnName("LAST_LOGIN")
                    .HasColumnType("datetime");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("LAST_NAME")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNumber)
                    .HasColumnName("MOBILE_NUMBER")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDatetime)
                    .HasColumnName("MODIFIED_DATETIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("USER_NAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserPasswordHash)
                    .IsRequired()
                    .HasColumnName("USER_PASSWORD_HASH")
                    .HasMaxLength(64)
                    .IsFixedLength();

                entity.Property(e => e.UserPasswordSalt).HasColumnName("USER_PASSWORD_SALT");
            });

            modelBuilder.Entity<TblUserClient>(entity =>
            {
                entity.HasKey(e => e.UserClientPk);

                entity.ToTable("TBL_USER_CLIENT");

                entity.HasIndex(e => new { e.UserIdPk, e.ClientId })
                    .HasName("ind_250")
                    .IsUnique();

                entity.Property(e => e.UserClientPk).HasColumnName("USER_CLIENT_PK");

                entity.Property(e => e.ClientId).HasColumnName("CLIENT_ID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDatetime)
                    .HasColumnName("CREATED_DATETIME")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDatetime)
                    .HasColumnName("MODIFIED_DATETIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserIdPk).HasColumnName("USER_ID_PK");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.TblUserClient)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_290");
            });

            modelBuilder.Entity<TblUserRole>(entity =>
            {
                entity.HasKey(e => e.UserRolePk);

                entity.ToTable("TBL_USER_ROLE");

                entity.Property(e => e.UserRolePk).HasColumnName("USER_ROLE_PK");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("CREATED_BY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDatetime)
                    .HasColumnName("CREATED_DATETIME")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive)
                    .HasColumnName("IS_ACTIVE")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.MdifiedDatetime)
                    .HasColumnName("MDIFIED_DATETIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("MODIFIED_BY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RoleIdPk).HasColumnName("ROLE_ID_PK");

                entity.Property(e => e.UserIdPk).HasColumnName("USER_ID_PK");

                entity.HasOne(d => d.RoleIdPkNavigation)
                    .WithMany(p => p.TblUserRole)
                    .HasForeignKey(d => d.RoleIdPk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_131");
            });
            modelBuilder.Entity<UserEntity>().HasNoKey();
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
