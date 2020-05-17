using Microsoft.AspNetCore.Identity;
using System;

namespace ModManager.Data
{
    public partial class ApplicationUserRole : IdentityUserRole<Guid>
    {
        public ApplicationUserRole() : base() { }
    }
}
