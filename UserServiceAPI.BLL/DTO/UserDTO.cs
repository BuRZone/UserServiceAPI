using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UserServiceAPI.BLL.DTO
{
    public class UserDTO
    {
        public int? Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Введите NickName")]
        [MaxLength(20, ErrorMessage = "Имя должно иметь длину меньше 20 символов")]
        [MinLength(3, ErrorMessage = "Имя должно иметь длину больше 3 символов")]
        public string NickName { get; set; }
        [Required(ErrorMessage = "Внесите описание")]
        public string Comments { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.Now;
    }
}
