using FIAP_PersistenciaDados.Context;
using FIAP_PersistenciaDados.Interfaces;
using FIAP_PersistenciaDados.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FIAP_PersistenciaDados.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        // GET: Produtos
        public async Task<IActionResult> Index()
        {
            var produtos = await _produtoService.GetAllAsync();
            return View(produtos);
        }

        // GET: Produtos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _produtoService.GetAllAsync();
            if (!produto.Any(m => m.Id == id))
            {
                return NotFound();
            }

            return View(produto.FirstOrDefault(m => m.Id == id));
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Preco")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                _produtoService.CreateAsync(produto);
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultado = await _produtoService.GetAllAsync();
            var produto = resultado.FirstOrDefault(x => x.Id == id);

            if (produto is null || produto.Id.Equals(0))
            {
                return NotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Preco")] Produto produto)
        {
            if (id != produto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _produtoService.UpdateByIdAsync(produto);
                }
                catch
                {
                    if (!await ProdutoExists(produto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultado = await _produtoService.GetAllAsync();
            var produto = resultado.FirstOrDefault(x => x.Id == id);

            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id, [Bind("Id,Nome,Preco")] Produto produto)
        {
            await _produtoService.DeleteAsync(produto);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ProdutoExists(int id)
        {
            var resultado = await _produtoService.GetAllAsync();
            return resultado.Any(e => e.Id == id);
        }
    }

}
