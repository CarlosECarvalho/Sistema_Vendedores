using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SalesWebMVC.Models
{
    public class Seller
    {
        public int SellerID { get; set; }

        [Display(Name = "Nome")]//utilizo anotations para formatar a exibição conforme a melhor visualização para o usuário
        [Required(ErrorMessage = "{0} é obrigatório")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O tamanho do {0} deve ser de {2} a {1} caracteres")]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Informe um {0} válido.")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        public string Email { get; set; }

        [Display(Name = "Salário Base")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        [Range(100.00, 5000.00, ErrorMessage = ("O {0} deve ser de {1} a {2} reais."))]
        [DataType(DataType.Currency)]
        public double BaseSalary { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "{0} é obrigatório")]
        public DateTime BirthDate { get; set; }

        [ForeignKey("Department")]
        [Display(Name = "Departamento")]
        public int DepartmentId { get; set; }
		[Display(Name = "Departamento")]
		public Department Department { get; set; } // vinculo o vendedor ao seu departamento

        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>(); //vinculo o vendedor a suas vendas

        public Seller() { }

        public Seller(string name, string email, double baseSalary, DateTime birthDate, Department department)//construtor sem ID, pois o EF ao criar a tabela no SQLServer atribiu o ID automaticamente com Auto incremento por ser chave primaria
        {
            Name = name;
            Email = email;
            BaseSalary = baseSalary;
            BirthDate = birthDate;
            Department = department;
        }

        public void AddSales(SalesRecord sr)
        { //adiciono uma venda vinculada a este vendedor
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
