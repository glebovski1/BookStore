using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.BusinessLogic.Models
{
     public class RegistrationModel
    {
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Emaill { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public bool IsPasswordConfirmed()
        {
            return (this.Password == this.ConfirmPassword);
        }
    }
}
