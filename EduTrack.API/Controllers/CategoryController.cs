using EduTrack.Application.Models.Category;
using EduTrack.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduTrack.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly EduTrackContext _eduTrackContext;

        public CategoryController(EduTrackContext eduTrackContext)
        {
            _eduTrackContext = eduTrackContext;
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategory createCategory)
        {   
            var category = new Category
            {
                Id = Guid.NewGuid(),
                Name = createCategory.Name,
                Description = createCategory.Description,
                CreatedByUserId = "codemaster"
                // CreatedByUserId = User.Identity.Name
                // CreatedByUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value
               
            };
            await _eduTrackContext.Categories.AddAsync(category);
            await _eduTrackContext.SaveChangesAsync(); 
            return Ok(category);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _eduTrackContext.Categories.ToListAsync();
            return Ok(categories);
        }

        //get category by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            var category = await _eduTrackContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }



        //update category
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(Application.Models.Category.UpdateCategory updateCategory)
        {
            var category = await _eduTrackContext.Categories.FirstOrDefaultAsync(x => x.Id == updateCategory.CategoryId);
            if (category == null)
            {
                return NotFound();
            }
            category.Name = updateCategory.Name;
            category.Description = updateCategory.Description;
            await _eduTrackContext.SaveChangesAsync();
            return Ok(category);
        }

        //delete category by id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var category = await _eduTrackContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _eduTrackContext.Categories.Remove(category);
            await _eduTrackContext.SaveChangesAsync();
            return Ok(category);
        }


    }
}
