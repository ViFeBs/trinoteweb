using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Fele_Conosco_Chat : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //txtChat.Enabled = false;
        CarregaMensagem();
    }

    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        string texto = txtMensagem.Text;
        Conexao c = new Conexao();
        c.conectar();
        c.command.CommandText = "insert into Mensagem(idSolicitacao,isUsuario,txtMensagem,dataHoraMensagem) values(@cod,@isUsu,@men,@dt)";
        c.command.Parameters.Add("@cod", SqlDbType.Int).Value = Convert.ToInt32(Request.QueryString["cod"]);
        c.command.Parameters.Add("@isUsu", SqlDbType.Bit).Value = 1;
        c.command.Parameters.Add("@men", SqlDbType.VarChar).Value = txtMensagem.Text;
        c.command.Parameters.Add("@dt", SqlDbType.DateTime).Value = DateTime.Now;
        c.command.ExecuteNonQuery();
        //txtChat.Text = texto;
        CarregaMensagem();
        txtMensagem.Text = "";
        Timer1.Enabled = true;
    }

    protected void Timer1_Tick(object sender, EventArgs e)
    {
        CarregaMensagem();
    }

    public void CarregaMensagem()
    {
        Conexao c = new Conexao();
        c.conectar();
        c.command.CommandText = "select count(*) as Mensagens from Mensagem where idSolicitacao = @cod";
        c.command.Parameters.Add("@cod", SqlDbType.Int).Value = Convert.ToInt32(Request.QueryString["cod"]);
        SqlDataAdapter dAdapter = new SqlDataAdapter();
        DataSet dt = new DataSet();
        dAdapter.SelectCommand = c.command;
        dAdapter.Fill(dt);
        string mensagem = "";
        if (Convert.ToInt32(dt.Tables[0].DefaultView[0].Row["Mensagens"]) >= 1)
        {
            for (int i = 0; i < Convert.ToInt32(dt.Tables[0].DefaultView[0].Row["Mensagens"]); i++)
            {
                c.command.CommandText = "select txtMensagem,isUsuario from Mensagem where idSolicitacao = @cod";
                DataSet dt2 = new DataSet();
                dAdapter.SelectCommand = c.command;
                dAdapter.Fill(dt2);
                if (Convert.ToInt32(dt2.Tables[0].DefaultView[i].Row["isUsuario"]) == 1)
                {
                    //mensagem += "Voce:" + dt2.Tables[0].DefaultView[i].Row["txtMensagem"].ToString() + "\n";
                    mensagem += "<div class='outgoing_msg'> " +
                                  "<div class='sent_msg'> " +
                                    "<p>" + dt2.Tables[0].DefaultView[i].Row["txtMensagem"].ToString() + "</p> " +
                                  "</div> " +
                                "</div> ";

                }
                else if (Convert.ToInt32(dt2.Tables[0].DefaultView[i].Row["isUsuario"]) == 0)
                {
                    //mensagem += "Funcionario:" + dt2.Tables[0].DefaultView[i].Row["txtMensagem"].ToString() + "\n";
                    mensagem += "<div class='incoming_msg'> " +
                                  "<div class='received_msg'> " +
                                    "<div class='received_withd_msg'> " +
                                      "<p>" + dt2.Tables[0].DefaultView[i].Row["txtMensagem"].ToString() + "</p> " +
                                  "</div> " +
                                "</div> ";
                }
                //txtChat.Text = mensagem;
                conversa.InnerHtml = mensagem;
            }
        }
    }

    protected void txtMensagem_TextChanged(object sender, EventArgs e)
    {
        Timer1.Enabled = false;
    }
}