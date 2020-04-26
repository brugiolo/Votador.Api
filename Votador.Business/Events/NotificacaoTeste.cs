using MediatR;

namespace Votador.Business.Configuration
{
    public class NotificacaoTeste : INotification
    {
        public string Mensagem { get; private set; }

        public NotificacaoTeste(string mensagem)
        {
            Mensagem = mensagem;
        }
    }
}