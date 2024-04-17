using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUDTATEST2024.Models;

namespace CRUDTATEST2024.Controllers
{
    public class ItensController : Controller
    {
        private readonly Contexto _context;

        public ItensController(Contexto context)
        {
            _context = context;
        }

        // GET: Itens
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Itens.Include(i => i.produto).Include(i => i.venda);
            return View(await contexto.ToListAsync());
        }

        // GET: Itens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Itens
                .Include(i => i.produto)
                .Include(i => i.venda)
                .FirstOrDefaultAsync(m => m.id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: Itens/Create
        public IActionResult Create()
        {
            ViewData["produtoID"] = new SelectList(_context.Produtos, "id", "descricao");
            ViewData["vendaID"] = new SelectList(_context.Vendas, "id", "id");
            return View();
        }

        // POST: Itens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,vendaID,produtoID,quantidade,valor")] Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item);
                var prod = await _context.Produtos.FindAsync(item.produtoID);
                prod.quantidade = prod.quantidade - item.quantidade;
                _context.Update(prod);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["produtoID"] = new SelectList(_context.Produtos, "id", "descricao", item.produtoID);
            ViewData["vendaID"] = new SelectList(_context.Vendas, "id", "id", item.vendaID);
            return View(item);
        }

        // GET: Itens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Itens.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            ViewData["produtoID"] = new SelectList(_context.Produtos, "id", "descricao", item.produtoID);
            ViewData["vendaID"] = new SelectList(_context.Vendas, "id", "id", item.vendaID);
            return View(item);
        }

        // POST: Itens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,vendaID,produtoID,quantidade,valor")] Item item)
        {
            if (id != item.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.id))
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
            ViewData["produtoID"] = new SelectList(_context.Produtos, "id", "descricao", item.produtoID);
            ViewData["vendaID"] = new SelectList(_context.Vendas, "id", "id", item.vendaID);
            return View(item);
        }

        // GET: Itens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Itens
                .Include(i => i.produto)
                .Include(i => i.venda)
                .FirstOrDefaultAsync(m => m.id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Itens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Itens.FindAsync(id);
            if (item != null)
            {
                _context.Itens.Remove(item);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(int id)
        {
            return _context.Itens.Any(e => e.id == id);
        }
    }
}
