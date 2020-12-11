using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TesteDesenvolvedorAspNet.Contracts;
using TesteDesenvolvedorAspNet.Models;

namespace TesteDesenvolvedorAspNet.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IProdutoRepositorio _produtoRepositorio;
        public ClienteController(IClienteRepositorio clienteRepositorio, IProdutoRepositorio produtoRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
            _produtoRepositorio = produtoRepositorio;
        }

        public ActionResult Index()
        {
            var listaCliente = from cliente in _clienteRepositorio.GetClientes() select cliente;
            return View(listaCliente);
        }
        public ActionResult AdicionarCliente()
        {
            var listaProduto = _produtoRepositorio.GetProdutosAtivos();
            ViewBag.Produtos = new SelectList(listaProduto, "IdProduto", "NomeProduto");
            return View(new Cliente());
        }
        [HttpPost]
        public ActionResult AdicionarCliente(Cliente cliente,Int64 IdProduto)
        {
            var retorno = _clienteRepositorio.VerificaCpf(cliente);
            if (retorno.Equals(""))
            {
                 retorno = _clienteRepositorio.VerificaEmail(cliente);
                if (retorno.Equals(""))
                {
                    _clienteRepositorio.AdicionarCliente(cliente, IdProduto);
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["ErroEmail"] = retorno;
                    var listaProduto = _produtoRepositorio.GetProdutosAtivos();
                    ViewBag.Produtos = new SelectList(listaProduto, "IdProduto", "NomeProduto");
                    return View(cliente);
                }
            }
            else
            {
                TempData["ErroCpf"] = retorno;
                var listaProduto = _produtoRepositorio.GetProdutosAtivos();
                ViewBag.Produtos = new SelectList(listaProduto, "IdProduto", "NomeProduto");
                return View(cliente);
            }
        }
        public ActionResult EditarCliente(Int64 id)
        {
            Cliente cliente = _clienteRepositorio.GetClienteporId(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }

            var listaProduto = _produtoRepositorio.GetProdutosAtivos();
            ViewBag.Produtos = new SelectList(listaProduto, "IdProduto", "NomeProduto");
            return View(cliente);
        }
        [HttpPost]
        public ActionResult EditarCliente(Cliente cliente)
        {
            var retorno = _clienteRepositorio.VerificaCpf(cliente);
            if (retorno.Equals(""))
            {
                retorno = _clienteRepositorio.VerificaEmail(cliente);
                if (retorno.Equals(""))
                {
                    _clienteRepositorio.AtualizaCliente(cliente);
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["ErroEmail"] = retorno;
                    var listaProduto = _produtoRepositorio.GetProdutosAtivos();
                    ViewBag.Produtos = new SelectList(listaProduto, "IdProduto", "NomeProduto");
                    return View(cliente);
                }
            }
            else
            {
                TempData["ErroCpf"] = retorno;
                var listaProduto = _produtoRepositorio.GetProdutosAtivos();
                ViewBag.Produtos = new SelectList(listaProduto, "IdProduto", "NomeProduto");
                return View(cliente);
            }
     
        }
        public ActionResult DeletarCliente(Int64 id)
        {
            Cliente produto = _clienteRepositorio.GetClienteporId(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }
        [HttpPost]
        public ActionResult DeletarCliente(Cliente cliente)
        {
            _clienteRepositorio.DeletaCliente(cliente.IdCliente);
            return RedirectToAction("Index");
        }
    }
}