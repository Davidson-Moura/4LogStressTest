using Api.Domain.SBO.Documents.DocumentSearchs;
using Api.Domain.Entities.PackingLists;

namespace _4LogStressTest
{
    internal static class PackingListService
    {
        private static readonly string _apiUrl = "https://localhost:7777";
        private static readonly string _email = "davidson@teste.com";
        private static readonly string _pwd = "sap@123";
        private static readonly string _appId = "35942fe6-964d-4f27-a020-aabee90506e5";
        private static string _token = "";
        public static async void CreatePk()
        {
            ValidateToken();

            var docs = GetDocuments()?.List;

            if (docs is null || docs.Count <= 0) return;

            var pk = new PackingList();
            pk.PackingDesc = "Teste de extresse";
            pk.VehicleTypeId = 1;

            pk.Orders = new List<Api.Domain.Entities.PackingLists.PackingListOrders.PackingListOrder>();

            docs.ForEach(d =>
            {
                var pkOrder = new Api.Domain.Entities.PackingLists.PackingListOrders.PackingListOrder();

                pkOrder.FillValues(d);

                pk.Orders.Add(pkOrder);
            });

            var uri = string.Join('/', _apiUrl, "PackingList/v1");

            var rs = RequestService.Post<PackingList, PackingList>(uri, pk, null, null);
        }
        private static ResultList<DocumentSearchSBO> GetDocuments()
        {
            var uri = string.Join('/', _apiUrl, "SearchDocument") + "?page=1&take=10&bplId=1";

            return RequestService.Get<ResultList<DocumentSearchSBO>>(uri, _token);
        }
        private static void ValidateToken()
        {
            if (!string.IsNullOrEmpty(_token)) return;

            var uri = string.Join('/', _apiUrl, "Authentication/Login/v1");

            var login = new Login()
            {
                AppId = _appId,
                Email = _email,
                Password = _pwd
            };

            var rs = RequestService.Post<Login, LoginResponse>(uri, login, null, null);

            _token = rs.Token;
        }
    }
    public class Login
    {
        public string AppId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class LoginResponse
    {
        public string Token { get; set; }
    }
}
