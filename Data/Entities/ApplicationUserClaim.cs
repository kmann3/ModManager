using Microsoft.AspNetCore.Identity;
using System;

namespace ModManager.Data
{
    public partial class ApplicationUserClaim : IdentityUserClaim<Guid>
    {
        public ApplicationUserClaim() : base() { }
    }
}
