using Microsoft.AspNetCore.Identity;
using System;

namespace ModManager.Db
{
    public partial class ApplicationUserRole : IdentityUserRole<Guid>
    {
        public ApplicationUserRole() : base() { }
    }
}
