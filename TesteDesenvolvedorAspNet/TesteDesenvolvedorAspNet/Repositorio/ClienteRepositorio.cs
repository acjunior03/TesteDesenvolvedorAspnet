using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using TesteDesenvolvedorAspNet.Data;
using TesteDesenvolvedorAspNet.Models;
using TesteDesenvolvedorAspNet.Contracts;

namespace TesteDesenvolvedorAspNet.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly Contexto _context;
        public ClienteRepositorio()
        {
            _context = new Contexto();
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
                _context.Entry(cliente).State = EntityState.Modified;
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
                return _context.ClienteItens.Include(x => x.Produtos).ToList();
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