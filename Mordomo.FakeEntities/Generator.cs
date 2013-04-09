using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordomo.FakeEntities
{
    public static class Generator
    {
        private static Random random = new Random((int)DateTime.Now.Ticks);

        public static Entities.CreditCardType CreateCreditCardType()
        {
            var newCreditCardType = new Entities.CreditCardType();
            newCreditCardType.Name = "MASTER";
            return newCreditCardType;
        }

        public static Entities.CreditCard CreateCreditCard(Entities.CreditCardType creditCardType, Entities.User user)
        {
            var creditCardNew = new Entities.CreditCard();
            creditCardNew.ExpirationYear = new Random().Next(2013, 2020);
            creditCardNew.SecurityCode = CreateRandomStringNumber(3);
            creditCardNew.ExpirationMonth = new Random().Next(1, 12);
            creditCardNew.CreditCardNumber = CreateRandomStringNumber(16);
            creditCardNew.CreditCardType = creditCardType;
            creditCardNew.User = user;

            return creditCardNew;
        }

        public static Entities.User CreateUser()
        {
            var userNew = new Entities.User();
            userNew.Active = true;
            userNew.Email = CreateEmail();
            userNew.Login = RandomString(20, false);
            userNew.Password = RandomString(30, false);
            userNew.Phone = CreateRandomStringNumber(11);
            userNew.LastLogin = DateTime.Now;
            userNew.Verified = true;                        

            return userNew;
        }

        public static Entities.Menu CreateMenu()
        {
            var menu = new Entities.Menu();
            menu.Name = "default";

            return menu;
        }

        public static Entities.MenuItem CreateMenuItem(Entities.Menu menu, bool subItem)
        {
            return CreateMenuItem(menu, subItem, null);
        }

        public static Entities.MenuItem CreateMenuItem(Entities.Menu menu, bool subItem, Entities.MenuItem parentMenuItem)
        {
            var menuItemNew = new Entities.MenuItem();
            menuItemNew.ItemText = RandomString(8, true);
            menuItemNew.Hyperlink = RandomString(20, false) + ".aspx";
            menuItemNew.Menu = menu;
            menuItemNew.ParentMenuItem = parentMenuItem;
            menu.MenuItems.Add(menuItemNew);            

            if(subItem)
            {
                for (int i = 0; i < 3; i++)
                    menuItemNew.SubItems.Add(CreateMenuItem(menu, false, menuItemNew));
            }

            return menuItemNew;
        }

        private static string CreateEmail()
        {
            return RandomString(15, false) + "@" + RandomString(15, false) + ".com.br";
        }
                        
        private static string RandomString(int size, bool upperCase)
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            if(upperCase)
                return builder.ToString().ToUpper();
            else
                return builder.ToString().ToLower();
        }

        private static string CreateRandomStringNumber(int size)
        {
            string ret = "";

            for (int i = 0; i < size; i++)
            {
                ret += random.Next(0, 9).ToString();
            }

            return ret;
        }        
    }
}
