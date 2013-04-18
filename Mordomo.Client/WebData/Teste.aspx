<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Teste.aspx.cs" Inherits="Mordomo.Client.WebData.Teste" %>
<%@ Register TagPrefix="asp" Namespace="Mordomo.Client.Controls" Assembly="Mordomo.Client" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></ajaxToolkit:ToolkitScriptManager>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <label>
                        <span class="pro_text-form fleft">Estado:</span>
                        <asp:NoValidationDropDownList ID="ddlState" runat="server">
                        </asp:NoValidationDropDownList>
                    </label>
                    <label>
                        <span class="pro_text-form fleft">Cidade:</span>
                        <asp:NoValidationDropDownList ID="ddlCity" runat="server">
                        </asp:NoValidationDropDownList>
                    </label>


                    <ajaxToolkit:CascadingDropDown ID="CascadingDropDown1" runat="server"
                        TargetControlID="ddlState" ServiceMethod="GetStates" ServicePath="~/WebService/LoadFormData.asmx"
                        Category="State">
                    </ajaxToolkit:CascadingDropDown>

                    <ajaxToolkit:CascadingDropDown ID="CascadingDropDown2" runat="server"
                        TargetControlID="ddlCity" ServiceMethod="GetCities" ServicePath="~/WebService/LoadFormData.asmx"
                        Category="City" ParentControlID="ddlState">
                    </ajaxToolkit:CascadingDropDown>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
