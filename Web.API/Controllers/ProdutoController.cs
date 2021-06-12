using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Entity;
using Infrastructure.Repository;
using Infrastructure.Repository.Interfaces;
using Infrastructure.Repository.Gererics;

namespace Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IRepositoryGeneric _repositoryGeneric;
        private readonly IRepositoryProduto _repositoryProduto;
        
        public ProdutoController(IRepositoryGeneric repositoryGeneric, IRepositoryProduto repositoryProduto)
        {
            _repositoryGeneric = repositoryGeneric;
            _repositoryProduto = repositoryProduto;
        }
        // [HttpPost]
        // public async Task<IActionResult> Post(Produto model)
        // {
        //     try
        //     {
        //         // Produto produto;
        //         var retorno = await _repositoryGeneric.Add<Produto>(model);
               
        //         return Ok(retorno);
        //     }
        //     catch (Exception ex)
        //     {
        //         return this.StatusCode(StatusCodes.Status500InternalServerError,
        //             $"Erro ao tentar adicionar eventos. Erro: {ex.Message}");
        //     }
        // }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var produtos = await _repositoryProduto.GetAllProdutosAsync();
                if (produtos == null) return NoContent();
                return Ok(produtos);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }
        }
        [HttpGet("{nome}/nome")]
        public async Task<IActionResult> Get(string nome)
        {
            try
            {
                var produto = await _repositoryProduto.GetAllProdutosAsyncByNome(nome);

                return Ok(produto);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }
        }
        [HttpGet("{ProdutosId}")]
        public async Task<IActionResult> Get(int ProdutosId)
        {
            try
            {
                var produto = await _repositoryProduto.GetProdutoAsyncById(ProdutosId);

                return Ok(produto);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }
        }
         
        


    }
}