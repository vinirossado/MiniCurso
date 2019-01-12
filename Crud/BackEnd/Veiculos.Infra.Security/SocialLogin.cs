using System;
using System.Collections.Generic;
using System.Text;

namespace MyHome.Infra.Security
{
    public class SocialLogin
    {
        #region Properties
        private string _provider;
        public string Provider
        {
            get => _provider;
            set => SetProvider(value);
        }

        private string _id;
        public string Id
        {
            get => _id;
            set => SetId(value);
        }

        private string _perfil;
        public string Perfil
        {
            get => _perfil;
            set => SetPerfil(value);
        }

        public string Email { get; set; }
        public string Nome { get; set; }
        public string Imagem { get; set; }
        #endregion

        #region Methods  
        private void SetId(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException("Social id is required.");

            _id = id;
        }

        private void SetProvider(string provider)
        {
            if (string.IsNullOrEmpty(provider))
                throw new ArgumentNullException("Social profile is required.");

            _provider = provider;
        }

        private void SetPerfil(string roles)
        {
            if (string.IsNullOrEmpty(roles))
                throw new ArgumentNullException("Social role is required.");

            _perfil = roles;
        }
        #endregion
    }
}
