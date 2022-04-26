using Microsoft.EntityFrameworkCore;
using Website.Data.Tutorial.Schema;

namespace Website.Data.Tutorial;

public class TutorialContext : DbContext
{


    public TutorialContext(DbContextOptions<TutorialContext> options) : base(options)
    {

    }

    public TutorialContext()
    {

    }


    protected override void OnModelCreating(ModelBuilder builder)
    {

    }

    private void SetBaseEntityDefaults<T>(ModelBuilder builder)
        where T : BaseEntity
    {

        builder.Entity<T>().Property(entity => entity.RecordBy)
               .ValueGeneratedOnAdd()
               .HasDefaultValueSql("SYSDATETIMEOFFSET()");

        builder.Entity<T>().Property(entity => entity.ModifiedDate)
        .ValueGeneratedOnUpdate()
        .HasDefaultValueSql("SYSDATETIMEOFFSET()");
    }





}