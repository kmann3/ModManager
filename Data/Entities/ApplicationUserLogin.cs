using Microsoft.AspNetCore.Identity;
using System;

namespace ModManager.Data
{
    public partial class ApplicationUserLogin : IdentityUserLogin<Guid>
    {
        public ApplicationUserLogin() : base() { }
    }
}
