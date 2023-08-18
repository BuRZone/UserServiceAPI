using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UserServiceAPI.DAL.Entity
{
    public class User
    {
        [Key]
        public string Email { get; set; }
        public string NickName { get; set; }
        public string Comments { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
