using System;
using System.ComponentModel.DataAnnotations;

namespace UserServiceAPI.BLL.DTO
{
    public class UserDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Введите NickName")]
        public string NickName { get; set; }
        [Required(ErrorMessage = "Внесите описание")]
        public string Comments { get; set; }
        public DateTime? CreateDate { get; set; } 
    }
}
