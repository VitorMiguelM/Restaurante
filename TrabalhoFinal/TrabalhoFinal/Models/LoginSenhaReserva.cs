using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrabalhoFinal.Models
{
    public class LoginSenhaReserva
    {
        [Required(ErrorMessage = "Login não deve estar vazio")]
        [MinLength(5, ErrorMessage = "O mínimo de carateres para login é 5")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Senha não deve estar vazio")]
        [MinLength(4, ErrorMessage = "O mínimo de caracteres para senha é 4")]
        [MaxLength(12, ErrorMessage = "O máximo de caracteres para senha é 12")]
        public string Senha { get; set; }
    }
}