using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Data;
using SalesWebMVC.Models;
using SalesWebMVC.Services.Exceptions;

namespace SalesWebMVC.Services
{
    public class SellerService
    {
        private readonly SalesWebMVCContext _context;

        public SellerService(SalesWebMVCContext context)//injeto dependencia com o MVCContext para acessar os dados
        {
            _context = context;
        }

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }

        public async Task InsertAsync(Seller obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Seller> FindByIdAsync(int id)
        {
            return await _context.Seller.Include(obj => obj.Department)
                .FirstOrDefaultAsync(obj => obj.SellerID == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Seller.FindAsync(id);
                _context.Seller.Remove(obj);
                await _context.SaveChangesAsync();
            } catch (DbUpdateException) 
            {
                throw new IntegrityException("Não foi possível apagar o vendedor, pois já possui vendas em seu nome.");
            }
        }

        public async Task UpdateAsync(Seller obj) //recebo o id e atualizo o controller
        {
            bool hasAny = await _context.Seller.AnyAsync(x => x.SellerID == obj.SellerID); //valido em uma variavel o Any e nego no if
            if (!hasAny)
            {
                throw new NotFoundException("Id não encontrado");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }catch (DbUpdateException e) 
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
