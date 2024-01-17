using EduTrack.Application.Models.CourseContent;
using EduTrack.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduTrack.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CourseContentController : ControllerBase
    {
        private readonly EduTrackContext _eduTrackContext;

        public CourseContentController(EduTrackContext eduTrackContext)
        {
            _eduTrackContext = eduTrackContext;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourseContent(Application.Models.CourseContent.CreateCourseContent createCourseContent)
        {
            var courseContent = new CourseContent
            {
                Id = Guid.NewGuid(),
                Name = createCourseContent.Name,
                Type = createCourseContent.Type,
                CourseId = createCourseContent.CourseId,
                Link = createCourseContent.Link,
                CreatedByUserId = "codemaster"
            };
            await _eduTrackContext.CourseContents.AddAsync(courseContent);
            await _eduTrackContext.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCourseContentById(Guid id)
        {
            var courseContent = await _eduTrackContext.CourseContents.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(courseContent);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourseContents()
        {
            var courseContents = await _eduTrackContext.CourseContents.ToListAsync();
            return Ok(courseContents);
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateCourseContent(Guid id, UpdateCourseContent updateCourseContent)
        {
            var courseContent = await _eduTrackContext.CourseContents.FirstOrDefaultAsync(x => x.Id == id);
            courseContent.Name = updateCourseContent.Name;
            courseContent.Type = updateCourseContent.Type;
            courseContent.CourseId = updateCourseContent.CourseId;
            courseContent.Link = updateCourseContent.Link;

            await _eduTrackContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCourseContent(Guid id)
        {
            var courseContent = await _eduTrackContext.CourseContents.FirstOrDefaultAsync(x => x.Id == id);
            _eduTrackContext.CourseContents.Remove(courseContent);
            await _eduTrackContext.SaveChangesAsync();
            return Ok();
        }
    }
}
