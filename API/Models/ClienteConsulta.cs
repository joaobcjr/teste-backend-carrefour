using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class ClienteConsulta
    {
        [MaxLength(150, ErrorMessage = "Este campo deve conter entre 3 e 150 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 150 caracteres")]
        public string Nome { get; set; }

        [MaxLength(20, ErrorMessage = "Este campo deve conter entre 8 e 20 caracteres")]
        [MinLength(8, ErrorMessage = "Este campo deve conter entre 8 e 20 caracteres")]
        public string RG { get; set; }

        [MaxLength(20, ErrorMessage = "Este campo deve conter entre 8 e 20 caracteres")]
        [MinLength(8, ErrorMessage = "Este campo deve conter entre 8 e 20 caracteres")]
        public string CPF { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? Data_nascimento { get; set; }

        [MaxLength(20, ErrorMessage = "Este campo deve conter entre 8 e 20 caracteres")]
        [MinLength(8, ErrorMessage = "Este campo deve conter entre 8 e 20 caracteres")]
        public string Telefone { get; set; }

        [MaxLength(20, ErrorMessage = "Este campo deve conter no máximo 150 caracteres")]
        public string Email { get; set; }
        public int? Cod_empresa { get; set; }



    }
}
