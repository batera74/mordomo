using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using AjaxControlToolkit;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace Mordomo.Client.WebService
{
    [ScriptService]
    public class CascadingDropDown : System.Web.Services.WebService
    {
        [WebMethod]
        public CascadingDropDownNameValue[] GetStates(string knownCategoryValues, string category)
        {
            var container = new UnityContainer();
            container.LoadConfiguration();

            var stateBiz = container.Resolve<Business.IState>();
            var states = stateBiz.GetAll();

            List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

            foreach (var item in states)
            {
                values.Add(new CascadingDropDownNameValue(item.Acronym, item.Id.ToString()));
            }

            return values.ToArray();
        }

        [WebMethod]
        public CascadingDropDownNameValue[] GetCities(string knownCategoryValues, string category)
        {
            var container = new UnityContainer();
            container.LoadConfiguration();

            var cityBiz = container.Resolve<Business.ICity>();
            var cities = cityBiz.GetAll();

            List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

            foreach (var item in cities)
            {
                values.Add(new CascadingDropDownNameValue(item.Name, item.Id.ToString()));
            }

            return values.ToArray();
        }
    }
}
