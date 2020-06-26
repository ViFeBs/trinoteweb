using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterLog : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CarregaUsu();
            CarregaAnun();
            CarregaAmigoSolicitado();
            CarregaAmigoAceito();
            SolicitacoesRecived();
        }
    }
    public void CarregaUsu()
    {
        Conexao c = new Conexao();
        c.conectar();
        c.command.CommandText = "select loginUsuario,foto from Usuario where idUsuario = @cod";
        c.command.Parameters.Add("@cod", SqlDbType.Int).Value = ((int)Session["codigoUsuario"]);
        SqlDataAdapter dAdapter = new SqlDataAdapter();
        DataSet dt = new DataSet();
        dAdapter.SelectCommand = c.command;
        dAdapter.Fill(dt);
        //------------------------------------------------------------------
        byte[] imgBytes;
        if (dt.Tables[0].DefaultView[0].Row["foto"] == DBNull.Value)
        {
            imgBytes = BitConverter.GetBytes(0);
        } else
        {
            imgBytes = (byte[])dt.Tables[0].DefaultView[0].Row["foto"];
        }        
        string strBase64 = Convert.ToBase64String(imgBytes);
        imgPerfil.ImageUrl = "data:Images/jpg;base64," + strBase64;
        //------------------------------------------------------------------
        lblPname.Text = dt.Tables[0].DefaultView[0].Row["loginUsuario"].ToString();
        c.fechaConexao();
    }
    public void CarregaAmigoSolicitado()
    {
        Conexao c = new Conexao();
        c.conectar();
        c.command.CommandText = "Select U.idUsuario,U.foto,U.nomeUsuario from Amigos A " +
                                    "JOIN Individuo I on A.idIndividuo = I.idIndividuo "+
                                    "JOIN Usuario U on A.idUsuario = U.idUsuario " +
                                    "Where I.idUsuario = @cod and A.Solicitacao = 1";
        c.command.Parameters.Add("@cod", SqlDbType.Int).Value = ((int)Session["codigoUsuario"]);
        SqlDataAdapter dAdapter = new SqlDataAdapter();
        DataSet dt = new DataSet();
        dAdapter.SelectCommand = c.command;
        dAdapter.Fill(dt);
        int qtde = dt.Tables[0].DefaultView.Count;
        if (qtde >= 1)
        {
            for (int i = 0; i < qtde; i++)
            {
                //--------------------------------------------------------------------
                byte[] imgBytes;
                if (dt.Tables[0].DefaultView[i].Row["foto"] == DBNull.Value)
                {
                    imgBytes = BitConverter.GetBytes(0);
                }
                else
                {
                    imgBytes = (byte[])dt.Tables[0].DefaultView[i].Row["foto"];
                }
                string strBase64 = Convert.ToBase64String(imgBytes);
                //--------------------------------------------------------------------
                string nome = dt.Tables[0].DefaultView[i].Row["nomeUsuario"].ToString();
                int IdAmigo = (int)dt.Tables[0].DefaultView[i].Row["idUsuario"];
                int NotesShared = NoteShared(IdAmigo);
                //friendlist.InnerHtml += "<style>a{font-size: 11px;}</style><img src='data:Images/jpg;base64," + strBase64 + "' Width='100px' Height='80px' class='rounded-circle'/><p>" + nome + "</p><a href='Perfil_Amigo.aspx?id=" + IdAmigo + "&type=2' class='btn btn-primary'>Ver Perfil</a><br /><a href=#>você tem " + NotesShared+" Anotações compartilhadas com "+nome+ "</a> <br />";
                lstAmigos.InnerHtml += "<a class='btn btn-outline-success' href='Perfil_Amigo.aspx?id=" + IdAmigo + "&type=2'>" +
                                        "<div class='con'>" +
                                            "<div class='con1'>" +
                                                "<img src = 'data:Images/jpg;base64," + strBase64 + "' class='userimg' />" +
                                            "</div>" +
                                            "<div class='sidebox'>" +
                                                "<span class='spanstyle'>" +
                                                    "<p>" + nome + "</p>" +
                                                "</span>" +
                                                "<div class='bottonbtn'>" +
                                                    "<p>Anotações <br />" +
                                                    "Compartilhadas:" + NotesShared + "</p>" +
                                                "</div>" +
                                            "</div>" +
                                        "</div>" +
                                       "<a />";
            }
        }
        c.fechaConexao();
    }
    public void CarregaAmigoAceito()
    {
        Conexao c = new Conexao();
        c.conectar();
        c.command.CommandText = "Select U.idUsuario,U.foto,U.nomeUsuario from Amigos A " +
                                    "JOIN Individuo I on A.idIndividuo = I.idIndividuo " +
                                    "JOIN Usuario U on I.idUsuario = U.idUsuario " +
                                    "Where A.idUsuario = @cod and A.Solicitacao = 1";
        c.command.Parameters.Add("@cod", SqlDbType.Int).Value = ((int)Session["codigoUsuario"]);
        SqlDataAdapter dAdapter = new SqlDataAdapter();
        DataSet dt = new DataSet();
        dAdapter.SelectCommand = c.command;
        dAdapter.Fill(dt);
        int qtde = dt.Tables[0].DefaultView.Count;
        if (qtde >= 1)
        {
            for (int i = 0; i < qtde; i++)
            {
                //--------------------------------------------------------------------
                byte[] imgBytes;
                if (dt.Tables[0].DefaultView[i].Row["foto"] == DBNull.Value)
                {
                    imgBytes = BitConverter.GetBytes(0);
                }
                else
                {
                    imgBytes = (byte[])dt.Tables[0].DefaultView[i].Row["foto"];
                }
                string strBase64 = Convert.ToBase64String(imgBytes);
                //--------------------------------------------------------------------
                string nome = dt.Tables[0].DefaultView[i].Row["nomeUsuario"].ToString();
                int IdAmigo = (int)dt.Tables[0].DefaultView[i].Row["idUsuario"];
                int NotesShared = NoteShared(IdAmigo);
                //friendlist.InnerHtml += "<style>a{font-size: 11px;}</style><img src='data:Images/jpg;base64," + strBase64 + "' Width='100px' Height='80px' class='rounded-circle'/><p>" + nome + "</p><a href='Perfil_Amigo.aspx?id=" + IdAmigo + "&type=2' class='btn btn-primary'>Ver Perfil</a><br /><a href=#>você tem " + NotesShared + " Anotações compartilhadas com " + nome + "</a> <br />";
                lstAmigos.InnerHtml += "<a class='btn btn-outline-success' href='Perfil_Amigo.aspx?id=" + IdAmigo + "&type=2'>" +
                                        "<div class='con'>" +
                                            "<div class='con1'>" +
                                                "<img src = 'data:Images/jpg;base64," + strBase64 + "' class='userimg' />" +
                                            "</div>" +
                                            "<div class='sidebox'>" +
                                                "<span class='spanstyle'>" +
                                                    "<p>" + nome + "</p>" +
                                                "</span>" +
                                                "<div class='bottonbtn'>" +
                                                    "<p>Anotações \n"+
                                                    "Compartilhadas:" + NotesShared + "</p>" +
                                                "</div>" +
                                            "</div>" +
                                        "</div>" +
                                       "<a />";
            }
        }
        c.fechaConexao();
    }


    public void SolicitacoesRecived()
    {
        //Solicitações Recebidas
        Conexao c = new Conexao();
        c.conectar();
        c.command.CommandText = "Select U.nomeUsuario,U.foto,I.idUsuario from Individuo I " + 
                                           "JOIN Amigos A on I.idIndividuo = A.idIndividuo " +
                                           "JOIN Usuario U on I.idUsuario = U.idUsuario " +
                                        "Where A.Solicitacao = 0 and A.idUsuario = @cod";
        c.command.Parameters.Add("@cod", SqlDbType.Int).Value = ((int)Session["codigoUsuario"]);
        SqlDataAdapter dAdapter = new SqlDataAdapter();
        DataSet dt = new DataSet();
        dAdapter.SelectCommand = c.command;
        dAdapter.Fill(dt);
        int qtde = dt.Tables[0].DefaultView.Count;
        if(qtde >= 1)
        {
            for(int i = 0; i < qtde; i++)
            {
                string nomeUsu = dt.Tables[0].DefaultView[i].Row["nomeUsuario"].ToString();
                int idUsu = (int)dt.Tables[0].DefaultView[i].Row["idUsuario"];
                byte[] imgBytes;
                if (dt.Tables[0].DefaultView[i].Row["foto"] == DBNull.Value)
                {
                    imgBytes = BitConverter.GetBytes(0);
                }
                else
                {
                    imgBytes = (byte[])dt.Tables[0].DefaultView[i].Row["foto"];
                }
                string strBase64 = Convert.ToBase64String(imgBytes);
                SolicitacoesRecebidas.InnerHtml += "<h5>Nova Solicitação de Amizade Recebida</h3><li><img src='data:Images/jpg;base64," + strBase64 + "' Width='100px' Height='80px' class='rounded-circle'/><p>" + nomeUsu + "</p><a href='Perfil_Amigo.aspx?id="+idUsu+"&type=1' class='btn btn-primary'>Ver Perfil</a></li>";
            }
        } 
    }
    public int NoteShared(int idFriend)
    {
        Conexao c = new Conexao();
        c.conectar();
        c.command.CommandText = "select * from Anotacao_Compartilhada C " +
                                    "JOIN Usuario U on U.idUsuario = C.idUsuario " +
                                    "JOIN Anotacao An on An.idAnotacao = C.idAnotacao " +
                                    "JOIN Amigos A on A.idAmigo = C.idAmigo " +
                                    "JOIN Individuo I on I.idIndividuo =  A.idIndividuo " +
                                "Where C.idUsuario = @idUsu and C.idUsuario = I.idUsuario and A.idUsuario = @idUsuAmi and An.statusAnotacao = 1";

        c.command.Parameters.Add("@idUsu", SqlDbType.Int).Value = ((int)Session["codigoUsuario"]);
        c.command.Parameters.Add("@idUsuAmi", SqlDbType.Int).Value = idFriend;

        SqlDataAdapter dAdapter = new SqlDataAdapter();
        DataSet dt = new DataSet();
        dAdapter.SelectCommand = c.command;
        dAdapter.Fill(dt);

        int retorno = (int)dt.Tables[0].DefaultView.Count;
        return retorno;
    }
    public void CarregaAnun()
    {
        Conexao c = new Conexao();
        c.conectar();
        c.command.CommandText = "select count(*) as Aceitas from Anuncio where validacao = 1";
        SqlDataAdapter dAdapter = new SqlDataAdapter();
        DataSet dt = new DataSet();
        dAdapter.SelectCommand = c.command;
        dAdapter.Fill(dt);
        if (Convert.ToInt32(dt.Tables[0].DefaultView[0].Row["Aceitas"])>=3)
        {
            c.command.CommandText = "select top 3 titulo,link,descricao,imagem from Anuncio where validacao = 1 order by NEWID()";
            DataSet dt2 = new DataSet();
            dAdapter.SelectCommand = c.command;
            dAdapter.Fill(dt2);
            for (int i = 0; i < 3; i++)
            {
                string Titulo = dt2.Tables[0].DefaultView[i].Row["titulo"].ToString();
                string Link = dt2.Tables[0].DefaultView[i].Row["link"].ToString();
                string Descricao = dt2.Tables[0].DefaultView[i].Row["descricao"].ToString();
                byte[] imgBytes = (byte[])dt2.Tables[0].DefaultView[i].Row["imagem"];
                string strBase64 = Convert.ToBase64String(imgBytes);
                string anunAtual = "<div class='card'><style>.card-img-top{width='100%'; height: 225;} </style><img src='data:Images/jpg;base64," + strBase64 + "'class='card-img-top'/><div class='card-body'><h1 class='card-title'>" + Titulo + "</h1><br /><p class='card-text'>" + Descricao + "</p><br /><a href = '" + Link + "' class='btn btn-primary'>Ver Mais</a></div></div>";
                mostraAnun.InnerHtml += anunAtual;
            }
        }
        else
        {
            AnuncioTitulo.Visible = false;
        }
        c.fechaConexao();
    }

    protected void imgLogOff_Click(object sender, ImageClickEventArgs e)
    {
        Session.Abandon();
        Response.Redirect("index.aspx");
    }

    protected void btnTeste_Click(object sender, EventArgs e)
    {
       
    }
}
