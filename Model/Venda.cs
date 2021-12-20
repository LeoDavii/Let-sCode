using System;
using System.Collections.Generic;
using System.Linq;

namespace aula01Ambev.Model
{
    public class Venda
    {
        public Guid id { get; set; }
        public int quantidade { get; set; }
        public Guid? idCliente { get; set; }
        public Guid idProduto { get; set; }
        public Guid idFilial { get; set; }
        public List<Venda> vendas { get; set; }
        public void RegistrarVenda(int _quantidade, Guid _idFilial, Guid _idProduto, Estoque estoque, Guid? _idCliente = null)
        {
            estoque.DiminuirEstoque(_idProduto, _idFilial, quantidade);
            vendas.Add(new Venda()
            {
                id = Guid.NewGuid(),
                idCliente = _idCliente,
                idProduto = _idProduto,
                idFilial = _idFilial,
                quantidade = _quantidade,
            });
        }

        public Venda BuscarVendaPorId(Guid _id)
        {
            return vendas.FirstOrDefault(p => p.id == _id);
        }

        public Venda BuscarVendaPorCliente(Guid _clienteId)
        {
            return vendas.FirstOrDefault(x => x.idCliente == _clienteId);
        }
    }
}
