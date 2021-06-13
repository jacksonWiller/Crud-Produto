using System;
using System.Threading.Tasks;
using AplicationApp.Interfaces;
using Domain.Entity;
using Infrastructure.Repository;
using Infrastructure.Repository.Interfaces;

namespace AplicationApp
{
    public class ProdutoService : IProdutoService
    {
        private readonly IRepositoryProduto _repositoryProduto;
        private readonly IRepositoryGeneric _repositoryGeneric;
        public ProdutoService(IRepositoryGeneric repositoryGeneric, IRepositoryProduto repositoryProduto)
        {
            _repositoryProduto = repositoryProduto;
            _repositoryGeneric = repositoryGeneric;
        }
        public async Task<Produto> AddProdutos(Produto model)
        {
           try
           {
               _repositoryGeneric.Add<Produto>(model); 
               if( await _repositoryGeneric.SaveChangesAsync()){
                   return await _repositoryProduto.GetProdutoAsyncById(model.Id);
               }
               return null;
           }
           catch (Exception ex)
           {
               
               throw new Exception(ex.Message) ;
           }
        }
        public async Task<Produto> UpdateProdutos(int produtoId, Produto model)
        {
            try
            {
                var  produto = await _repositoryProduto.GetProdutoAsyncById(produtoId);
                if (produto == null) return null; 

                model.Id = produto.Id;

                _repositoryGeneric.Update(model);
                if(await _repositoryGeneric.SaveChangesAsync()){
                    return await _repositoryProduto.GetProdutoAsyncById(model.Id);
                }
                return null;
            }
            catch (System.Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteProduto(int produtoId)
        {
            try
            {
                var  produto = await _repositoryProduto.GetProdutoAsyncById(produtoId);
                if (produto == null) throw new Exception("Produto para delete não foi encontrado."); 
                
                _repositoryGeneric.Delete<Produto>(produto);
                return await _repositoryProduto.SaveChangesAsync();
                
            }
            catch (System.Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
        public async Task<Produto[]> GetAllProdutosAsync()
        {
            try
            {
                var produto = await _repositoryProduto.GetAllProdutosAsync();
                if (produto == null) return null;

                return produto;
            } 
            catch (System.Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Produto[]> GetAllProdutosAsyncByNome(string nome)
        {
            try
            {
                var produto = await _repositoryProduto.GetAllProdutosAsyncByNome(nome);
                if (produto == null) return null;

                return produto;
            } 
            catch (System.Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Produto> GetProdutoAsyncById(int produtosId)
        {
            try
            {
                var produto = await _repositoryProduto.GetProdutoAsyncById(produtosId);
                if (produto == null) return null;

                return produto;
            } 
            catch (System.Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
    }
}