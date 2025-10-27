using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;

class Program
{
    static void Main()
    {
        Console.Write("Enter JWT token: ");
        string token  = Console.ReadLine().ToString();
        var handler = new JwtSecurityTokenHandler();
        var jwt = handler.ReadJwtToken(token);

        Console.WriteLine("Header:");
        Console.WriteLine(JsonSerializer.Serialize(jwt.Header, new JsonSerializerOptions { WriteIndented = true }));

        Console.WriteLine("\nPayload:");
        Console.WriteLine(JsonSerializer.Serialize(jwt.Payload, new JsonSerializerOptions { WriteIndented = true }));

        Console.WriteLine("\nSignature:");
        Console.WriteLine(token.Split('.')[2]);
    }
}