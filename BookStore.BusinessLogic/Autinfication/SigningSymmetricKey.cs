using System;
using System.Collections.Generic;
using System.Text;
using BookStore.BusinessLogic.Autinfication.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace BookStore.BusinessLogic.Autinfication
{
    public class SigningSymmetricKey : IJwtSigningDecodingKey, IJwtSigningEncodingKey
    {
        private readonly SymmetricSecurityKey _secretKey;
        public string SigningAlgorithm { get; }

        public SigningSymmetricKey(string key)
        {
            this._secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            SigningAlgorithm = SecurityAlgorithms.HmacSha256;
        }
        public SecurityKey GetKey()
        {
            return this._secretKey;
        }
    }
}
