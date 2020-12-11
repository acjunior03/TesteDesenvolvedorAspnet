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
        private readonly IClienteRepositorio _clienteRepositorio;

        public ProdutoController(IProdutoRepositorio produtoRepositorio, IClienteRepositorio clienteRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
            _clienteRepositorio = clienteRepositorio;
        }
        public ActionResult Index()
        {
            var listaProduto = from produto in _produtoRepositorio.GetProdutos() select produto;
            return View(listaProduto);
        }
        public ActionResult AdicionarProduto()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdicionarProduto(Produto produto)
        {
            produto.IdCliente = 0;
            _produtoRepositorio.AdicionarProduto(produto);
            return RedirectToAction("Index");
        }
        public ActionResult EditarProduto(Int64 id = 0)
        {
            var listaClientes = _clienteRepositorio.GetClientes();
            ViewBag.Clientes = new SelectList(listaClientes, "IdCliente", "NomeCliente");

            Produto produto = _produtoRepositorio.GetProdutoporId(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }
        [HttpPost]
        public ActionResult EditarProduto(Produto produto)
        {
            _produtoRepositorio.AtualizaProduto(produto);
            return RedirectToAction("Index");
        }  

        public ActionResult RemoverCliente(Int64 IdProduto, Int64 IdCliente)
        {
            _produtoRepositorio.RemoveClienteProduto(IdProduto);
            return RedirectToAction("ProdutosCliente", new { id = IdCliente } );
        }
        public ActionResult DeletarProduto(Int64 id)
        {
            Produto produto = _produtoRepositorio.GetProdutoporId(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }
        [HttpPost]
        public ActionResult DeletarProduto(Produto produto)
        {
            if (produto.IdCliente ==0)
            {
                _produtoRepositorio.DeletaProduto(produto.IdProduto);
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ErroExcluir"] = "Produto vinculado a um cliente";
                return RedirectToAction("DeletarProduto", new { id = produto.IdProduto });
            }
        }
        public ActionResult ProdutosCliente(Int64 id)
        {
            var listaProduto  = _produtoRepositorio.GetProdutoPorIdCliente(id);
            return View(listaProduto);
        }
    }
}