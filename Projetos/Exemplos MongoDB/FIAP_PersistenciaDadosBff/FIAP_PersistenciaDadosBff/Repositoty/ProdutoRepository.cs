using Dapper;
using Dapper.Contrib.Extensions;
using FIAP_PersistenciaDadosBff.Interfaces;
using FIAP_PersistenciaDadosBff.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.Common;

namespace FIAP_PersistenciaDadosBff.Repositoty
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly IDbConnection _context;
        
        public ProdutoRepository(IDbConnection context)
        {
            _context = context;
        }

        public async Task CreateAsync(Produto produto)
        {
            var comandoSql = @"INSERT INTO Produto (""Nome"", ""Preco"") 
                               VALUES (@Nome, @Preco)";

            await _context.ExecuteAsync(comandoSql, produto);
        }

        public async Task DeleteAsync(int id)
        {
            var listaRegistros = await GetAllAsync();
            var produto = listaRegistros.FirstOrDefault(x => x.Id.Equals(id));

            if (produto != null)
            {
                await _context.DeleteAsync(produto);
            }
        }

        public async Task<IList<Produto>> GetAllAsync()
        {
            var resultado =  await _context.GetAllAsync<Produto>();
            return resultado.ToList();
        }

        public async Task UpdateAsync(Produto produto)
        {
            var listaRegistros = await GetAllAsync();
            var produtoExistente = listaRegistros.FirstOrDefault(x => x.Id.Equals(produto.Id));

            if (produtoExistente != null)
            {
                produtoExistente.Nome = produto.Nome;
                produtoExistente.Preco = produto.Preco;

                await _context.UpdateAsync<Produto>(produtoExistente);
            }
        }
    }
}
