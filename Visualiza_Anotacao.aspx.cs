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
    static string fonte;
    protected void Page_Load(object sender, EventArgs e)
    {
        txtConteudo.Visible = false;
        txtTitulo.Visible = false;
        btnSalvar.Visible = false;
        imgEdit.Visible = false;
        editFont.Visible = false;   
        if (!IsPostBack)
        {
            CarregaPagina();
            myModal.Visible = false;
            BuscaAmigoSolicitado();
            BuscaAmigoAceito();
        }
    }
    public void CarregaPagina()
    {
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
        imgAno.ImageUrl = "data:Images/jpg;base64," + strBase64;
        lblTitulo.Text = dt.Tables[0].DefaultView[0].Row["titulo"].ToString();
        lblConteudo.Text = dt.Tables[0].DefaultView[0].Row["conteudo"].ToString();
        if(dt.Tables[0].DefaultView[0].Row["Font"].ToString() == null)
        {
            fonte = "Arial";
        }
        else
        {
            fonte = dt.Tables[0].DefaultView[0].Row["Font"].ToString();
        }
        lblConteudo.Font.Name = fonte;
        lblTitulo.Font.Name = fonte;
    }
    public void CarregaEdição()
    {
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
        imgAno.ImageUrl = "data:Images/jpg;base64," + strBase64;

        txtConteudo.Visible = true;
        txtTitulo.Visible = true;
        btnSalvar.Visible = true;
        editFont.Visible = true;
        imgEdit.Visible = true;

        txtTitulo.Text = dt.Tables[0].DefaultView[0].Row["titulo"].ToString();
        txtConteudo.Text = dt.Tables[0].DefaultView[0].Row["conteudo"].ToString();

        txtConteudo.Font.Name = fonte;
        txtTitulo.Font.Name = fonte;
        lblFont.Font.Name = fonte;


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
        if (fupImg.HasFile)
        {
            //"Pegando" a Imagem
            int length = fupImg.PostedFile.ContentLength;
            byte[] imgbyte = new byte[length];
            HttpPostedFile img = fupImg.PostedFile;
            img.InputStream.Read(imgbyte, 0, length);

            Conexao c = new Conexao();
            c.conectar();
            c.command.CommandText = "update Anotacao set titulo = @tit where idAnotacao = @cod";
            c.command.Parameters.Add("@cod", SqlDbType.Int).Value = Convert.ToInt32(Request.QueryString["id"]);
            c.command.Parameters.Add("@tit", SqlDbType.VarChar).Value = txtTitulo.Text;
            c.command.ExecuteNonQuery();

            c.command.CommandText = "update Anotacao set Font = @font where idAnotacao = @cod";
            c.command.Parameters.Add("@font", SqlDbType.VarChar).Value = fonte;
            c.command.ExecuteNonQuery();

            c.command.CommandText = "update Anotacao set Imagem = @img where idAnotacao = @cod";
            c.command.Parameters.Add("@img", SqlDbType.VarBinary).Value = imgbyte;
            c.command.ExecuteNonQuery();

            c.command.CommandText = "update Anotacao set conteudo = @con where idAnotacao = @cod";
            c.command.Parameters.Add("@con", SqlDbType.VarChar).Value = txtConteudo.Text;
            c.command.ExecuteNonQuery();
            Response.Redirect("Visualiza_Anotacao.aspx?id=" + Convert.ToInt32(Request.QueryString["id"]));
        }
        else
        {
            Conexao c = new Conexao();
            c.conectar();
            c.command.CommandText = "update Anotacao set titulo = @tit where idAnotacao = @cod";
            c.command.Parameters.Add("@cod", SqlDbType.Int).Value = Convert.ToInt32(Request.QueryString["id"]);
            c.command.Parameters.Add("@tit", SqlDbType.VarChar).Value = txtTitulo.Text;
            c.command.ExecuteNonQuery();

            c.command.CommandText = "update Anotacao set Font = @font where idAnotacao = @cod";
            c.command.Parameters.Add("@font", SqlDbType.VarChar).Value = fonte;
            c.command.ExecuteNonQuery();

            c.command.CommandText = "update Anotacao set conteudo = @con where idAnotacao = @cod";
            c.command.Parameters.Add("@con", SqlDbType.VarChar).Value = txtConteudo.Text;
            c.command.ExecuteNonQuery();
            Response.Redirect("Visualiza_Anotacao.aspx?id=" + Convert.ToInt32(Request.QueryString["id"]));
        }
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

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedValue == "Amatic SC")
        {
            txtTitulo.Font.Name = "Amatic SC";
            txtConteudo.Font.Name = "Amatic SC";
            lblFont.Font.Name = "Amatic SC";
            fonte = "Amatic SC";
            CarregaEdição();
        }
        else if (DropDownList1.SelectedValue == "Sacramento")
        {
            txtTitulo.Font.Name = "Sacramento";
            txtConteudo.Font.Name = "Sacramento";
            lblFont.Font.Name = "Sacramento";
            fonte = "Sacramento";
            CarregaEdição();
        }
        else if (DropDownList1.SelectedValue == "Dancing Script")
        {
            txtTitulo.Font.Name = "Dancing Script";
            txtConteudo.Font.Name = "Dancing Script";
            lblFont.Font.Name = "Dancing Script";
            fonte = "Dancing Script";
            CarregaEdição();
        }
        else if (DropDownList1.SelectedValue == "Press Start 2P")
        {
            txtTitulo.Font.Name = "Press Start 2P";
            txtConteudo.Font.Name = "Press Start 2P";
            lblFont.Font.Name = "Press Start 2P";
            fonte = "Press Start 2P";
            CarregaEdição();
        }
        else if (DropDownList1.SelectedValue == "Tangerine")
        {
            txtTitulo.Font.Name = "Tangerine";
            txtConteudo.Font.Name = "Tangerine";
            lblFont.Font.Name = "Tangerine";
            fonte = "Tangerine";
            CarregaEdição();
        }
        else if (DropDownList1.SelectedValue == "Notable")
        {
            txtTitulo.Font.Name = "Notable";
            txtConteudo.Font.Name = "Notable";
            lblFont.Font.Name = "Notable";
            fonte = "Notable";
            CarregaEdição();
        }
        else if (DropDownList1.SelectedValue == "Reenie Beanie")
        {
            txtTitulo.Font.Name = "Reenie Beanie";
            txtConteudo.Font.Name = "Reenie Beanie";
            lblFont.Font.Name = "Reenie Beanie";
            fonte = "Reenie Beanie";
            CarregaEdição();
        }
        else if (DropDownList1.SelectedValue == "Pinyon Script")
        {
            txtTitulo.Font.Name = "Pinyon Script";
            txtConteudo.Font.Name = "Pinyon Script";
            lblFont.Font.Name = "Pinyon Script";
            fonte = "Pinyon Script";
            CarregaEdição();
        }
        else if (DropDownList1.SelectedValue == "Ruge Boogie")
        {
            txtTitulo.Font.Name = "Ruge Boogie";
            txtConteudo.Font.Name = "Ruge Boogie";
            lblFont.Font.Name = "Ruge Boogie";
            fonte = "Ruge Boogie";
            CarregaEdição();
        }
    }
}