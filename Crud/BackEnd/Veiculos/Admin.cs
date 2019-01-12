
using MyHome.Helpers;
using MyHome.Interfaces.Domain;
using MyHome.Security;
using System;
using System.Runtime.CompilerServices;

namespace MyHome
{
    public class Admin : BaseDomain, IUsuario
    {
        #region Properties

        private string _nome;
        public string Nome { get => _nome; set => SetNome(value); }

        private string _email;
        public string Email { get => _email; set => SetEmail(value); }

        private string _senha;
        public string Senha { get => _senha; set => SetSenha(value); }

        public int? CodigoVerificacao { get; set; }
        public int? CodigoAlteracaoSenha { get; set; }
        public DateTime? ValidadeCodigo { get; set; }
        public DateTime? DataConfirmacao { get; set; }

        public string Imagem { get; set; }
        public string Token { get; set; }
        public string Perfil { get; set; }
        public string FacebookId { get; set; }
        public string GoogleId { get; set; }
        public bool PossuiSenha => !string.IsNullOrEmpty(Senha);
        #endregion

        #region Constructors
        public Admin() { }

        public Admin(string nome, string email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Perfil = Permissoes.Admin;
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

        private void SetSenha(string senha, [CallerMemberName]string propertyName = null)
        {
            Validators.ValidateNullOrEmpty(senha, propertyName);
            _senha = senha;
        }
        #endregion
    }
}
