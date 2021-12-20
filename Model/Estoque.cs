using System;
using System.Collections.Generic;
using System.Linq;

namespace aula01Ambev.Model
{
    public class Estoque
    {
        public Guid id { get; set; }
        public Guid idProduto { get; set; }
        public int quantidade { get; set; }
        public Guid idFilial {get; set;}
        public List<Estoque> estoques { get; set; }

        public void CadastrarEstoque(Guid _idProduto, Guid _idFilial, int _quantidade)
        {
            //Estes dois métodos, na estrutura sugerida, acabariam sempre resultando em exceção, visto que
            //uma instância nova de cada classe sempre vai retornar as listas de produtos e filiais zeradas
            new Produto().BuscarProdutoPorId(_idProduto);
            new Filiais().BuscarFilialPorId(_idFilial);
            if (BuscarEstoquePorProduto(_idProduto, _idFilial) == null)
            {
                estoques.Add(new Estoque()
                {
                    id = Guid.NewGuid(),
                    idProduto = _idProduto,
                    idFilial = _idFilial,
                    quantidade = _quantidade,
                });
            }
            else {
                throw new Exception("Já existe estoque cadastrado para este produto");
            }
        }


        public void AtualizarEstoque(Guid _idProduto, Guid _idFilial, int _quantidade)
        {
            var estoque = BuscarEstoquePorProduto(_idProduto, _idFilial);
            if (estoque != null)
            {
                estoque.quantidade = _quantidade;
            }
            else
            {
                throw new Exception("Não existe estoque para este produto nesta filial, favor cadastrar");
            }
        }

        public void DiminuirEstoque(Guid _idProduto, Guid _idFilial, int _quantidadeADiminuir)
        {
            var estoque = BuscarEstoquePorProduto(_idProduto, _idFilial);
            if (estoque.quantidade >= _quantidadeADiminuir)
            {
                estoque.quantidade = estoque.quantidade - _quantidadeADiminuir;
            }
            else
            {
                throw new Exception("A quantidade informada é superior à quantidade disponível");
            }
        }

        public Estoque BuscarEstoquePorProduto(Guid _idProduto, Guid _idFilial)
        {
            return estoques.FirstOrDefault(p => p.idProduto == _idProduto && p.idFilial == _idFilial);
        }
    }
}