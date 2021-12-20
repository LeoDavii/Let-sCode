using System;

namespace aula01Ambev.Model
{
    public class ClientePJ : Pessoa {
        public override void VerificaDocumento(string _documento)
        {
            var documentEValido = _documento.Length == 14;
            if (!documentEValido)
            {
                throw new Exception("Documento inválido"); 
            }
        }

        public void CadastrarPJ(string _nome, string _documento, Endereco _endereco, string _telefone, string _email, string _nomeSocial = null)
        {
            VerificaDocumento(_documento);
            if (BuscarClientePorDocumento(_documento) != null)
            {
                var pessoa = new ClientePJ()
                {
                    id = Guid.NewGuid(),
                    nome = _nome,
                    nomeSocial = _nomeSocial ?? _nome,
                    documento = _documento,
                    endereco = _endereco,
                    telefone = _telefone,
                    email = _email
                };
                clientes.Add(pessoa);
            }
            else
            {
                throw new Exception("Documento já utilizado por outro cliente");
            }
        }
        
        public void AtualizarPJ(Guid _id, ClientePJ _cadastroAtualizado)
        {
            var cliente = BuscarClientePorId(_id);

            if (cliente != null)
            {
                VerificaDocumento(_cadastroAtualizado.documento);
                cliente = _cadastroAtualizado;
            }
            else
            {
                throw new Exception("Cliente não encontrado");
            }
        }
    }   
}