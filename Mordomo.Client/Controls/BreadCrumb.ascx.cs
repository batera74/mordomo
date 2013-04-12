using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.Unity;

namespace Mordomo.Client.Controls
{
    public partial class BreadCrumb : CustomUserControl
    {
        public string Name { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var breadcrumbBiz = base.container.Resolve<Business.IBreadcrumb>();

                string activePageName = Session["activePageName"].ToString();

                var bread = breadcrumbBiz.Query(b => b.Name.Equals(activePageName), "BreadcrumbItems", "BreadcrumbItems.Page")
                    .FirstOrDefault();

                if (bread != null)
                {
                    int actualOrder = bread.BreadcrumbItems.FirstOrDefault(b => b.Page.Name.Equals(activePageName)).Order;

                    foreach (var item in bread.BreadcrumbItems.OrderBy(b => b.Order))
                    {
                        if (item.Order == actualOrder)
                        {
                            lblBreadcrumb.Text += "<li><a class=\"current\">" + item.Page.Name + "</a>";
                        }
                        else
                        {
                            if(item.Order < actualOrder)
                                lblBreadcrumb.Text += "<li><a href=\"" + item.Page.Link + "\">" + item.Page.Name + "</a>";
                            else
                                lblBreadcrumb.Text += "<li><a class=\"after\">" + item.Page.Name + "</a>";
                        }
                    }
                }
            }
        }
    }
}