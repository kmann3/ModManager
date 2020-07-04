using Microsoft.AspNetCore.Identity;
using System;

namespace ModManager.Db
{
    public partial class ApplicationUserToken : IdentityUserToken<Guid>
    {
        public ApplicationUserToken() : base() { }
    }
}
