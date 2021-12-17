using System;

namespace aula01Ambev.Model {
    public class Pessoa {
        public int id { get; set; }
        public string nome { get; set; }
        public string nomeSocial { get; set; }
        public string documento { get; set; }
        public Endereco endereco { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }

        public virtual void VerificaDocumento(string _documento) { }
    }
}