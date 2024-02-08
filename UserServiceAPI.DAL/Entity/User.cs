using System;

namespace UserServiceAPI.DAL.Entity
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string NickName { get; set; } = string.Empty;
        public string Comments { get; set; } = string.Empty;
        public string CreateDate { get; set; } = string.Empty;
    }
}
