using System;
using System.Collections.Generic;
using System.Linq;

namespace aula01Ambev.Model
{
    public class Estoque
    {
        public Guid id { get; set; }
        public Produto produto { get; set; }
        public int quantidade { get; set; }
        public List<Estoque> estoques { get; set; }

        public void CadastrarEstoque(Produto _produto, int _quantidade)
        {
            if (BuscarEstoquePorProduto(_produto) != null)
            {
                estoques.Add(new Estoque()
                {
                    id = Guid.NewGuid(),
                    produto = _produto,
                    quantidade = _quantidade,
                });
            }
            else {
                throw new Exception("Já existe estoque cadastrado para este produto");
            }
        }


        public void AtualizarEstoque(Produto _produto, int _quantidade)
        {
            var estoque = BuscarEstoquePorProduto(_produto);
            if (estoque != null)
            {
                estoque.produto = _produto;
                estoque.quantidade = _quantidade;
            }
            else
            {
                CadastrarEstoque(_produto, _quantidade);
            }
        }

        public void DiminuirEstoque(Produto _produto, int _quantidadeADiminuir)
        {
            var estoque = BuscarEstoquePorProduto(_produto);
            if (estoque.quantidade >= _quantidadeADiminuir)
            {
                estoque.quantidade = estoque.quantidade - _quantidadeADiminuir;
            }
            else
            {
                throw new Exception("A quantidade informada é superior à quantidade disponível");
            }
        }

        public Estoque BuscarEstoquePorProduto(Produto _produto)
        {
            return estoques.FirstOrDefault(p => p.produto == _produto);
        }
    }
}