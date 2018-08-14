using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrabalhoFinal_Restaurante.Models
{
    public class clientes
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome não pode ser vazio")]
        [MinLength(3,ErrorMessage="Nome deve estar completo no minimo 3 carateres")]
        [MaxLength(100, ErrorMessage = "Nome deve conter no máximo 100 caracteres")]
        public string NomeCompleto { get; set; }

        public string  Login { get; set; }
        public string Senha { get; set; }
        public double Celular { get; set; }
        public string DataNacimento{ get; set; }
        public double CPF { get; set; }
        public string Estado { get; set; }
        public string Cidade  { get; set; }
        public string Bairro { get; set; }
        public string Logadouro { get; set; }
        public string cep { get; set; }
    }
}