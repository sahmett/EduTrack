using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EduTrack.Domain.Entities;

public class UserCourseConfiguration : IEntityTypeConfiguration<UserCourse>
{
    public void Configure(EntityTypeBuilder<UserCourse> builder)
    {
        // Bileşik Anahtar Tanımlama
        builder.HasKey(uc => new { uc.UserId, uc.CourseId });

        // User ile olan ilişki
        builder.HasOne(uc => uc.User)
               .WithMany(u => u.UserCourses)
               .HasForeignKey(uc => uc.UserId);

        // Course ile olan ilişki
        builder.HasOne(uc => uc.Course)
               .WithMany(c => c.UserCourses)
               .HasForeignKey(uc => uc.CourseId);

        // EntityBase ortak konfigürasyonları
        builder.Property(e => e.CreatedByUserId).IsRequired();
        builder.Property(e => e.CreatedOn).IsRequired();
        //builder.Property(e => e.ModifiedByUserId).IsRequired(false);
        //builder.Property(e => e.ModifiedOn).IsRequired(false);
        //builder.Property(e => e.IsDeleted).IsRequired();
        //builder.Property(e => e.DeletedByUserId).IsRequired(false);
        //builder.Property(e => e.DeletedOn).IsRequired(false);
    }
}
