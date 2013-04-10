using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mordomo.Client.Dados
{
    public partial class CadastroUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["activePageName"] = "cadastroUsuario";

            if (!IsPostBack)
            {
                this.pnlForm.Visible = false;
            }
        }

        protected void lnkPhysicalPerson_Click(object sender, EventArgs e)
        {
            ChangePersonFormVisibility(pnlPhysicalPerson);
        }

        protected void lnkLegalPerson_Click(object sender, EventArgs e)
        {
            ChangePersonFormVisibility(pnlLegalPerson);
        }

        private void ChangePersonFormVisibility(Panel personTypePanel)
        {
            pnlPerson.Visible = false;
            pnlForm.Visible = true;
            personTypePanel.Visible = true;
        }
    }
}