﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDrive
{
    public class Usuario
    {
        #region Propriedades Públicas
        public int id { get; set; }
        public string nome { get; set; }
        public string dataNascimento { get; set; }
        public string telefone { get; set; }
        public string email { get; set; } 
        #endregion
    }

    public class ResultadoLogin
    {
        public Usuario usuario { get; set; }
    }
}
