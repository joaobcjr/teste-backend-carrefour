using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Endereco
    {
        [NotMapped]
        public int Id { get; set; }


        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(244, ErrorMessage = "Este campo deve conter entre 10 e 255 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 10 e 255 caracteres")]
        public string Rua { get; set; }


        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(50, ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 50 caracteres")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(50, ErrorMessage = "Este campo deve conter entre 1 e 50 caracteres")]
        [MinLength(1, ErrorMessage = "Este campo deve conter entre 1 e 50 caracteres")]
        public string Numero { get; set; }

        [MaxLength(100, ErrorMessage = "Este campo deve conter no máximo 50 caracteres")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string CEP { get; set; }


        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, 3)]
        public int Tipo_endereco { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public int Tb_cidade_id { get; set; }

        [NotMapped]
        public List<ClienteEndereco> clienteEndereco { get; set; }


    }
}
