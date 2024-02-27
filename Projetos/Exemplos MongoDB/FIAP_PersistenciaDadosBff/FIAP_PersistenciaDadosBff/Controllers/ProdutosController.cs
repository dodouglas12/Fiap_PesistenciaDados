using FIAP_PersistenciaDadosBff.Interfaces;
using FIAP_PersistenciaDadosBff.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FIAP_PersistenciaDadosBff.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var resultado = await _produtoService.GetAllAsync();

            if (resultado is null || !resultado.Any())
            {
                return Ok(new List<Produto>());
            }

            return Ok(resultado);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync(Produto produto)
        {
            await _produtoService.CreateAsync(produto);
            return Created();
        }

        [HttpDelete("Remove")]
        public async Task<IActionResult> DeleteAsync([FromQuery] int id)
        {
            await _produtoService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync(Produto produto)
        {
            await _produtoService.UpdateAsync(produto);
            return Ok(produto);
        }
    }
}
