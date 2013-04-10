<%@ Page Title="" Language="C#" MasterPageFile="~/master/Default.Master" AutoEventWireup="true" CodeBehind="CadastroUsuario.aspx.cs" Inherits="Mordomo.Client.Dados.CadastroUsuario" %>

<%@ Register TagPrefix="uc" TagName="BreadCrumb" Src="~/Controls/BreadCrumb.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script type="text/javascript">
        function pageLoad(sender, args) {
            fixJqForm('.pro_form', args.get_isPartialLoad());
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <section id="content">
        <div class="main">
            <h2>Contratando seu mordomo</h2>
            <br />
            <uc:BreadCrumb ID="breadCrumb" runat="server" />
            <div class="line"></div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" class="mg-bt">
                <ContentTemplate>
                    <asp:Panel CssClass="grid_9" runat="server" ID="pnlPerson">
                        <div class="grid_3 pro_curved-hz-2">
                            <div class="pro_text-shadow">
                                <asp:LinkButton ID="lnkPhysicalPerson" runat="server" OnClick="lnkPhysicalPerson_Click">Sou Pessoa Física</asp:LinkButton>
                            </div>
                        </div>
                        <div class="grid_3 pro_curved-hz-2">
                            <div class="pro_text-shadow">
                                <asp:LinkButton ID="lnkLegalPerson" runat="server" OnClick="lnkLegalPerson_Click">Sou Pessoa Jurídica</asp:LinkButton>
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel runat="server" ID="pnlForm" CssClass="userData">
                        <asp:Panel ID="pnlPhysicalPerson" runat="server" Visible="false">
                            <div id="pro_form_physical" class="pro_form">
                                <h3>Dados Básicos</h3>
                                <label>
                                    <span class="pro_text-form">Nome:</span>
                                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                                </label>
                                <label>
                                    <span class="pro_text-form">Sobrenome:</span>
                                    <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
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
                                </label>
                                <label>
                                    <span class="pro_text-form">Sexo:</span>
                                    <div class="d-in-block">
                                        <input id="Radio1" type="radio" name="group1" runat="server"><div class="pro_text-form2 fleft">Masculino</div>
                                    </div>
                                    <div class="d-in-block">
                                        <input id="Radio2" type="radio" name="group1" runat="server"><div class="pro_text-form2 fleft">Feminino</div>
                                    </div>
                                </label>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="pnlLegalPerson" runat="server" Visible="false">
                            <div id="pro_form_legal" class="pro_form">
                                <h3>Dados Básicos</h3>
                                <label>
                                    <span class="pro_text-form">Nome Fantasia:</span>
                                    <asp:TextBox ID="txtFancyName" runat="server"></asp:TextBox>
                                </label>
                                <label>
                                    <span class="pro_text-form">Razão Social:</span>
                                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                                </label>
                                <label>
                                    <span class="pro_text-form">CNPJ:</span>
                                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                                </label>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="pnlCommonData" runat="server">
                            <div id="pro_form_common" class="pro_form" visible="false">
                                <label>
                                    <span class="pro_text-form">Telefone:</span>
                                    <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                                </label>

                                <label>
                                    <span class="pro_text-form">Celular:</span>
                                    <asp:TextBox ID="txtMobilePhone" runat="server"></asp:TextBox>
                                </label>

                                <br />
                                <h3>Dados de Acesso</h3>

                                <label>
                                    <span class="pro_text-form">E-mail:</span>
                                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
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
                                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                </label>
                                <label>
                                    <span class="pro_text-form">Complemento:</span>
                                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                </label>
                                <label>
                                    <span class="pro_text-form">CEP:</span>
                                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                </label>
                                <label>
                                    <span class="pro_text-form fleft">Estado:</span>
                                    <asp:DropDownList ID="DropDownList1" runat="server">
                                        <asp:ListItem>São Paulo</asp:ListItem>
                                        <asp:ListItem>Rio de Janeiro</asp:ListItem>
                                    </asp:DropDownList>
                                </label>
                                <label>
                                    <span class="pro_text-form fleft">Cidade:</span>
                                    <asp:DropDownList ID="ddlCity" runat="server">
                                        <asp:ListItem>São Paulo</asp:ListItem>
                                        <asp:ListItem>Rio de Janeiro</asp:ListItem>
                                    </asp:DropDownList>
                                </label>
                                <label>
                                    <span class="pro_text-form fleft">Tipo de Endereço:</span>
                                    <asp:DropDownList ID="ddlAndressType" runat="server">
                                        <asp:ListItem>Comercial</asp:ListItem>
                                        <asp:ListItem>Residencial</asp:ListItem>
                                    </asp:DropDownList>
                                </label>
                                <div class="pro_wrapper">
                                    <input type="checkbox"><div class="pro_text-form3 fleft">Aceito receber e-mails com os detaques e novidade do site.</div>
                                </div>
                                <br />
                                <div class="grid_5 alignright">
                                    <asp:Button ID="Button1" runat="server" CssClass="pro_btn pro_medium" Text="Enviar" />
                                    <asp:Button ID="Button2" runat="server" CssClass="pro_btn pro_medium" Text="Limpar" />
                                </div>
                            </div>
                        </asp:Panel>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </section>
</asp:Content>
