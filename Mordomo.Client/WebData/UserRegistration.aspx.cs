﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mordomo.Client.WebData
{
    public partial class UserRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["activePageName"] = "Cadastro";

            if (!IsPostBack)
            {
                
            }
        }

        protected void lnkPhysicalPerson_Click(object sender, EventArgs e)
        {
            
        }

        protected void lnkLegalPerson_Click(object sender, EventArgs e)
        {
            
        }

        private void ChangePersonFormVisibility(Panel personTypePanel)
        {
            
        }
    }
}