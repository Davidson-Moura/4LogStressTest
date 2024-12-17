using Api.Domain.Entities.PackingLists.PackingListPayments.PackingListPaymentCarriers;
using Api.Domain.Entities.PackingLists.PackingListEmployees;
using Api.Domain.Entities.PackingLists.PackingListFreights;
using Api.Domain.Entities.PackingLists.PackingListOrders;
using Api.Domain.Entities.PackingLists.PackingListRoutes;

namespace Api.Domain.Entities.PackingLists
{
    public class PackingList
    {
        public int ID { get; set; }
        public string PackingDesc { get; set; }
        public int? CompanyId { get; set; }
        public int? BplId { get; set; }
        public string BplName { get; set; }
        public DateTime? DocDate { get; set; } = DateTime.Now;
        public DateTime? CreateDate { get; set; } = DateTime.Now;
        public DateTime? ForecastShipDate { get; set; } = DateTime.Now;
        public int? StatusId { get; set; }
        public int? VehicleId { get; set; }
        public string LicensePlateUF { get; set; }
        public string LicensePlate { get; set; }
        public int? VehicleTypeId { get; set; }
        public string CardCodeCarrier { get; set; }
        public string CardNameCarrier { get; set; }
        public int? RouteId { get; set; }
        public decimal? Height { get; set; }
        public decimal? Width { get; set; }
        public decimal? Length { get; set; }
        public decimal? Weight { get; set; }
        public string Comments { get; set; }
        public decimal? FreightCost { get; set; }
        public decimal? NegotiatedFreight { get; set; }
        public decimal? FreightCostTerritory { get; set; }
        public int? Incoterms { get; set; }
        public int? EmployeeSeparationCode { get; set; }
        public string EmployeeSeparationName { get; set; }
        public int? EmployeeAssistantSeparationCode { get; set; }
        public string EmployeeAssistantSeparationName { get; set; }
        public string UserName { get; set; }
        public bool? UseInternalFreight { get; set; }
        public bool? RoutedByDocument { get; set; }
        public int? NegotiationId { get; set; }
        public string NegotiationDescription { get; set; }
        public int? CountQuantity { get; set; }
        public int? CarrierDriverId { get; set; }
        public decimal? PackingListTotalPlusTaxes { get; set; }
        public string WithErrorInProcess { get; set; } = "N";
        public int? InvoicingUserID { get; set; }
        #region Props not in table
        public PackingListStatusEnum StatusEnum { get { return (PackingListStatusEnum)(StatusId ??0); } set { StatusId = (int)value; } }
        public string StatusName { get; set; }
        public string VehicleName { get; set; }
        public string CarrierDriverName { get; set; }
        public string VehicleTypeName { get; set; }
        public string RouteName { get; set; }
        public string CompanyName { get; set; }
        public decimal? VehicleWeight { get; set; }
        public decimal? VehicleWidth { get; set; }
        public decimal? VehicleHeight { get; set; }
        public decimal? VehicleLength { get; set; }
        #endregion
        public List<PackingListOrder> Orders { get; set; } = new List<PackingListOrder>();
        public List<PackingListPaymentCarrier> CarrierPayments { get; set; } = new List<PackingListPaymentCarrier>();
        public List<PackingListRoute> Routes { get; set; } = new List<PackingListRoute>();
        public List<PackingListEmployee> PackingListEmployees { get; set; } = new List<PackingListEmployee>();
        public PackingListFreight InternalFreight { get; set; }


        #region Functions
        public bool CanCancel()
        {
            var status = new List<PackingListStatusEnum>
            {
                PackingListStatusEnum.PendingLiberatedQuote,
                PackingListStatusEnum.OnFreightQuote,
                PackingListStatusEnum.OnOrderApproval,
                PackingListStatusEnum.OnApproval,
                PackingListStatusEnum.FreightApproved,
                PackingListStatusEnum.FreightReproved,
                PackingListStatusEnum.OrderReproved,
                PackingListStatusEnum.LiberatedQuote
            };

            return status.Any(c => c == StatusEnum);
        }
        public void CalculateValues()
        {
            this.Height = decimal.Zero;
            this.Width = decimal.Zero;
            this.Length = decimal.Zero;
            this.Weight = decimal.Zero;

            this.CountQuantity = 0;
            this.PackingListTotalPlusTaxes = decimal.Zero;

            if (this.CarrierPayments is not null)
            {
                this.NegotiatedFreight = decimal.Zero;
                CarrierPayments.ForEach(c =>
                {
                    this.NegotiatedFreight = c.DocumentFreightCost;
                });
                this.FreightCost = this.NegotiatedFreight;
            }

            if (this.FreightCost is null) this.FreightCost = 0;
            bool isNoFreight = this.FreightCost.Value <= 0;

            this.Orders.ForEach(o =>
            {
                o.CompanyHierarchyId = this.CompanyId;
                o.ItemsTotal = decimal.Zero;
                o.Items.ForEach(i =>
                {
                    this.Height += (i.Height ?? 0) * (i.Quantity ?? 0);
                    this.Width += (i.Width ?? 0) * (i.Quantity ?? 0);
                    this.Length += (i.Length ?? 0) * (i.Quantity ?? 0);
                    this.Weight += (i.Weight ?? 0) * (i.Quantity ?? 0);
                    this.CountQuantity += (int)(i.Quantity ?? 0);
                    o.ItemsTotal += i.LineTotalPlusVatSum;

                    if (isNoFreight) this.FreightCost += i.LineFreightTotal;
                });
                this.PackingListTotalPlusTaxes += (o.DocumentTaxes ?? 0m) + (o.DocTotal ?? 0m);
            });
        }

        public void SetStatusInOrders(PackingListStatusEnum statusEnum)
        {
            this.Orders?.ForEach(o =>
            {
                o.StatusId = (int)statusEnum;
            });
        }
        #endregion
    }
    public class PackingListMin
    {
        public int ID { get; set; }
        public string PackingDesc { get; set; }
        public int? StatusId { get; set; }
    }
    /// <summary>
    /// Status do romaneio.
    /// </summary>
    public enum PackingListStatusEnum
    {
        None = 0,
        /// <summary>
        /// Pendente de Liberação.
        /// </summary>
        PendingLiberatedQuote = 1,

        /// <summary>
        /// Em Cotação de Frete.
        /// </summary>
        OnFreightQuote = 2,

        /// <summary>
        /// Em aprovação de pedido.
        /// </summary>
        OnOrderApproval = 3,

        /// <summary>
        /// Em Aprovação.
        /// </summary>
        OnApproval = 4,

        /// <summary>
        /// Frete Aprovado.
        /// </summary>
        FreightApproved = 5,

        /// <summary>
        /// Frete Reprovado.
        /// </summary>
        FreightReproved = 6,

        /// <summary>
        /// Em Faturamento.
        /// </summary>
        OnInvoice = 7,

        /// <summary>
        /// Faturado.
        /// </summary>
        Invoiced = 8,

        /// <summary>
        /// Em Expedição.
        /// </summary>
        OnShipping = 9,

        /// <summary>
        /// Carga Enviada.
        /// </summary>
        ShipmentSent = 10,

        /// <summary>
        /// Pedidos reprovados.
        /// </summary>
        OrderReproved = 11,

        /// <summary>
        /// Liberado
        /// </summary>
        LiberatedQuote = 13,

        ///<summary>
        ///Aguardando Separação 
        ///</summary>
        WaitingSeparation = 14,

        ///<summary>
        /// Em Separação
        /// </summary>
        InSeparation = 15,

        /// <summary>
        /// Separação C
        /// </summary>
        SeparationCanceled = 16,

        /// <summary>ancelada
        /// Aguardando Checkout
        /// </summary>
        WaitingCheckout = 17,

        /// <summary>
        /// Em Checkout
        /// </summary>
        InChekout = 18,

        /// <summary>
        /// Checkout Finalizado
        /// </summary>
        CheckoutFinalized = 19,

        /// <summary>
        /// Aguardando Conferência
        /// </summary>
        WaitConfLabel = 20,

        /// <summary>
        /// Em Conferência
        /// </summary>
        InConfLabel = 21,

        /// <summary>
        /// Conferência Finalizada
        /// </summary>
        ConfLabelFinalized = 22,

        /// <summary>
        /// Removido
        /// </summary>
        Removed = 23,

        /// <summary>
        /// Envio Realizado
        /// </summary>
        ShipmentReleased = 24,

        /// <summary>
        /// Aguardando pagamento de frete
        /// </summary>
        WaitPaymentFreight = 25,

        /// <summary>
        /// Parcialmente pago
        /// </summary>
        PartialPaidFreight = 26,

        /// <summary>
        /// Pagamento de frete provisionado
        ///  </summary>
        PaidFreight = 27,

        /// <summary>
        /// Faturamento Externo
        ///  </summary>
        ExternalBilling = 28,

        /// <summary>
        /// Em liberação de romaneio
        ///  </summary>
        InReleasingPackingList = 29,

        /// <summary>
        /// Erro no faturamento
        ///  </summary>
        ErrorInvoice = 30,

        /// <summary>
        /// Erro ao liberação o romaneio
        ///  </summary>
        ErrorReleasingPackingList = 31,

        /// <summary>
        /// Cancelado.
        /// </summary>
        Canceled = 99,
    }
}
