using NUnit.Framework;
using OpenQA.Selenium;
using Take.Bases;

namespace Take.Pages
{
    public class ContactPage : PageBase
    {
        #region Mapping
        readonly By nameText = By.Id("g2-name");
        readonly By emailText = By.Id("g2-email");
        readonly By commentText = By.Id("contact-form-comment-g2-comment");
        readonly By enviarButton = By.ClassName("pushbutton-wide");
        readonly By erroLabel = By.ClassName("form-error-message");
        readonly By voltarLink = By.LinkText("voltar");
        #endregion

        #region Actions
        public void preencheNome(string nome)
        {
            SendKeys(nameText, nome);
        }

        public void preencheEmail(string email)
        {
            SendKeys(emailText, email);
        }

        public void preencheComentario(string comentario)
        {
            SendKeys(commentText, comentario);
        }

        public void clicaEmEnviar()
        {
            ClickJavaScript(enviarButton);
        }

        #endregion

        #region Verifications

        public void verificaErroDeEnvio()
        {
            #region Parameter
            string message = "Email requer um endereço de email válido";
            #endregion

            Assert.AreEqual(message, GetText(erroLabel));
        }

        public void verificaEnvioComSucesso()
        {
            Assert.IsTrue(ReturnIfElementIsDisplayed(voltarLink));
        }

        #endregion
    }
}
