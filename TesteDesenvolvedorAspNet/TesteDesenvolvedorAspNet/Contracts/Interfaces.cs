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
        Produto GetProdutoporId(Int64 idProduto);
        void AdicionarProduto(Produto produto);
        void DeletaProduto(Int64 produtoId);
        void AtualizaProduto(Produto produto);
    }
    public interface IClienteRepositorio
    {
        IEnumerable<Cliente> GetClientes();
        Cliente GetClienteporId(Int64 idCliente);
        void AdicionarCliente(Cliente cliente);
        void DeletaCliente(Int64 ClienteId);
        void AtualizaCliente(Cliente cliente);
    }
}
