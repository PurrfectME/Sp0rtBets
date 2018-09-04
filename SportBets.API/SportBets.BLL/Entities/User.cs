using System;

namespace SportBets.BLL.Entities
{
    public class User
    {
        public virtual int Id { get; set; }
        public virtual string Email { get; set; }
        public virtual string PasswordHash { get; set; }
        public virtual DateTime RegistrationDate { get; set; }
    }
}
