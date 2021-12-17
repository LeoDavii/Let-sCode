using System;

namespace aula01Ambev.Model
{
    public class Endereco {
        public string logradouro { get; set; }
        public string nome { get; set; }
        public int numero { get; set; }
        public string complemento { get; set; }
        public string cep { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public string pais { get; set; }
    }
}