using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorStoreServAppV5.Repository.StoreLogic.LiqPay;

public class LiqPayService
{
    private readonly string publicKey = "sandbox_i28978238204";
    private readonly string privateKey = "sandbox_bwDnxAuih7Fm0OrR9fZsk0De78JV7JzAaFF0RlfW";
    private readonly HttpClient httpClient;
    private string encoded;
    public LiqPayService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<string> GetCheckoutUrl(decimal amount, string description)
    {
        var data = new Dictionary<string, string>
        {
            { "public_key", publicKey },
            { "version", "3" },
            { "action", "pay" },
            { "amount", amount.ToString() },
            { "currency", "UAH" },
            { "description", "test" },
            { "order_id", "00001" }
        };
        var serializedData = JsonSerializer.Serialize(data);

       
        var signature = GenerateSignature(privateKey, data);

        var formContent = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("data", serializedData),
            new KeyValuePair<string, string>("signature", signature)
        });

        var response =
            await httpClient.PostAsync("https://www.liqpay.ua/api/3/checkout", formContent);
        var responseString = await response.Content.ReadAsStringAsync();
        return responseString;
    }

    private string GenerateSignature(string privateKey, string data)
    {
        var sha1 = new SHA1CryptoServiceProvider();
        encoded = Convert.ToBase64String(Encoding.UTF8.GetBytes(data));
        var sign_string = privateKey + encoded + privateKey;
        var hashBytes = sha1.ComputeHash(Encoding.UTF8.GetBytes(sign_string));
        var base64EncodedHash = Convert.ToBase64String(hashBytes);

        return base64EncodedHash;
    }
}