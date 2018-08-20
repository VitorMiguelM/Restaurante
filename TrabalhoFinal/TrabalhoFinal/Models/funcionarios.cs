using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrabalhoFinal.Models
{
    public class Funcionarios
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome não pode ser vazio")]
        [MinLength(3, ErrorMessage = "Nome deve estar completo no minimo 3 carateres")]
        [MaxLength(100, ErrorMessage = "Nome deve conter no máximo 100 caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Sobrenome não pode ser vazio")]

        [MaxLength(100, ErrorMessage = "Sobrenome deve conter no máximo 100 caracteres")]
        public string SobreNome { get; set; }
          [Required(ErrorMessage = "Senha não pode ser vazio")]
        public string Senha { get; set; }
          [Required(ErrorMessage = "Celular não pode ser vazio")]
        public  double Celular { get; set; }
          [Required(ErrorMessage = "Data de nacimento não pode ser vazio")]
        public DateTime DataDeNacimento { get; set; }
          [Required(ErrorMessage = "CPF não pode ser vazio")]
        public double CPF { get; set; }
          [Required(ErrorMessage = "Sobrenome não pode ser vazio")]
        public string Estado { get; set; }
          [Required(ErrorMessage = "Cidade não pode ser vazio")]

        public string Cidade { get; set; }
          [Required(ErrorMessage = "Bairro não pode ser vazio")]
        public string Bairro { get; set; }
          [Required(ErrorMessage = "Logadouro não pode ser vazio")]
        public string Logradouro { get; set; }
          [Required(ErrorMessage = "CEP não pode ser vazio")]
        public double CEP { get; set; }
          [Required(ErrorMessage = "Cargo não pode ser vazio")]
        public string Cargo { get; set; }



    }
}