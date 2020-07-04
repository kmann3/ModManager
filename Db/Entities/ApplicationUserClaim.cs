using Microsoft.AspNetCore.Identity;
using System;

namespace ModManager.Db
{
    public partial class ApplicationUserClaim : IdentityUserClaim<Guid>
    {
        public ApplicationUserClaim() : base() { }
    }
}
