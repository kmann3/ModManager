using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModManager.Db
{
    /// <summary>
    /// Basic table structure that nearly all tables should have.
    /// </summary>
    public abstract class BasicTable<T> : IEntityTypeConfiguration<T> where T : class
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; } = RT.Comb.Provider.Sql.Create();

        [Required]
        [Display(Name = "Name")]
        [StringLength(255)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Date Created")]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        [Display(Name = "Date Created")]
        [DisplayFormat(DataFormatString = "{0: dd MMMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreatedOnCST
        {
            get
            {
                TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
                return TimeZoneInfo.ConvertTimeFromUtc(CreatedOn, cstZone); ;
            }
        }

        [Required]
        [Display(Name = "Created by")]
        public Guid CreatedByUserId { get; set; }
        public ApplicationUser CreatedByUser { get; set; }

        public override string ToString()
        {
            return $"Name: {Name} | ID: {Id}";
        }

        public abstract void Configure(EntityTypeBuilder<T> modelBuilder);

        public void Configure(ModelBuilder modelBuilder)
        {
            Configure(modelBuilder.Entity<T>());
            //modelBuilder.Entity<BasicTable<T>>().HasIndex(x => x.Name);
        }
    }

    /// <summary>
    /// Until .NET 5 comes out, we have to use Link tables.
    /// </summary>
    public abstract class BasicLinkTable<T> : IEntityTypeConfiguration<T> where T : class
    {
        [Required]
        [Display(Name = "Date Created")]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        [Display(Name = "Date Created")]
        [DisplayFormat(DataFormatString = "{0: dd MMMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreatedOnCST
        {
            get
            {
                TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
                return TimeZoneInfo.ConvertTimeFromUtc(CreatedOn, cstZone); ;
            }
        }

        [Required]
        [Display(Name = "Created by")]
        public Guid CreatedByUserId { get; set; }
        public ApplicationUser CreatedByUser { get; set; }

        public abstract void Configure(EntityTypeBuilder<T> modelBuilder);

        public void Configure(ModelBuilder modelBuilder)
        {
            Configure(modelBuilder.Entity<T>());
        }
    }
}
