using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModManager.Db
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public IList<ApplicationUserRole> UserRoles { get; set; }

        public ApplicationRole()
        { }

        public void Configure(EntityTypeBuilder<ApplicationUser> modelBuilder)
        {
            // Default ID
            modelBuilder.Property(x => x.Id).HasDefaultValue(RT.Comb.Provider.Sql.Create());
        }

        public static Guid GetRoleId(Role role)
        {
            switch (role)
            {
                case Role.Admin:
                    using (ModManDbContext _context = new ModManDbContext())
                    {
                        return (from b in _context.ApplicationRoles where b.Name == "Admin" select b.Id).Single();
                    }
                case Role.User:
                    using (ModManDbContext _context = new ModManDbContext())
                    {
                        return (from b in _context.ApplicationRoles where b.Name == "User" select b.Id).Single();
                    }
                default:
                    throw new NotImplementedException("Unknown role: " + role.ToString());
            }
        }

        public enum Role
        {
            Admin,
            User
        }
    }
}
