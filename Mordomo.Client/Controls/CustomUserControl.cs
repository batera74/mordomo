using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mordomo.Client.Controls
{
    public class CustomUserControl : System.Web.UI.UserControl
    {
        public CustomUserControl()
        {
            LoadContainer();
        }

        protected UnityContainer container;

        protected void LoadContainer()
        {
            container = new UnityContainer();
            container.LoadConfiguration();
        }
    }
}