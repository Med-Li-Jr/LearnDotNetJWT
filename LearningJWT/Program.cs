using System;
using System.Linq;
using System.Security.Claims;
using System.Collections.Generic;


namespace LearningJWT
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            JWTContainerModel model = GetJWTContainerModel(
                new Contract()
                {
                    NameOrganization = "Moshe Binieli",
                    StatusOrganisation = "mmoshikoo@gmail.com"
                });


            JWTService authService = new JWTService();

            string token = authService.GenerateToken(model);

            token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJOYW1lT3JnYW5pemF0aW9uIjoiTW9zaGUgQmluaWVsaSIsIlN0YXR1c09yZ2FuaXNhdGlvbiI6Im1AZ21haWwuY29tIiwibmJmIjoxNjIyNTUzNzQzLCJleHAiOjE2MjI1NTczNDMsImlhdCI6MTYyMjU1Mzc0M30.cWsDdLV9Vwx27zClgYbt0O8lWax1xqrQRzmmEH9yvqg";

            if (!authService.IsTokenValid(token))
                throw new UnauthorizedAccessException();
            else
            {
                List<Claim> claims = authService.GetTokenClaims(token).ToList();

                Contract mContract = Contract.FromClaims(claims);

                Console.WriteLine(mContract.NameOrganization);
//                Console.WriteLine(claims.FirstOrDefault(e => e.Type.Equals(ClaimTypes.Email)).Value);
                Console.WriteLine(mContract.StatusOrganisation);
            }
        }

        private static JWTContainerModel GetJWTContainerModel(Contract contract)
        {
            return new JWTContainerModel()
            {
                Claims = contract.ToClaim()
            };
        }
    }
}
