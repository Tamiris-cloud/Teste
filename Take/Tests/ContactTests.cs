using NUnit.Framework;
using Take.Bases;
using Take.Flows;

namespace Take.Tests
{
    public class ContactTests : TestBase
    {
        [Test]
        public void RealizaContatoComSucesso()
        {
            #region Parameters
            string nome = "Tamiris Fernandes";
            string email = "bastos.tamiris@yahoo.com.br";
            string comentario = "TAMIRIS FERNANDES testando envio de contato";
            #endregion

            ContactFlows contactFlows = new ContactFlows();
            contactFlows.EnviaContatoComSucesso(nome, email, comentario);
        }

        [Test]
        public void RealizaContatoComFalha()
        {
            #region Parameters
            string nome = "Tamiris Fernandes";
            string email = "bastos.tamiris@y";
            string comentario = "TAMIRIS FERNANDES testando envio de contato com erro";
            #endregion

            ContactFlows contactFlows = new ContactFlows();
            contactFlows.EnviaContatoComErro(nome, email, comentario);
        }
    }
}
