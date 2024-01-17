namespace EduTrack.Application.Models.Category
{
    public class UpdateCategory
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
    }
}