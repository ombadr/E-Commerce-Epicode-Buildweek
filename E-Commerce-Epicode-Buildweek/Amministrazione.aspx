<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/BaseTemplate.Master" AutoEventWireup="true" CodeBehind="Amministrazione.aspx.cs" Inherits="E_Commerce_Epicode_Buildweek.Amministrazione" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="Amministrazione.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="m-5 fs-1 fw-bold">Amministrazione</div>
            <div class="row">
                 <div class="col fs-6">IMMAGINE</div>
                 <div class="col fs-6">NOME</div>
                 <div class="col fs-6">DESCRIZIONE</div>
                 <div class="col fs-6">DETTAGLIO</div>
                 <div class="col fs-6">PREZZO</div>
                 <div class="col"></div>
            </div>
    <asp:Repeater ID="RepeaterBackoffice" runat="server">
        <ItemTemplate>
            <div class="row m-3">
                <div class="d-flex">
                    <div class="col imgCard">
                        <img style="width: 160px; height: 180px;" src="<%# Eval("Immagine") %>" />
                    </div>
                    <div class="col">
                        <div style="height: 210px;" id="Nametxt" class="form-control">
                            <%# Eval("Nome") %>
                        </div>
                    </div>
                    <div class="col">
                        <div style="height: 210px;" id="Desctxt" class="form-control" style="word-wrap: break-word;">
                            <%# Eval("Descrizione") %>
                        </div>
                    </div>
                    <div class="col">
                        <div style="height: 210px;" id="Detailstxt" class="form-control" style="word-wrap: break-word;">
                            <%# Eval("Dettagli") %>
                        </div>
                    </div>
                    <div class="col">
                        <div style="height: 210px;" id="Pricetxt" class="form-control">
                            <%# Eval("Prezzo")+"€" %>
                        </div>
                    </div>

                    <div class="col">
                        <asp:Button ID="Mod" runat="server" Text="Modifica" UseSubmitBehavior="false" CommandName="Mod" CssClass="btnGlowLab" CommandArgument='<%# Eval("Id") %>' OnClick="Mod_Click" />
                        <asp:Button ID="DelBtn" runat="server" Text="Rimuovi" UseSubmitBehavior="false" CommandName="Delete" CssClass="btnGlowLab" CommandArgument='<%# Eval("Id") %>' OnClick="DelBtn_Click" />
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
