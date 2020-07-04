using Microsoft.AspNetCore.Identity;
using System;

namespace ModManager.Db
{
    public partial class ApplicationRoleClaim : IdentityRoleClaim<Guid>
    {
        public ApplicationRoleClaim() : base() { }
    }
}
