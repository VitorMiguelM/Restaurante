﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrabalhoFinal_Restaurante.Models
{
    public class pratos
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome não pode ser vazio")]
        [MinLength(3, ErrorMessage = "Nome deve estar completo no minimo 3 carateres")]
        [MaxLength(100, ErrorMessage = "Nome deve conter no máximo 100 caracteres")]
        public string Nome { get; set; }
         [Required(ErrorMessage = "modo de peparo não pode ser vazio")]
        public string ModoDePreparo { get; set; }
         [Required(ErrorMessage = "propiedades não pode ser vazio")]
        public string PropiedadesNaturais { get; set; }
         [Required(ErrorMessage = "Preso não pode ser vazio")]
         public double preco { get; set; }

        public string descricao { get; set; }

    }
}