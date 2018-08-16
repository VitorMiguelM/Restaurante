﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrabalhoFinal_Restaurante.Models
{
    public class Clientes
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome não pode ser vazio")]
        [MinLength(3,ErrorMessage="Nome deve estar completo no minimo 3 carateres")]
        [MaxLength(100, ErrorMessage = "Nome deve conter no máximo 100 caracteres")]
        public string NomeCompleto { get; set; }
        [Required(ErrorMessage = "Login não pode ser vazio")]
        [MinLength(3, ErrorMessage = "Login deve estar completo no minimo 3 carateres")]
        [MaxLength(100, ErrorMessage = "Login deve conter no máximo 100 caracteres")]
        public string  Login { get; set; }
        [Required(ErrorMessage = "Senha não pode ser vazio")]
        [MinLength(3, ErrorMessage = "Senha deve estar completo no minimo 3 carateres")]
        [MaxLength(100, ErrorMessage = "Senha deve conter no máximo 100 caracteres")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "Celular não pode ser vazio")]
       
        public double Celular { get; set; }
 
        public string DataNacimento{ get; set; }
         [Required(ErrorMessage = "CPF não pode ser vazio")]
        public double CPF { get; set; }
         [Required(ErrorMessage = "Estado não pode ser vazio")]
        public string Estado { get; set; }
         [Required(ErrorMessage = "Cidade não pode ser vazio")]
        public string Cidade  { get; set; }
         [Required(ErrorMessage = "Bairro não pode ser vazio")]
        public string Bairro { get; set; }
         [Required(ErrorMessage = "Logadouro não pode ser vazio")]
        public string Logadouro { get; set; }
         [Required(ErrorMessage = "CEP não pode ser vazio")]
        public string cep { get; set; }
    }
}