using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mordomo.Client.WebData
{
    public partial class UserRegistration : System.Web.UI.Page
    {   private UnityContainer _container;

        protected void Page_Load(object sender, EventArgs e)
        {
            _container = new UnityContainer();
            _container.LoadConfiguration();

            Session["activePageName"] = "Cadastro";

            if (!IsPostBack)
            {
                //BindDropDownLists();
            }
        }

        protected void lnkEnviar_Click(object sender, EventArgs e)
        {
            string personType = hdnPersonType.Value;

            try
            {
                CreateUser(personType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CreateUser(string personType)
        {
            var userBiz = _container.Resolve<Business.IUser>();

            Entities.User user = new Entities.User();
            user.Andresses.Add(CreateAndress(user));
            user.Email = txtEmail.Text;
            user.Login = txtLogin.Text;
            user.Password = Infrastructure.Encrypt.HashText(txtPassword.Text);
            user.Phone = txtPhoneAreaCode.Text + txtPhone.Text;
            user.Phone = txtMobilePhoneAreaCode.Text + txtMobilePhone.Text;

            if (personType.Equals("physical"))
                user.PhysicalPerson = CreatePhysicalPerson(user);
            else
                user.LegalPerson = CreateLegalPerson(user);

            userBiz.Save(user, true);
        }

        private Entities.PhysicalPerson CreatePhysicalPerson(Entities.User user)
        {
            Entities.PhysicalPerson pp = new Entities.PhysicalPerson(user);
            pp.Name = txtName.Text;
            pp.LastName = txtLastName.Text;
            pp.BirthDate = new DateTime(Convert.ToInt32(txtBirthDateDayYear.Text),
                                        Convert.ToInt32(txtBirthDateDayMonth.Text),
                                        Convert.ToInt32(txtBirthDateDay.Text));
            pp.CPF = txtCPF.Text;
            pp.Gender = rdnMale.Checked ? "M" : "F";

            return pp;
        }

        private Entities.LegalPerson CreateLegalPerson(Entities.User user)
        {
            Entities.LegalPerson lp = new Entities.LegalPerson(user);
            lp.CorporateName = txtCorporateName.Text;
            lp.FancyName = txtFancyName.Text;
            lp.CNPJ = txtCnpj.Text;

            return lp;
        }

        private Entities.Andress CreateAndress(Entities.User user)
        {
            var cityBiz = _container.Resolve<Business.ICity>();
            var andressTypeBiz = _container.Resolve<Business.IAndressType>();

            Entities.Andress andress = new Entities.Andress(user);
            andress.AndressLine1 = txtAndress.Text;
            andress.Number = Convert.ToInt32(txtAndressNumber.Text);
            andress.Complement = txtAndressComplement.Text;
            andress.PostalCode = txtPostalCode.Text;
            andress.City = cityBiz.Query(c => c.Id == Convert.ToInt32(hdnCity.Value), "State", "State.Country").FirstOrDefault();
            andress.AndressType = andressTypeBiz.Get(Convert.ToInt32(hdnAndressType.Value));

            return andress;
        }
    }
}