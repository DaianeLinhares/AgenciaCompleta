﻿using System.ComponentModel.DataAnnotations;

namespace AgenciaComBack.Models
{
    public class Contato
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Mensagem { get; set; }
    }
}
