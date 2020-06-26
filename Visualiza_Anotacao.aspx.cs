using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Visualiza_Anotacao : System.Web.UI.Page
{
    int IdAmigo;
    protected void Page_Load(object sender, EventArgs e)
    {
        txtConteudo.Visible = false;
        txtTitulo.Visible = false;
        btnSalvar.Visible = false;   
        CarregaPagina();
        if (!IsPostBack)
        {
            myModal.Visible = false;
            BuscaAmigoSolicitado();
            BuscaAmigoAceito();
        }
    }
    public void CarregaPagina()
    {
        string Fonte = "";
        Conexao c = new Conexao();
        c.conectar();
        c.command.CommandText = "select titulo,conteudo,Imagem,Font from Anotacao where idAnotacao = @cod";
        c.command.Parameters.Add("@cod", SqlDbType.Int).Value = Convert.ToInt32(Request.QueryString["id"]);
        SqlDataAdapter dAdapter = new SqlDataAdapter();
        DataSet dt = new DataSet();
        dAdapter.SelectCommand = c.command;
        dAdapter.Fill(dt);
        byte[] imgBytes = (byte[])dt.Tables[0].DefaultView[0].Row["Imagem"];
        string strBase64 = Convert.ToBase64String(imgBytes);
        Image1.ImageUrl = "data:Images/jpg;base64," + strBase64;
        lblTitulo.Text = dt.Tables[0].DefaultView[0].Row["titulo"].ToString();
        lblConteudo.Text = dt.Tables[0].DefaultView[0].Row["conteudo"].ToString();
        if(dt.Tables[0].DefaultView[0].Row["Font"].ToString() == null)
        {
            Fonte = "Arial";
        }
        else
        {
            Fonte = dt.Tables[0].DefaultView[0].Row["Font"].ToString();
        }
        lblConteudo.Font.Name = Fonte;
        lblTitulo.Font.Name = Fonte;
    }
    public void CarregaEdição()
    {
        string Fonte = "";
        Conexao c = new Conexao();
        c.conectar();
        c.command.CommandText = "select titulo,conteudo,Imagem,Font from Anotacao where idAnotacao = @cod";
        c.command.Parameters.Add("@cod", SqlDbType.Int).Value = Convert.ToInt32(Request.QueryString["id"]);
        SqlDataAdapter dAdapter = new SqlDataAdapter();
        DataSet dt = new DataSet();
        dAdapter.SelectCommand = c.command;
        dAdapter.Fill(dt);
        byte[] imgBytes = (byte[])dt.Tables[0].DefaultView[0].Row["Imagem"];
        string strBase64 = Convert.ToBase64String(imgBytes);
        Image1.ImageUrl = "data:Images/jpg;base64," + strBase64;
        txtConteudo.Visible = true;
        txtTitulo.Visible = true;
        btnSalvar.Visible = true;
        txtTitulo.Text = dt.Tables[0].DefaultView[0].Row["titulo"].ToString();
        txtConteudo.Text = dt.Tables[0].DefaultView[0].Row["conteudo"].ToString();
        if (dt.Tables[0].DefaultView[0].Row["Font"].ToString() == null)
        {
            Fonte = "Arial";
        }
        else
        {
            Fonte = dt.Tables[0].DefaultView[0].Row["Font"].ToString();
        }
        txtConteudo.Font.Name = Fonte;
        txtTitulo.Font.Name = Fonte;
    }
    public void Deletar()
    {
        Conexao c = new Conexao();
        c.conectar();
        c.command.CommandText = "update Anotacao set statusAnotacao = 0 where idAnotacao = @cod";
        c.command.Parameters.Add("@cod", SqlDbType.Int).Value = Convert.ToInt32(Request.QueryString["id"]);
        c.command.ExecuteNonQuery();
    }
    public void BuscaAmigoSolicitado()
    {
        Conexao c = new Conexao();
        c.conectar();
        c.command.CommandText = "Select A.idAmigo,U.idUsuario,U.nomeUsuario,U.foto from Amigos A " +
                                    "JOIN Individuo I on A.idIndividuo = I.idIndividuo " +
                                    "JOIN Usuario U on A.idUsuario = U.idUsuario " +
                                    "Where I.idUsuario = @cod and A.Solicitacao = 1";
        c.command.Parameters.Add("@cod", SqlDbType.Int).Value = (int)Session["codigoUsuario"];
        SqlDataAdapter dAdapter = new SqlDataAdapter();
        DataSet dt = new DataSet();
        dAdapter.SelectCommand = c.command;
        dAdapter.Fill(dt);
        //---------------------------------------------------------------
        if (Convert.ToInt32(dt.Tables[0].DefaultView.Count) >= 1)
        {
            if (dt.Tables[0].DefaultView[0].Row["foto"] == DBNull.Value)
            {
                string strBase64 = "Images/Profile_Default.png";
                //---------------------------------------------------------------
                string nome = dt.Tables[0].DefaultView[0].Row["nomeUsuario"].ToString();
                IdAmigo = (int)dt.Tables[0].DefaultView[0].Row["idUsuario"];
                int idAnotacao = Convert.ToInt32(Request.QueryString["id"]);
                int idFriend = (int)dt.Tables[0].DefaultView[0].Row["idAmigo"];
                //---------------------------------------------------------------

                lstAmigos.InnerHtml += "<img src='" + strBase64 + "' alt='" + nome + "' class='mr - 3 mt - 3 rounded - circle' style='width: 60px; '>" +
                                        "<div class='media-body'>" +
                                          "<h4>" + nome + "</h4>" +
                                          "<a href='Compartilha.aspx?idAmigo=" + IdAmigo + "&"+idAnotacao+"&"+idFriend+"' class='btn btn-primary'>Compartilhar</a>" +
                                        "</div>";
            }
            else
            {
                byte[] imgBytes = (byte[])dt.Tables[0].DefaultView[0].Row["foto"];
                string strBase64 = Convert.ToBase64String(imgBytes);
                //---------------------------------------------------------------
                string nome = dt.Tables[0].DefaultView[0].Row["nomeUsuario"].ToString();
                IdAmigo = (int)dt.Tables[0].DefaultView[0].Row["idUsuario"];
                int idAnotacao = Convert.ToInt32(Request.QueryString["id"]);
                int idFriend = (int)dt.Tables[0].DefaultView[0].Row["idAmigo"];
                //---------------------------------------------------------------

                lstAmigos.InnerHtml += "<img src='data:Images/jpg;base64," + strBase64 + "' alt='" + nome + "' class='mr - 3 mt - 3 rounded - circle' style='width: 60px; '>" +
                                        "<div class='media-body'>" +
                                          "<h4>" + nome + "</h4>" +
                                          "<a href='Compartilha.aspx?idAmigo=" + IdAmigo + "&idAnotacao=" + idAnotacao + "&idReamigo=" + idFriend + "' class='btn btn-primary'>Compartilhar</a>" +
                                        "</div>";
            }
        }
    }
    public void BuscaAmigoAceito()
    {
        Conexao c = new Conexao();
        c.conectar();
        c.command.CommandText = "Select A.idAmigo,U.idUsuario,U.nomeUsuario,U.foto from Amigos A " +
                                    "JOIN Individuo I on A.idIndividuo = I.idIndividuo " +
                                    "JOIN Usuario U on I.idUsuario = U.idUsuario " +
                                    "Where A.idUsuario = @cod and A.Solicitacao = 1";
        c.command.Parameters.Add("@cod", SqlDbType.Int).Value = (int)Session["codigoUsuario"];
        SqlDataAdapter dAdapter = new SqlDataAdapter();
        DataSet dt = new DataSet();
        dAdapter.SelectCommand = c.command;
        dAdapter.Fill(dt);
        //---------------------------------------------------------------
        //if (dt!= null && dt.Tables[0].Rows.Count == 0 && dt.Tables[0].Rows.Count > 0)
        //{
        if (Convert.ToInt32(dt.Tables[0].DefaultView.Count) >= 1)
        {
            if (dt.Tables[0].DefaultView[0].Row["foto"] == DBNull.Value)
            {
                string strBase64 = "Images/Profile_Default.png";
                //---------------------------------------------------------------
                string nome = dt.Tables[0].DefaultView[0].Row["nomeUsuario"].ToString();
                IdAmigo = (int)dt.Tables[0].DefaultView[0].Row["idUsuario"];
                int idAnotacao = Convert.ToInt32(Request.QueryString["id"]);
                int idFriend = (int)dt.Tables[0].DefaultView[0].Row["idAmigo"];
                //---------------------------------------------------------------

                lstAmigos.InnerHtml += "<img src='" + strBase64 + "' alt='" + nome + "' class='mr - 3 mt - 3 rounded - circle' style='width: 60px; '>" +
                                        "<div class='media-body'>" +
                                          "<h4>" + nome + "</h4>" +
                                          "<a href='Compartilha.aspx?idAmigo=" + IdAmigo + "&" + idAnotacao + "&" + idFriend + "' class='btn btn-primary'>Compartilhar</a>" +
                                        "</div>";
            }
            else
            {
                byte[] imgBytes = (byte[])dt.Tables[0].DefaultView[0].Row["foto"];
                string strBase64 = Convert.ToBase64String(imgBytes);
                //---------------------------------------------------------------
                string nome = dt.Tables[0].DefaultView[0].Row["nomeUsuario"].ToString();
                IdAmigo = (int)dt.Tables[0].DefaultView[0].Row["idUsuario"];
                int idAnotacao = Convert.ToInt32(Request.QueryString["id"]);
                int idFriend = (int)dt.Tables[0].DefaultView[0].Row["idAmigo"];
                //---------------------------------------------------------------

                lstAmigos.InnerHtml += "<img src='data:Images/jpg;base64," + strBase64 + "' alt='" + nome + "' class='mr - 3 mt - 3 rounded - circle' style='width: 60px; '>" +
                                        "<div class='media-body'>" +
                                          "<h4>" + nome + "</h4>" +
                                          "<a href='Compartilha.aspx?idAmigo=" + IdAmigo + "&idAnotacao=" + idAnotacao + "&idReamigo=" + idFriend + "' class='btn btn-primary'>Compartilhar</a>" +
                                        "</div>";
            }
            //}
        }
    }
    protected void imgBedit_Click(object sender, ImageClickEventArgs e)
    {
        lblConteudo.Visible = false;
        lblTitulo.Visible = false;
        CarregaEdição();
    }

    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        //update Anotacao set titulo = '' where idAnotacao = 2 
        Conexao c = new Conexao();
        c.conectar();
        c.command.CommandText = "update Anotacao set titulo = @tit where idAnotacao = @cod";
        c.command.Parameters.Add("@cod", SqlDbType.Int).Value = Convert.ToInt32(Request.QueryString["id"]);
        c.command.Parameters.Add("@tit", SqlDbType.VarChar).Value = txtTitulo.Text;
        c.command.ExecuteNonQuery();

        c.command.CommandText = "update Anotacao set conteudo = @con where idAnotacao = @cod";
        c.command.Parameters.Add("@con", SqlDbType.VarChar).Value = txtConteudo.Text;
        c.command.ExecuteNonQuery();
        Response.Redirect("Visualiza_Anotacao.aspx?id=" + Convert.ToInt32(Request.QueryString["id"]));
    }

    protected void imgBdelet_Click(object sender, ImageClickEventArgs e)
    {
        Deletar();
        Response.Redirect("HomeLog.aspx");
    }

    protected void imgBshare_Click(object sender, ImageClickEventArgs e)
    {
        myModal.Visible = true;
    }

    protected void btnclose_Click(object sender, EventArgs e)
    {
        myModal.Visible = false;
    }
}