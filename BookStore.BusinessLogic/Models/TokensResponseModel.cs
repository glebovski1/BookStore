using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.BusinessLogic.Models
{
    public class TokensResponseModel
    {
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }

        public string Role { get; set; }

        public int Id { get; set; }
    }
}
