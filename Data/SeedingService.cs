

using SalesWebMVC.Models.Enums;
using SalesWebMVC.Models;

namespace SalesWebMVC.Data
{
    public class SeedingService
    {
        private readonly SalesWebMVCContext _context;

        public SeedingService (SalesWebMVCContext context)
        {
            _context = context; //instancio a classe com dependencia com o contexto
        }

        public void Seed()
        {
            if (_context.Department.Any() || _context.SalesRecord.Any() || _context.Seller.Any()) 
            {
                return; //verifico se algum Model possui dados e saio caso positivo
            }
            
            Department d1 = new( "Computadores");
            Department d2 = new( "Eletrônicos");
            Department d3 = new( "Moda");
            Department d4 = new( "Livros");

            Seller s1 = new( "Bob Brown", "bob@gmail.com", 1000.0, new DateTime(1998, 4, 21),  d1);
            Seller s2 = new( "Maria Green", "maria@gmail.com", 1000.0, new DateTime(1979, 12, 31),  d2);
            Seller s3 = new( "Alex Grey", "alex@gmail.com", 2200.0, new DateTime(1988, 1, 15),  d1);
            Seller s4 = new( "Martha Red", "martha@gmail.com", 3000.0, new DateTime(1993, 11, 30),  d4);
            Seller s5 = new( "Donald Blue", "donald@gmail.com", 4000.0, new DateTime(2000, 1, 9),  d3);
            Seller s6 = new( "Alex Pink", "bob@gmail.com", 3000.0, new DateTime(1997, 3, 4),  d2);

            SalesRecord r1 = new ( new DateTime(2023, 09, 25), 11000.0, SaleStatus.Faturado, s1);
            SalesRecord r2 = new ( new DateTime(2023, 09, 4), 7000.0, SaleStatus.Faturado, s5);
            SalesRecord r3 = new ( new DateTime(2023, 09, 13), 4000.0, SaleStatus.Cancelado, s4);
            SalesRecord r4 = new ( new DateTime(2023, 09, 1), 8000.0, SaleStatus.Faturado, s1);
            SalesRecord r5 = new ( new DateTime(2023, 09, 21), 3000.0, SaleStatus.Faturado, s3);
            SalesRecord r6 = new ( new DateTime(2023, 09, 15), 2000.0, SaleStatus.Faturado, s1);
            SalesRecord r7 = new ( new DateTime(2023, 09, 28), 13000.0, SaleStatus.Faturado, s2);
            SalesRecord r8 = new( new DateTime(2023, 09, 11), 4000.0, SaleStatus.Faturado, s4);
            SalesRecord r9 = new( new DateTime(2023, 09, 14), 11000.0, SaleStatus.Pendente, s6);
            SalesRecord r10 = new( new DateTime(2023, 09, 7), 9000.0, SaleStatus.Faturado, s6);
            SalesRecord r11 = new( new DateTime(2023, 09, 13), 6000.0, SaleStatus.Faturado, s2);
            SalesRecord r12 = new( new DateTime(2023, 09, 25), 7000.0, SaleStatus.Pendente, s3);
            SalesRecord r13 = new( new DateTime(2023, 09, 29), 10000.0, SaleStatus.Faturado, s4);
            SalesRecord r14 = new( new DateTime(2023, 09, 4), 3000.0, SaleStatus.Faturado, s5);
            SalesRecord r15 = new( new DateTime(2023, 09, 12), 4000.0, SaleStatus.Faturado, s1);
            SalesRecord r16 = new( new DateTime(2023, 10, 5), 2000.0, SaleStatus.Faturado, s4);
            SalesRecord r17 = new( new DateTime(2023, 10, 1), 12000.0, SaleStatus.Faturado, s1);
            SalesRecord r18 = new( new DateTime(2023, 10, 24), 6000.0, SaleStatus.Faturado, s3);
            SalesRecord r19 = new( new DateTime(2023, 10, 22), 8000.0, SaleStatus.Faturado, s5);
            SalesRecord r20 = new( new DateTime(2023, 10, 15), 8000.0, SaleStatus.Faturado, s6);
            SalesRecord r21 = new( new DateTime(2023, 10, 17), 9000.0, SaleStatus.Faturado, s2);
            SalesRecord r22 = new( new DateTime(2023, 10, 24), 4000.0, SaleStatus.Faturado, s4);
            SalesRecord r23 = new( new DateTime(2023, 10, 19), 11000.0, SaleStatus.Cancelado, s2);
            SalesRecord r24 = new( new DateTime(2023, 10, 12), 8000.0, SaleStatus.Faturado, s5);
            SalesRecord r25 = new( new DateTime(2023, 10, 31), 7000.0, SaleStatus.Faturado, s3);
            SalesRecord r26 = new( new DateTime(2023, 10, 6), 5000.0, SaleStatus.Faturado, s4);
            SalesRecord r27 = new( new DateTime(2023, 10, 13), 9000.0, SaleStatus.Pendente, s1);
            SalesRecord r28 = new( new DateTime(2023, 10, 7), 4000.0, SaleStatus.Faturado, s3);
            SalesRecord r29 = new( new DateTime(2023, 10, 23), 12000.0, SaleStatus.Faturado, s5);
            SalesRecord r30 = new( new DateTime(2023, 10, 12), 5000.0, SaleStatus.Faturado, s2);

            _context.Department.AddRange(d1, d2, d3, d4);

            _context.Seller.AddRange(s1, s2, s3, s4, s5, s6);

            _context.SalesRecord.AddRange(r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12, r13, r14, r15, r16, r17, r18, r19, r20, r21, r22, r23, r24, r25, r26, r27, r28, r29, r30);

            _context.SaveChanges();
        }
    }
}
