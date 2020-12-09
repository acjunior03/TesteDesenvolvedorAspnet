using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteDesenvolvedorAspNet.Contracts;
using TesteDesenvolvedorAspNet.Models;

namespace TesteDesenvolvedorAspNet.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoController(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }
        public ActionResult Index()
        {
            var listaProduto = from produto in _produtoRepositorio.GetProdutos() select produto;
            return View(listaProduto);
        }
        public ActionResult AdicionarUsuario()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdicionarProduto(Produto produto)
        {
            _produtoRepositorio.AdicionarProduto(produto);
            return RedirectToAction("Index");
        }
        public ActionResult EditarProduto(Int64 id = 0)
        {
            Produto produto = _produtoRepositorio.GetProdutoporId(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }
        [HttpPut]
        public ActionResult EditarProduto(Produto produto)
        {
            _produtoRepositorio.AtualizaProduto(produto);
            return RedirectToAction("Index");
        }
        public ActionResult DeletarProduto(Int64 id = 0)
        {
            Produto produto = _produtoRepositorio.GetProdutoporId(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }
        [HttpDelete]
        public ActionResult DeletarProduto(Produto produto)
        {
            _produtoRepositorio.DeletaProduto(produto.IdProduto);
            return RedirectToAction("Index");
        }
    }
}