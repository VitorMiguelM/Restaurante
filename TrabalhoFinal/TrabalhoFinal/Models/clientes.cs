﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrabalhoFinal.Models
{
    public class Clientes
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome não pode estar vazio.")]
        [MinLength(3, ErrorMessage = "Nome deve conter no mínimo 10 caracteres. (nome e sobrenome).")]
        [MaxLength(50, ErrorMessage = "Nome deve conter no máximo 50 caracteres.")]
        public string NomeCompleto { get; set; }

        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$", ErrorMessage = "Informe um e-mail válido.")]
        [Required(ErrorMessage = "E-mail não pode estar vazio.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Login não pode estar vazio.")]
        [MinLength(5, ErrorMessage = "O mínimo de caracteres para login é 5.")]
        [MaxLength(15, ErrorMessage = "O máximo de caracteres para login é 15.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Senha não pode estar vazio.")]
        [MinLength(4, ErrorMessage = "Senha deve conter no mínimo 4 carateres.")]
        [MaxLength(12, ErrorMessage = "Senha deve conter no máximo 12 caracteres.")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Telefone Celular não pode estar vazio.")]
        [MinLength(12, ErrorMessage = "Esse número é inválido.")]
        [MaxLength(16, ErrorMessage = "Esse número é invalido.")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "Data de nascimento não pode estar vazio.")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "CPF deve ser preenchido!")]
        [MinLength(14, ErrorMessage = "Esse CPF é inválido!")]
        [MaxLength(14, ErrorMessage = "Esse CPF é inválido!")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Estado não pode estar vazio.")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Cidade não pode estar vazio.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Bairro não pode esar vazio.")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Logadouro não pode estar vazio.")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "CEP não pode ser vazio.")]
        [MinLength(8, ErrorMessage = "CEP deve conter no mínimo 8 caracteres")]
        [MaxLength(9, ErrorMessage = "CEP deve conter no máximo 9 caracteres")]
        public string CEP { get; set; }


        
    }
}