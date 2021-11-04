﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Team6CVGS.Models
{
    public partial class CVGSContext : DbContext
    {
        public CVGSContext()
        {
        }

        public CVGSContext(DbContextOptions<CVGSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<CreditCard> CreditCards { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeePayCategory> EmployeePayCategories { get; set; }
        public virtual DbSet<EmployeePosition> EmployeePositions { get; set; }
        public virtual DbSet<EsrbContentDescriptor> EsrbContentDescriptors { get; set; }
        public virtual DbSet<EsrbRating> EsrbRatings { get; set; }
        public virtual DbSet<EventLog> EventLogs { get; set; }
        public virtual DbSet<GameCategory> GameCategories { get; set; }
        public virtual DbSet<GameCompany> GameCompanies { get; set; }
        public virtual DbSet<GamePerspective> GamePerspectives { get; set; }
        public virtual DbSet<GameStatus> GameStatuses { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<LocationType> LocationTypes { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistories { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Platform> Platforms { get; set; }
        public virtual DbSet<Population> Populations { get; set; }
        public virtual DbSet<PopulationClassification> PopulationClassifications { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<Sku> Skus { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<SupplierContact> SupplierContacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-7JMFIQA;Database=CVGS;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AI");

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.Name, "RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.UserName, "UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_UserId");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId })
                    .HasName("PK_dbo.AspNetUserLogins");

                entity.HasIndex(e => e.UserId, "IX_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PK_dbo.AspNetUserRoles");

                entity.HasIndex(e => e.RoleId, "IX_RoleId");

                entity.HasIndex(e => e.UserId, "IX_UserId");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.RoleId).HasMaxLength(128);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("Country_PK");

                entity.ToTable("Country");

                entity.Property(e => e.Code)
                    .HasMaxLength(3)
                    .IsFixedLength(true);

                entity.Property(e => e.Alpha2Code)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsFixedLength(true);

                entity.Property(e => e.EnglishName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FrenchName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CreditCard>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("CreditCard_PK");

                entity.ToTable("CreditCard");

                entity.Property(e => e.Code)
                    .HasMaxLength(15)
                    .IsFixedLength(true);

                entity.Property(e => e.CardNumberPrefixList)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.EnglishName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsFixedLength(true);

                entity.Property(e => e.FrenchName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("Department_PK");

                entity.ToTable("Department");

                entity.Property(e => e.Code)
                    .HasMaxLength(2)
                    .IsFixedLength(true);

                entity.Property(e => e.EnglishName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FrenchName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.PersonId)
                    .HasName("Employee_PK");

                entity.ToTable("Employee");

                entity.Property(e => e.PersonId).ValueGeneratedNever();

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.DepartmentCode)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsFixedLength(true);

                entity.Property(e => e.Gln)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsFixedLength(true);

                entity.Property(e => e.HireDate).HasColumnType("datetime");

                entity.Property(e => e.Note).HasMaxLength(4000);

                entity.Property(e => e.PayCategoryCode)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsFixedLength(true);

                entity.Property(e => e.PositionCode)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsFixedLength(true);

                entity.Property(e => e.TerminationDate).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasDefaultValueSql("('Unknown')");

                entity.HasOne(d => d.DepartmentCodeNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Employee_Department_FK");

                entity.HasOne(d => d.GlnNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.Gln)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Employee_Location_FK");

                entity.HasOne(d => d.PayCategoryCodeNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PayCategoryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Employee_EmployeePayCategory_FK");

                entity.HasOne(d => d.Person)
                    .WithOne(p => p.Employee)
                    .HasForeignKey<Employee>(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Employee_Person_FK");

                entity.HasOne(d => d.PositionCodeNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PositionCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Employee_EmployeePosition_FK");
            });

            modelBuilder.Entity<EmployeePayCategory>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("EmployeePayCategory_PK");

                entity.ToTable("EmployeePayCategory");

                entity.Property(e => e.Code)
                    .HasMaxLength(3)
                    .IsFixedLength(true);

                entity.Property(e => e.EnglishName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.FrenchName)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<EmployeePosition>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("EmployeePosition_PK");

                entity.ToTable("EmployeePosition");

                entity.Property(e => e.Code)
                    .HasMaxLength(3)
                    .IsFixedLength(true);

                entity.Property(e => e.EnglishName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FrenchName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<EsrbContentDescriptor>(entity =>
            {
                entity.ToTable("EsrbContentDescriptor");

                entity.Property(e => e.EnglishDescriptor)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FrenchDescriptor)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<EsrbRating>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("EsrbRatingCode_PK");

                entity.ToTable("EsrbRating");

                entity.Property(e => e.Code)
                    .HasMaxLength(5)
                    .IsFixedLength(true);

                entity.Property(e => e.EnglishRating)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.FrenchRating)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<EventLog>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .HasName("EventLog_PK")
                    .IsClustered(false);

                entity.ToTable("EventLog");

                entity.HasIndex(e => e.Date, "EventLog_Date_IX")
                    .IsClustered();

                entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(11)
                    .HasDefaultValueSql("('INFORMATION')")
                    .IsFixedLength(true);

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Detail).HasMaxLength(4000);

                entity.Property(e => e.Event).HasMaxLength(6);
            });

            modelBuilder.Entity<GameCategory>(entity =>
            {
                entity.ToTable("GameCategory");

                entity.Property(e => e.EnglishCategory)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.FrenchCategory)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<GameCompany>(entity =>
            {
                entity.ToTable("GameCompany");

                entity.Property(e => e.EnglishName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.FrenchName)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<GamePerspective>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("GamePerspective_PK");

                entity.ToTable("GamePerspective");

                entity.Property(e => e.Code)
                    .HasMaxLength(1)
                    .IsFixedLength(true);

                entity.Property(e => e.EnglishPerspectiveName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsFixedLength(true);

                entity.Property(e => e.FrenchPerspectiveName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<GameStatus>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("GameStatus_PK");

                entity.ToTable("GameStatus");

                entity.Property(e => e.Code)
                    .HasMaxLength(1)
                    .IsFixedLength(true);

                entity.Property(e => e.EnglishCategory)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.FrenchCategory)
                    .IsRequired()
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(e => e.Gln)
                    .HasName("Location_PK");

                entity.ToTable("Location");

                entity.Property(e => e.Gln)
                    .HasMaxLength(11)
                    .HasDefaultValueSql("('?')")
                    .IsFixedLength(true);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsFixedLength(true);

                entity.Property(e => e.Fax).HasMaxLength(22);

                entity.Property(e => e.LocalPhone)
                    .IsRequired()
                    .HasMaxLength(22);

                entity.Property(e => e.LocationTypeCode)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsFixedLength(true);

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.ProvinceCode)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsFixedLength(true);

                entity.Property(e => e.Sequence).ValueGeneratedOnAdd();

                entity.Property(e => e.SiteName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.TollFreePhone).HasMaxLength(22);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasDefaultValueSql("('Unknown')");

                entity.HasOne(d => d.CountryCodeNavigation)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.CountryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Location_Country_FK");

                entity.HasOne(d => d.LocationTypeCodeNavigation)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.LocationTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Location_LocationType_FK");

                entity.HasOne(d => d.ProvinceCodeNavigation)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.ProvinceCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Location_Province_FK");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Location_Region_FK");
            });

            modelBuilder.Entity<LocationType>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("LocationType_PK");

                entity.ToTable("LocationType");

                entity.Property(e => e.Code)
                    .HasMaxLength(1)
                    .IsFixedLength(true);

                entity.Property(e => e.EnglishName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.FrenchName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person");

                entity.HasIndex(e => new { e.Surname, e.GivenName }, "Person_SurnameGivenName_IX");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsFixedLength(true);

                entity.Property(e => e.Email).HasMaxLength(60);

                entity.Property(e => e.Extension).HasMaxLength(6);

                entity.Property(e => e.Fax).HasMaxLength(22);

                entity.Property(e => e.GivenName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LandLine).HasMaxLength(22);

                entity.Property(e => e.Mobile).HasMaxLength(22);

                entity.Property(e => e.PostalCode).HasMaxLength(10);

                entity.Property(e => e.ProvinceCode)
                    .HasMaxLength(2)
                    .IsFixedLength(true);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasDefaultValueSql("('Unknown')");

                entity.HasOne(d => d.CountryCodeNavigation)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.CountryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Person_Country_FK");

                entity.HasOne(d => d.ProvinceCodeNavigation)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.ProvinceCode)
                    .HasConstraintName("Person_Province_FK");
            });

            modelBuilder.Entity<Platform>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("Platform_PK");

                entity.ToTable("Platform");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.EnglishName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.FrenchName)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<Population>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .HasName("Population_PK")
                    .IsClustered(false);

                entity.ToTable("Population");

                entity.HasIndex(e => e.City, "Population_City_IX");

                entity.HasIndex(e => new { e.Surname, e.GivenName }, "Population_SurnameGivenName_IX");

                entity.Property(e => e.Guid).ValueGeneratedNever();

                entity.Property(e => e.AccountNumber)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Amex)
                    .HasMaxLength(20)
                    .IsFixedLength(true);

                entity.Property(e => e.BankCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.BranchAddress).HasMaxLength(60);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsFixedLength(true);

                entity.Property(e => e.Email).HasMaxLength(60);

                entity.Property(e => e.Extension).HasMaxLength(6);

                entity.Property(e => e.Fax).HasMaxLength(22);

                entity.Property(e => e.FinancialInstitution).HasMaxLength(50);

                entity.Property(e => e.GivenName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Hin)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.LandLine).HasMaxLength(22);

                entity.Property(e => e.MasterCard)
                    .HasMaxLength(20)
                    .IsFixedLength(true);

                entity.Property(e => e.Mobile).HasMaxLength(22);

                entity.Property(e => e.PopulationClassificationCode)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsFixedLength(true);

                entity.Property(e => e.PostalCode).HasMaxLength(10);

                entity.Property(e => e.ProvinceCode)
                    .HasMaxLength(2)
                    .IsFixedLength(true);

                entity.Property(e => e.Sequence).ValueGeneratedOnAdd();

                entity.Property(e => e.Sin)
                    .HasMaxLength(9)
                    .IsFixedLength(true);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TransitNumber)
                    .HasMaxLength(5)
                    .IsFixedLength(true);

                entity.Property(e => e.Visa)
                    .HasMaxLength(20)
                    .IsFixedLength(true);

                entity.HasOne(d => d.CountryCodeNavigation)
                    .WithMany(p => p.Populations)
                    .HasForeignKey(d => d.CountryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Population_Country_FK");

                entity.HasOne(d => d.PopulationClassificationCodeNavigation)
                    .WithMany(p => p.Populations)
                    .HasForeignKey(d => d.PopulationClassificationCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Population_PopulationClassification_FK");

                entity.HasOne(d => d.ProvinceCodeNavigation)
                    .WithMany(p => p.Populations)
                    .HasForeignKey(d => d.ProvinceCode)
                    .HasConstraintName("Population_Province_FK");
            });

            modelBuilder.Entity<PopulationClassification>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PopulationClassification_PK");

                entity.ToTable("PopulationClassification");

                entity.Property(e => e.Code)
                    .HasMaxLength(1)
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("ProvinceLookup_PK");

                entity.ToTable("Province");

                entity.Property(e => e.Code)
                    .HasMaxLength(2)
                    .IsFixedLength(true);

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsFixedLength(true);

                entity.Property(e => e.EnglishName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FederalTax).HasDefaultValueSql("((0))");

                entity.Property(e => e.FederalTaxAcronym)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.FrenchName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ProvincialTax).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProvincialTaxAcronym)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.PstOnGst).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.ToTable("Region");

                entity.Property(e => e.EnglishName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.FrenchName)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Sku>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Sku");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("Supplier");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsFixedLength(true);

                entity.Property(e => e.Fax).HasMaxLength(22);

                entity.Property(e => e.LocalPhone)
                    .IsRequired()
                    .HasMaxLength(22);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.ProvinceCode)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsFixedLength(true);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.TollFreePhone).HasMaxLength(22);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasDefaultValueSql("('Unknown')");

                entity.Property(e => e.WebSite).HasMaxLength(60);

                entity.HasOne(d => d.CountryCodeNavigation)
                    .WithMany(p => p.Suppliers)
                    .HasForeignKey(d => d.CountryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Supplier_Country_FK");

                entity.HasOne(d => d.ProvinceCodeNavigation)
                    .WithMany(p => p.Suppliers)
                    .HasForeignKey(d => d.ProvinceCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Supplier_Province_FK");
            });

            modelBuilder.Entity<SupplierContact>(entity =>
            {
                entity.ToTable("SupplierContact");

                entity.Property(e => e.Email).HasMaxLength(60);

                entity.Property(e => e.Extension).HasMaxLength(6);

                entity.Property(e => e.GivenName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LandLine).HasMaxLength(22);

                entity.Property(e => e.Mobile).HasMaxLength(22);

                entity.Property(e => e.Note).HasMaxLength(4000);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasDefaultValueSql("('Unknown')");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.SupplierContacts)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SupplierContact_Supplier_FK");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
