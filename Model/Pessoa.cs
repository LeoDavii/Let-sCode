using System;
using System.Collections.Generic;
using System.Linq;

namespace aula01Ambev.Model
{
    public class Pessoa
    {
        public Guid id { get; set; }
        public string nome { get; set; }
        public string nomeSocial { get; set; }
        public string documento { get; set; }
        public Endereco endereco { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public List<Pessoa> clientes { get; set; }

        public virtual void VerificaDocumento(string _documento) { }

        public Pessoa BuscarClientePorId(Guid _id)
        {
            return clientes.FirstOrDefault(p => p.id == _id);
        }

        public List<Pessoa> BuscarClientePorNome(string _nome)
        {
            return clientes.Where(p => p.nome == _nome).ToList();
        }

        public Pessoa BuscarClientePorDocumento(string _documento)
        {
            return clientes.FirstOrDefault(p => p.documento == _documento);
        }
    }
}