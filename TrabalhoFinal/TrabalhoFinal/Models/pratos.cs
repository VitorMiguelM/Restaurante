using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrabalhoFinal.Models
{
    public class Pratos
    {
        public int Id { get; set; }
      
        [Required(ErrorMessage = "Nome deve ser preenchido")]
        [MinLength(3, ErrorMessage = "Nome deve estar completo no minimo 3 carateres")]
        [MaxLength(100, ErrorMessage = "Nome deve conter no máximo 100 caracteres")]
        public string Nome { get; set; }

    
        [Required(ErrorMessage = "Campo modo de peparo deve  ser preenchido")]
        public string ModoDePreparo { get; set; }

       
        [Required(ErrorMessage = "Campo propiedades deve preenchido")]
        public string Propriedades_Nutricionais { get; set; }

        [Required(ErrorMessage = "Campo email deve preenchido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo celular deve preenchido")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "Camppo preço deve ser preenchido")]
        public decimal preco { get; set; }



        [Required(ErrorMessage = "Campo descriçao deve preenchido")]
        public string Descricao { get; set; }

        

        
    }
}