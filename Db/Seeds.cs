using System;
using System.Security.Cryptography;

namespace ModManager.Db
{
    public class Seeds
    {
        //public class NewsData
        //{
        //    public static News InitArticle = new News()
        //    {
        //        Id = Guid.NewGuid(),
        //        CreatedByUserId = AppUser.Kenny.Id,
        //        CreatedOn = DateTime.UtcNow,
        //        Log = "A new db has been created.",
        //        Name = "Init News",
        //        TypeCssBg = "",
        //        TypeCssText = "text-danger"
        //    };
        //}
        public class AppUser
        {
            private static string HashPassword(string password)
            {
                byte[] salt;
                byte[] buffer2;
                if (password == null)
                {
                    throw new ArgumentNullException("password");
                }
                using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
                {
                    salt = bytes.Salt;
                    buffer2 = bytes.GetBytes(0x20);
                }
                byte[] dst = new byte[0x31];
                Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
                Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
                return Convert.ToBase64String(dst);
            }

            /// <summary>
            /// Kenny
            /// </summary>
            public static ApplicationUser Kenny = new ApplicationUser()
            {
                Id = Guid.Parse("9fa7c39d-a4c7-4c7c-9986-b48644c309af"),
                UserName = "kmann@etherpunk.com",
                NormalizedUserName = "KMANN@ETHERPUNK.COM",
                NormalizedEmail = "kmann@etherpunk.com".ToUpper(),
                Email = "kmann@etherpunk.com",
                EmailConfirmed = false,
                PasswordHash = HashPassword("Foobarbang!"),
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                AccessFailedCount = 0,
                FirstName = "Kenny",
                LastName = "Mann",
                IsDisabled = false,
                IsDeleted = false,
                CreatedOn = new DateTime(2017, 01, 22, 11, 00, 13)
            };

            /// <summary>
            /// PlainUser
            /// </summary>
            public static ApplicationUser PlainUser = new ApplicationUser()
            {
                Id = Guid.Parse("9957d930-3560-4e6c-9b1a-52a25b35ae69"),
                UserName = "myuser@user.com",
                NormalizedUserName = "MYUSER@USER.COM",
                NormalizedEmail = "MYUSER@USER.COM",
                Email = "myuser@user.com",
                EmailConfirmed = false,
                PasswordHash = HashPassword("Foobarbang!"),
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                AccessFailedCount = 0,
                FirstName = "Plain",
                LastName = "User",
                IsDisabled = false,
                IsDeleted = false,
                CreatedOn = new DateTime(2017, 01, 22, 11, 00, 13)
            };
        }

        public class AppUserRole
        {
            public static ApplicationUserRole KennyAdmin = new ApplicationUserRole
            {
                UserId = AppUser.Kenny.Id,
                RoleId = Roles.Admin.Id,
            };

            public static ApplicationUserRole KevinAdmin = new ApplicationUserRole
            {
                RoleId = Roles.Admin.Id
            };

            public static ApplicationUserRole PlainUser = new ApplicationUserRole()
            {
                UserId = AppUser.PlainUser.Id,
                RoleId = Roles.User.Id
            };

        }

        public class Roles
        {
            public static ApplicationRole Admin => new ApplicationRole()
            {
                Id = Guid.Parse("6d68a30e-caec-45d4-9df7-126478e0fa04"),
                Name = "Admin",
                NormalizedName = "ADMIN"
            };

            public static ApplicationRole User => new ApplicationRole()
            {
                Id = Guid.Parse("1e1d997b-ad2b-464f-9ab0-c734bff80e5c"),
                Name = "User",
                NormalizedName = "USER"
            };
        }
    }
}
