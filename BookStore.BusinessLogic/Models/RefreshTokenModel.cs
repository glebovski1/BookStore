using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.BusinessLogic.Models
{
    public class RefreshTokenModel
    {
        public string Email { get; set; }

        public string LoginProvider { get; set; }

        public string RefreshTokenFromClient { get; set; }
    }
}
