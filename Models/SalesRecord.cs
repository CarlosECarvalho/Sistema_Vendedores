using SalesWebMVC.Models.Enums;

namespace SalesWebMVC.Models
{
    public class SalesRecord
    {
        public int SalesRecordId { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public SaleStatus Status { get; set; }
        public Seller Seller { get; set; }

        public SalesRecord () { }

        public SalesRecord ( DateTime date, double amount, SaleStatus status, Seller seller)//construtor sem ID, pois o EF ao criar a tabela no SQLServer atribiu o ID automaticamente com Auto incremento por ser chave primaria
        {
            Date = date;
            Amount = amount;
            Status = status;
            Seller = seller;
        }
    }
}
