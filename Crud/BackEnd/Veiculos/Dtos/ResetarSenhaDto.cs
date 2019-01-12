using System;
using System.Collections.Generic;
using System.Text;

namespace MyHome.Dtos
{
    public class ResetarSenhaDto
    {
        public string Email { get; set; }
        public int CodigoAlteracao { get; set; }
        public string NovaSenha { get; set; }
    }
}
