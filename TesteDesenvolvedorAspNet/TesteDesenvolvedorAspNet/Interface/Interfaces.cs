using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteDesenvolvedorAspNet.Models;

namespace TesteDesenvolvedorAspNet.Contracts
{
    public interface IProdutoRepositorio
    {
        IEnumerable<Produto> GetProdutos();
        IEnumerable<Produto> GetProdutosAtivos();
        Produto GetProdutoporId(Int64 idProduto);
        void AdicionarProduto(Produto produto);
        void DeletaProduto(Int64 produtoId);
        void AtualizaProduto(Produto produto);
        void RemoveClienteProduto(Int64 IdProduto);
        IEnumerable<Produto> GetProdutoPorIdCliente(Int64 idCliente);
    }
    public interface IClienteRepositorio
    {
        IEnumerable<Cliente> GetClientes();
        Cliente GetClienteporId(Int64 idCliente);
        string VerificaCpf(Cliente cliente);
        string VerificaEmail(Cliente cliente);
        void AdicionarCliente(Cliente cliente, Int64 IdProduto);
        void DeletaCliente(Int64 ClienteId);
        void AtualizaCliente(Cliente cliente);
    }
}
