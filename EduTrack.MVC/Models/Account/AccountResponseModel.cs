namespace EduTrack.MVC.Models.Account
{
    public class AccountResponseModel
    {
        public bool Succeeded { get; set; }
        public IEnumerable<AccountErrorModel> Errors { get; set; }
        public string UserToken { get; set; }
        public string Username { get; set; }
    }

}