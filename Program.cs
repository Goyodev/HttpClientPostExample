using System.Text;

string url = "https://petstore.swagger.io/v2/pet";

string jsonBody = "{\"id\": 0, \"name\": \"doggie\"}";

using (HttpClient client = new HttpClient())
{
    var request = new HttpRequestMessage
    {
        Method = HttpMethod.Post,
        RequestUri = new Uri(url),
        Content = new StringContent(jsonBody, Encoding.UTF8, "application/json")
    };

    HttpResponseMessage response = await client.SendAsync(request);

    if (response.IsSuccessStatusCode)
    {
        string responseBody = await response.Content.ReadAsStringAsync();
        Console.WriteLine("Respuesta:");
        Console.WriteLine(responseBody);
    }
    else
    {
        Console.WriteLine($"La solicitud no fue exitosa. Código de estado: {response.StatusCode}");
    }
}