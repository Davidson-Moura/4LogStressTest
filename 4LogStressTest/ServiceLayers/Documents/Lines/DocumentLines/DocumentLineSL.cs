using Api.Domain.ServiceLayers.Documents.Lines.SerialNumbers;
using Api.Domain.ServiceLayers.Documents.Lines.BatchNumbers;
using Api.Domain.SBO.Documents.Lines.DocumentLines;
using System.Collections.Generic;

namespace Api.Domain.ServiceLayers.Documents.Lines.DocumentLines
{
    public class DocumentLineSL
    {
        public int? LineNum { get; set; }
        public string ItemCode { get; set; }
        public string WarehouseCode { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? UnitsOfMeasurment { get; set; }

        public int? Usage { get; set; }
        public string ProjectCode { get; set; }
        public string LineStatus { get; set; }
        public string TaxCode { get; set; }
        public string AccountCode { get; set; }
        public string CostingCode { get; set; }
        public string CostingCode2 { get; set; }
        public string CostingCode3 { get; set; }
        public string CostingCode4 { get; set; }
        public string CostingCode5 { get; set; }
        public int? BaseEntry { get; set; }
        public int? BaseType { get; set; }
        public int? BaseLine { get; set; }
        public int? UoMEntry { get; set; }
        public int? SalesPersonCode { get; set; }
        public List<BatchNumberLineSL> BatchNumbers { get; set; } = new List<BatchNumberLineSL>();
        public List<SerialNumberLineSL> SerialNumbers { get; set; } = new List<SerialNumberLineSL>();
        public double Price { get; internal set; }

        internal void SetBatchNumbers(List<BatchAndSerialSBO> batchNumbers)
        {
            if (batchNumbers is null) return;
            batchNumbers.ForEach(bn =>
            {
                BatchNumbers.Add(new BatchNumberLineSL
                {
                    BatchNumber = bn.DistNumber,
                    SystemSerialNumber = bn.SysNumber,
                    ItemCode = bn.ItemCode,
                    Quantity = bn.Quantity
                });
            });
        }

        internal void SetSerialNumbers(List<BatchAndSerialSBO> serialNumbers)
        {
            if (serialNumbers is null) return;
            serialNumbers.ForEach(sn =>
            {
                SerialNumbers.Add(new SerialNumberLineSL
                {
                    SystemSerialNumber = sn.SysNumber,
                    ItemCode = sn.ItemCode,
                    Quantity = 1
                });
            });
        }
    }
}
