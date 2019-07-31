using Take.Pages;

namespace Take.Flows
{
    public class ContactFlows
    {
        #region Page Object and Constructor
        ContactPage contactPage;
        InicialPage inicialPage;
        public ContactFlows()
        {
            contactPage = new ContactPage();
            inicialPage = new InicialPage();
        }
        #endregion

        public void EnviaContatoComSucesso(string nome, string email, string comentario)
        {
            inicialPage.acessaOMenu();
            inicialPage.abreFormDeContato();
            contactPage.preencheNome(nome);
            contactPage.preencheEmail(email);
            contactPage.preencheComentario(comentario);
            contactPage.clicaEmEnviar();
            contactPage.verificaEnvioComSucesso();
        }

        public void EnviaContatoComErro(string nome, string email, string comentario)
        {
            inicialPage.acessaOMenu();
            inicialPage.abreFormDeContato();
            contactPage.preencheNome(nome);
            contactPage.preencheEmail(email);
            contactPage.preencheComentario(comentario);
            contactPage.clicaEmEnviar();
            contactPage.verificaErroDeEnvio();
        }
    }
}
