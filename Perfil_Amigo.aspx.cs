using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Perfil_Amigo : System.Web.UI.Page
{
    int idIndividuo;
    protected void Page_Load(object sender, EventArgs e)
    {
        int tipo = Convert.ToInt32(Request.QueryString["type"]);
        if(tipo == 0)
        {
            btnAdicionar.Text = "Enviar Solicitação de Amizade";
            anoAmigo.Visible = false;
        }
        else if(tipo == 1)
        {
            btnAdicionar.Text = "Aceitar Solicitação";
            anoAmigo.Visible = false;
        }
        else if(tipo == 2)
        {
            btnAdicionar.Visible = false;
            CarregaCompartilhadasSolicitado();
            CarregaCompartilhadasAceitos();
        }
        Conexao c = new Conexao();
        c.conectar();
        c.command.CommandText = "select idUsuario,nomeUsuario,foto from Usuario where idUsuario = @cod";
        c.command.Parameters.Add("@cod", SqlDbType.Int).Value = Convert.ToInt32(Request.QueryString["id"]);
        SqlDataAdapter dAdapter = new SqlDataAdapter();
        DataSet dt = new DataSet();
        dAdapter.SelectCommand = c.command;
        dAdapter.Fill(dt);
        lblNome.Text = dt.Tables[0].DefaultView[0].Row["nomeUsuario"].ToString();
        if (dt.Tables[0].DefaultView[0].Row["foto"] == DBNull.Value)
        {
            string strBase64 = "Images/Profile_Default.png";
            //---------------------------------------------------------------
            imgPerfil.ImageUrl = "~"+strBase64;
            imgPerfil.CssClass = "fb-image-profile thumbnail";
        }
        else
        {
            byte[] imgBytes = (byte[])dt.Tables[0].DefaultView[0].Row["foto"];
            string strBase64 = Convert.ToBase64String(imgBytes);
            //---------------------------------------------------------------
            imgPerfil.ImageUrl = "data:Images/jpg;base64,"+strBase64;
            imgPerfil.CssClass = "fb-image-profile thumbnail";
        }

    }

    protected void btnAdicionar_Click(object sender, EventArgs e)
    {
        int tipo = Convert.ToInt32(Request.QueryString["type"]);
        if(tipo == 0)
        {
            EnviarSolicitacao();
        }
        else if(tipo == 1)
        {
            AceitarSolicitacao();
        }
    }

    public void AceitarSolicitacao()
    {
        Conexao c = new Conexao();
        c.conectar();
        c.command.CommandText = "select idIndividuo from Individuo where idUsuario = @id";
        c.command.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(Request.QueryString["id"]);
        SqlDataAdapter dAdapter = new SqlDataAdapter();
        DataSet dt = new DataSet();
        dAdapter.SelectCommand = c.command;
        dAdapter.Fill(dt);
        idIndividuo = (int)dt.Tables[0].DefaultView[0].Row["idIndividuo"];

        c.command.CommandText = "update A set Solicitacao = @so from Amigos A " +
                                        "join Individuo I on A.idIndividuo = I.idIndividuo "+
                                    "where I.idUsuario = @id and A.idUsuario = @cod";
        c.command.Parameters.Add("@so", SqlDbType.Bit).Value = 1;
        c.command.Parameters.Add("@cod", SqlDbType.Int).Value = (int)Session["codigoUsuario"];
        c.command.ExecuteNonQuery();

        Response.Redirect("HomeLog.aspx");
    }

    public void CarregaCompartilhadasSolicitado()
    {
        Conexao c = new Conexao();
        c.conectar();
        c.command.CommandText = "select A.idAnotacao,A.usuarioCria,A.titulo,A.conteudo,A.Font,A.Imagem,A.statusAnotacao,U.loginUsuario from Anotacao_Compartilhada C " +
                                                                                "JOIN Anotacao A on C.idAnotacao = A.idAnotacao " +
                                                                                "JOIN Amigos AMI on C.idAmigo = AMI.idAmigo " +
                                                                                "JOIN Individuo I on AMI.idIndividuo = I.idIndividuo " +
                                                                                "JOIN Usuario U on I.idUsuario = U.idUsuario " +
                                                                          "where I.idUsuario = @id and Ami.idUsuario = @idUsu and A.statusAnotacao = 1 and A.usuarioCria != @idUsu";
        c.command.Parameters.Add("@idUsu", SqlDbType.Int).Value = (int)Session["codigoUsuario"];
        c.command.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(Request.QueryString["id"]);
        SqlDataAdapter dAdapter = new SqlDataAdapter();
        DataSet dt = new DataSet();
        dAdapter.SelectCommand = c.command;
        dAdapter.Fill(dt);
        int qtde = dt.Tables[0].DefaultView.Count;
        if (qtde >= 1)
        {
            for (int i = 0; i < qtde; i++)
            {
                string Titulo = dt.Tables[0].DefaultView[i].Row["titulo"].ToString();
                string conteudo = dt.Tables[0].DefaultView[i].Row["conteudo"].ToString();
                byte[] imgBytes = (byte[])dt.Tables[0].DefaultView[i].Row["Imagem"];
                string strBase64 = Convert.ToBase64String(imgBytes);
                string id = dt.Tables[0].DefaultView[i].Row["idAnotacao"].ToString();
                string Fonte = "";
                if (dt.Tables[0].DefaultView[i].Row["Font"].ToString() == "")
                {
                    Fonte = "'Arial'";
                }
                else
                {
                    Fonte = dt.Tables[0].DefaultView[i].Row["Font"].ToString();
                }
                string anunAtual = "<div class='card'><style>.card-img-top{width='100%'; height: 225;} #id" + i + "{font-family:" + Fonte + "} #idt" + i + "{font-family:" + Fonte + "}</style><img src='data:Images/jpg;base64," + strBase64 + "'class='card-img-top'/><div class='card-body'><h1 class='card-title' id='idt" + i + "'>" + Titulo + "</h1><br /><p class='card-text' id='id" + i + "'>" + conteudo + "</p><br /><a href = 'Anotacao_Compartilhada.aspx?id=" + id + "' class='btn btn-primary'>Ver Mais</a></div></div>";
                GeraAnotacaoAmigo.InnerHtml += anunAtual;
            }
            nadaEncontrado.Visible = false;
        }
        else
        {
            nadaEncontrado.InnerHtml =  "<div class='container'>"+
                                            "<h1 class='display-4'>Não encontramos nenhuma anotação<i class='fas fa-sad-tear'></i></h1>"+
                                            "<p class='lead'>Seu Amigo ainda não compartilhou nada com você</p>" +
                                        "</div>";
        }
    }
    public void CarregaCompartilhadasAceitos()
    {
        Conexao c = new Conexao();
        c.conectar();
        c.command.CommandText = "select A.idAnotacao,A.usuarioCria,A.titulo,A.conteudo,A.Font,A.Imagem,A.statusAnotacao,U.loginUsuario from Anotacao_Compartilhada C " +
                                                                                "JOIN Anotacao A on C.idAnotacao = A.idAnotacao " +
                                                                                "JOIN Amigos AMI on C.idAmigo = AMI.idAmigo " +
                                                                                "JOIN Individuo I on AMI.idIndividuo = I.idIndividuo " +
                                                                                "JOIN Usuario U on I.idUsuario = U.idUsuario " +
                                                                          "where I.idUsuario = @idUsu and Ami.idUsuario = @id and A.statusAnotacao = 1 and A.usuarioCria != @idUsu";
        c.command.Parameters.Add("@idUsu", SqlDbType.Int).Value = (int)Session["codigoUsuario"];
        c.command.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(Request.QueryString["id"]);
        SqlDataAdapter dAdapter = new SqlDataAdapter();
        DataSet dt = new DataSet();
        dAdapter.SelectCommand = c.command;
        dAdapter.Fill(dt);
        int qtde = dt.Tables[0].DefaultView.Count;
        if (qtde >= 1)
        {
            for (int i = 0; i < qtde; i++)
            {
                string Titulo = dt.Tables[0].DefaultView[i].Row["titulo"].ToString();
                string conteudo = dt.Tables[0].DefaultView[i].Row["conteudo"].ToString();
                byte[] imgBytes;
                if (dt.Tables[0].DefaultView[i].Row["Imagem"] == DBNull.Value)
                {
                    imgBytes = BitConverter.GetBytes(0);
                }
                else
                {
                    imgBytes = (byte[])dt.Tables[0].DefaultView[i].Row["Imagem"];
                }
                string strBase64 = Convert.ToBase64String(imgBytes);
                string id = dt.Tables[0].DefaultView[i].Row["idAnotacao"].ToString();
                string Fonte = "";
                if (dt.Tables[0].DefaultView[i].Row["Font"].ToString() == "")
                {
                    Fonte = "'Arial'";
                }
                else
                {
                    Fonte = dt.Tables[0].DefaultView[i].Row["Font"].ToString();
                }
                string anunAtual = "<div class='card'><style>.card-img-top{width='100%'; height: 225;} #id" + i + "{font-family:" + Fonte + "} #idt" + i + "{font-family:" + Fonte + "}</style><img src='data:Images/jpg;base64," + strBase64 + "'class='card-img-top'/><div class='card-body'><h1 class='card-title' id='idt" + i + "'>" + Titulo + "</h1><br /><p class='card-text' id='id" + i + "'>" + conteudo + "</p><br /><a href = 'Anotacao_Compartilhada.aspx?id=" + id + "' class='btn btn-primary'>Ver Mais</a></div></div>";
                GeraAnotacaoAmigo.InnerHtml += anunAtual;
            }
            nadaEncontrado.Visible = false;
        }
        else
        {
            nadaEncontrado.InnerHtml = "<div class='container'>" +
                                            "<h1 class='display-4'>Não encontramos nenhuma anotação<i class='fas fa-sad-tear'></i></h1>" +
                                            "<p class='lead'>Seu Amigo ainda não compartilhou nada com você</p>" +
                                        "</div>";
        }
    }
    public void EnviarSolicitacao()
    {
        Conexao c = new Conexao();
        c.conectar();
        c.command.CommandText = "insert into Individuo(idUsuario) values(@cod)";
        c.command.Parameters.Add("@cod", SqlDbType.Int).Value = ((int)Session["codigoUsuario"]);
        c.command.ExecuteNonQuery();

        c.command.CommandText = "select idIndividuo from Individuo where idUsuario = @cod";
        SqlDataAdapter dAdapter = new SqlDataAdapter();
        DataSet dt = new DataSet();
        dAdapter.SelectCommand = c.command;
        dAdapter.Fill(dt);
        idIndividuo = (int)dt.Tables[0].DefaultView[0].Row["idIndividuo"];

        c.conectar();
        c.command.CommandText = "insert into Amigos(idUsuario,idIndividuo,Solicitacao,Recusadas) values(@id,@ind,@so,@re)";
        c.command.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(Request.QueryString["id"]);
        c.command.Parameters.Add("@ind", SqlDbType.Int).Value = idIndividuo;
        c.command.Parameters.Add("@so", SqlDbType.Bit).Value = 0;
        c.command.Parameters.Add("@re", SqlDbType.Bit).Value = 0;
        c.command.ExecuteNonQuery();

        Response.Write("<script language='javascript'>alert('Solicitação Enviada Com Sucesso')</script>");
        btnAdicionar.Text = "Aguardando Reposta";
        btnAdicionar.Enabled = false;
    }
}