using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrabalhoFinal_Restaurante.Models
{
    public class funcionarios
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Senha { get; set; }
        public  double Celular { get; set; }
        public double DataDeNacimento { get; set; }
        public double cpf { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Logadouro { get; set; }
        public double cep { get; set; }
        public string Cargo { get; set; }



    }
}