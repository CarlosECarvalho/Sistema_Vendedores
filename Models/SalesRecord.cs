using SalesWebMVC.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SalesWebMVC.Models
{
    public class SalesRecord
    {
        [Display(Name ="Número da Venda")]
        public int SalesRecordId { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data da Venda")]
        public DateTime Date { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Valor da Venda")]
        public double Amount { get; set; }

        [Display(Name = "Situação da Venda")]
        public SaleStatus Status { get; set; }

        public int SellerId { get; set; }
		[Display(Name = "Vendedor")]
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
