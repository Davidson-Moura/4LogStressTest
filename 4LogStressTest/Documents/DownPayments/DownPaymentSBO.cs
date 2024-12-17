using System.Collections.Generic;
using System.Linq;
using System;

namespace Api.Domain.SBO.Documents.DownPayments
{
    public class DownPaymentSBO
    {
        public int DocNum { get; set; }
        public int DocEntry { get; set; }
        public DateTime DocDate { get; set; }
        public DateTime DocDueDate { get; set; }
        public string CardCode { get; set; }
        public string CardName { get; set; }
        public string Comments { get; set; }
        public decimal PaidSys { get; set; } // Valor do adiantamento pago
        public decimal DpmAppl { get; set; } // Valor do adiantamento já utilizado
        public decimal DocTotalSy { get; set; } //Total do documento
        public decimal AvailableValue { get { // Valor disponível para utilização
                return PaidSys - DpmAppl;
            } set{ } }
    }
}
