<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLogSemAnuncio.master" AutoEventWireup="true" CodeFile="Solicitacoes.aspx.cs" Inherits="Solicitacoes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style>
        .jumbotron{
            color:white;
            background-color:transparent;
        }
        .Alinhamento{
            margin-left:50px;
        }
        .box{
            display:none;
        }
    </style>
    <script>
        $(function () {
            $('section#content article div.btn').click(function () {
                $(this).siblings('div.box').slideToggle();
                if ($(this).text() == "Fazer Uma Solicitação") {
                    $(this).text("Cancelar Solicitação");
                } else {
                    $(this).text("Fazer Uma Solicitação")
                }
            });
        });
    </script>
    <div  class="jumbotron">
        <div class="container">
            <h1 class="jumbotron-heading">Fale-Conosco:</h1>
        </div>
    </div>
    <section id="content" class ="Alinhamento">
        <article class="btn btn-dark">
            <div class="btn func">Fazer uma Solicitação</div>
            <div class="box">
                <div class="Alinhamento">
                    <h2>Motivo: </h2><br />
                    <asp:RadioButton ID="rdnHate" runat="server" GroupName="grpMotivo" Text="Reclamação" />
                    <asp:RadioButton ID="rdnBug" runat="server" GroupName="grpMotivo" Text="Reportar Bug" />
                    <asp:RadioButton ID="rdnOutro" runat="server" GroupName="grpMotivo" Text="Outro" /><br />
                    <br />
                    <asp:TextBox ID="txtMensagem" runat="server" Placeholder="Especifique o Motivo em poucas palavras (máximo de 50 caracteres)." Width="455px"></asp:TextBox>
                    <br />
                    <asp:Button ID="btnEnv" runat="server" Text="Enviar" OnClick="btnEnv_Click" CssClass="btn btn-success"/><br />
                    <br />
                 </div>
            </div>
        </article>
    </section><br />
    <br />
    <div class="Alinhamento">
        <asp:GridView ID="GridView1" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="idSolicitacao" HeaderText="Solicitação" />
                <asp:BoundField HeaderText="Motivo" DataField="Motivo" />
                <asp:BoundField DataField="dataHoraInicioSol" HeaderText="Data" />
                <asp:HyperLinkField HeaderText="Conversas" Text="ver/Iniciar" ControlStyle-CssClass="btn btn-success" DataNavigateUrlFields="idSolicitacao" DataNavigateUrlFormatString="Fele_Conosco_Chat.aspx?cod={0}">
                <ControlStyle CssClass="btn btn-success"></ControlStyle>
                </asp:HyperLinkField>
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="#28a745" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
    </div>
</asp:Content>

