using EduTrack.Application.Models.Course;
using EduTrack.Application.Models.CourseContent;
using EduTrack.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduTrack.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly EduTrackContext _eduTrackContext;

        public CourseController(EduTrackContext eduTrackContext)
        {
            _eduTrackContext = eduTrackContext;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody]CreateCourseRequest createCourse)
        {
            var course = new Course
            {
                Id = Guid.NewGuid(),
                Name = createCourse.Name,
                Description = createCourse.Description,
                InternalTrainer = createCourse.InternalTrainer,                     
                Capacity = createCourse.Capacity,
                Cost = createCourse.Cost,
                Duration = createCourse.Duration,
                CategoryId = Guid.Parse(createCourse.CategoryId),
                CreatedByUserId = "codemaster"

                //course content null

                //Duration = TimeSpan.Parse("1:00:00"),
                //CategoryId = Guid.Parse("c71cae3f-1a70-40cb-9147-44cb87587682"),
                //InternalTrainer = true,

            };
            await _eduTrackContext.Courses.AddAsync(course);
            await _eduTrackContext.SaveChangesAsync();
            return Ok(course);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourseTwo([FromBody] CreateCourseRequestTwo createCourse)
        {
            var course = new Course
            {
                Id = Guid.NewGuid(),
                Name = createCourse.Name,
                Description = createCourse.Description,
                InternalTrainer = createCourse.InternalTrainer,
                Capacity = createCourse.Capacity,
                Cost = createCourse.Cost,
                Duration = createCourse.Duration,
                CategoryId = Guid.Parse(createCourse.CategoryId),
                CourseContentId = Guid.Parse(createCourse.CourseContentId),
                CreatedByUserId = "codemaster"

                //course content null

                //Duration = TimeSpan.Parse("1:00:00"),
                //CategoryId = Guid.Parse("c71cae3f-1a70-40cb-9147-44cb87587682"),
                //InternalTrainer = true,

            };
            await _eduTrackContext.Courses.AddAsync(course);
            await _eduTrackContext.SaveChangesAsync();
            return Ok(course);
        }

        //add course content to course
        [HttpPost("{id}")]
        public async Task<IActionResult> CreateCourseContentToCourse(Guid id, [FromBody] CreateCourseContent createCourseContent)
        {
            var course = await _eduTrackContext.Courses.FindAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            var courseContent = new CourseContent
            {
                Id = Guid.NewGuid(),
                Name = createCourseContent.Name,
                Type = createCourseContent.Type,
                CourseId = id,
                Link = createCourseContent.Link,
                CreatedByUserId = "codemaster"
            };

            await _eduTrackContext.CourseContents.AddAsync(courseContent);
            await _eduTrackContext.SaveChangesAsync();
            return Ok(courseContent);
        }

        //add course content from course content id to course 
        [HttpPost("{id}/{courseContentId}")]
        public async Task<IActionResult> AddCourseContentToCourse(Guid id, Guid courseContentId)
        {
            var course = await _eduTrackContext.Courses.FindAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            var courseContent = await _eduTrackContext.CourseContents.FindAsync(courseContentId);

            if (courseContent == null)
            {
                return NotFound();
            }

            course.CourseContents.Add(courseContent);
            await _eduTrackContext.SaveChangesAsync();
            return Ok(courseContent);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            var courses = await _eduTrackContext.Courses.ToListAsync();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(Guid id)
        {
            var course = await _eduTrackContext.Courses
                .Include(c => c.CourseContents)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (course == null)
            {
                return NotFound();
            }

            return course;
        }

        //update course with id use UpdateCourseRequest
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(Guid id, UpdateCourseRequest updateCourse)
        {
            var course = await _eduTrackContext.Courses.FindAsync(id);

            if (course == null)
            {
                return NotFound();
            }
            course.Name = updateCourse.Name;
            course.Description = updateCourse.Description;
            course.InternalTrainer = updateCourse.InternalTrainer;
            course.Capacity = updateCourse.Capacity;
            course.Cost = updateCourse.Cost;
            course.Duration = updateCourse.Duration;
            course.CategoryId = Guid.Parse(updateCourse.CategoryId);
            course.ModifiedByUserId = "codemaster";

            await _eduTrackContext.SaveChangesAsync();
            return Ok(course);
        }

        //delete course with id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(Guid id)
        {
            var course = await _eduTrackContext.Courses.FindAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            _eduTrackContext.Courses.Remove(course);
            await _eduTrackContext.SaveChangesAsync();
            return Ok(course);
        }

    }
}
