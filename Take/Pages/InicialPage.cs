using OpenQA.Selenium;
using Take.Bases;

namespace Take.Pages
{
    public class InicialPage : PageBase
    {
        #region Mapping
        readonly By menuButton = By.Id("site-navigation");
        readonly By contatoLink = By.Id("menu-item-7");
        #endregion

        #region Actions
        public void acessaOMenu()
        {
            Click(menuButton);
        }

        public void abreFormDeContato()
        {
            Click(contatoLink);
        }
        #endregion
    }
}
