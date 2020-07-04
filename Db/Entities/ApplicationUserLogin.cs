using Microsoft.AspNetCore.Identity;
using System;

namespace ModManager.Db
{
    public partial class ApplicationUserLogin : IdentityUserLogin<Guid>
    {
        public ApplicationUserLogin() : base() { }
    }
}
