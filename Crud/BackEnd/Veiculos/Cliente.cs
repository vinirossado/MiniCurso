using MyHome.Helpers;
using MyHome.Interfaces.Domain;
using MyHome.Security;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace MyHome
{
    public class Cliente : BaseDomain, IUsuario
    {
        #region Properties
        private string _nome;
        public string Nome { get => _nome; set => SetNome(value); }
        private string _email;
        public string Email { get => _email; set => SetEmail(value); }
        public string FacebookId { get; set; }
        public string GoogleId { get; set; }
        public string Imagem { get; set; }
        public string Senha { get; set; }
        public string Token { get; set; }
        public string Perfil { get; set; }
        public bool PossuiSenha => !string.IsNullOrEmpty(Senha);
        public int? CodigoVerificacao { get; set; }
        public int? CodigoAlteracaoSenha { get; set; }
        public DateTime? ValidadeCodigo { get; set; }
        public DateTime? DataConfirmacao { get; set; }

        public string Cpf { get; set; }
        public string TelefoneFixo { get; set; }
        public string TelefoneMovel { get; set; }
        public string Observacao { get; set; }
        public DateTime? DataNascimento { get; set; }

        #endregion

        #region Constructors
        public Cliente() { }

        public Cliente(string nome, string email)
        {
            Nome = nome;
            Email = email;
            Perfil = Permissoes.User;
        }
        #endregion

        #region Methods
        private void SetNome(string nome, [CallerMemberName]string propertyName = null)
        {
            Validators.ValidateNullOrEmpty(nome, propertyName);
            _nome = nome;
        }

        private void SetEmail(string email, [CallerMemberName]string propertyName = null)
        {
            Validators.ValidateNullOrEmpty(email, propertyName);
            _email = email;
        }
        #endregion
    }
}
