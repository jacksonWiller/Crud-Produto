using Infrastructure.Repository.Gererics;
using Domain.Entity;
using Domain.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using ProAgil.Repository;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Repository.Interfaces;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryProduto : RepositoryGeneric<Produto>, IRepositoryProduto
    {
        private readonly DataContext _context;
        public RepositoryProduto(DataContext context)
        {
            _context = context;
        }
        public async Task<Produto[]> GetAllProdutosAsync()
        {
            IQueryable<Produto> query = _context.Produtos;
               
            query = query.AsNoTracking().OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Produto[]> GetAllProdutosAsyncByNome(string nome)
        {
            
            IQueryable<Produto> query = _context.Produtos;
               


            query = query.AsNoTracking().OrderBy(e => e.Id);

            return await query.ToArrayAsync(); 
        }

         public async Task<Produto> GetProdutoAsyncById(int ProdutoId)
        {
            IQueryable<Produto> query = _context.Produtos;

            return await query.FirstOrDefaultAsync();
        }

        
    }
}