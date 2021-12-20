using System;
using System.Collections.Generic;
using System.Linq;

namespace aula01Ambev.Model
{
    public class Venda
    {
        public Guid id { get; set; }
        public int quantidade { get; set; }
        public Pessoa? cliente { get; set; }
        public Produto produto { get; set; }
        public List<Venda> vendas { get; set; }
        public void RegistrarVenda(int _quantidade, Produto _produto, Pessoa _cliente = null, Estoque estoque)
        {
            estoque.DiminuirEstoque(_produto, quantidade);
            vendas.Add(new Venda()
            {
                id = Guid.NewGuid(),
                cliente = _cliente,
                produto = _produto,
                quantidade = _quantidade,
            });
        }

        public Venda BuscarVendaPorId(Guid _id)
        {
            return vendas.FirstOrDefault(p => p.id == _id);
        }

        public Venda BuscarVendaPorCliente(Guid _clienteId)
        {
            return vendas.FirstOrDefault(x => x.cliente.id == _clienteId);
        }
    }
}
