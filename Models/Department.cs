using System.ComponentModel.DataAnnotations;

namespace SalesWebMVC.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Display(Name = "Nome")]
        public string Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>(); //vai instanciar os vendedores do departamento

        public Department()
        {
        }

        public Department ( string name) //construtor sem ID, pois o EF ao criar a tabela no SQLServer atribiu o ID automaticamente com Auto incremento por ser chave primaria
        {
            Name = name;
        }

        public void AddSeller (Seller seller) { 
            Sellers.Add(seller);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sellers.Sum(seller => seller.TotalSales(initial, final)); //recebo a soma de vendas do periodo de um vendedor e somo para obter o total de vendas do periodo
        }
    }
}
