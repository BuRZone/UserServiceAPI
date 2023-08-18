using System;
using System.ComponentModel.DataAnnotations;

namespace UserServiceAPI.BLL.DTO
{
    public class UserDTO
    {
        public int? Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Введите NickName")]
        public string NickName { get; set; }
        [Required(ErrorMessage = "Внесите описание")]
        public string Comments { get; set; }
        [DataType(DataType.Date)]
        public DateTime? CreateDate { get; set; }
    }
}
