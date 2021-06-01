using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace LearningJWT
{
    class JWTContainerModel 
        //: IAuthContainerModel
    {
        public int ExpireMinutes { get; set; } = 10080; // 7 days.
        //public string SecretKey { get; set; } = "mysecretcodedocstream"; // This secret key should be moved to some configurations outter server.
        public string SecurityAlgorithm { get; set; } =  SecurityAlgorithms.HmacSha256Signature;

        public Claim[] Claims { get; set; }
    }
}
