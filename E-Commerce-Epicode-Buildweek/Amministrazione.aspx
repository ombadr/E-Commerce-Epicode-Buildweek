<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/BaseTemplate.Master" AutoEventWireup="true" CodeBehind="Amministrazione.aspx.cs" Inherits="E_Commerce_Epicode_Buildweek.Amministrazione" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Amministrazione</h2>
       <asp:Repeater ID="RepeaterBackoffice" runat="server">
            <ItemTemplate>
                <div class="row">
                    <div class="d-flex">
                        <div class="col d-flex">
                            <img style="width: 100px; height: 120px;" src="<%# Eval("Immagine") %>" />
                            <textarea id="Nametxt" class="form-control" type="text"><%# Eval("Nome") %></textarea>
                        </div>
                        <div class="col">
                            <textarea style="height: 120px;" id="Desctxt" class="form-control" type="text" style="word-wrap: break-word;"><%# Eval("Descrizione") %></textarea>
                        </div>
                        <div class="col">
                            <textarea style="height: 120px;" id="Detailstxt" class="form-control" type="text" style="word-wrap: break-word;"><%# Eval("Dettagli") %></textarea>
                        </div>
                        <div class="col">
                            <textarea style="height: 120px;" id="Pricetxt" class="form-control" type="text"><%# Eval("Prezzo")+"€" %></textarea>
                        </div>
                        <%--<a href='<%# "Dettagli.aspx/" + Eval("Idoggetto") %>' class="btn btn-primary">Dettagli</a>--%>
                        <div class="col">
                            <asp:Button ID="Mod" runat="server" Text="Modifica" UseSubmitBehavior="false" CommandName="Mod" CommandArgument='<%# Eval("Id") %>' OnClick="Mod_Click" />
                            <asp:Button ID="DelBtn" runat="server" Text="Rimuovi" UseSubmitBehavior="false" CommandName="Delete" CommandArgument='<%# Eval("Id") %>' OnClick="DelBtn_Click" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
</asp:Content>