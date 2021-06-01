using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace LearningJWT
{
    public class Contract
    {

        public string NameOrganization { get; set; }
        public string StatusOrganisation { get; set; }

        public Contract() { }

        public static Contract FromClaims(List<Claim> claims)
        {
            return new Contract()
            {
                NameOrganization = claims.FirstOrDefault(e => e.Type.Equals("NameOrganization")).Value,
                StatusOrganisation = claims.FirstOrDefault(e => e.Type.Equals("StatusOrganisation")).Value,
            };
        }

        public Claim[] ToClaim()
        {
            return new Claim[]
            {
                new Claim("NameOrganization", NameOrganization),
                new Claim("StatusOrganisation", StatusOrganisation),
            };
        }
        
    }
}
