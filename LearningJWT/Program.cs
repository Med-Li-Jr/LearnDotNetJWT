using System;
using System.Linq;
using System.Security.Claims;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
namespace LearningJWT
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from first card  
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            }
            string ipLocal = "";
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    ipLocal = ip.ToString();
                    break;
                }
            }
            Console.WriteLine(ipLocal + " // " + sMacAddress);
            //            JWTContainerModel model = GetJWTContainerModel(
            //                new Contract()
            //                {
            //                    NameOrganization = "Moshe Binieli",
            //                    StatusOrganisation = "mmoshikoo@gmail.com"
            //                });


            //            JWTService authService = new JWTService();

            //            string token = authService.GenerateToken(model);

            //            token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJOYW1lT3JnYW5pemF0aW9uIjoiTW9zaGUgQmluaWVsaSIsIlN0YXR1c09yZ2FuaXNhdGlvbiI6Im1AZ21haWwuY29tIiwibmJmIjoxNjIyNTUzNzQzLCJleHAiOjE2MjI1NTczNDMsImlhdCI6MTYyMjU1Mzc0M30.cWsDdLV9Vwx27zClgYbt0O8lWax1xqrQRzmmEH9yvqg";

            //            if (!authService.IsTokenValid(token))
            //                throw new UnauthorizedAccessException();
            //            else
            //            {
            //                List<Claim> claims = authService.GetTokenClaims(token).ToList();

            //                Contract mContract = Contract.FromClaims(claims);

            //                Console.WriteLine(mContract.NameOrganization);
            ////                Console.WriteLine(claims.FirstOrDefault(e => e.Type.Equals(ClaimTypes.Email)).Value);
            //                Console.WriteLine(mContract.StatusOrganisation);
            //            }
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
