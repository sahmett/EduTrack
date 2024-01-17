
using EduTrack.Application.Models.User;
using EduTrack.Domain.Entities;
using EduTrack.Domain.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduTrack.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly EduTrackContext _eduTrackContext;
        private readonly UserManager<User> _userManager;

        public UserController(EduTrackContext eduTrackContext, UserManager<User> userManager)
        {
            _eduTrackContext = eduTrackContext;
            _userManager = userManager;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _eduTrackContext.Users.ToListAsync();
            return Ok(users);
        }

        //enrolment list by user id
        [HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> GetEnrolmentByUserId(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                return NotFound();
            }
            var userCourses = await _eduTrackContext.UserCourses.Where(x => x.UserId == userId).ToListAsync();
            return Ok(userCourses);
        }


        //update user
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserRequest updateUser)
        {
            var user = await _userManager.FindByEmailAsync(updateUser.Email);
            if (user == null)
            {
                return NotFound();
            }
            user.FirstName = updateUser.FirstName;
            user.LastName = updateUser.LastName;
            user.Email = updateUser.Email;
            user.UserName = updateUser.UserName;
            await _userManager.UpdateAsync(user);
            return Ok(user);
        }


        //delete user
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return NotFound();
            }
            await _userManager.DeleteAsync(user);
            return Ok();
        }


    }
}
