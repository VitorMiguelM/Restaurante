using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrabalhoFinal.Models
{
    public class Reserva
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome não pode ser vazio")]

        [MinLength(3, ErrorMessage = "O mínimo de caracteres para o nome é 3")]

        [MaxLength(100, ErrorMessage = "O máximo de caracteres para o nome é 100")]

        public string Nome { get; set; }

        [Required(ErrorMessage = "Celular não deve estar vazio")]

        [MinLength(14, ErrorMessage = "O número deve conter no mínimo 14 caracteres")]

        [MaxLength(15, ErrorMessage = "O número deve conter no máximo 15 caracteres")]

        public string Celular { get; set; }

        [Required(ErrorMessage = "CPF não deve estar vazio")]

        [MinLength(14, ErrorMessage = "CPF não deve conter no mínimo 14 caracteres")]

        [MaxLength(14, ErrorMessage = "CPF deve conter no máximo 14 caracteres")]

        public string CPF { get; set; }

        [Required(ErrorMessage = "Informe o horário")]

        public DateTime Horario { get; set; }

        [Required(ErrorMessage = "Informe como vai ser o pagamento")]

        public string Pagamento { get; set; }
    }
}






