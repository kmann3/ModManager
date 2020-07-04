using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Make sure you have Access database connection install. This is not installed by default.
/// Database schema and context for LotEK.
/// If you need to rebuild the database then do the following:
/// Open up SSMS and run the following code to remove all the tables (or you can manually delete them).
/// <code>
/*
DECLARE @Sql NVARCHAR(500) DECLARE @Cursor CURSOR
SET @Cursor = CURSOR FAST_FORWARD FOR
SELECT DISTINCT sql = 'ALTER TABLE [' + tc2.TABLE_SCHEMA + '].[' + tc2.TABLE_NAME + '] DROP [' + rc1.CONSTRAINT_NAME + '];'
FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS rc1
LEFT JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc2 ON tc2.CONSTRAINT_NAME = rc1.CONSTRAINT_NAME
OPEN @Cursor FETCH NEXT FROM @Cursor INTO @Sql
WHILE (@@FETCH_STATUS = 0)
BEGIN
Exec sp_executesql @Sql
FETCH NEXT FROM @Cursor INTO @Sql
END
CLOSE @Cursor DEALLOCATE @Cursor
GO
EXEC sp_MSforeachtable 'DROP TABLE ?'
GO
*/
/// </code>
/// Then delete the migrations
/// Then run, in Package Manager Console with the default project set to LotEK_DB:
/// add-migration init
/// update-database
/// // add-migration 000-init -OutputDir Db/Migrations -Context ModManDbContext
/// </summary>
namespace ModManager.Db
{
    public class ModManDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid, ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>
    {
        private static string _connectionString { get; set; } = null;
        public static string ConnectionString
        {
            get => _connectionString;
            set => _connectionString = value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (ConnectionString == null)
            {
                optionsBuilder.UseSqlServer("Data Source=KENNY-MSI-LAPTO;Initial Catalog=ModMan;Integrated Security=true;");
            }
            else
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        public ModManDbContext(DbContextOptions<ModManDbContext> options)
            : base(options)
        {
        }

        public ModManDbContext()
        {
        }

        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<ApplicationRoleClaim> ApplicationRoleClaims { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationUserClaim> ApplicationUserClaims { get; set; }
        public DbSet<ApplicationUserLogin> ApplicationUserLogins { get; set; }
        public DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }
        public DbSet<ApplicationUserToken> ApplicationUserTokens { get; set; }
    }
}
