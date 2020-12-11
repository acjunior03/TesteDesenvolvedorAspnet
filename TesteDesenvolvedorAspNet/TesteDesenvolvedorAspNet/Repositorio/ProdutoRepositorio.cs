using System;
using System.Collections.Generic;
using System.Linq;
using TesteDesenvolvedorAspNet.Contracts;
using TesteDesenvolvedorAspNet.Data;
using TesteDesenvolvedorAspNet.Models;
using System.Data.Entity;

namespace TesteDesenvolvedorAspNet.Repositorio
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly Contexto _context;
        public ProdutoRepositorio(Contexto context)
        {
            _context = context;
        }
        public void AdicionarProduto(Produto produto)
        {
            try
            {
                _context.ProdutoItens.Add(produto);
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

        public void AtualizaProduto(Produto produto)
        {
            try
            {
                _context.Entry(produto).State = EntityState.Modified;
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
        public void RemoveClienteProduto(Int64 IdProduto)
        {
            try
            {
                Produto produto = _context.ProdutoItens.SingleOrDefault(x => x.IdProduto == IdProduto);
                produto.IdCliente = new Int64();
                _context.Entry(produto).State = EntityState.Modified;
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

        public void DeletaProduto(Int64 produtoId)
        {
            try
            {
                Produto _produto = _context.ProdutoItens.SingleOrDefault(x => x.IdProduto == produtoId);
                _context.ProdutoItens.Remove(_produto);
                _context.SaveChanges();
                _produto = null;
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

        public Produto GetProdutoporId(Int64 idProduto)
        {
            try
            {
                dynamic obj = new Produto();
                obj = _context.ProdutoItens.Include(z => z.Cliente).SingleOrDefault(s => s.IdProduto == idProduto);
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
        public IEnumerable<Produto> GetProdutoPorIdCliente(Int64 idCliente)
        {
            try
            {
                dynamic obj = new Produto();
                obj = _context.ProdutoItens.Include(z => z.Cliente).Where(s => s.IdCliente == idCliente).ToList();
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

        public IEnumerable<Produto> GetProdutos()
        {
            try
            {
                var f = _context.ProdutoItens.ToList();
                return f;
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
        public IEnumerable<Produto> GetProdutosAtivos()
        {
            try
            {
                return _context.ProdutoItens.Where(z => z.Ativo == true && z.IdCliente == 0).ToList();
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