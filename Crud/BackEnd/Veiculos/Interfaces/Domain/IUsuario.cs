using System;
using System.Collections.Generic;
using System.Text;

namespace MyHome.Interfaces.Domain
{
    public interface IUsuario : IBaseDomain
    {
        string Nome { get; set; }
        string Imagem { get; set; }
        string Email { get; set; }
        string Senha { get; set; }
        string FacebookId { get; set; }
        string GoogleId { get; set; }
        string Token { get; set; }
        bool PossuiSenha { get; }
        string Perfil { get; set; }
        int? CodigoVerificacao { get; set; }
        DateTime? DataConfirmacao { get; set; }
        int? CodigoAlteracaoSenha { get; set; }
        DateTime? ValidadeCodigo { get; set; }
    }
}
