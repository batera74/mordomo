using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mordomo.Data;
using System.Collections;
using Mordomo.Business.Repository;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace Mordomo.ConsoleTest
{
    class Program
    {
        static UnityContainer container;

        static void Main(string[] args)
        {
            container = new UnityContainer();
            container.LoadConfiguration();
            CreateMenu();
            CreateBreadcrumb();
        }

        public static void CreateMenu()
        {
            var userBiz = container.Resolve<Business.IUser>();

            var menuBiz = container.Resolve<Business.IMenu>();

            //Menu
            Entities.Menu menu = new Entities.Menu() { Name = "default" };

            //Entities.Menu menu = menuBiz.Query(m => m.Id == 1, "MenuItems").FirstOrDefault();

            //SubItems
            Entities.MenuItem homeItem = new Entities.MenuItem(menu);
            homeItem.ItemText = "HOME";
            homeItem.Menu = menu;
            homeItem.Page = new Entities.Page() { Name = "Default", Link = "Default.aspx" };

            Entities.MenuItem whoItem = new Entities.MenuItem(menu);
            whoItem.ItemText = "O MORDOMO";
            whoItem.Menu = menu;
            whoItem.Page = new Entities.Page() { Name = "Quem Somos", Link = "Who.aspx" };

            Entities.MenuItem servItem = new Entities.MenuItem(menu);
            servItem.ItemText = "SERVIÇOS";
            servItem.Menu = menu;
            servItem.Page = new Entities.Page() { Name = "Serviços", Link = "Services.aspx" };

            Entities.MenuItem parcItem = new Entities.MenuItem(menu);
            parcItem.ItemText = "PARCEIROS";
            parcItem.Menu = menu;
            parcItem.Page = new Entities.Page() { Name = "Parceiros", Link = "Partners.aspx" };

            Entities.MenuItem contItem = new Entities.MenuItem(menu);
            contItem.ItemText = "CONTATO";
            contItem.Menu = menu;
            contItem.Page = new Entities.Page() { Name = "Contato", Link = "Contact.aspx" };

            menu.MenuItems.Add(homeItem);
            menu.MenuItems.Add(whoItem);
            menu.MenuItems.Add(servItem);
            menu.MenuItems.Add(parcItem);
            menu.MenuItems.Add(contItem);

            menuBiz.Save(menu, true);
        }

        public static void CreateBreadcrumb()
        {
            var breadcrumbBiz = container.Resolve<Business.IBreadcrumb>();

            Entities.Breadcrumb breadcrumb = new Entities.Breadcrumb();
            breadcrumb.Name = "Cadastro";

            //var breadcrumb = breadcrumbBiz.Query(b => b.Id == 1, "BreadcrumbItems").First();

            Entities.BreadcrumbItem breadItem1 = new Entities.BreadcrumbItem(breadcrumb);
            Entities.BreadcrumbItem breadItem2 = new Entities.BreadcrumbItem(breadcrumb);
            Entities.BreadcrumbItem breadItem3 = new Entities.BreadcrumbItem(breadcrumb);
            Entities.BreadcrumbItem breadItem4 = new Entities.BreadcrumbItem(breadcrumb);
            breadItem1.Page = new Entities.Page() { Name = "Cadastro", Link = "UserRegistration.aspx" };
            breadItem1.Order = 1;
            breadItem2.Page = new Entities.Page() { Name = "Escolher do Plano", Link = "ChoosePlan.aspx" };
            breadItem1.Order = 2;
            breadItem3.Page = new Entities.Page() { Name = "Dados do Pagamento", Link = "PaymentData.aspx" };
            breadItem1.Order = 3;
            breadItem4.Page = new Entities.Page() { Name = "Confirmação", Link = "ConfirmRegistration.aspx" };
            breadItem1.Order = 4;

            breadcrumb.BreadcrumbItems.Add(breadItem1);
            breadcrumb.BreadcrumbItems.Add(breadItem2);
            breadcrumb.BreadcrumbItems.Add(breadItem3);
            breadcrumb.BreadcrumbItems.Add(breadItem4);

            breadcrumbBiz.Save(breadcrumb, true);
        }

        public static void QueryBreadcrumb(int id)
        {
            var breadcrumbBiz = container.Resolve<Business.IBreadcrumb>();

            var bread = breadcrumbBiz.Query(b => b.Id == id, "BreadcrumbItems").First();
            bread.BreadcrumbItems[0].Order = 1;
            bread.BreadcrumbItems[1].Order = 2;
            bread.BreadcrumbItems[3].Order = 3;
            bread.BreadcrumbItems[2].Order = 4;

            breadcrumbBiz.Save(bread, true);
        }
    }
}
