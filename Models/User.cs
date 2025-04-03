using System.ComponentModel.DataAnnotations;

public enum UserRole
{
    Admin,
    User,
    Moderator
}
public class User
{
    [Key]
    public int UserId { get; set; }

    [Required]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 20 characters.")]
    [RegularExpression(@"^\w+$", ErrorMessage = "Username can only contain letters, numbers, and underscores.")]
    [Display(Name = "Username")]
    public string UserName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [StringLength(255, ErrorMessage = "Email cannot exceed 255 characters.")]
    [RegularExpression(@"^[^@\s]+@[^@\s]+\.[a-zA-Z]{2,6}$", ErrorMessage = "Invalid email format.")]
    [Display(Name = "Email")]
    public string Email { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    public string PasswordHash { get; set; } = string.Empty;  // Hashed Password

    [Required]
    public byte[] PasswordSalt { get; set; } = Array.Empty<byte>();  // Salt for password hashing

    [Required]
    [Display(Name = "User Type")]
    public string Role { get; set; } = "User";  // Default role
}
