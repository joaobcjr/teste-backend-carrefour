using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(150, ErrorMessage = "Este campo deve conter entre 3 e 150 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 150 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(20, ErrorMessage = "Este campo deve conter entre 8 e 20 caracteres")]
        [MinLength(8, ErrorMessage = "Este campo deve conter entre 8 e 20 caracteres")]
        public string RG { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(20, ErrorMessage = "Este campo deve conter entre 8 e 20 caracteres")]
        [MinLength(8, ErrorMessage = "Este campo deve conter entre 8 e 20 caracteres")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [DataType(DataType.DateTime)]
        public DateTime Data_nascimento { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(20, ErrorMessage = "Este campo deve conter entre 8 e 20 caracteres")]
        [MinLength(8, ErrorMessage = "Este campo deve conter entre 8 e 20 caracteres")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(20, ErrorMessage = "Este campo deve conter no máximo 150 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, 2)]
        public int Cod_empresa { get; set; }

        public List<ClienteEndereco> clienteEndereco { get; set; }

    }
}
