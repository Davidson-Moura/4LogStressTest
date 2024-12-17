using Api.Domain.ServiceLayers.Documents.Lines.DocumentLines;
using Api.Domain.ServiceLayers.Documents.Orders;

namespace _4LogStressTest
{
    internal class SLService
    {
        private static readonly string _apiUrl = "https://hanab1:50000/b1s/v1";

        private static readonly string _user = "manager";
        private static readonly string _pwd = "Imagine01";
        private static readonly string _company = "SBODemoBR";

        private static string _B1SESSION = "";
        private static string _ROUTEID = "";

        private static readonly string _cardCode = "C99999";
        private static readonly string _itemCode = "A00001";

        public static async void CreateDoc()
        {
            ValidateToken();

            var doc = new OrderSL()
            {
                CardCode = _cardCode,
                DocumentLines = new List<DocumentLineSL>()
                {
                    new DocumentLineSL()
                    {
                        ItemCode = _itemCode,
                        Quantity = 3
                    }
                }
            };
            
            var uri = string.Join('/', _apiUrl, "Orders");

            var rs = RequestService.Post<OrderSL, OrderSL>(uri, doc, _B1SESSION, _ROUTEID);
        }
        private static void ValidateToken()
        {
            if (!string.IsNullOrEmpty(_B1SESSION)) return;

            var uri = string.Join('/', _apiUrl, "Login"); // https://localhost:50000/b1s/v1/Login

            var login = new SLLogin()
            {
                CompanyDB = _company,
                UserName = _user,
                Password = _pwd
            };

            var rs = RequestService.LoginSL(uri, login);

            _B1SESSION = rs.B1SESSION;
            _ROUTEID = rs.ROUTEID;
        }
    }
    public class SLLogin
    {
        public string CompanyDB { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class SLLoginResponse
    {
        public string B1SESSION { get; set; }
        public string ROUTEID { get; set; }
    }
}
