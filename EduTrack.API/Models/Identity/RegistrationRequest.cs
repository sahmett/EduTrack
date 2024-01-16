using System.ComponentModel.DataAnnotations;

public class RegistrationRequest
{
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string UserName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "Şifre en az {2} ve en fazla {1} karakter uzunluğunda olmalıdır.", MinimumLength = 6)]
    public string Password { get; set; }

    // İsteğe bağlı olarak ek bilgiler (örneğin, kullanıcı rolü) eklenebilir
}
