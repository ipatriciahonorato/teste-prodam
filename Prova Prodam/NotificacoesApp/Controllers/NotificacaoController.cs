using Microsoft.AspNetCore.Mvc;
using NotificacoesApp.Models;
using System.Linq;

namespace NotificacoesApp.Controllers
{
    public class NotificacaoController : Controller
    {
        private readonly AppDbContext _context;

        public NotificacaoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Notificacao/
        public IActionResult Index(string filtroTipo, string filtroGravidade)
        {
            var lista = _context.Notificacoes.AsQueryable();

            if (!string.IsNullOrEmpty(filtroTipo))
            {
                lista = lista.Where(n => n.Tipo.Contains(filtroTipo));
            }

            if (!string.IsNullOrEmpty(filtroGravidade))
            {
                lista = lista.Where(n => n.Gravidade.Contains(filtroGravidade));
            }

            return View(lista.ToList());
        }

        // GET: /Notificacao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Notificacao/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Notificacao notificacao)
        {
            if (ModelState.IsValid)
            {
                notificacao.DataRecebimento = System.DateTime.Now;
                _context.Notificacoes.Add(notificacao);
                _context.SaveChanges(); // Salva no banco de dados
                return RedirectToAction(nameof(Index));
            }
            return View(notificacao);
        }

        // GET: /Notificacao/Edit/1
        public IActionResult Edit(int id)
        {
            var notificacao = _context.Notificacoes.Find(id);
            if (notificacao == null) return NotFound();
            return View(notificacao);
        }

        // POST: /Notificacao/Edit/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Notificacao notificacaoEditada)
        {
            var notificacao = _context.Notificacoes.Find(id);
            if (notificacao == null) return NotFound();

            if (ModelState.IsValid)
            {
                notificacao.Tipo = notificacaoEditada.Tipo;
                notificacao.Gravidade = notificacaoEditada.Gravidade;
                _context.SaveChanges(); // Salva no banco de dados
                return RedirectToAction(nameof(Index));
            }

            return View(notificacaoEditada);
        }

        // GET: /Notificacao/Delete/1
        public IActionResult Delete(int id)
        {
            var notificacao = _context.Notificacoes.Find(id);
            if (notificacao == null) return NotFound();
            return View(notificacao);
        }

        // POST: /Notificacao/Delete/1
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var notificacao = _context.Notificacoes.Find(id);
            if (notificacao != null)
            {
                _context.Notificacoes.Remove(notificacao);
                _context.SaveChanges(); // Salva no banco de dados
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

