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
        public void AdicionarCliente(Cliente cliente, Int64 IdProduto)
        {
            try
            {
                DbContextTransaction transacao = null;
                transacao = _context.Database.BeginTransaction();
                {
                    var produto = _context.ProdutoItens.SingleOrDefault(s => s.IdProduto == IdProduto);
                    if (produto is null)
                    {
                        transacao.Rollback();
                    }
                    else
                    {
                        _context.ClienteItens.Add(cliente);
                        _context.SaveChanges();

                        produto.IdCliente = cliente.IdCliente;
                        _context.SaveChanges();
                        transacao.Commit();
                    }
                }
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
        public string VerificaCpf(Cliente cliente)
        {
            string retorno = "";
            try
            {
                IEnumerable<Cliente> obj = _context.ClienteItens.Where(s => s.CPF == cliente.CPF);
                if (obj.Count() > 0)
                {
                    if (!(obj.FirstOrDefault().IdCliente == cliente.IdCliente))
                    {
                        retorno = "Já existe CPF cadastrado";
                    }
                }
                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string VerificaEmail(Cliente cliente)
        {
            string retorno = "";
            try
            {
                IEnumerable<Cliente> obj = _context.ClienteItens.Where(s => s.Email == cliente.Email);
                if (obj.Count() > 0)
                {
                    if (!(obj.FirstOrDefault().IdCliente == cliente.IdCliente))
                    {
                        retorno = "Já existe Email cadastrado";
                    }
                }
                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AtualizaCliente(Cliente cliente)
        {
            try
            {
                dynamic obj = new Cliente();
                obj = _context.ClienteItens.Include(x => x.Produtos).SingleOrDefault(s => s.IdCliente == cliente.IdCliente);

                obj.Email = cliente.Email;
                obj.CPF = cliente.CPF;
                obj.NomeCliente = cliente.NomeCliente;
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
                DbContextTransaction transacao = null;
                transacao = _context.Database.BeginTransaction();
                {
                    Cliente _cliente = _context.ClienteItens.SingleOrDefault(x => x.IdCliente == clienteId);
                    IEnumerable<Produto> produtos = _context.ProdutoItens.Where(z => z.IdCliente == clienteId);
                    foreach (var item in produtos)
                    {
                        item.IdCliente = 0;
                        _context.Entry(item).State = EntityState.Modified;
                    }
                    _context.SaveChanges();

                    _context.ClienteItens.Remove(_cliente);
                    _context.SaveChanges();
                    _cliente = null;
                    transacao.Commit();
                }
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
                obj = _context.ClienteItens.Include(x=> x.Produtos).AsNoTracking().SingleOrDefault(s => s.IdCliente == idCliente);
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