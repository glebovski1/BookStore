using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.BusinessLogic.Autinfication.Interfaces
{
    public interface IJwtSigningEncodingKey
    {

        string SigningAlgorithm { get; }

        SecurityKey GetKey();

    }
}
