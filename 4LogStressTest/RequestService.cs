using Newtonsoft.Json;
using System.Text;

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

                return JsonConvert.DeserializeObject<T>(result);
            }
        }
        public static R Post<T, R>(string uri, T data,
            string b1Session, string routeId) where T : class, new() where R : class, new()
        {
            string jsonContent = JsonConvert.SerializeObject( data);
            using var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            using HttpClientHandler handler = new HttpClientHandler
            {
                UseCookies = true,
                ServerCertificateCustomValidationCallback = (message, certificate, chain, sslPolicyErrors) => true
            };
            handler.CookieContainer = new System.Net.CookieContainer();
            if(!string.IsNullOrEmpty(b1Session))handler.CookieContainer.Add(new Uri(uri), new System.Net.Cookie("B1SESSION", b1Session, "/", ".example.com") { HttpOnly = true, Secure = true });
            if(!string.IsNullOrEmpty(routeId)) handler.CookieContainer.Add(new Uri(uri), new System.Net.Cookie("ROUTEID", routeId, "/", ".example.com") { Secure = true });

            using HttpClient client = new HttpClient(handler);

            HttpResponseMessage response = client.PostAsync(uri, content).Result;

            if (response.IsSuccessStatusCode)
            {
                string responseJson = response.Content.ReadAsStringAsync().Result;

                var setCookies = response.Headers.GetValues("Set-Cookie");

                foreach (var cookie in setCookies)
                {
                    Console.WriteLine($"Cookie recebido: {cookie}");
                }

                var rs = JsonConvert.DeserializeObject<R>(responseJson);
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
            string jsonContent = JsonConvert.SerializeObject(data);
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

                var rs = JsonConvert.DeserializeObject<SLLoginResponse>(responseJson);

                var setCookies = response.Headers.GetValues("Set-Cookie");

                foreach (var cookie in setCookies)
                {
                    var split = cookie.Split('=');
                    if (split[0] == "B1SESSION") rs.B1SESSION = split[1];
                    if (split[0] == "ROUTEID") rs.ROUTEID = split[1];
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
