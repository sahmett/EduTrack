namespace EduTrack.Domain.Common
{
    public interface IModifiedByEntity
    {
        public DateTimeOffset? ModifiedOn { get; set; }
        public string? ModifiedByUserId { get; set; }
    }
}
