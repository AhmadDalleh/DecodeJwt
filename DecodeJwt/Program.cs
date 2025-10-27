using System;
using System.Text;
using System.Text.Json;

class Program
{
    static void Main()
    {
        string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTUwIiwicm9sZSI6ImRvY3RvciIsImV4cCI6MTY4MjQ2NjAwMH0.dsg5KlRsdpQZn1uvKjMf2M3Kw8E3ljUlShVlxVc43F4";

        string[] parts = token.Split('.');

        if (parts.Length != 3)
        {
            Console.WriteLine("Invalid JWT format.");
            return;
        }

        string header = DecodeBase64(parts[0]);
        string payload = DecodeBase64(parts[1]);
        string signature = parts[2]; // Signature is not decoded

        Console.WriteLine("Header:\n" + PrettyJson(header));
        Console.WriteLine("\nPayload:\n" + PrettyJson(payload));
        Console.WriteLine("\nSignature:\n" + signature);
    }

    static string DecodeBase64(string base64)
    {
        string padded = base64.PadRight(base64.Length + (4 - base64.Length % 4) % 4, '=');
        byte[] bytes = Convert.FromBase64String(padded.Replace('-', '+').Replace('_', '/'));
        return Encoding.UTF8.GetString(bytes);
    }

    static string PrettyJson(string json)
    {
        using var doc = JsonDocument.Parse(json);
        return JsonSerializer.Serialize(doc, new JsonSerializerOptions { WriteIndented = true });
    }
}