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
        static void Main(string[] args)
        {
            var container = new UnityContainer();
            container.LoadConfiguration();
            var userBiz = container.Resolve<Business.IUser>();

            var menuBiz = container.Resolve<Business.IMenu>();
            
            Entities.Menu menu = FakeEntities.Generator.CreateMenu();
            Entities.MenuItem menuItem = FakeEntities.Generator.CreateMenuItem(menu, true);
            Entities.MenuItem subMenuItem = menuItem.SubItems.FirstOrDefault();
            Entities.MenuItem subsubMenuItem = FakeEntities.Generator.CreateMenuItem(menu, false, subMenuItem);
            subsubMenuItem.SubItems.Add(FakeEntities.Generator.CreateMenuItem(menu, false, subsubMenuItem));
            subMenuItem.SubItems.Add(subsubMenuItem);
            Entities.MenuItem menuItem2 = FakeEntities.Generator.CreateMenuItem(menu, false);
            Entities.MenuItem menuItem3 = FakeEntities.Generator.CreateMenuItem(menu, false);
            Entities.MenuItem menuItem4 = FakeEntities.Generator.CreateMenuItem(menu, true);
            Entities.MenuItem menuItem5 = FakeEntities.Generator.CreateMenuItem(menu, false);
            
            menuBiz.Save(menu, true);      

            //Menu
            //Entities.Menu menu = new Entities.Menu() { Name = "default" };
            
            ////SubItems
            //Entities.MenuItem homeItem = new Entities.MenuItem();
            //homeItem.ItemText = "HOME";
            //homeItem.Menu = menu;
            //homeItem.Hyperlink = "default.aspx";

            //Entities.MenuItem whoItem = new Entities.MenuItem();
            //whoItem.ItemText = "O MORDOMO";
            //whoItem.Menu = menu;
            //whoItem.Hyperlink = "quemsomos.aspx";

            //Entities.MenuItem servItem = new Entities.MenuItem();
            //servItem.ItemText = "SERVIÇOS";
            //servItem.Menu = menu;
            //servItem.Hyperlink = "servicos.aspx";

            //Entities.MenuItem parcItem = new Entities.MenuItem();
            //parcItem.ItemText = "PARCEIROS.aspx";
            //parcItem.Menu = menu;
            //parcItem.Hyperlink = "parceiros.aspx";

            //Entities.MenuItem contItem = new Entities.MenuItem();
            //contItem.ItemText = "CONTATO";
            //contItem.Menu = menu;
            //contItem.Hyperlink = "contato.aspx";


            
        }
    }
}
