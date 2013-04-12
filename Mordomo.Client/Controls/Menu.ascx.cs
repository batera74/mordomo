using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mordomo.Client.Controls
{
    public partial class Menu : CustomUserControl
    {
        public string Name { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var menuBiz = base.container.Resolve<Business.IMenu>();
                
                string activePageName = Session["activePageName"].ToString();

                Entities.Menu menu = menuBiz.Query(m => m.Name.Equals(Name), "MenuItems", "MenuItems.SubItems", "MenuItems.Page").FirstOrDefault();

                if (menu != null)
                {
                    foreach (var item in menu.MenuItems.Where(x => x.ParentMenuItem == null))
                    {
                        string cssClass = "class=\"active\" ";

                        if (item.ItemText.ToLower().Equals(activePageName.ToLower()))
                            ltlMenu.Text += "<li><a " + cssClass + "href=\"" + item.Page.Link + "\">" + item.ItemText + "</a>";
                        else
                            ltlMenu.Text += "<li><a href=\"" + item.Page.Link + "\">" + item.ItemText + "</a>";

                        if (item.SubItems != null && item.SubItems.Count() > 0)
                        {
                            ltlMenu.Text += GenerateSubItems(item.SubItems);
                        }

                        ltlMenu.Text += "</li>";
                    }
                }
            }
        }

        protected string GenerateSubItems(List<Entities.MenuItem> subItems)
        {
            string result = "<ul>";

            foreach (var subItem in subItems)
            {
                result += "<li><a href=\"more.html\">" + subItem.ItemText + "</a>";

                if (subItem.SubItems != null && subItem.SubItems.Count() > 0)
                    result += GenerateSubItems(subItem.SubItems);

                result += "</li>";
            }

            result += "</ul>";

            return result;
        }
    }
}