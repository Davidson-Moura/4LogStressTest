using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace _4LogStressTest
{
    internal class RequestService
    {
        public static T Get<T>(string uri, string token) where T : class, new()
        {
            using HttpClientHandler handler = new HttpClientHandler
            {
                UseCookies = true,
                ServerCertificateCustomValidationCallback = (message, certificate, chain, sslPolicyErrors) => true
            };
            using (HttpClient client = new HttpClient(handler))
            {
                if (!string.IsNullOrEmpty(token)) client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var result = client.GetStringAsync(uri).Result;

                return JsonSerializer.Deserialize<T>(result);
            }
        }
        public static R Post<T, R>(string uri, T data, string token,
            string b1Session, string routeId) where T : class, new() where R : class, new()
        {
            var jsonOptions = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };
            string jsonContent = JsonSerializer.Serialize(data, jsonOptions);
            using var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            using HttpClientHandler handler = new HttpClientHandler
            {
                UseCookies = true,
                ServerCertificateCustomValidationCallback = (message, certificate, chain, sslPolicyErrors) => true
            };
            handler.CookieContainer = new System.Net.CookieContainer();
            if(!string.IsNullOrEmpty(b1Session))handler.CookieContainer.Add(new Uri(uri), new System.Net.Cookie("B1SESSION", b1Session) { HttpOnly = true, Secure = true });
            if(!string.IsNullOrEmpty(routeId)) handler.CookieContainer.Add(new Uri(uri), new System.Net.Cookie("ROUTEID", routeId) { Secure = true });

            using HttpClient client = new HttpClient(handler);

            if (!string.IsNullOrEmpty(token)) client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = client.PostAsync(uri, content).Result;

            if (response.IsSuccessStatusCode)
            {
                string responseJson = response.Content.ReadAsStringAsync().Result;

                if (response.Headers.Contains("Set-Cookie"))
                {
                    var setCookies = response.Headers.GetValues("Set-Cookie");

                    foreach (var cookie in setCookies)
                    {
                        Console.WriteLine($"Cookie recebido: {cookie}");
                    }
                }

                if (string.IsNullOrEmpty(responseJson)) return null;

                var rs = JsonSerializer.Deserialize<R>(responseJson);
                return rs;
            }
            else
            {
                string errorResponse = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine($"Error - Detalhes: {errorResponse}");
            }
            return null;
        }

        public static SLLoginResponse LoginSL(string uri, SLLogin data)
        {
            string jsonContent = JsonSerializer.Serialize(data);
            using var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            using HttpClientHandler handler = new HttpClientHandler
            {
                UseCookies = true,
                ServerCertificateCustomValidationCallback = (message, certificate, chain, sslPolicyErrors) => true
            };

            using HttpClient client = new HttpClient(handler);

            HttpResponseMessage response = client.PostAsync(uri, content).Result;

            if (response.IsSuccessStatusCode)
            {
                string responseJson = response.Content.ReadAsStringAsync().Result;

                var rs = JsonSerializer.Deserialize<SLLoginResponse>(responseJson);

                var setCookies = response.Headers.GetValues("Set-Cookie");

                foreach (var cookie in setCookies)
                {
                    var split = cookie.Split('=');
                    if (split[0] == "B1SESSION") rs.B1SESSION = split[1].Split(';')[0];
                    if (split[0] == "ROUTEID") rs.ROUTEID = split[1].Split(';')[0];
                }

                return rs;
            }
            else
            {
                string errorResponse = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine($"Error - Detalhes: {errorResponse}");
            }
            return null;
        }
    }
}
