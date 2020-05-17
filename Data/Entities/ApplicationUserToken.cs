using Microsoft.AspNetCore.Identity;
using System;

namespace ModManager.Data
{
    public partial class ApplicationUserToken : IdentityUserToken<Guid>
    {
        public ApplicationUserToken() : base() { }
    }
}
