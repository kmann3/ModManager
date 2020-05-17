using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModManager.Data
{
    public partial class ApplicationUser : IdentityUser<Guid>, IEntityTypeConfiguration<ApplicationUser>
    {
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public string FirstName { get; set; }

        public string FullNameFirstFirst => FirstName + " " + LastName;

        public string FullNameLastFirst => LastName + ", " + FirstName;

        /// <summary>
        /// Users are NEVER deleted because they can reference data and deleting them would orphan that data.
        /// </summary>
        public bool IsDeleted { get; set; } = false;

        public bool IsDisabled { get; set; } = false;
        public string LastName { get; set; } = String.Empty;

        //=================
        // CreatedBy
        //=================
        //public IList<Armor> ArmorsCreatedBy { get; set; }

        public void Configure(EntityTypeBuilder<ApplicationUser> modelBuilder)
        {
            // Default ID
            modelBuilder.Property(x => x.Id).HasDefaultValueSql("newsequentialid()");
        }

        public static bool IsUserInGroup(Guid userId, ApplicationRole.Role role)
        {
            using (ModManDbContext _context = new ModManDbContext())
            {
                Guid roleId = ApplicationRole.GetRoleId(role);
                ApplicationUserRole link = (from a in _context.ApplicationUserRoles where a.RoleId == roleId && a.UserId == userId select a).FirstOrDefault();

                if (link == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
