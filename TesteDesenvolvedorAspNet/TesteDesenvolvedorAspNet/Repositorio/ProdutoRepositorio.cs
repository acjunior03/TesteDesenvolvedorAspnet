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
                obj = _context.ProdutoItens.SingleOrDefault(s => s.IdProduto == idProduto);
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
                var a = _context.ProdutoItens.ToList();
                return a;
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