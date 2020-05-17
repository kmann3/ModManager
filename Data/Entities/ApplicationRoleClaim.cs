using Microsoft.AspNetCore.Identity;
using System;

namespace ModManager.Data
{
    public partial class ApplicationRoleClaim : IdentityRoleClaim<Guid>
    {
        public ApplicationRoleClaim() : base() { }
    }
}
