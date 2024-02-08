using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UserServiceAPI.BLL.Models
{
    public class UpdateUserDto
    {
        [JsonPropertyName("email")]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("nickname")]
        [Required(ErrorMessage = "NickName is required")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "NickName must be less then or equal 30 and greater than 5")]
        [RegularExpression(@"^[A-Za-z]+\d*[A-Za-z]*\d*", ErrorMessage = "Characters are not allowed.")]
        public string NickName { get; set; } = string.Empty;

        [JsonPropertyName("comments")]
        [Required(ErrorMessage = "Comments is required")]
        [MaxLength(250)]
        public string Comments { get; set; } = string.Empty;

        public string UpdatedDate => DateTime.Now.ToString();
    }
}
