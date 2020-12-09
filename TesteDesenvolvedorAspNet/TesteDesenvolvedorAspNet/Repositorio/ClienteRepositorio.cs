using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TesteDesenvolvedorAspNet.Contracts;
using TesteDesenvolvedorAspNet.Data;
using TesteDesenvolvedorAspNet.Models;

namespace TesteDesenvolvedorAspNet.Repositorio
{
    public class ClienteRepositorio
    {
        private readonly Contexto _context;
        public ClienteRepositorio(Contexto context)
        {
            _context = context;
        }
        public void AdicionarCliente(Cliente cliente)
        {
            try
            {
                _context.ClienteItens.Add(cliente);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_context != null)
                {
                    _context.Dispose();
                }
            }
        }

        public void AtualizaCliente(Cliente cliente)
        {
            try
            {
                var atualizarCliente = _context.ClienteItens.Where(x => x.IdCliente == cliente.IdCliente).FirstOrDefault();
                atualizarCliente.NomeCliente = cliente.NomeCliente;
                atualizarCliente.CPF = cliente.CPF;
                atualizarCliente.Email = cliente.Email;
                atualizarCliente.IdCliente = cliente.IdCliente;

                _context.SaveChanges();
                atualizarCliente = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_context != null)
                {
                    _context.Dispose();
                }
            }
        }

        public void DeletaCliente(Int64 clienteId)
        {
            try
            {
                Cliente _cliente = _context.ClienteItens.SingleOrDefault(x => x.IdCliente == clienteId);
                _context.ClienteItens.Remove(_cliente);
                _context.SaveChanges();
                _cliente = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_context != null)
                {
                    _context.Dispose();
                }
            }
        }

        public Cliente GetClienteporId(Int64 idCliente)
        {
            try
            {
                dynamic obj = new Cliente();
                obj = _context.ClienteItens.SingleOrDefault(s => s.IdCliente == idCliente);
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_context != null)
                {
                    _context.Dispose();
                }
            }
        }

        public IEnumerable<Cliente> GetClientes()
        {
            try
            {
                return _context.ClienteItens.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_context != null)
                {
                    _context.Dispose();
                }
            }
        }

    }
}