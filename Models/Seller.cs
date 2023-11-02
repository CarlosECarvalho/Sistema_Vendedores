using System.Linq;

namespace SalesWebMVC.Models
{
    public class Seller
    {
        public int SellerID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public double BaseSalary { get; set; }
        public DateTime BirthDate { get; set; }
        public Department Department { get; set; } // vinculo o vendedor ao seu departamento
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>(); //vinculo o vendedor a suas vendas

        public Seller() { }

        public Seller( string name, string email, double baseSalary, DateTime birthDate, Department department)//construtor sem ID, pois o EF ao criar a tabela no SQLServer atribiu o ID automaticamente com Auto incremento por ser chave primaria
        {
            Name = name;
            Email = email;
            BaseSalary = baseSalary;
            BirthDate = birthDate;
            Department = department;
        }

        public void AddSales(SalesRecord sr){ //adiciono uma venda vinculada a este vendedor
            Sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }
         public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount); //faco a consulta do total de vendas de um vendedor denntro de um periodo inicial e final
        }

    }
}
