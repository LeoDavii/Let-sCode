using System;
using System.Linq;
using System.Collections.Generic;

namespace aula01Ambev.Model
{
    public class Produto
    {
        public Guid id { get; set; }
        public string nome { get; set; }
        public List<Produto> produtos { get; set; }

        public void CadastrarProduto(string _nome)
        {
            produtos.Add(new Produto()
            {
                id = Guid.NewGuid(),
                nome = _nome,
            });
        }

        public void AtualizarProduto(string novoNome, Guid _id)
        {
            var produto = BuscarProdutoPorId(_id);
            produto.nome = novoNome;
        }

        public void DeletarProduto(Guid _id)
        {
            produtos.Remove(BuscarProdutoPorId(_id));
        }

        public Produto BuscarProdutoPorId(Guid _id)
        {
            var produto = produtos.FirstOrDefault(p => p.id == _id);
            if (produto != null)
            {
                return produto;
            }
            else
            {
                throw new Exception("Não foi possível localizar um produto com este Id");
            }
        }
    }
}