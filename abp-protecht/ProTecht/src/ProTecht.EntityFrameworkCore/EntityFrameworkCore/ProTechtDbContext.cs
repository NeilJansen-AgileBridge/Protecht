using ProTecht.Quotes;
using ProTecht.People;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.LanguageManagement.EntityFrameworkCore;
using Volo.Abp.TextTemplateManagement.EntityFrameworkCore;
using Volo.Abp.Gdpr;

namespace ProTecht.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityProDbContext))]
[ConnectionStringName("Default")]
public class ProTechtDbContext :
    AbpDbContext<ProTechtDbContext>,
    IIdentityProDbContext
{
    public DbSet<Quote> Quotes { get; set; } = null!;
    public DbSet<Person> People { get; set; } = null!;
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    /* Notice: We only implemented IIdentityProDbContext 
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityProDbContext .
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    // Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }
    public DbSet<IdentitySession> Sessions { get; set; }

    #endregion

    public ProTechtDbContext(DbContextOptions<ProTechtDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureFeatureManagement();
        builder.ConfigureIdentityPro();
        builder.ConfigureOpenIddictPro();
        builder.ConfigureLanguageManagement();
        builder.ConfigureTextTemplateManagement();
        builder.ConfigureGdpr();
        builder.ConfigureBlobStoring();

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(ProTechtConsts.DbTablePrefix + "YourEntities", ProTechtConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
        if (builder.IsHostDatabase())
        {

        }
        if (builder.IsHostDatabase())
        {

        }
        if (builder.IsHostDatabase())
        {

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<Quote>(b =>
            {
                b.ToTable(ProTechtConsts.DbTablePrefix + "Quotes", ProTechtConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.Amount).HasColumnName(nameof(Quote.Amount));
                b.Property(x => x.Vendor).HasColumnName(nameof(Quote.Vendor));
                b.HasOne<Person>().WithMany().HasForeignKey(x => x.PersonId).OnDelete(DeleteBehavior.SetNull);
            });

        }
        if (builder.IsHostDatabase())
        {

        }
        if (builder.IsHostDatabase())
        {

        }
        if (builder.IsHostDatabase())
        {
            builder.Entity<Person>(b =>
            {
                b.ToTable(ProTechtConsts.DbTablePrefix + "People", ProTechtConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.PersonId).HasColumnName(nameof(Person.PersonId));
                b.Property(x => x.Name).HasColumnName(nameof(Person.Name)).IsRequired();
                b.Property(x => x.Surname).HasColumnName(nameof(Person.Surname)).IsRequired();
                b.Property(x => x.ContactNumber).HasColumnName(nameof(Person.ContactNumber));
                b.Property(x => x.VehicleRegistration).HasColumnName(nameof(Person.VehicleRegistration));
                b.Property(x => x.VehicleType).HasColumnName(nameof(Person.VehicleType));
                b.Property(x => x.Age).HasColumnName(nameof(Person.Age));
            });

        }
    }
}