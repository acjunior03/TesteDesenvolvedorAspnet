using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteDesenvolvedorAspNet.Contracts;
using TesteDesenvolvedorAspNet.Models;

namespace TesteDesenvolvedorAspNet.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        public ClienteController(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }
        public ActionResult Index()
        {
            var listaCliente = from cliente in _clienteRepositorio.GetClientes() select cliente;
            return View(listaCliente);
        }
        public ActionResult AdicionarUsuario()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdicionarCliente(Cliente cliente)
        {
            _clienteRepositorio.AdicionarCliente(cliente);
            return RedirectToAction("Index");
        }
        public ActionResult EditarCliente(Int64 id = 0)
        {
            Cliente cliente = _clienteRepositorio.GetClienteporId(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }
        [HttpPut]
        public ActionResult EditarCliente(Cliente cliente)
        {
            _clienteRepositorio.AtualizaCliente(cliente);
            return RedirectToAction("Index");
        }
        public ActionResult DeletarCliente(Int64 id = 0)
        {
            Cliente produto = _clienteRepositorio.GetClienteporId(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }
        [HttpDelete]
        public ActionResult DeletarCliente(Cliente cliente)
        {
            _clienteRepositorio.DeletaCliente(cliente.IdCliente);
            return RedirectToAction("Index");
        }
    }
}