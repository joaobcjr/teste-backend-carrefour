using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class ClienteEndereco
    {
        [NotMapped]
        public int Id { get; set; }

        [NotMapped]
        public int Tb_cliente_id { get; set; }

        [NotMapped]
        public int Tb_endereco_id { get; set; }
        public Cliente cliente { get; set; }


        public Endereco endereco { get; set; }


    }
}
