<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLogSemAnuncio.master" AutoEventWireup="true" CodeFile="Fele_Conosco_Chat.aspx.cs" Inherits="Fele_Conosco_Chat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:Timer ID="Timer1" runat="server" Interval="10000" OnTick="Timer1_Tick"></asp:Timer>
    <style>
        .jumbotron{
            background-color:white;
        }
        .Alinhamento{
            padding-left: 80px;
            padding-right: -1000px;
        }
        .container{max-width:800px; margin-left:-20px;}
        img{ max-width:100%;}
        .inbox_people {
          background: #f8f8f8 none repeat scroll 0 0;
          float: left;
          overflow: hidden;
          width: 40%; border-right:1px solid #c4c4c4;
        }
        .inbox_msg {
          border: 1px solid #c4c4c4;
          clear: both;
          overflow: hidden;
        }
        .top_spac{ margin: 20px 0 0;}


        .recent_heading {float: left; width:40%;}
        .srch_bar {
          display: inline-block;
          text-align: right;
          width: 60%; padding:
        }
        .headind_srch{ padding:10px 29px 10px 20px; overflow:hidden; border-bottom:1px solid #c4c4c4;}

        .recent_heading h4 {
          color: #05728f;
          font-size: 21px;
          margin: auto;
        }
        .srch_bar input{ border:1px solid #cdcdcd; border-width:0 0 1px 0; width:80%; padding:2px 0 4px 6px; background:none;}
        .srch_bar .input-group-addon button {
          background: rgba(0, 0, 0, 0) none repeat scroll 0 0;
          border: medium none;
          padding: 0;
          color: #707070;
          font-size: 18px;
        }
        .srch_bar .input-group-addon { margin: 0 0 0 -27px;}

        .chat_ib h5{ font-size:15px; color:#464646; margin:0 0 8px 0;}
        .chat_ib h5 span{ font-size:13px; float:right;}
        .chat_ib p{ font-size:14px; color:#989898; margin:auto}
        .chat_img {
          float: left;
          width: 11%;
        }
        .chat_ib {
          float: left;
          padding: 0 0 0 15px;
          width: 88%;
        }

        .chat_people{ overflow:hidden; clear:both;}
        .chat_list {
          border-bottom: 1px solid #c4c4c4;
          margin: 0;
          padding: 18px 16px 10px;
        }
        .inbox_chat { height: 550px; overflow-y: scroll;}

        .active_chat{ background:#ebebeb;}

        .incoming_msg_img {
          display: inline-block;
          width: 6%;
        }
        .received_msg {
          display: inline-block;
          padding: 0 0 0 10px;
          vertical-align: top;
          width: 92%;
         }
         .received_withd_msg p {
          background: #ebebeb none repeat scroll 0 0;
          border-radius: 3px;
          color: #646464;
          font-size: 14px;
          margin: 0;
          padding: 5px 10px 5px 12px;
          width: 100%;
        }
        .time_date {
          color: #747474;
          display: block;
          font-size: 12px;
          margin: 8px 0 0;
        }
        .received_withd_msg { width: 57%;}
        .mesgs {
          float: left;
          padding: 30px 15px 0 25px;
          width: 100%;
        }

         .sent_msg p {
          background: #28a746 none repeat scroll 0 0;
          border-radius: 3px;
          font-size: 14px;
          margin: 0; color:#fff;
          padding: 5px 10px 5px 12px;
          width:100%;
        }
        .outgoing_msg{ overflow:hidden; margin:26px 0 26px;}
        .sent_msg {
          float: right;
          width: 46%;
        }
        .input_msg_write input {
          background: rgba(0, 0, 0, 0) none repeat scroll 0 0;
          border: medium none;
          color: #4c4c4c;
          font-size: 15px;
          min-height: 48px;
          width: 100%;
        }

        .type_msg {border-top: 1px solid #c4c4c4;position: relative;}
        .messaging { padding: 0 0 500px 0;}
        .msg_history {
          height: 517px;
          overflow-y: auto;
        }
    </style>
    <div  class="jumbotron">
        <div class="container">
            <h1 class="jumbotron-heading">Fale-Conosco:</h1>
        </div>
    </div>
    <div class="Alinhamento">
        <asp:TextBox ID="txtMensagem" runat="server" Placeholder="Digite Aqui Sua Mensagem" Width="663px" OnTextChanged="txtMensagem_TextChanged"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnEnviar" runat="server" Text="Enviar" CssClass="btn btn-outline-success" OnClick="btnEnviar_Click"/><br />
        <br />
        <div class="container">
            <div class="messaging">
                <div class="inbox_msg">
                    <div class="mesgs">
                    <div class="msg_history" id="conversa" runat="server">
                    </div>
                    </div>
                </div>
            </div>
        </div>
    </div> 
</asp:Content>

