<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLog.master" AutoEventWireup="true" CodeFile="Visualiza_Anotacao.aspx.cs" Inherits="Visualiza_Anotacao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style>
        .items-margin{
            margin-left:50px;
        }
        /* The Modal (background) */
        .Boxshare {
          position: fixed; /* Stay in place */
          z-index: 1; /* Sit on top */
          left: 0;
          top: 0;
          width: 100%; /* Full width */
          height: 100%; /* Full height */
          overflow: auto; /* Enable scroll if needed */
          background-color: rgb(0,0,0); /* Fallback color */
          background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
        }

        /* Modal Content/Box */
        .share-content {
          background-color: #fefefe;
          margin: 15% auto; /* 15% from the top and centered */
          padding: 20px;
          border: 1px solid #888;
          width: 80%; /* Could be more or less, depending on screen size */
        }

        /* The Close Button */
        .close {
          color: #aaa;
          float: right;
          font-size: 28px;
          font-weight: bold;
        }

        .close:hover,
        .close:focus {
          color: black;
          text-decoration: none;
          cursor: pointer;
        }
    </style>
    <h1 class="text-center">Minha Anotação</h1>
    <div class="text-right">
         <asp:ImageButton ID="imgBedit" runat="server" ImageUrl="~/Images/Editar.jpg" Width="40px" Height="40px" OnClick="imgBedit_Click"/> 
         <asp:ImageButton ID="imgBdelet" runat="server" ImageUrl="~/Images/Deletar.png" Width="40px" Height="40px" OnClick="imgBdelet_Click"/>
    <asp:ImageButton ID="imgBshare" runat="server"  ImageUrl="~/Images/Compartilhar.png.jpg" Width="40px" Height="40px" OnClick="imgBshare_Click"/>
    </div>
    <div class="items-margin">
        <asp:Image ID="Image1" runat="server" Width="1000" Height="500"/><br />
        <br />
        <h1>Titulo:
            <asp:Label ID="lblTitulo" runat="server" Text=""></asp:Label>
            <asp:TextBox ID="txtTitulo" runat="server"></asp:TextBox>
        </h1><br />
        <h2>Conteudo:</h2>
        <p>
            <asp:Label ID="lblConteudo" runat="server" Text=""></asp:Label>
            <asp:TextBox ID="txtConteudo" runat="server" Height="166px" TextMode="MultiLine" Width="321px"></asp:TextBox>
        </p>
        <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="btn btn-primary" OnClick="btnSalvar_Click"/>
        <div id="myModal" class="Boxshare" runat="server">
            <div class="share-content">
                <asp:Button ID="btnclose" runat="server" Text="&times;" CssClass="close" OnClick="btnclose_Click"/>
                <div class="container mt-3">
                    <div class="media border p-3" id="lstAmigos" runat="server">

                    </div>
                </div>
            </div>
        </div>
    </diV>
</asp:Content>

