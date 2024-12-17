using Api.Domain.SBO.Documents.DocumentSearchs;
using Api.Domain.Entities.PackingLists;
using _4LogStressTest.Entities.PackingLists;

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

            var pk = new PackingList()
            {
                CompanyId = 1,
                BplId = 1,
                BplName = "1",
                StatusId = 1,
                //VehicleId = 1,
                LicensePlateUF = "1",
                LicensePlate = "RJ",
                VehicleTypeId = 1,
                CardCodeCarrier = "",
                CardNameCarrier = "",
                RouteId = 0,
                Height = 0,
                Width = 0,
                Length = 0,
                Weight = 0,
                Comments = "",
                FreightCost = 10,
                NegotiatedFreight = 10,
                FreightCostTerritory = 10,
                Incoterms = 0,
                EmployeeSeparationCode = null,
                EmployeeSeparationName = "",
                EmployeeAssistantSeparationCode = null,
                EmployeeAssistantSeparationName = "",
                UserName = "",
                UseInternalFreight= false,
                RoutedByDocument = false,
                NegotiationId = 0,
                NegotiationDescription = "",
                CountQuantity = 1,
                CarrierDriverId = null,
                PackingListTotalPlusTaxes = 0,
                InvoicingUserID = 0,
                InternalFreight = new Api.Domain.Entities.PackingLists.PackingListFreights.PackingListFreight()
            };
            pk.PackingDesc = "Teste de extresse";
            pk.VehicleTypeId = 1;

            pk.Orders = new List<Api.Domain.Entities.PackingLists.PackingListOrders.PackingListOrder>();

            docs.ForEach(d =>
            {
                var pkOrder = new Api.Domain.Entities.PackingLists.PackingListOrders.PackingListOrder();

                pkOrder.DocEntry = d.DocEntry;
                pkOrder.DocNum = d.DocNum;
                pkOrder.ObjTypeId = 17;
                pkOrder.FillValues(d);

                pk.Orders.Add(pkOrder);
            });

            var uri = string.Join('/', _apiUrl, "PackingList/v1");

            var rs = RequestService.Post<PackingList, PackingList>(uri, pk, _token, null, null);

            Release(rs);
            ReleaseCargo();
        }

        private static void ReleaseCargo()
        {
            var uri = string.Join('/', _apiUrl, "PackingList/v1") + "?status=5";

            var rs = RequestService.Get<ResultList<PackingList>>(uri, _token)?.List;

            if (rs is null || rs.Count <= 0) return;

            var uri2 = string.Join('/', _apiUrl, "PackingList/ReleaseCargo/v1");

            var rs2 = RequestService.Post<List<ReleaseCargoModel>, List<ReleaseCargoModel>>(uri2, 
                rs.Select(x=> new ReleaseCargoModel() { PackingListID = x.ID, DownPayments = new List<ReleaseCargoDownPaymentByOrderModel>() }).ToList(),
                _token, null, null);
        }

        private static void Release(PackingList rs)
        {
            var uri = string.Join('/', _apiUrl, "PackingList/ReleasePackingList/v1");

            RequestService.Post<List<int>, List<int>>(uri, new List<int>() { rs.ID }, _token, null, null);
        }
        private static ResultList<DocumentSearchSBO> GetDocuments()
        {
            var uri = string.Join('/', _apiUrl, "SearchDocument/v1") + "?page=1&take=10&bplId=1&b1Object=17";

            return RequestService.Get<ResultList<DocumentSearchSBO>>(uri, _token);
        }
        private static void ValidateToken()
        {
            if (!string.IsNullOrEmpty(_token)) return;

            var uri = string.Join('/', _apiUrl, "Authentication/Login/v1");

            var login = new Login2()
            {
                AppId = _appId,
                Login = _email,
                Password = _pwd
            };

            var rs = RequestService.Post<Login2, LoginResponse>(uri, login, null, null, null);

            _token = rs.Token;
        }
    }
    public class Login2
    {
        public string AppId { get; set; }
        public string? Login { get; set; }
        public string Password { get; set; }
    }
    public class LoginResponse
    {
        public string Token { get; set; }
    }
}
