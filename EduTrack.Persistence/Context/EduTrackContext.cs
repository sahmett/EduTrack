using Microsoft.EntityFrameworkCore;
using EduTrack.Domain.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;
using EduTrack.Domain.Identity;
using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

public class EduTrackContext : IdentityDbContext<User, Role, Guid>
{


    public DbSet<Course> Courses { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<CourseContent> CourseContents { get; set; }
    public DbSet<UserCourse> UserCourses { get; set; }

    public EduTrackContext(DbContextOptions<EduTrackContext> dbContextOptions)
    : base(dbContextOptions)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);

        // Burada Fluent API ile ilişkileri ve kısıtlamaları konfigüre edebiliriz
    }
}
