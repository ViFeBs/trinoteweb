using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Adicionar_Amigo : System.Web.UI.Page
{
    int IdAmigo;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void BuscaAmigo()
    {
        Conexao c = new Conexao();
        c.conectar();
        c.command.CommandText = "select nomeUsuario,foto,idUsuario from Usuario where idUsuario != @cod and nomeUsuario LIKE '%"+txtBusca.Text+"%'";
        c.command.Parameters.Add("@cod", SqlDbType.Int).Value = (int)Session["codigoUsuario"];
        SqlDataAdapter dAdapter = new SqlDataAdapter();
        DataSet dt = new DataSet();
        dAdapter.SelectCommand = c.command;
        dAdapter.Fill(dt);
        int qtde = dt.Tables[0].DefaultView.Count;
        for (int i = 0; i < qtde; i++)
        {
            //---------------------------------------------------------------
            if (dt.Tables[0].DefaultView[i].Row["foto"] == DBNull.Value)
            {
                string strBase64 = "Images/Profile_Default.png";
                //---------------------------------------------------------------
                string nome = dt.Tables[0].DefaultView[i].Row["nomeUsuario"].ToString();
                IdAmigo = (int)dt.Tables[0].DefaultView[i].Row["idUsuario"];
                //---------------------------------------------------------------
                lstAmigos.InnerHtml += "<div class='card'>"+
                                            "<style>"+
                                                ".card-img-top{"+
                                                "width ='100%'; height: 225;"+
                                             "</style>"+
                                             "<img src='data:Images/jpg;base64," + strBase64 + "'class='card-img-top'/>"+
                                             "<div class='card-body'>"+
                                                "<h1 class='card-title'>" + nome + "</h1><br />"+
                                                "<p class='card-text'> descricao </p><br />"+
                                                "<a href = 'Perfil_Amigo.aspx?id=" + IdAmigo + "' class='btn btn-primary'>Ver Perfil</a>" +
                                             "</div>"+
                                        "</div>";
            }
            else
            {
                byte[] imgBytes = (byte[])dt.Tables[0].DefaultView[i].Row["foto"];
                string strBase64 = Convert.ToBase64String(imgBytes);
                //---------------------------------------------------------------
                string nome = dt.Tables[0].DefaultView[i].Row["nomeUsuario"].ToString();
                IdAmigo = (int)dt.Tables[0].DefaultView[i].Row["idUsuario"];
                //---------------------------------------------------------------
                lstAmigos.InnerHtml += "<div class='card'>" +
                                            "<style>" +
                                                ".card-img-top{" +
                                                "width ='100%'; height: 225;" +
                                             "</style>" +
                                             "<img src='data:Images/jpg;base64," + strBase64 + "'class='card-img-top'/>" +
                                             "<div class='card-body'>" +
                                                "<h1 class='card-title'>" + nome + "</h1><br />" +
                                                "<p class='card-text'> descricao </p><br />" +
                                                "<a href = 'Perfil_Amigo.aspx?id=" + IdAmigo + "' class='btn btn-primary'>Ver Perfil</a>" +
                                             "</div>" +
                                        "</div>";
            }
        }
    }

    protected void btnBusca_Click(object sender, EventArgs e)
    {
        BuscaAmigo();
    }
}