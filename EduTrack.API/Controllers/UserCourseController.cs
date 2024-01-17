
using EduTrack.Application.Models.User;
using EduTrack.Domain.Entities;
using EduTrack.Domain.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduTrack.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserCourseController : ControllerBase
    {
        private readonly EduTrackContext _eduTrackContext;
        private readonly UserManager<User> _userManager;

        public UserCourseController(EduTrackContext eduTrackContext, UserManager<User> userManager)
        {
            _eduTrackContext = eduTrackContext;
            _userManager = userManager;
        }


        //enrol user by user id to course
        [HttpPost]
        [Route("{userId}")]
        public async Task<IActionResult> EnrolUserToCourse(Guid userId, EnrolUserToCourseRequest enrolUserToCourse)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                return NotFound();
            }
            var course = await _eduTrackContext.Courses.FirstOrDefaultAsync(x => x.Id == enrolUserToCourse.CourseId);
            if (course == null)
            {
                return NotFound();
            }
            var userCourse = new UserCourse
            {
                UserId = user.Id,
                CourseId = course.Id,
                CreatedByUserId = "codemaster"
            };
            await _eduTrackContext.UserCourses.AddAsync(userCourse);
            await _eduTrackContext.SaveChangesAsync();
            return Ok();
        }

        //enrol course by enrolusertocourse model
        [HttpPost]
        public async Task<IActionResult> EnrolUserToCourse(EnrolUserToCourseRequest enrolUserToCourse)
        {
            var user = await _userManager.FindByIdAsync(enrolUserToCourse.UserId.ToString());
            if (user == null)
            {
                return NotFound();
            }
            var course = await _eduTrackContext.Courses.FirstOrDefaultAsync(x => x.Id == enrolUserToCourse.CourseId);
            if (course == null)
            {
                return NotFound();
            }
            var userCourse = new UserCourse
            {
                UserId = user.Id,
                CourseId = course.Id,
                CreatedByUserId = "codemaster"
            };
            await _eduTrackContext.UserCourses.AddAsync(userCourse);
            await _eduTrackContext.SaveChangesAsync();
            return Ok();
        }

        //update enroled course isFinished status true by user id and course id
        [HttpPut]
        [Route("{userId}/{courseId}")]
        public async Task<IActionResult> CompleteCourse(Guid userId, Guid courseId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                return NotFound();
            }
            var course = await _eduTrackContext.Courses.FirstOrDefaultAsync(x => x.Id == courseId);
            if (course == null)
            {
                return NotFound();
            }
            var userCourse = await _eduTrackContext.UserCourses.FirstOrDefaultAsync(x => x.UserId == userId && x.CourseId == courseId);
            if (userCourse == null)
            {
                return NotFound();
            }
            userCourse.isFinished = true;
            await _eduTrackContext.SaveChangesAsync();
            return Ok(userCourse);
        }


        //delete enrolment by user id and course id
        [HttpDelete]
        [Route("{userId}/{courseId}")]
        public async Task<IActionResult> DeleteEnrolment(Guid userId, Guid courseId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                return NotFound();
            }
            var course = await _eduTrackContext.Courses.FirstOrDefaultAsync(x => x.Id == courseId);
            if (course == null)
            {
                return NotFound();
            }
            var userCourse = await _eduTrackContext.UserCourses.FirstOrDefaultAsync(x => x.UserId == userId && x.CourseId == courseId);
            if (userCourse == null)
            {
                return NotFound();
            }
            _eduTrackContext.UserCourses.Remove(userCourse);
            await _eduTrackContext.SaveChangesAsync();
            return Ok();
        }

        

    }
}
