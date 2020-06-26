using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HomeLog : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Convert.ToInt32(Request.QueryString["cod"]) == 1)
            {
                Response.Write("<script language = 'javascript'>alert('Anotação Salva Com Sucesso!');</script>");
            }
            else if (Convert.ToInt32(Request.QueryString["Share"]) == 1)
            {
                Response.Write("<script language = 'javascript'>alert('Anotação Compartilhada Com Sucesso!');</script>");
            }
            Conexao c = new Conexao();
            c.conectar();
            c.command.CommandText = "select count(*) as Anotacoes from Anotacao where usuarioCria = @cod and statusAnotacao = 1";
            c.command.Parameters.Add("@cod", SqlDbType.Int).Value = ((int)Session["codigoUsuario"]);
            SqlDataAdapter dAdapter = new SqlDataAdapter();
            DataSet dt = new DataSet();
            dAdapter.SelectCommand = c.command;
            dAdapter.Fill(dt);
            if (Convert.ToInt32(dt.Tables[0].DefaultView[0].Row["Anotacoes"]) <= 3)
            {
                for (int i = 0; i < Convert.ToInt32(dt.Tables[0].DefaultView[0].Row["Anotacoes"]); i++)
                {
                    c.command.CommandText = "select idAnotacao,titulo,conteudo,Imagem,Font from Anotacao where usuarioCria = @cod and statusAnotacao = 1";
                    DataSet dt2 = new DataSet();
                    dAdapter.SelectCommand = c.command;
                    dAdapter.Fill(dt2);
                    string Titulo = dt2.Tables[0].DefaultView[i].Row["titulo"].ToString();
                    string conteudo = dt2.Tables[0].DefaultView[i].Row["conteudo"].ToString();
                    byte[] imgBytes = (byte[])dt2.Tables[0].DefaultView[i].Row["Imagem"];
                    string strBase64 = Convert.ToBase64String(imgBytes);
                    string id = dt2.Tables[0].DefaultView[i].Row["idAnotacao"].ToString();
                    string Fonte = "";
                    if (dt2.Tables[0].DefaultView[i].Row["Font"].ToString() == "")
                    {
                        Fonte = "'Arial'";
                    }
                    else
                    {
                        Fonte = dt2.Tables[0].DefaultView[i].Row["Font"].ToString();
                    }
                    string anunAtual = "<div class='card'><style>.card-img-top{width='100%'; height: 225;} #id"+i+"{font-family:"+Fonte+ "} #idt" + i + "{font-family:" + Fonte + "}</style><img src='data:Images/jpg;base64," + strBase64 + "'class='card-img-top'/><div class='card-body'><h1 class='card-title' id='idt" + i + "'>" + Titulo + "</h1><br /><p class='card-text' id='id"+i+"'>" + conteudo + "</p><br /><a href = 'Visualiza_Anotacao.aspx?id=" + id + "' class='btn btn-primary'>Ver Mais</a></div></div>";
                    GeraAnotacao.InnerHtml += anunAtual;
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    c.command.CommandText = "select idAnotacao,titulo,conteudo,Imagem,Font from Anotacao where usuarioCria = @cod and statusAnotacao = 1";
                    DataSet dt2 = new DataSet();
                    dAdapter.SelectCommand = c.command;
                    dAdapter.Fill(dt2);
                    string Titulo = dt2.Tables[0].DefaultView[i].Row["titulo"].ToString();
                    string conteudo = dt2.Tables[0].DefaultView[i].Row["conteudo"].ToString();
                    byte[] imgBytes = (byte[])dt2.Tables[0].DefaultView[i].Row["Imagem"];
                    string strBase64 = Convert.ToBase64String(imgBytes);
                    string id = dt2.Tables[0].DefaultView[i].Row["idAnotacao"].ToString();
                    string Fonte = "";
                    if (dt2.Tables[0].DefaultView[i].Row["Font"].ToString() == "")
                    {
                        Fonte = "Arial";
                    }
                    else
                    {
                        Fonte = dt2.Tables[0].DefaultView[i].Row["Font"].ToString();
                    }
                    string anunAtual = "<div class='card'><style>.card-img-top{width:100%; height:225;} #id" + i + "{font-family:" + Fonte+ " } #idt" + i + "{font-family:" + Fonte + "}</style><img src='data:Images/jpg;base64," + strBase64 + "'class='card-img-top'/><div class='card-body'><h3 class='card-title' id = 'idt" + i + "''>" + Titulo + "</h3><br /><p class='card-text' id='id" + i + "'>" + conteudo + "</p><br /><a href = 'Visualiza_Anotacao.aspx?id=" + id + "' class='btn btn-outline-primary'>Ver Mais</a></div></div>";
                    GeraAnotacao.InnerHtml += anunAtual;
                }
            }
        }
    }
}