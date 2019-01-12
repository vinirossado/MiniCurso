using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyHome.Interfaces.Services
{
    public interface IEmailService
    {
        Task Enviar(string emailDestinatario, string assunto, string mensagem);
    }
}
