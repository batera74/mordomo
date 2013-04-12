<%@ Page Title="" Language="C#" MasterPageFile="~/master/Default.Master" AutoEventWireup="true" CodeBehind="UserRegistration.aspx.cs" Inherits="Mordomo.Client.WebData.UserRegistration" %>

<%@ Register TagPrefix="uc" TagName="BreadCrumb" Src="~/Controls/BreadCrumb.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script type="text/javascript">

        $(function () {
            changeControlVisibility("pnlForm", "hide");
            $('#changePerson').click(function () { changePerson(); return false; });
        });


        function showForm(personType) {
            fixJqForm('.pro_form', true);
            changeControlVisibility("pnlPerson", "hide");
            changeControlVisibility("pnlForm", "show");

            if (personType == "legal") {
                changeControlVisibility("pnlPhysicalPerson", "hide");
                changeControlVisibility("pnlLegalPerson", "show");
            }
            else if (personType == "physical") {
                changeControlVisibility("pnlLegalPerson", "hide");
                changeControlVisibility("pnlPhysicalPerson", "show");
            }

            $('#hdnPersonType').val(personType);
            return false;
        }

        function changePerson() {
            changeControlVisibility("pnlPerson", "show");
            changeControlVisibility("pnlForm", "hide");
        }

        function InitializeValidation() {
            var validator = $("#pnlForm").bind("invalid-form.validate", function () { }).validate({
                errorElement: "em",
                errorPlacement: function (error, element) {
                    error.appendTo(element.parent("td").next("td"));
                },
                success: function (label) {
                    label.text("ok!").addClass("success");
                }
            });
        }

    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <asp:HiddenField ID="hdnPersonType" runat="server" />
    <div class="container_12">
        <section id="content">
            <div class="main">
                <h2>Contratando seu mordomo</h2>
                <br />
                <uc:BreadCrumb ID="breadCrumb" runat="server" Name="Cadastro" />
                <div class="line"></div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" class="mg-bt">
                    <ContentTemplate>
                        <div class="grid_9" id="pnlPerson">
                            <div class="grid_3 pro_curved-hz-2">
                                <div class="pro_text-shadow">
                                    <asp:LinkButton ID="lnkPhysicalPerson" runat="server" OnClientClick="return showForm('physical');">Sou Pessoa Física</asp:LinkButton>
                                </div>
                            </div>
                            <div class="grid_3 pro_curved-hz-2">
                                <div class="pro_text-shadow">
                                    <asp:LinkButton ID="lnkLegalPerson" runat="server" OnClientClick="return showForm('legal');">Sou Pessoa Jurídica</asp:LinkButton>
                                </div>
                            </div>
                        </div>

                        <div id="pnlForm" class="userData pro_form invisible">

                            <div><a id="changePerson" class="pro_btn pro_person"><span></span>Alterar Tipo de Pessoa</a></div>
                            <br />
                            <br />

                            <div id="pnlPhysicalPerson" class="invisible">
                                <div id="pro_form_physical" class="pro_form">
                                    <h3>Dados Básicos</h3>
                                    <label class="name">
                                        <span class="pro_text-form">Nome:</span>
                                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                                        <div class="d-in-block">
                                        </div>
                                    </label>
                                    <label class="name">
                                        <span class="pro_text-form">Sobrenome:</span>
                                        <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                                        <div class="d-in-block">
                                        </div>
                                    </label>
                                    <label>
                                        <span class="pro_text-form">Data de Nascimento:</span>
                                        <asp:TextBox ID="txtBirthDateDay" runat="server" Width="20px"></asp:TextBox>
                                        <asp:TextBox ID="txtBirthDateDayMonth" runat="server" Width="20px"></asp:TextBox>
                                        <asp:TextBox ID="txtBirthDateDayYear" runat="server" Width="50px"></asp:TextBox>
                                    </label>
                                    <label>
                                        <span class="pro_text-form">CPF:</span>
                                        <asp:TextBox ID="txtCPF" runat="server"></asp:TextBox>
                                        <div class="d-in-block">
                                        </div>
                                    </label>
                                    <label>
                                        <span class="pro_text-form">Sexo:</span>
                                        <div class="d-in-block">
                                            <input id="Radio1" type="radio" name="group1" runat="server"><div class="pro_text-form2 fleft">Masculino</div>
                                        </div>
                                        <div class="d-in-block">
                                            <input id="Radio2" type="radio" name="group1" runat="server"><div class="pro_text-form2 fleft">Feminino</div>
                                        </div>
                                        <div class="d-in-block">
                                        </div>
                                    </label>
                                </div>

                            </div>

                            <div id="pnlLegalPerson" class="invisible">
                                <div id="pro_form_legal" class="pro_form">
                                    <h3>Dados Básicos</h3>
                                    <label>
                                        <span class="pro_text-form">Nome Fantasia:</span>
                                        <asp:TextBox ID="txtFancyName" runat="server"></asp:TextBox>
                                        <div class="d-in-block">
                                        </div>
                                    </label>
                                    <label>
                                        <span class="pro_text-form">Razão Social:</span>
                                        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                                        <div class="d-in-block">
                                        </div>
                                    </label>
                                    <label>
                                        <span class="pro_text-form">CNPJ:</span>
                                        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                                        <div class="d-in-block">
                                        </div>
                                    </label>
                                </div>
                            </div>

                            <div id="pnlCommonData">
                                <div id="pro_form_common" class="pro_form" visible="false">
                                    <label>
                                        <span class="pro_text-form">Telefone:</span>
                                        <asp:TextBox ID="txtPhoneAreaCode" runat="server" Width="20px"></asp:TextBox>
                                        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                                        <div class="d-in-block">
                                        </div>
                                    </label>

                                    <label>
                                        <span class="pro_text-form">Celular:</span>
                                        <asp:TextBox ID="txtMobilePhoneAreaCode" runat="server" Width="20px"></asp:TextBox>
                                        <asp:TextBox ID="txtMobilePhone" runat="server"></asp:TextBox>
                                        <div class="d-in-block">
                                        </div>
                                    </label>

                                    <br />
                                    <h3>Dados de Acesso</h3>

                                    <label>
                                        <span class="pro_text-form">E-mail:</span>
                                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                                        <div class="d-in-block">
                                        </div>

                                    </label>
                                    <label>
                                        <span class="pro_text-form">Login:</span>
                                        <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox>
                                    </label>
                                    <label>
                                        <span class="pro_text-form">Senha:</span>
                                        <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                                    </label>

                                    <br />
                                    <h3>Dados de Entrega e Cobrança</h3>

                                    <label>
                                        <span class="pro_text-form">Endereço:</span>
                                        <asp:TextBox ID="txtAndress" runat="server"></asp:TextBox>
                                    </label>
                                    <label>
                                        <span class="pro_text-form">Número:</span>
                                        <asp:TextBox ID="txtNumber" runat="server"></asp:TextBox>
                                    </label>
                                    <label>
                                        <span class="pro_text-form">Complemento:</span>
                                        <asp:TextBox ID="txtComplement" runat="server"></asp:TextBox>
                                    </label>
                                    <label>
                                        <span class="pro_text-form">CEP:</span>
                                        <asp:TextBox ID="txtPostalCode" runat="server"></asp:TextBox>
                                    </label>
                                    <label>
                                        <span class="pro_text-form fleft">Estado:</span>
                                        <ajaxToolkit:CascadingDropDown ID="cc1" runat="server" PromptText="UF..." PromptValue="0"
                                            ServicePath="/WebService/CascadingDropDown.asmx" ServiceMethod="GetStates"
                                            TargetControlID="ddlState" Category="State"/>
                                        </ajaxToolkit:CascadingDropDown>        
                                        <asp:DropDownList ID="ddlState" Style="height: 50px;" runat="server">
                                        </asp:DropDownList>                                
                                    </label>
                                    <label>
                                        <span class="pro_text-form fleft">Cidade:</span>
                                        <ajaxToolkit:CascadingDropDown ID="cc2" runat="server" PromptText="Cidade..." PromptValue="0"
                                            ServicePath="/WebService/CascadingDropDown.asmx" ServiceMethod="GetCities"
                                            TargetControlID="ddlCity" Category="City" ParentControlID="State"/>
                                        </ajaxToolkit:CascadingDropDown>    
                                        <asp:DropDownList ID="ddlCity" runat="server">
                                        </asp:DropDownList>
                                    </label>
                                    <label>
                                        <span class="pro_text-form fleft">Tipo de Endereço:</span>
                                        <asp:DropDownList ID="ddlAndressType" runat="server">
                                        </asp:DropDownList>
                                    </label>
                                </div>
                            </div>

                            <div class="pro_wrapper">
                                <input type="checkbox"><div class="pro_text-form3 fleft">Aceito receber e-mails com os detaques e novidade do site.</div>
                            </div>

                            <div class="grid_5 alignright">
                                <div class="pro_buttons">
                                    <span><a class="pro_btn pro_medium" data-type="reset">Limpar</a></span>
                                    <span>
                                        <asp:LinkButton CssClass="pro_btn pro_medium" data-type="submit" ID="lnkEnviar" runat="server">Enviar</asp:LinkButton>
                                    </span>
                                </div>
                            </div>
                            <br />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </section>
    </div>
</asp:Content>
