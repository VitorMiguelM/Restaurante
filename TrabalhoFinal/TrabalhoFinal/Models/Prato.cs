using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrabalhoFinal.Models
{
    public class Prato
    {
        public int Id { get; set; }
     
      
        [Required(ErrorMessage = "Nome deve ser preenchido")]
        [MinLength(3, ErrorMessage = "Campo nome deve conter 3 carateres no minimo")]
        public string Nome { get; set; }

    
        [Required(ErrorMessage = "Campo modo de peparo deve  ser preenchido")]
        public string ModoDePreparo { get; set; }

       
        [Required(ErrorMessage = "Campo propiedades deve preenchido")]
        public string Propriedades_Nutricionais { get; set; }
         [MinLength(8, ErrorMessage = "Campo Email deve conter no minimo 8 caracteres")]
        [Required(ErrorMessage = "Campo Email deve preenchido")]

        public string Email { get; set; }

        [Required(ErrorMessage = "Campo celular deve preenchido")]
        [MinLength(8, ErrorMessage = "Campo celular deve conter no minimo 8 caracteres")]
        [MaxLength(15,ErrorMessage="Campo celular deve conter no maximo 15 carateres ")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "Campo preço deve ser preenchido")]
        public decimal preco { get; set; }



        [Required(ErrorMessage = "Campo descriçao deve preenchido")]
        public string Descricao { get; set; }

        

        
    }
}