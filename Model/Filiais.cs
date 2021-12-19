using System;
using System.Linq;
using System.Collections.Generic;

namespace aula01Ambev.Model
{
    public class Filiais
    {
        public Guid id { get; set; }
        public string nome { get; set; }
        public Endereco endereco { get; set; }
        public List<Filiais> filiais { get; set; }

        public void CadastrarFilial(string _nome, Endereco _endereco)
        {
            filiais.Add(new Filiais()
            {
                id = Guid.NewGuid(),
                nome = _nome,
                endereco = _endereco,
            });
        }

        public void AtualizarFilial(string novoNome, Endereco novoEndereco, Guid _id)
        {
            var filial = BuscarFilialPorId(_id);
            if (filial != null)
            {
                filial.nome = novoNome;
                filial.endereco = novoEndereco;
            }
            else
            {
                throw new Exception("Não foi possível localizar uma filial com este Id");
            }
        }

        public Filiais BuscarFilialPorId(Guid _id)
        {
            return filiais.FirstOrDefault(x => x.id == id);
        }

        public Filiais BuscarFilialPorNome(string _nome)
        {
            return filiais.FirstOrDefault(x => x.nome == _nome);
        }

    }
}