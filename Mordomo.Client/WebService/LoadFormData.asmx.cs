using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using AjaxControlToolkit;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Collections.Specialized;
using Mordomo.Entities;

namespace Mordomo.Client.WebService
{
    [ScriptService]
    public class LoadFormData : System.Web.Services.WebService
    {
        [WebMethod]
        public CascadingDropDownNameValue[] GetStates(string knownCategoryValues, string category)
        {
            var container = new UnityContainer();
            container.LoadConfiguration();

            var stateBiz = container.Resolve<Business.IState>();
            var states = stateBiz.GetAll();

            var values = new List<CascadingDropDownNameValue>();

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

            StringDictionary ddlStateData = AjaxControlToolkit.CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
            int state = Convert.ToInt32(ddlStateData["State"]);

            if (state > 0)
            {
                var cityBiz = container.Resolve<Business.ICity>();
                var cities = cityBiz.Query(c => c.State.Id == state, "State");

                List<CascadingDropDownNameValue> values = new List<CascadingDropDownNameValue>();

                foreach (var item in cities)
                {
                    values.Add(new CascadingDropDownNameValue(item.Name, item.Id.ToString()));
                }

                return values.ToArray();
            }

            return new CascadingDropDownNameValue[0];
        }

        [WebMethod]
        public List<DropDownData> GetStates2(string promptText)
        {
            var container = new UnityContainer();
            container.LoadConfiguration();

            var stateBiz = container.Resolve<Business.IState>();
            var states = stateBiz.GetAll();

            var result = new List<DropDownData>();
            result.Add(new DropDownData(0, promptText));

            foreach(var item in states)
                result.Add(new DropDownData(item.Id, item.Name));

            return result;
        }

        [WebMethod]
        public List<DropDownData> GetCities2(int stateId, string promptText)
        {
            var container = new UnityContainer();
            container.LoadConfiguration();

            var result = new List<DropDownData>();
            result.Add(new DropDownData(0, promptText));

            if (stateId > 0)
            {
                var cityBiz = container.Resolve<Business.ICity>();
                var cities = cityBiz.Query(c => c.State.Id == stateId, "State");


                foreach (var item in cities)
                    result.Add(new DropDownData(item.Id, item.Name));
            }

            return result;
        }

        [WebMethod]
        public List<DropDownData> GetAndressTypes(string promptText)
        {
            var container = new UnityContainer();
            container.LoadConfiguration();

            var andressTypeBiz = container.Resolve<Business.IAndressType>();
            var andressTypes = andressTypeBiz.GetAll();

            var result = new List<DropDownData>();
            result.Add(new DropDownData(0, promptText));

            foreach (var item in andressTypes)
                result.Add(new DropDownData(item.Id, item.Name));

            return result;
        }        
    }
}
